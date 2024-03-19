using System.Collections.Generic;
using Backup.Windows;
using System.IO;
using DriveType = Backup.Windows.DriveType;


namespace Backup.Drive {

    /// <summary>
    /// Gerenciador de drives do Windows.
    /// </summary>
    public class DrivesManager {


        // Lista dos drives internos (HD/SSD interno).
        private readonly List<Drive> internalDrives;


        public DrivesManager() {
            internalDrives = GetDrives(DriveType.INTERNAL);
        }


        /// <summary>
        /// Obter a lista dos drives que atendam ao critério de tipo.
        /// </summary>
        /// <param name="driveType">Tipo de drive a listar.</param>
        /// <returns>Lista de drives segundo o tipo.</returns>
        private List<Drive> GetDrives(DriveType driveType) {
            List<DriveInfo> drives = WindowsSystem.GetDrives(driveType);
            List<Drive> drivesList = new List<Drive>(drives.Count);
            drives.ForEach(driveInfo => {drivesList.Add(new Drive(driveInfo, driveType));});
            return drivesList;
        }
        

        /// <summary>
        /// Lista de drives internos (HD interno, SSD).
        /// </summary>
        public List<Drive> InternalDrives {
            get {
                return internalDrives;
            }
        }


        /// <summary>
        /// Lista de drives externos (USB drives).
        /// </summary>
        public List<Drive> ExternalDrives {
            get {
                return GetDrives(DriveType.EXTERNAL);
            }
        }


        /// <summary>
        /// Lista de drives de rede.
        /// </summary>
        public List<Drive> NetworkDrives {
            get {
                return GetDrives(DriveType.NETWORK);
            }
        }


        /// <summary>
        /// Obter a lista dos drives que são Unidades de Backup.
        /// </summary>
        /// <returns>Lista de Unidades de Backup.</returns>
        public List<Drive> GetInstalledDrives() {
            List<Drive> externalDrives = GetDrives(DriveType.EXTERNAL);
            List<Drive> networkDrives = GetDrives(DriveType.NETWORK);
            List<Drive> installedDrives = new List<Drive>();
            foreach (Drive drive in externalDrives) {
                if (drive.IsInstalled) {
                    installedDrives.Add(drive);
                }
            }
            foreach (Drive drive in networkDrives) {
                if (drive.IsInstalled) {
                    installedDrives.Add(drive);
                }
            }
            return installedDrives;
        }


        /// <summary>
        /// Obter a lista de drives que não são Unidadede Backup de acordo com seu tipo 
        /// específico.
        /// </summary>
        /// <param name="type">Tipo de drive a listar.</param>
        /// <returns>Lista de drives não instalados.</returns>
        public List<Drive> GetNotInstalledDrives(DriveType type) {
            List<Drive> drives = GetDrives(type);
            List<Drive> notInstalledDrives = new List<Drive>();
            foreach (Drive drive in drives) {
                if (!drive.IsInstalled) {
                    notInstalledDrives.Add(drive);
                }
            }
            return notInstalledDrives;
        }


    }

}
