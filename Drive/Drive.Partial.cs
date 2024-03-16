using Backup.Utils;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Linq;

namespace Backup.Drive {

    public partial class Drive {


        // Verifica os arquivos de acordo com a data da última atualização.
        public const int LAST_UPDATE_DATE_MODE = 1;

        // Verifica os arquivos comparando o HASH de ambos.
        public const int MD5_HASH_MODE = 2;


        /// <summary>
        /// Copiar o arquivo de origem para o arquivo de destino.
        /// </summary>
        /// <param name="sourceFilePath">Path do arquivo de origem.</param>
        /// <param name="targetFilePath">Path do arquivo de destino.</param>
        private void CopyFile(string sourceFilePath, string targetFilePath) {
            if (File.Exists(sourceFilePath)) {
                ResetAttributes(sourceFilePath);
                if (File.Exists(targetFilePath)) {
                    ResetAttributes(targetFilePath);
                }
                File.Copy(sourceFilePath, targetFilePath, true);
                if (!File.Exists(targetFilePath)) {
                    throw new Exception("Arquivo de destino inválido.");
                }
                // Os metadados do arquivo também são copias do original para a cópia,
                // mas por garantia, sobrescrevo os que são usados para controle de
                // modificação do arquivo na origem.
                File.SetCreationTime(sourceFilePath, File.GetCreationTime(targetFilePath));
                File.SetLastAccessTime(sourceFilePath, File.GetLastAccessTime(targetFilePath));
                File.SetLastWriteTime(sourceFilePath, File.GetLastWriteTime(targetFilePath));
            }
        }


        /// <summary>
        /// Excluir o arquivo.
        /// </summary>
        /// <param name="path">Path do arquivo.</param>
        private void DeleteFile(string path) {
            if (File.Exists(path)) {
                ResetAttributes(path);
                File.Delete(path);
            }
        }


        /// <summary>
        /// Criar o diretório.
        /// </summary>
        /// <param name="path">Path do diretório.</param>
        private void CreateDirectory(string path) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
        }


        /// <summary>
        /// Excluir o diretório.
        /// </summary>
        /// <param name="path">Path do diretório.</param>
        private void DeleteDirectory(string path) {
            if (Directory.Exists(path)) {
                ResetAttributes(path);
                Directory.Delete(path);
            }
        }


        /// <summary>
        /// Limpar os atributos de proteção do arquivo, para evitar problemas no
        /// momento do backup.
        /// </summary>
        /// <param name="path">Path do arquivo.</param>
        private void ResetAttributes(string path) {
            File.SetAttributes(
                path,
                FileAttributes.Normal
            );
        }


        /// <summary>
        /// Criar a lista com os paths de todos os subdiretórios do diretório
        /// passado.
        /// </summary>
        /// <param name="directory">Path do diretório</param>
        /// <param name="subdirectories">Lista dos subdiretórios.</param>
        private void ListSubdirectoriesTree(string directory, LinkedList<string> subdirectories) {
            CheckIfTheProcessHasBeenAborted();
            List<string> list = new List<string>(Directory.GetDirectories(directory));
            foreach (String dir in list) {
                CheckIfTheProcessHasBeenAborted();
                subdirectories.AddLast(dir);
            }
            if (list.Count > 0) {
                foreach (string dir in list) {
                    ListSubdirectoriesTree(dir, subdirectories);
                }
            }
        }


        /// <summary>
        /// Contar o número de arquivos em um diretório e em seus subdiretórios.
        /// </summary>
        /// <param name="directoryPath">Path do diretório</param>
        /// <returns></returns>
        private int CountFiles(string directoryPath) {
            /* TODO: Precisa de melhorias no método de contagem...
             * O método menos custoso em termos de alocação de memória, uso de CPU e
             * tempo de busca foi EnumerableFiles. Tentei uma técnica de chamada à
             * API do Windows, mas se mostrou menos eficaz. Ainda é uma solução que
             * estou testando, pois é um gargalo na execução do programa, haja vista
             * o número elevado de arquivos no sistema local. Próxima implementação vou
             * tentar acesso à MFT (ou tabelas relacionadas com o respectivo sistema
             * de arquivos do drive), para fazer a contagem "in loco". Para isso, preciso
             * estudar níveis de acesso necessários, se preciso criar um driver para
             * ter este acesso, se a API do Windows tem métodos nativos, se consigo fazer
             * chamadas de sistema usando linguagem assembly, etc, etc, etc.
             * 
             * A solução abaixo, portanto, é parcial e pode passar por mudanças afim 
             * de melhorar o tempo da contagem de arquivos, etapa anterior à varredura.
             */
            return (
                from file in Directory.EnumerateFiles(
                    directoryPath,
                    "*.*",
                    SearchOption.AllDirectories
                ) select file
            ).Count();
        }


