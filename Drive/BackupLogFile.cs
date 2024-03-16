using Backup.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Backup.Drive {

    /// <summary>
    /// 
    /// Arquivo ZIP com os registros de backup realizados na Unidade de Backup. O arquivo é
    /// compactado, para otimização do espaço ocupado na Unidade de Backup, e cada entrada
    /// no ZIP segue o seguinte padrão de nomeação:
    /// 
    /// <example>
    /// <code>
    /// BACKUP000001.log
    /// BACKUP000002.log
    /// BACKUP000003.log
    /// BACKUP000004.log
    /// ...
    /// ...
    /// </code> 
    /// </example>
    /// 
    /// Cada entrada é um arquivo texto UTF-8, com o seguinte formato:
    /// 
    /// <example>
    /// <code>
    /// Backup Time: [Backup Time]
    /// Is Partial: [True/False]
    /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
    /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
    /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
    /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
    /// ...
    /// ...
    /// </code>
    /// </example>
    /// 
    /// Onde:
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>Backup Time: [Backup Time]</u></i>: Data do backup.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>Is Partial: [True/False]</u></i>: Status de backup parcial. True, o backup
    /// foi parcial. False, o backup foi completo.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]</u></i>:
    /// Registro de backup de um arquivo.
    /// 
    /// <br><br></br></br>
    /// 
    /// Onde:
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[M]</u></i>: Modo de operação de backup. Sendo:
    /// 
    /// <br><br></br></br>
    /// 
    /// 1- Arquivo criado 
    /// <br></br>
    /// 2- Arquivo excluído
    /// <br></br>
    /// 3- Arquivo modificado
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>$</u></i>: Caracter ASCII número 1, não imprimível.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Source Path]</u></i>: Path do arquivo de origem.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Target Path]</u></i>: Path do arquivo de destino.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Creation Time]</u></i>: Data da criação do arquivo.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Modif. Time]</u></i>: Data da modificação do arquivo.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Size]</u></i>: Tamanho do arquivo.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Backup Time]</u></i>: Data do backup do arquivo.
    /// 
    /// </summary>
    public class BackupLogFile: InstallationFile {


        public BackupLogFile(string path): base(path) {
        }


        /// <summary>
        /// Gravar um novo registro de backup no arquivo de log.
        /// </summary>
        /// <param name="logEntries">Lista de entradas de log.</param>
        /// <param name="isPartial">True, o backup foi parcial. False, o backup foi completo.</param>
        /// <param name="backupTime">Data do backup.</param>
        public void Write(LinkedList<string> logEntries, bool isPartial, DateTime backupTime) {
            try {
                SetHidden(false);
                using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Update)) {
                    int counter = archive.Entries.Count + 1;
                    ZipArchiveEntry zipEntry = archive.CreateEntry(
                        "BACKUP" +
                        Formatter.FormatInt(counter, 6) + ".log"
                    );
                    using (StreamWriter sw = new StreamWriter(zipEntry.Open())) {
                        // Apesar de demandar mais memória RAM, optei por codificar o arquivo assim, para
                        // gravá-lo completo no arquivo ZIP, dessa forma melhorando o tempo de gravação e
                        // otimizando o acesso à memória secundária, normalmente bem mais lenta. Também
                        // melhora os tempos para a compactação do arquivo pois ocorre numa etapa só com
                        // o arquivo completo.
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Backup Time: " + Formatter.FormatDate(backupTime));
                        sb.Append("\r\n");
                        sb.Append("Is Partial: " + isPartial.ToString());
                        foreach (string logEntry in logEntries) {
                            sb.Append("\r\n");
                            sb.Append(logEntry);
                        }
                        sw.Write(sb.ToString());
                    }
                }
            } finally {
                SetHidden(true);
            }
        }


        /// <summary>
        /// Obter a lista com as entradas do arquivo de log, que é um arquivo no formato ZIP.
        /// Cada entrada é relacionada a um registro de backup.
        /// 
        /// <br><br></br></br>
        /// 
        /// A sintaxe da entrada é:
        /// 
        /// <br><br></br></br>
        /// 
        /// BACKUPXXXXXX.log
        /// 
        /// <br><br></br></br>
        /// 
        /// Onde XXXXXX é um número sequêncial iniciando em 000001 e terminando em 999999.
        /// 
        /// <br><br></br></br>
        /// 
        /// Exemplo:
        /// 
        /// <br><br></br></br>
        /// 
        /// BACKUP000002.log
        /// 
        /// </summary>
        /// <returns>Lista com as entradas do arquivo de log.</returns>
        public List<string> ReadEntries() {
            List<string> entries = new List<string>();
            using (ZipArchive archive = ZipFile.OpenRead(path)) {
                foreach (ZipArchiveEntry entry in archive.Entries) {
                    entries.Add(entry.FullName);
                }
            }
            return entries;
        }


        /// <summary>
        /// Ler o registro de log de acordo com a entrada no arquivo ZIP. É um
        /// arquivo texto UTF-8, com o seguinte formato:
        /// 
        /// <example>
        /// <code>
        /// Backup Time: [Backup Time]
        /// Is Partial: [True/False]
        /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
        /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
        /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
        /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
        /// ...
        /// ...
        /// </code>
        /// </example>
        /// 
        /// Onde:
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>Backup Time: [Backup Time]</u></i>: Data do backup.
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>Is Partial: [True/False]</u></i>: Status de backup parcial. True, o backup
        /// foi parcial. False, o backup foi completo.
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>[M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]</u></i>:
        /// Registro de backup de um arquivo.
        /// 
        /// <br><br></br></br>
        /// 
        /// Onde:
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>[M]</u></i>: Modo de operação de backup. Sendo:
        /// 
        /// <br><br></br></br>
        /// 
        /// 1- Arquivo criado 
        /// <br></br>
        /// 2- Arquivo excluído
        /// <br></br>
        /// 3- Arquivo modificado
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>$</u></i>: Caracter ASCII número 1, não imprimível.
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>[Source Path]</u></i>: Path do arquivo de origem.
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>[Target Path]</u></i>: Path do arquivo de destino.
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>[Creation Time]</u></i>: Data da criação do arquivo.
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>[Modif. Time]</u></i>: Data da modificação do arquivo.
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>[Size]</u></i>: Tamanho do arquivo.
        /// 
        /// <br><br></br></br>
        /// 
        /// <i><u>[Backup Time]</u></i>: Data do backup do arquivo.
        /// 
        /// </summary>
        /// <param name="entryName">Nome da entrada no arquivo ZIP.</param>
        /// <returns>Texto codificado.</returns>
        public string Read(string entryName) {
            string logData;
            using (ZipArchive archive = ZipFile.OpenRead(path)) {
                ZipArchiveEntry entry = archive.GetEntry(entryName);
                using (Stream stream = entry.Open()) {
                    using (StreamReader sr = new StreamReader(stream)) {
                        logData = sr.ReadToEnd();
                    }
                }
            }
            return logData;
        }


    }

}
