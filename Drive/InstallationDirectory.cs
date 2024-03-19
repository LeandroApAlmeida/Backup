using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using Backup.Windows;

namespace Backup.Drive {

    /// <summary>
    /// Diretório de instalação da Unidade de Backup.
    /// </summary>
    public class InstallationDirectory {


        // Path do diretório.
        private readonly string path;


        public InstallationDirectory(string path) {
            this.path = path;
        }


        /// <summary>
        /// Criar o diretório.
        /// </summary>
        public void Create() {
            if (!Exists()) {
                Directory.CreateDirectory(path);
            }
            SetHidden(true);
        }


        /// <summary>
        ///  Aplicar os atributos de proteção ao diretório. Tem efeito somente em 
        ///  sistemas de arquivo no formato NTFS.
        /// </summary>
        public void SetHidden(bool isHidden) {
            if (Exists()) {
                if (isHidden) {
                    File.SetAttributes(
                        path,
                        FileAttributes.Hidden | 
                        FileAttributes.ReadOnly
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
        /// Verificar se o diretório existe.
        /// </summary>
        /// <returns>True, o diretório existe. False, o diretório não existe.</returns>
        public bool Exists() {
            return Directory.Exists(path);
        }


        /// <summary>
        /// Excluir o diretório.
        /// </summary>
        public void Delete() {
            if (Exists()) {
                Directory.Delete(path);
            }
        }


        /// <summary>
        /// Path do diretório.
        /// </summary>
        public string Path {
            get {
                return path;
            }
        }


    }

}