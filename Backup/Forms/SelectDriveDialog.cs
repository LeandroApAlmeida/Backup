using Backup.Drive;
using Backup.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Backup.Forms {

    /// <summary>
    /// Diálogo para a seleção de um drive interno do sistema (disco local).
    /// </summary>
    public partial class SelectDriveDialog : Form {


        private readonly Drive.Drive drive;

        // Gerenciador de drives do Windows.
        private readonly DrivesManager drivesManager;

        // Drive interno selecionado na lista.
        private readonly List<Drive.Drive> selectedDrivesList;

        // Lista dos drives internos (partições).
        private List<Drive.Drive> internalDrives;


        /// <summary>
        /// Constructor da classe.
        /// </summary>
        public SelectDriveDialog(Drive.Drive drive) {
            InitializeComponent();
            this.drive = drive;
            selectedDrivesList = new List<Drive.Drive>();
            StartPosition = FormStartPosition.CenterParent;
            drivesManager = new DrivesManager();
            UpdateDrivesList();
        }


        /// <summary>
        /// Atualizar a lista de drives internos.
        /// </summary>
        private void UpdateDrivesList() {
            try {
                ltvDrives.Items.Clear();
                internalDrives = drivesManager.InternalDrives;
                List<ListViewItem> listViewItems = new List<ListViewItem>();
                List<string> destinationDrives = this.drive.DestinationDrives;
                bool insertDrive;
                for (int i = 0; i < internalDrives.Count; i++) {
                    insertDrive = false;
                    Drive.Drive drive = internalDrives[i];
                    foreach (string letter in destinationDrives) {
                        if (letter.Equals(drive.Letter)) {
                            insertDrive = true;
                            break;
                        }
                    }
                    if (insertDrive) {
                        ListViewItem item = new ListViewItem(
                            new string[] {
                                drive.Description,
                                Formatter.FormatSize(drive.Size),
                                Formatter.FormatSize(drive.FreeSpace),
                                drive.FileSystemFormat
                            },
                            0
                        );
                        listViewItems.Add(item);
                    }
                }
                ltvDrives.Items.AddRange(listViewItems.ToArray());
                if (SafeRestore.IsPendingRestore) {
                    if (SafeRestore.SourceDriveId != drive.UID) {
                        ltvDrives.Enabled = false;
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Conecte a Unidade de Backup com o Identificador ");
                        sb.Append(SafeRestore.SourceDriveId);
                        sb.Append(" para concluir a restauração pendente.");
                        throw new Exception(sb.ToString());
                    }
                    List<string> targetRestoreDrives = SafeRestore.TargetDrives;
                    for (int i = 0; i < internalDrives.Count; i++) {
                        Drive.Drive drive = internalDrives[i];
                        if (drive.Letter.Equals(SafeRestore.TargetDrives)) {
                            ltvDrives.Items[i].Checked = true;
                        }
                    }
                    ltvDrives.Enabled = false;
                }
            } catch (Exception ex) {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        /// <summary>
        /// Selecionar o drive interno.
        /// </summary>
        private void SelectDrive() {
            if (ltvDrives.CheckedItems.Count > 0) {
                foreach (ListViewItem item in ltvDrives.CheckedItems) {
                    foreach (Drive.Drive drive in internalDrives) {
                        if (drive.Description.Equals(item.Text)) {
                            selectedDrivesList.Add(drive);
                        }
                    }
                }
                Close();
            } else {
                MessageBox.Show(
                    this,
                    "Nenhum drive selecionado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
            }
        }


        /// <summary>
        /// Obter o drive interno selecionado.
        /// </summary>
        public List<Drive.Drive> SelectedDrivesList {
            get {
                return selectedDrivesList;
            }
        }


        private void btnSelect_Click(object sender, EventArgs e) {
            SelectDrive();
        }


        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }


    }

}