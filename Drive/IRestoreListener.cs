using System;
using System.Collections.Generic;
using System.IO;

namespace Backup.Drive {

    /// <summary>
    /// Ouvinte do processo de restauração.
    /// </summary>
    public interface IRestoreListener {

        /// <summary>
        /// Evento de listagem dos arquivos a restaurar.
        /// </summary>
        /// <param name="restoreFiles">Lista dos arquivos a restaurar.</param>
        void ListRestoreFiles(LinkedList<FileInfo> restoreFiles);

        /// <summary>
        /// Evento de restore iniciado.
        /// </summary>
        /// <param name="numberOfFiles">Número de arquivos a processar.</param>
        void RestoreInitialized(int numberOfFiles);

        /// <summary>
        /// Evento de arquivo em processo de restauração.
        /// </summary>
        /// <param name="fileIndex">Posição do arquivo.</param>
        /// <param name="file">Caminho do arquivo.</param>
        void ProcessingFile(int fileIndex, string file);

        /// <summary>
        /// Evento de restauração abortada por erro.
        /// </summary>
        /// <param name="ex">Erro ocorrido no restauração.</param>
        void RestoreAbortedByError(Exception ex);

        /// <summary>
        /// Evento de restauração abortada pelo usuário.
        /// </summary>
        void RestoreAbortedByUser();

        /// <summary>
        /// Evento de restauração concluída com sucesso.
        /// </summary>
        void RestoreDone(LinkedList<String> errorFilesList);

    }

}