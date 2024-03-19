using Backup.Drive;
using Backup.Utils;
using System;
using System.Windows.Forms;
using static Backup.Windows.WindowsSystem;
using DriveType = Backup.Windows.DriveType;

namespace Backup.Forms {

    /// <summary>
    /// Diálogo para exibir informações sobre a Unidade de Backup selecionada
    /// na tela principal.
    /// </summary>
    public partial class DriveInfoDialog : Form {


        /// <summary>
        /// Constructor da classe.
        /// </summary>
        /// <param name="drive">Unidade de Backup selecionada na tela principal.</param>
        public DriveInfoDialog(Drive.Drive drive) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            Text = "SOBRE " + drive.Description;
            lvDriveInfo.Items.Clear();
            Print(drive);
        }


        /// <summary>
        /// Exibir as informações sobre a Unidade de Backup.
        /// </summary>
        /// <param name="drive">Unidade de Backup selecionada na tela principal.</param>
        private void Print(Drive.Drive drive) {
            try {
                ListViewItem lviUid = new ListViewItem(
                    new string[] {
                        "IDENTIFICADOR",
                        drive.UID
                    },
                    -1
                );
                ListViewItem lviLabel = new ListViewItem(
                    new string[] {
                        "RÓTULO",
                        drive.VolumeLabel
                    },
                    -1
                );
                ListViewItem lviInstDate = new ListViewItem(
                    new string[] {
                        "DATA DA INSTALAÇÃO",
                        drive.InstallationTime.ToString()
                    },
                    -1
                );
                ListViewItem lviLastBackDate = new ListViewItem(
                    new string[] {
                        "DATA DO ÚLT. BACKUP",
                        drive.HaveLastBackupTime ? 
                        drive.LastBackupTime.ToString() :
                        "[indisponível]"
                    },
                    -1
                );
                ListViewItem lviTotalSize = new ListViewItem(
                    new string[] {
                        "ESPAÇO TOTAL",
                        Formatter.FormatSize(drive.Size)
                    },
                    -1
                );
                ListViewItem lviFreeSpace = new ListViewItem(
                    new string[] {
                        "ESPAÇO LIVRE",
                        Formatter.FormatSize(drive.FreeSpace)
                    },
                    -1
                );
                ListViewItem lviRootDir = new ListViewItem(
                    new string[] {
                        "DIRETÓRIO RAIZ",
                        drive.RootDirectory
                    },
                    -1
                );
                ListViewItem lviFsFormat = new ListViewItem(
                    new string[] {
                        "FORMATO",
                        drive.FileSystemFormat
                    },
                    -1
                );
                string type = "";
                switch (drive.Type) {
                    case DriveType.INTERNAL:  type = "INTERNO"; break;
                    case DriveType.EXTERNAL:  type = "REMOVÍVEL"; break;
                    case DriveType.NETWORK:  type = "REDE"; break;
                }
                ListViewItem lviType = new ListViewItem(
                    new string[] {
                        "TIPO DE MÍDIA",
                        type
                    },
                    -1
                );
                lvDriveInfo.Items.AddRange(
                    new ListViewItem[] {
                        lviUid,
                        lviLabel,
                        lviInstDate,
                        lviLastBackDate,
                        lviTotalSize,
                        lviFreeSpace,
                        lviRootDir,
                        lviFsFormat,
                        lviType
                    }
                );
                this.chData.Width = 188;
                this.chValue.Width = 257;
            } catch (Exception ex ) {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


    }

}
