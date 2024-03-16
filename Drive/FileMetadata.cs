using System;

namespace Backup.Drive {

    /// <summary>
    /// Metadados de um arquivo de backup.
    /// </summary>
    public class FileMetadata {


        // Modo de operação com o arquivo.
        private readonly int operation;

        // Path de destino do arquivo.
        private readonly string targetPath;

        // Path de origem do arquivo.
        private readonly string sourcePath;

        // Data da criação do arquivo.
        private readonly DateTime creationTime;

        // Data de backup do arquivo.
        private readonly DateTime backupTime;

        // Data da última modificação do arquivo.
        private readonly DateTime lastModifiedTime;

        // Tamanho do arquivo.
        private readonly long size;


        /// <summary>
        /// Constructor da classe.
        /// </summary>
        /// <param name="operation">Modo de operação com o arquivo.</param>
        /// <param name="targetPath">Path de destino do arquivo.</param>
        /// <param name="sourcePath">Path de origem do arquivo.</param>
        /// <param name="creationTime">Data da criação do arquivo.</param>
        /// <param name="backupTime">Data de backup do arquivo.</param>
        /// <param name="lastModifiedTime">Data da última modificação do arquivo.</param>
        /// <param name="size">Tamanho do arquivo (em bytes).</param>
        public FileMetadata(int operation, string targetPath, string sourcePath,
        DateTime creationTime, DateTime backupTime, DateTime lastModifiedTime,
        long size) {
            this.operation = operation;
            this.targetPath = targetPath;
            this.sourcePath = sourcePath;
            this.creationTime = creationTime;
            this.backupTime = backupTime;
            this.lastModifiedTime = lastModifiedTime;
            this.size = size;
        }


        /// <summary>
        /// Modo de operação com o arquivo.
        /// </summary>
        public int Operation {
            get {
                return operation;
            }
        }


        /// <summary>
        /// Path de destino do arquivo.
        /// </summary>
        public string TargetPath {
            get {
                return targetPath;
            }
        }


        /// <summary>
        /// Path de origem do arquivo.
        /// </summary>
        public string SourcePath {
            get {
                return sourcePath;
            }
        }


        /// <summary>
        /// Data de criação do arquivo.
        /// </summary>
        public DateTime CreationTime {
            get {
                return creationTime;
            }
        }


        /// <summary>
        /// Data do backup do arquivo.
        /// </summary>
        public DateTime BackupTime {
            get {
                return backupTime;
            }
        }


        /// <summary>
        /// Data da última modificação do arquivo.
        /// </summary>
        public DateTime LastModifiedTime {
            get {
                return lastModifiedTime;
            }
        }


        /// <summary>
        /// Tamanho do arquivo (em bytes).
        /// </summary>
        public long Size {
            get {
                return size;
            }
        }


    }

}
