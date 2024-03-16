using System.Drawing;
using System.IO;

namespace Backup.Drive {

    /// <summary>
    /// Arquivo de ícone para exibição no Windows Explorer. O Ícone em questão
    /// está incorporado nos resources do executável com o nome "BackupDrive".
    /// </summary>
    public class IconFile: InstallationFile {


        public IconFile(string path): base(path) {
        }


        /// <summary>
        /// Extrair o arquivo de ícone dos resources e gravar na Unidade de Backup.
        /// </summary>
        public void Write() {
            Icon icon = Drive1.Properties.Resources.BackupDrive;
            using (FileStream fs = new FileStream(path, FileMode.Create)) {
                icon.Save(fs);
            }
            SetHidden(true);
        }


    }

}
