using System;
using System.Collections.Generic;

namespace Backup.Drive {

    /// <summary>
    /// Ouvinte do processo de backup.
    /// </summary>
    public interface IBackupListener {

        /// <summary>
        /// Evento de backup iniciado.
        /// </summary>
        /// <param name="numberOfFiles">Número de arquivos a processar.</param>
        void BackupInitialized(int numberOfFiles);

        /// <summary>
        /// Evento de arquivo em processo de backup.
        /// </summary>
        /// <param name="fileIndex">Posição do arquivo.</param>
        /// <param name="filePath">Caminho do arquivo.</param>
        /// <param name="mode">Modo de operação com o arquivo.</param>
        void ProcessingFile(int fileIndex, string filePath, int mode);

        /// <summary>
        /// Evento de backup abortado por erro.
        /// </summary>
        /// <param name="ex">Erro ocorrido no backup.</param>
        void BackupAbortedByError(Exception ex);

        /// <summary>
        /// Evento de backup abortado pelo usuário.
        /// </summary>
        void BackupAbortedByUser();

        /// <summary>
        /// Evento de backup concluído com sucesso.
        /// </summary>
        void BackupDone(LinkedList<String> errorFilesList);

    }

}