        /// <summary>
        /// Retornar o path do arquivo como se estivesse dentro do diretório.
        /// </summary>
        /// <param name="directoryPath">Path do diretório.</param>
        /// <param name="filePath">Path do arquivo.</param>
        /// <returns>Path do arquivo como se estivesse dentro do diretório.</returns>
        private string RelativePath(string directoryPath, string filePath) {
            string directoryDrive = directoryPath.Substring(0, directoryPath.IndexOf(":", 0) + 2);
            string targetPath = filePath.Substring(0, 12);
            return filePath.Replace(targetPath, directoryDrive);
        }


        /// <summary>
        /// Retornar o path do arquivo como se estivesse dentro da Unidade de Backup.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Path do arquivo como se estivesse dentro da Unidade de Backup</returns>
        private string RelativePath(string path) {
            string parcialPath = path.Substring(3, path.Length - 3);
            string targetDir = Letter + @"\backup\" + path[0] + @"\";
            return String.Concat(targetDir, parcialPath);
        }


        /// <summary>
        /// Verificar se o arquivo na origem foi atualizado. O critério de verificação
        /// é escolhido de acordo com o modo escolhido.
        /// 
        /// <br><br></br></br>
        /// 
        /// Os modos são os seguintes:
        /// 
        /// <br><br></br></br>
        /// 
        /// <ul>
        /// 
        /// <li><b><u>LAST_UPDATE_DATE_MODE:</u></b> Compara a data da modificação
        /// do arquivo de origem com a do arquivo de destino. Para uma maior garantia da
        /// integridade do backup, verifica também se o tamanho do arquivo de destino (em bytes)
        /// é o mesmo do arquivo de origem no sistema local. Esta verificação é necessária pois
        /// pode ocorrer de o dispositivo ser desconectado por acidente antes que todo o 
        /// arquivo tenha sido transferido.</li>
        /// 
        /// <br><br></br></br>
        /// 
        /// <li><b><u>MD5_HASH_MODE:</u></b> Gera o hash de ambos os arquivos e compara se eles
        /// são iguais. É um método mais preciso, porém muito lento de verificação.</li>
        /// 
        /// </ul>
        /// 
        /// </summary>
        /// <param name="sourceFile">Path do arquivo no origem.</param>
        /// <param name="backupFile">Path do arquivo na Unidade de Backup.</param>
        /// <returns></returns>
        private bool UpdatedFile(FileInfo sourceFile, FileInfo backupFile, int mode) {
            bool update = false;
            switch (mode) {

                case Drive.MD5_HASH_MODE: {
                    string hash1 = GetFileHash(sourceFile.FullName);
                    string hash2 = GetFileHash(backupFile.FullName);
                    update = !hash1.Equals(hash2);
                } break;

                case Drive.LAST_UPDATE_DATE_MODE: {
                    update = sourceFile.LastWriteTime != backupFile.LastWriteTime ||
                    sourceFile.Length != backupFile.Length;
                } break;

            }
            return update;
        }


        /// <summary>
        /// Calcula o Hash MD5 do arquivo passado.
        /// </summary>
        /// <param name="path">Path do arquivo.</param>
        /// <returns>Hash do arquivo em formato Base64.</returns>
        private string GetFileHash(string path) {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                using (System.Security.Cryptography.MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                    byte[] hash;
                    hash = md5.ComputeHash(stream);
                    return Encoding.Unicode.GetString(hash);
                }
            }
        }


    }

}
