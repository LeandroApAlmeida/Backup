using Backup.Drive;
using Backup.Windows;
using System;
using System.Collections.Generic;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using static Backup.Windows.WindowsSystem;

namespace Backup.Forms {

    /// <summary>
    /// Diálogo para a instalação de uma Unidade de Backup.
    /// </summary>
    public partial class InstallDriveDialog : Form, IUsbEventListener {


        // Gerenciador de drives do Windows.
        private DrivesManager drivesManager;


        /// <summary>
        /// Constructor da classe.
        /// </summary>
        public InstallDriveDialog() {
            InitializeComponent();
            UsbMonitor.Instance.AddListener(this);
            drivesManager = new DrivesManager();
            StartPosition = FormStartPosition.CenterParent;
        }


        /// <summary>
        /// Atualizar a lista de drives.
        /// </summary>
        private void UpdateDrivesList() {
            Invoke((MethodInvoker)delegate () {
                try {
                    cbbDrive.Items.Clear();
                    List<Backup.Drive.Drive> notInstalledDrives = rbLocalDrive.Checked ?
                    drivesManager.GetNotInstalledDrives(DriveType.EXTERNAL) :
                    drivesManager.GetNotInstalledDrives(DriveType.NETWORK);
                    cbbDrive.Items.AddRange(notInstalledDrives.ToArray());
                    if (cbbDrive.Items.Count > 0) {
                        cbbDrive.SelectedIndex = 0;
                        btnInstall.Enabled = true;
                        cbbDrive.Enabled = true;
                        lblFormatting.Visible = false;
                        if (rbNetworkDrive.Checked) {
                            rbFormatDrive.Enabled = false;
                            rbNoFormatDrive.Enabled = false;
                        } else {
                            rbFormatDrive.Enabled = true;
                            rbNoFormatDrive.Enabled = true;
                        }
                        CheckFormatDriveStatus();                        
                    } else {
                        btnInstall.Enabled = false;
                        cbbDrive.Enabled = false;
                        cbbFileSystemFormat.Enabled = false;
                        txbLabel.Enabled = false;
                        lblFormatting.Visible = true;
                        rbNoFormatDrive.Enabled = false;
                        rbFormatDrive.Enabled = false;
                        lblFormatting.Text = "Nenhum dispositivo disponível";
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
            });
        }


        /// <summary>
        /// Listar os formatos de sistema de arquivos para a formatação.
        /// </summary>
        private void ListFormats() {
            string[] fileSystemFormat = {
                "NTFS",
                "FAT32",
                "exFAT"
            };
            cbbFileSystemFormat.Items.AddRange(fileSystemFormat);
            cbbFileSystemFormat.SelectedIndex = 0;
        }


        /// <summary>
        /// Instalar a Unidade de Backup.
        /// </summary>
        private void Install() {
            Invoke((MethodInvoker) delegate () {
                try {
                    Cursor = Cursors.WaitCursor;
                    cbbDrive.Enabled = false;
                    cbbFileSystemFormat.Enabled = false;
                    txbLabel.Enabled = false;
                    btnInstall.Enabled = false;
                    btnCancel.Enabled = false;
                    Backup.Drive.Drive selectedDrive = (Backup.Drive.Drive)cbbDrive.SelectedItem;
                    if (selectedDrive.Type == DriveType.EXTERNAL) {
                        if (rbFormatDrive.Checked) {
                            lblFormatting.Visible = true;
                            lblFormatting.Text = "Formatando o dispositivo...";
                            string fileSystemFormat = (string)cbbFileSystemFormat.SelectedItem;
                            string label = txbLabel.Text;
                            selectedDrive.Format(
                                fileSystemFormat,
                                label
                            );
                        }
                    }
                    selectedDrive.Install();
                    MessageBox.Show(
                        this,
                        "Unidade de Backup instalada.",
                        "Concluído!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    Close();
                    Cursor = Cursors.Default;
                } catch (Exception ex) {
                    Cursor = Cursors.Default;
                    cbbDrive.Enabled = false;
                    cbbFileSystemFormat.Enabled = false;
                    txbLabel.Enabled = false;
                    btnInstall.Enabled = false;
                    lblFormatting.Visible = false;
                    btnCancel.Enabled = true;
                    MessageBox.Show(
                        this,
                        ex.Message,
                        "Erro",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                    );
                }
                Application.DoEvents();
            });
        }


        private void StartInstall() {
            new Thread(Install).Start();
        }


        private void CheckFormatDriveStatus() {
            cbbFileSystemFormat.Enabled = rbFormatDrive.Checked;
            txbLabel.Enabled = rbFormatDrive.Checked;
        }


        void IUsbEventListener.DeviceInserted(object sender, EventArrivedEventArgs e) {
            new Thread(UpdateDrivesList).Start();
        }


        void IUsbEventListener.DeviceRemoved(object sender, EventArrivedEventArgs e) {
            new Thread(UpdateDrivesList).Start();
        }


        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }


        private void btnInstall_Click(object sender, EventArgs e) {
            StartInstall();
        }


        private void InstallDriveDialog_FormClosing(object sender, FormClosingEventArgs e) {
            UsbMonitor.Instance.RevomeListener(this);
        }


        private void InstallDriveDialog_Load(object sender, EventArgs e) {
            UpdateDrivesList();
            ListFormats();
        }


        private void rbFormatDrive_CheckedChanged(object sender, EventArgs e) {
            CheckFormatDriveStatus();
        }


        private void rbNoFormatDrive_CheckedChanged(object sender, EventArgs e) {
            CheckFormatDriveStatus();
        }


        private void rbLocalDrive_CheckedChanged(object sender, EventArgs e) {
            UpdateDrivesList();
        }


        private void rbNetworkDrive_CheckedChanged(object sender, EventArgs e) {
            UpdateDrivesList();
        }


    }

}
