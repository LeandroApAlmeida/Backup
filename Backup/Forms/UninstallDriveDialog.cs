using Backup.Drive;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Backup.Forms {

    /// <summary>
    /// Diálogo para a desinstalação da Unidade de Backup.
    /// </summary>
    public partial class UninstallDriveDialog : Form {


        // Unidade de Backup selecionada na tela principal.
        private Backup.Drive.Drive drive;


        /// <summary>
        /// Constructor da classe.
        /// </summary>
        /// <param name="drive">Unidade de Backup selecionada na tela principal.</param>
        public UninstallDriveDialog(Backup.Drive.Drive drive) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            this.drive = drive;
            lblDrive.Text = drive.Description;
        }


        /// <summary>
        /// Desinstalar a Unidade de Backup.
        /// </summary>
        private void Uninstall() {
            if (btnConfirm.InvokeRequired) {
                Action safe = delegate {
                    Uninstall();
                };
                btnConfirm.Invoke(safe);
            } else {
                try {
                    btnConfirm.Enabled = false;
                    btnCancel.Enabled = false;
                    drive.Uninstall(cbKeepBackupLog.Checked);
                    MessageBox.Show(
                        this,
                        "Unidade de Backup desinstalada.",
                        "Concluído!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    Close();
                } catch (Exception ex) {
                    btnConfirm.Enabled = true;
                    btnCancel.Enabled = true;
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


        private void StartUninstall() {
            new Thread(Uninstall).Start();
        }


        private void btnConfirm_Click(object sender, System.EventArgs e) {
            StartUninstall();
        }


        private void btnCancel_Click(object sender, System.EventArgs e) {
            Close();
        }


    }

}
