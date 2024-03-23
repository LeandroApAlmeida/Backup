using Backup.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Backup.Drive {

    /// <summary>
    /// Controle de restore seguro. A operação de restore deve ser concluída antes que se
    /// possa executar qualquer outra ação no sistema.
    /// </summary>
    public static class SafeRestore {


        // Arquivo de controle de restore.
        private static RestoreFile restoreFile;

        // Identificador da Unidade de Backup.
        private static string sourceId;

        // Identificador do drive de destino.
        private static List<string> targetIdList;

        // Data de ínicio do restore.
        private static DateTime restoreTime;


        /// <summary>
        /// Carrega os dados sobre o restore.
        /// </summary>
        static SafeRestore() {
            restoreFile = new RestoreFile(AppDomain.CurrentDomain.BaseDirectory + @"\restore-info.xml");
            if (restoreFile.Exists()) {
                Dictionary<string, object> dictionary = restoreFile.Read();
                sourceId = (string)dictionary["source-drive-id"];
                string drives = (string)dictionary["target-drive-id"];
                string[] drivesList = drives.Split(',');
                targetIdList = new List<string>(drivesList.Length);
                foreach (string drive in drivesList) {
                    targetIdList.Add(drive);
                }
                restoreTime = (DateTime)dictionary["restore-time"];
            } else {
                targetIdList = new List<string>();
            }
        }


        /// <summary>
        /// Sinalizar o início do restore. Assim que o restore é iniciado, cria o 
        /// arquivo de controle para garantir que nenhuma ação seja realizada no sistema
        /// antes que o mesmo seja concluído.
        /// </summary>
        /// <param name="sourceDrive">Drive de origem do restore.</param>
        /// <param name="destinationDrive">Drive de destino do restore.</param>
        public static void RestoreStarted(Drive sourceDrive, List<Drive> destinationDrive) {
            sourceId = sourceDrive.UID;
            StringBuilder sb = new StringBuilder();
            sb.Append(destinationDrive[0]);
            for (int i = 1; i < destinationDrive.Count; i++) {
                sb.Append(",");
                sb.Append(destinationDrive[i].Letter);
            }
            restoreTime = DateTime.Now;
            if (!restoreFile.Exists()) {
                restoreFile.Write(sourceId, sb.ToString(), restoreTime);
            }
        }


        /// <summary>
        /// Sinalizar a conclusão do restore. Assim que o restore é concluído, exclui o
        /// arquivo de controle.
        /// </summary>
        public static void RestoreDone() {
            restoreFile.Delete();
        }


        /// <summary>
        /// Status de restore pendente. True, há restore está pendente. False, não há
        /// restore pendente.
        /// </summary>
        public static bool IsPendingRestore {
            get {
                return restoreFile.Exists();
            }
        }
        

        /// <summary>
        /// Identificador da Unidade de Backup.
        /// </summary>
        public static string SourceDriveId {
            get {
                return sourceId;
            }
        }


        /// <summary>
        /// Identificador do drive de destino.
        /// </summary>
        public static List<string> TargetDrives {
            get {
                return targetIdList;
            }
        }


        /// <summary>
        /// Data de início do restore.
        /// </summary>
        public static DateTime RestoreTime {
            get {
                return restoreTime;
            }
        }


    }

}
