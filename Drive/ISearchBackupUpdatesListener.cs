using System;
using System.Collections.Generic;
using System.IO;

namespace Backup.Drive {

    /// <summary>
    /// Ouvinte de busca de atualização de arquivos para backup.
    /// </summary>
    public interface ISearchBackupUpdatesListener {

        /// <summary>
        /// Evento de início de busca por arquivos.
        /// </summary>
        /// <param name="totalFiles">Número de arquivos a serem verificados.</param>
        void SearchInitialized(int totalFiles);

        /// <summary>
        /// Evento de processamento de um arquivo.
        /// </summary>
        /// <param name="fileIndex">Índice do arquivo.</param>
        /// <param name="file">Caminho do arquivo.</param>
        void ProcessingFile(int fileIndex, string file);

        /// <summary>
        /// Evento de conclusão da busca por arquivos.
        /// </summary>
        /// <param name="createdFilesList">Lista de arquivos que serão criados na unidade de backup.</param>
        /// <param name="deletedFilesList">Lista de arquivos que serão excluídos da unidade de backup.</param>
        /// <param name="updatedFilesList">Lista de arquivos que serão atualizados na unidade de backup.</param>
        /// <param name="errorFilesList">Lista de arquivos com erro no processamento.</param>
        void SearchFinished(LinkedList<FileInfo> createdFilesList, LinkedList<FileInfo> deletedFilesList,
        LinkedList<FileInfo> updatedFilesList, LinkedList<DamageInfo> errorFilesList);

        /// <summary>
        /// Evento de processo abortado por erro.
        /// </summary>
        /// <param name="ex">Erro ocorrido no processo.</param>
        void SearchAbortedByError(Exception ex);

        /// <summary>
        /// Evento de processo abortado pelo usuário.
        /// </summary>
        void SearchAbortedByUser();

    }

}