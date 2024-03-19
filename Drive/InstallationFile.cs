using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using Backup.Windows;

namespace Backup.Drive {

    /// <summary>
    /// Classe que representa um arquivo de instalação da Unidade de backup. Há vários
    /// arquivos criados no momento da instalação, e esta classe implementa as funcionalidades
    /// básicas de cada um destes.
    /// </summary>
    public abstract class InstallationFile {


        // Path do arquivo.
        protected readonly string path;


        public InstallationFile(string path) {
            this.path = path;
        }


        /// <summary>
        /// Aplicar os atributos de proteção do arquivo de instalação. Tem efeito somente
        /// em sistemas de arquivo no formato NTFS.
        /// </summary>
        public void SetHidden(bool isHidden) {
            if (Exists()) {
                if (isHidden) {
                    File.SetAttributes(
                        path,
                        FileAttributes.Hidden 
                    );
                } else {
                    File.SetAttributes(
                        path,
                        FileAttributes.Normal
                    );
                }
            }
        }


        /// <summary>
        /// Excluir o arquivo.
        /// </summary>
        public void Delete() {
            if (Exists()) {
                SetHidden(false);
                File.Delete(path);
            }
        }


        /// <summary>
        /// Verificar se o arquivo existe.
        /// </summary>
        /// <returns>True, o arquivo existe. False, o arquivo não existe.</returns>
        public bool Exists() {
            return File.Exists(path);
        }


        /// <summary>
        /// Obter o path do arquivo.
        /// </summary>
        public string Path {
            get {
                return path;
            }
        }


    }

}
