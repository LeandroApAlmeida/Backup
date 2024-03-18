using Backup.Drive;
using Backup.Utils;
using Backup.Environment;
using Backup.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using DriveType = Backup.Environment.WindowsSystem.DriveType;
using System.Text;

namespace Backup.Forms {

    /// <summary>
    /// Tela principal do programa.
    /// </summary>
    public partial class MainWindow : Form, IUsbEventListener, ISearchBackupUpdatesListener,
    IBackupListener, IRestoreListener {


        // Número de arquivos na lista de arquivos recentes no menu. Cada arquivo
        // corresponde a uma entrada no registro de log.
        private readonly int NUM_RECENT_FILES = 5;

        // Lista contendo os ícones de arquivos de acordo com sua extensão.
        // Estes ícones são utilizados para exibição na lista da tela principal. Uso
        // para a otimização do uso da memória, pois vários arquivos terão a mesma
        // extensão, e, portanto, o mesmo ícone. Então, seria um desperdício de memória
        // guardar um ícone para cada arquivo. Desta forma, mantenho apenas uma cópia
        // do ícone para cada extensão de arquivo.
        private Dictionary<string, Dictionary<string, object>> extensionIcons;

        // Gerenciador de drives do Windows.
        private DrivesManager drivesManager;

        // Unidade de Backup selecionada pelo usuário.
        private Drive.Drive selectedDrive;

        // Status de processamento de backup.
        private bool processingBackup;

        // Status de processamento abortado.
        private bool proccessAborted;

        private int actionAfterBackupCode ;



        
        /// <summary>
        /// Constructor da classe.
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            UsbMonitor.Instance.AddListener(this);
            extensionIcons = new Dictionary<string, Dictionary<string, object>>();
            processingBackup = false;
            drivesManager = new DrivesManager();
            selectedDrive = null;
            rbpCancel.Visible = false;
            pgbFiles.Visible = false;
            tslStatus.Visible = false;
            lblProccessStatus.Visible = false;
            contextMenuStrip.Enabled = false;
            actionAfterBackupCode = 1;
            UpdateDrivesList();
            UpdateDriveSelectionStatus();
        }    




        #region UI configuration


        /// <summary>
        /// Atualizar a lista de Unidades de Backup no menu Selecionar.
        /// </summary>
        private void UpdateDrivesList() {
            List<Drive.Drive> installedDrives = drivesManager.GetInstalledDrives();
            romSelectDrive.DropDownItems.Clear();
            foreach (Drive.Drive drive in installedDrives) {
                RibbonButton ribbonButton = new RibbonButton();
                ribbonButton.DropDownArrowDirection = RibbonArrowDirection.Left;
                if (drive.Type == DriveType.EXTERNAL) {
                    ribbonButton.LargeImage = Resources.usb_16;
                    ribbonButton.SmallImage = Resources.usb_16;
                } else {
                    ribbonButton.LargeImage = Resources.net2_16;
                    ribbonButton.SmallImage = Resources.net2_16;
                }
                ribbonButton.Text = drive.Description;
                ribbonButton.Click += (sender, args) => {
                    OpenBackupDrive(drive);
                };
                romSelectDrive.DropDownItems.Add(ribbonButton);
                RibbonSeparator sep = new RibbonSeparator();
                romSelectDrive.DropDownItems.Add(sep);
            }
            {
                RibbonButton ribbonButton = new RibbonButton();
                ribbonButton.DropDownArrowDirection = RibbonArrowDirection.Left;
                ribbonButton.LargeImage = Resources.pluss_16;
                ribbonButton.SmallImage = Resources.pluss_16;
                ribbonButton.Text = "Instalar Unidade de Backup";
                ribbonButton.Click += (sender, args) => {
                    ShowInstallDriveDialog();
                };
                romSelectDrive.DropDownItems.Add(ribbonButton);
            }
            if (selectedDrive != null) {
                bool connected = false;
                foreach (Drive.Drive drive in installedDrives) {
                    if (drive.UID.Equals(selectedDrive.UID)) {
                        connected = true;
                        break;
                    }
                }
                if (!connected) {
                    CancelProccess();
                    CloseBackupDrive();
                }
            }
        }


        /// <summary>
        /// Atualizar os controles da interface gráfica de acordo com uma
        /// Unidade de Backup estar selecionada ou não.
        /// </summary>
        private void UpdateDriveSelectionStatus() {
            bool isSelectedDrive = selectedDrive != null;
            romSelectDrive.Enabled = !isSelectedDrive;
            romUninstall.Enabled = isSelectedDrive;
            romProps.Enabled = isSelectedDrive;
            romDirectories.Enabled = isSelectedDrive;
            rboClose.Enabled = isSelectedDrive;
            rbbRunBackup.Enabled = isSelectedDrive;
            rbpBackup.ButtonMoreEnabled = isSelectedDrive;
            rbbUpdate.Enabled = isSelectedDrive;
            rbpUpdate.ButtonMoreEnabled = isSelectedDrive;
            rbbHistory.Enabled = isSelectedDrive;
            rbbDirectories.Enabled = isSelectedDrive;
            rbbRestore.Enabled = isSelectedDrive;
            lblLastBackupDate.Visible = isSelectedDrive;
            lblNumFiles.Visible = isSelectedDrive;
            if (isSelectedDrive) {
                romSelectDrive.Text = selectedDrive.Description;
                romSelectDrive.Style = RibbonButtonStyle.Normal;
                ribbon.OrbText = selectedDrive.Description;
                UpdateStatusBarData();
                if (ltvFiles.Items.Count > 0) {
                    contextMenuStrip.Enabled = true;
                }
            } else {
                romSelectDrive.Text = "Selecionar";
                romSelectDrive.Style = RibbonButtonStyle.DropDown;
                ribbon.OrbText = "Unidade de Backup";
                lblLastBackupDate.Text = "";
                lblNumFiles.Text = "";
                contextMenuStrip.Enabled = false;
                tsslFileName.Visible = false;
            }
        }


        /// <summary>
        /// Atualizar a lista de arquivos recentes no menu. Cada arquivo
        /// na lista corresponde a uma entrada no arquivo de log.
        /// </summary>
        private void UpdateRecentFilesList() {
            ribbon.OrbDropDown.RecentItems.Clear();
            if (selectedDrive != null) {
                if (selectedDrive.LogFile.Exists()) {
                    List<string> logFileEntries = selectedDrive.LogFile.ReadEntries();
                    int numFiles = logFileEntries.Count > NUM_RECENT_FILES ?
                    NUM_RECENT_FILES : logFileEntries.Count;
                    for (int i = 1; i <= numFiles; i++) {
                        int relativeIndex = logFileEntries.Count - i;
                        string logFileEntry = logFileEntries[relativeIndex];
                        RibbonOrbRecentItem recentItem = new RibbonOrbRecentItem();
                        recentItem.Text = logFileEntry;
                        recentItem.Click += (sender, args) => {
                            ShowBackupHistoryDialog(relativeIndex);
                        };
                        ribbon.OrbDropDown.RecentItems.Add(recentItem);
                    }
                }
            }
        }


        /// <summary>
        /// Atualizar os dados exibidos à esquerda na barra de status.
        /// </summary>
        private void UpdateStatusBarData() {
            int numFiles = ltvFiles.Items.Count;
            if (numFiles == 0) {
                lblNumFiles.Text = "    ATUALIZAÇÕES: NENHUMA";
            } else if (numFiles == 1) {
                lblNumFiles.Text = "    ATUALIZAÇÕES: 1 ARQUIVO";
            } else {
                lblNumFiles.Text = "    ATUALIZAÇÕES: " + numFiles.ToString() + " ARQUIVOS";
            }
            if (selectedDrive.HaveLastBackupTime) {
                lblLastBackupDate.Text = "ÚLTIMO BACKUP: " +
                selectedDrive.LastBackupTime.ToString();
            } else {
                lblLastBackupDate.Text = "ÚLTIMO BACKUP: NÃO REALIZADO";
            }
        }


        /// <summary>
        /// Atualizar os controles da interface gráfica de acordo com o status de
        /// processamento de backup/Restore.
        /// </summary>
        /// <param name="isProcessing"></param>
        private void UpdateProcessingBackupStatus(bool isProcessing) {
            if (isProcessing) {
                foreach (RibbonOrbRecentItem item in ribbon.OrbDropDown.RecentItems) {
                    item.Enabled = false;
                }
                rbbCancelProccess.Enabled = true;
                rbpCancel.Visible = true;
                rbbRunBackup.Enabled = false;
                rbpBackup.ButtonMoreEnabled = false;
                rbbUpdate.Enabled = false;
                rbpUpdate.ButtonMoreEnabled = false;
                rbbHistory.Enabled = false;
                rbbRestore.Enabled = false;
                rbbDirectories.Enabled = false;
                romUninstall.Enabled = false;
                romDirectories.Enabled = false;
                rboClose.Enabled = false;
            } else {
                foreach (RibbonOrbRecentItem item in ribbon.OrbDropDown.RecentItems) {
                    item.Enabled = true;
                }
                rbbCancelProccess.Enabled = true;
                rbpCancel.Visible = false;
                rbbUpdate.Enabled = true;
                rbpUpdate.ButtonMoreEnabled = true;
                rbbHistory.Enabled = true;
                rbbRestore.Enabled = true;
                rbbDirectories.Enabled = true;
                romUninstall.Enabled = true;
                romDirectories.Enabled = true;
                tsslFileName.Visible = false;
                rboClose.Enabled = true;
                int numFiles = ltvFiles.Items.Count;
                if (numFiles > 0) {
                    rbbRunBackup.Enabled = true;
                    rbpBackup.ButtonMoreEnabled = true;
                } else {
                    rbbRunBackup.Enabled = false;
                    rbpBackup.ButtonMoreEnabled = false;
                }
            }
        }


        /// <summary>
        /// Obter o ícone e a descrição de um arquivo a ser exibido na lista, de acordo
        /// com a extensão do arquivo. 
        /// </summary>
        /// <param name="fileInfo">Informações sobre o arquivo.</param>
        /// <returns>Dictionary contendo o índice do ícone no componente ImageCollection
        /// imlFiles e a descrição do arquivo.</returns>
        private Dictionary<string, object> GetExtensionInfo(FileInfo fileInfo) {
            // Aqui há uma pequena otimização, pois ao invéz de carregar um ícone toda vez
            // que se lista um arquivo, o que envolve acesso à memória secundária, uma vez
            // que tais ícones estão inseridos como recurso no arquivo executável que abre
            // aquele tipo de arquivo, e também buscar a descrição daquele tipo de arquivo
            // no registro do Windows, eu uso a estratégia de criar um Dictionary que
            // tem como chave a extensão do arquivo e como conteúdo um outro Dictionary, que
            // tem o índice do ícone no componente ImageCollection imlFiles e a descrição do
            // arquivo. Este último Dictionary é que é retornado pelo método e vai fornecer
            // tais informações sobre o arquivo na lista.
            //
            // Se o arquivo for um executável do Windows, o ícone recuperado será o mesmo
            // exibido no Windows Explorer. Neste caso específico, não adiciono o ícone pela
            // chave da extensão do arquivo, mas pelo seu caminho completo.
            Dictionary<string, object> dic;
            if (extensionIcons.ContainsKey(fileInfo.Extension)) {
                dic = extensionIcons[fileInfo.Extension];
            } else if (extensionIcons.ContainsKey(fileInfo.FullName)) {
                dic = extensionIcons[fileInfo.FullName];
            } else {
                Icon icon = WindowsSystem.ExtractFileIcon(fileInfo.FullName);
                string description = WindowsSystem.GetFileDescription(fileInfo.FullName);
                imlFiles.Images.Add(icon);
                int index = imlFiles.Images.Count - 1;
                dic = new Dictionary<string, object>();
                dic["icon_index"] = index;
                dic["description"] = description;
                if (!fileInfo.Extension.ToLower().Equals(".exe")) {
                    extensionIcons[fileInfo.Extension] = dic;
                } else {
                    extensionIcons[fileInfo.FullName] = dic;
                }
            }
            return dic;
        }


        #endregion




        #region Menu actions


        /// <summary>
        /// Abrir o diálogo para instalação da Unidade de Backup
        /// </summary>
        private void ShowInstallDriveDialog() {
            Cursor = Cursors.WaitCursor;
            InstallDriveDialog dialog = new InstallDriveDialog();
            dialog.ShowDialog();
            Cursor = Cursors.Default;
            UpdateDrivesList();
        }


        /// <summary>
        /// Abrir o diálogo para desinstalação da Unidade de Backup.
        /// </summary>
        private void ShowUninstallDriveDialog() {
            Cursor = Cursors.WaitCursor;
            UninstallDriveDialog dialog = new UninstallDriveDialog(selectedDrive);
            dialog.ShowDialog();
            if (!selectedDrive.IsInstalled) {
                CloseBackupDrive();
                UpdateDrivesList();
            }
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Abrir o diálogo para manutenção de diretórios para backup.
        /// </summary>
        private void ShowDirectoriesDialog() {
            Cursor = Cursors.WaitCursor;
            DirectoriesDialog dialog = new DirectoriesDialog(selectedDrive);
            dialog.ShowDialog();
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Abrir o diálogo para informações sobre a Unidade de Backup.
        /// </summary>
        private void ShowDriveInfoDialog() {
            Cursor = Cursors.WaitCursor;
            DriveInfoDialog dialog = new DriveInfoDialog(selectedDrive);
            dialog.ShowDialog();
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Abrir o diálogo Histórico de Backup na última página.
        /// </summary>
        private void ShowBackupHistoryDialog() {
            ShowBackupHistoryDialog(-1);
        }


        /// <summary>
        /// Abrir o diálogo Histórico de Backup numa página específica.
        /// </summary>
        /// <param name="index"></param>
        private void ShowBackupHistoryDialog(int index) {
            Cursor = Cursors.WaitCursor;
            BackupHistoryDialog dialog = new BackupHistoryDialog(selectedDrive, index);
            dialog.ShowDialog();
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Abrir o diálogo para definir o modo de busca por atualizações de arquivos.
        /// </summary>
        private void ShowSearchUpdatesModeDialog() {
            Cursor = Cursors.WaitCursor;
            SearchUpdatesDialog dialog = new SearchUpdatesDialog();
            dialog.ShowDialog();
            Cursor = Cursors.Default;
        }


        private void ShowActionAfterBackupDialog() {
            Cursor = Cursors.WaitCursor;
            ActionAfterBackupDialog dialog = new ActionAfterBackupDialog(actionAfterBackupCode);
            dialog.ShowDialog();
            actionAfterBackupCode = dialog.ActionCode;
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Abrir o diálogo para seleção de um drive interno do sistema. Este
        /// será definido para a restauração do backup.
        /// </summary>
        private void ShowSelectDriveDialog() {
            Cursor = Cursors.WaitCursor;
            SelectDriveDialog dialog = new SelectDriveDialog(selectedDrive);
            dialog.ShowDialog();
            List<Drive.Drive> targetDrivesList = dialog.SelectedDrivesList;
            if (targetDrivesList.Count > 0) {
                StringBuilder sb = new StringBuilder();
                sb.Append(targetDrivesList[0].Letter);
                for (int i = 1; i < targetDrivesList.Count; i++) {
                    sb.Append("\n");
                    sb.Append(targetDrivesList[i].Letter);
                }
                DialogResult dr = MessageBox.Show(
                    this,
                    "Restaurar os arquivos no(s) drive(s):\n\n" + sb.ToString(),
                    "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (dr == DialogResult.Yes) {
                    DoRestore(targetDrivesList);
                }
            }
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Abrir o diálogo Sobre o programa.
        /// </summary>
        private void ShowAboutDialog() {
            Cursor = Cursors.WaitCursor;
            AboutDialog dialog = new AboutDialog();
            dialog.ShowDialog();
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Abrir o manual do programa.
        /// </summary>
        private void OpenHelpFile() {
            Cursor = Cursors.WaitCursor;
            WindowsSystem.OpenFileWithDefaultProgram(@"Manual\Index.html");
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Abrir o arquivo selecionado na lista com o programa padrão definido.
        /// </summary>
        private void OpenSelectedFile() {
            Cursor = Cursors.WaitCursor;
            int index = ltvFiles.SelectedIndices[0];
            string path = ltvFiles.Items[index].Text;
            WindowsSystem.OpenFileWithDefaultProgram(path);
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Abrir o diretório de um arquivo e selecionar o mesmo neste diretório.
        /// </summary>
        private void OpenSelectedFileFolder() {
            Cursor = Cursors.WaitCursor;
            int index = ltvFiles.SelectedIndices[0];
            string path = ltvFiles.Items[index].Text;
            WindowsSystem.OpenFileFolder(path);
            Cursor = Cursors.Default;
        }


        #endregion




        #region Selected Backup Drive actions


        /// <summary>
        /// Abrir uma Unidade de Backup após selecionada pelo usuário. Para abrir,
        /// é necessário obter o bloqueio da mesma. Para obter o bloqueio, nenhuma
        /// outra instância do programa deve tê-lo obtido antes.
        /// </summary>
        /// <param name="drive">Drive selecionado pelo usuário.</param>
        private void OpenBackupDrive(Drive.Drive drive) {
            Cursor = Cursors.WaitCursor;
            try {
                selectedDrive = drive;
                if (selectedDrive.Lock()) {
                    UpdateDriveSelectionStatus();
                    UpdateRecentFilesList();
                    rbbRunBackup.Enabled = false;
                    rbpBackup.ButtonMoreEnabled = false;
                    //FindUpdates();
                } else {
                    MessageBox.Show(
                        this,
                        "A Unidade de Backup está selecionada em outra instância do programa.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            } catch (Exception ex ) {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Fechar a Unidade de Backup.
        /// </summary>
        private void CloseBackupDrive() {
            try {
                if (selectedDrive != null) {
                    selectedDrive.Unlock();
                }
            } catch (Exception ex) {
            }
            selectedDrive = null;
            System.GC.Collect();
            ltvFiles.Items.Clear();
            ribbon.OrbDropDown.RecentItems.Clear();
            UpdateDriveSelectionStatus();
        }


        /// <summary>
        /// Iniciar o processo de busca por atulizações de arquivos no sistema
        /// local.
        /// </summary>
        private void FindUpdates() {
            processingBackup = true;
            proccessAborted = false;
            lblProccessStatus.Visible = true;
            lblNumFiles.Text = "    PROCESSANDO: ";
            pgbFiles.Value = 0;
            UpdateProcessingBackupStatus(true);
            selectedDrive.SearchBackupUpdatesAsynk(
                Settings.Default.SearchUpdatesMode,
                this
            );
        }


        /// <summary>
        /// Iniciar o processo de backup.
        /// </summary>
        private void DoBackup() {
            processingBackup = true;
            proccessAborted = false;
            UpdateProcessingBackupStatus(true);
            selectedDrive.PerformBackupAsynk(this);
        }


        /// <summary>
        /// Iniciar o processo de restore.
        /// </summary>
        /// <param name="targetDrivesList">Drive local para restauração dos arquivos.</param>
        private void DoRestore(List<Drive.Drive> targetDrivesList) {
            processingBackup = true;
            proccessAborted = false;
            lblProccessStatus.Visible = true;
            UpdateProcessingBackupStatus(true);
            selectedDrive.PerformRestoreAsynk(targetDrivesList, this);
        }


        /// <summary>
        /// Cancelar o processo em execução.
        /// </summary>
        private void CancelProccess() {
            if (selectedDrive != null) {
                tslStatus.Text = "    CANCELANDO O PROCESSO: ";
                rbbCancelProccess.Enabled = false;
                lblProccessStatus.Visible = false;
                selectedDrive.AbortProcess();
                pgbFiles.Visible = false;
            }
        }


        private void ActionAfterBackup() {
            switch (actionAfterBackupCode) {
                case 2: new PowerOffTimeDialog(300).ShowDialog() ; break;
            }
        }


        #endregion




        #region Search updates event handlers


        void ISearchBackupUpdatesListener.SearchInitialized(int totalFiles) {
            Invoke((MethodInvoker) delegate () {
                lblProccessStatus.Visible = false;
                pgbFiles.Visible = true;
                pgbFiles.Maximum = totalFiles;
                pgbFiles.Minimum = 0;
            });
        }


        void ISearchBackupUpdatesListener.ProcessingFile(int fileIndex, string file) {
            Invoke((MethodInvoker) delegate () {
                pgbFiles.Value = fileIndex;
            });
        }


        void ISearchBackupUpdatesListener.SearchFinished(LinkedList<FileInfo> createdFilesList,
        LinkedList<FileInfo> deletedFilesList, LinkedList<FileInfo> updatedFilesList, LinkedList<String> errorFilesList) {
            Invoke((MethodInvoker) delegate () {
                try {
                    pgbFiles.Visible = false;
                    ltvFiles.Groups[0].Header = "Arquivos novos";
                    ltvFiles.Items.Clear();
                    ListViewItem[] listViewItems = new ListViewItem[createdFilesList.Count +
                    deletedFilesList.Count + updatedFilesList.Count];
                    int index = 0;
                    foreach (FileInfo fileInfo in createdFilesList) {
                        Dictionary<string, object> info = GetExtensionInfo(fileInfo);
                        int iconIndex = (int)info["icon_index"];
                        string description = (string)info["description"];
                        ListViewItem item = new ListViewItem(
                            new string[] {
                                fileInfo.FullName,
                                fileInfo.CreationTime.ToString(),
                                fileInfo.LastWriteTime.ToString(),
                                Formatter.FormatSize(fileInfo.Length),
                                description
                            },
                            iconIndex
                        );
                        item.Group = ltvFiles.Groups[0];
                        listViewItems[index] = item;
                        index++;
                    }
                    foreach (FileInfo fileInfo in deletedFilesList) {
                        Dictionary<string, object> info = GetExtensionInfo(fileInfo);
                        int iconIndex = (int)info["icon_index"];
                        string description = (string)info["description"];
                        ListViewItem item = new ListViewItem(
                            new string[] {
                                fileInfo.FullName,
                                fileInfo.CreationTime.ToString(),
                                fileInfo.LastWriteTime.ToString(),
                                Formatter.FormatSize(fileInfo.Length),
                                description
                            },
                            iconIndex
                        );
                        item.ForeColor = Color.Red;
                        item.Group = ltvFiles.Groups[1];
                        listViewItems[index] = item;
                        index++;
                    }
                    foreach (FileInfo fileInfo in updatedFilesList) {
                        Dictionary<string, object> info = GetExtensionInfo(fileInfo);
                        int iconIndex = (int)info["icon_index"];
                        string description = (string)info["description"];
                        ListViewItem item = new ListViewItem(
                            new string[] {
                                fileInfo.FullName,
                                fileInfo.CreationTime.ToString(),
                                fileInfo.LastWriteTime.ToString(),
                                Formatter.FormatSize(fileInfo.Length),
                                description
                            },
                            iconIndex
                        );
                        item.ForeColor = Color.Green;
                        item.Group = ltvFiles.Groups[2];
                        listViewItems[index] = item;
                        index++;
                    }
                    ltvFiles.Items.AddRange(listViewItems);
                    rbbRunBackup.Enabled = (listViewItems.Length > 0);
                    rbpBackup.ButtonMoreEnabled = (listViewItems.Length > 0);
                    if (ltvFiles.Items.Count > 0) {
                        contextMenuStrip.Enabled = true;
                    } else {
                        contextMenuStrip.Enabled = false;
                    }
                } catch (Exception ex) {
                    MessageBox.Show(
                        this,
                        ex.Message,
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                } finally {
                    UpdateProcessingBackupStatus(false);
                    UpdateStatusBarData();
                    processingBackup = false;
                    lblProccessStatus.Visible = false;
                }
                if (errorFilesList.Count > 0) {
                    new ErrorLogDialog(errorFilesList).ShowDialog();
                }
            });
        }


        void ISearchBackupUpdatesListener.SearchAbortedByUser() {
            Invoke((MethodInvoker)delegate () {
                UpdateProcessingBackupStatus(false);
                UpdateStatusBarData();
                processingBackup = false;
                if (ltvFiles.Items.Count > 0) {
                    contextMenuStrip.Enabled = true;
                } else {
                    contextMenuStrip.Enabled = false;
                }
            });
        }


        void ISearchBackupUpdatesListener.SearchAbortedByError(Exception ex) {
            Invoke((MethodInvoker)delegate () {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                UpdateProcessingBackupStatus(false);
                UpdateStatusBarData();
                processingBackup = false;
                if (ltvFiles.Items.Count > 0) {
                    contextMenuStrip.Enabled = true;
                } else {
                    contextMenuStrip.Enabled = false;
                }
                lblProccessStatus.Visible = false;
            });
        }


        #endregion




        #region Backup events handlers


        void IBackupListener.BackupInitialized(int numberOfFiles) {
            Invoke((MethodInvoker)delegate () {
                tsslFileName.Visible = true;
                tslStatus.Visible = true;
                tslStatus.Text = "    COPIANDO: ";
                pgbFiles.Visible = true;
                pgbFiles.Minimum = 0;
                pgbFiles.Value = 0;
                pgbFiles.Maximum = numberOfFiles;
            });
        }


        void IBackupListener.ProcessingFile(int fileIndex, string filePath, int mode) {
            Invoke((MethodInvoker)delegate () {
                pgbFiles.Value = fileIndex;
                tsslFileName.Text = "    " + Path.GetFileName(filePath);
            });
        }


        void IBackupListener.BackupAbortedByUser() {
            Invoke((MethodInvoker)delegate () {
                proccessAborted = true;
                tsslFileName.Visible = false;
                if (ltvFiles.Items.Count > 0) {
                    contextMenuStrip.Enabled = true;
                } else {
                    contextMenuStrip.Enabled = false;
                }
            });
        }


        void IBackupListener.BackupAbortedByError(Exception ex) {
            Invoke((MethodInvoker)delegate () {
                pgbFiles.Visible = false;
                tslStatus.Visible = false;
                pgbFiles.Minimum = 0;
                pgbFiles.Maximum = 0;
                rbpCancel.Visible = false;
                tsslFileName.Visible = false;
                UpdateRecentFilesList();
                if (!proccessAborted) {
                    ltvFiles.Items.Clear();
                    UpdateStatusBarData();
                    UpdateProcessingBackupStatus(false);
                } else {
                    UpdateProcessingBackupStatus(false);
                }
                processingBackup = false;
                if (ltvFiles.Items.Count > 0) {
                    contextMenuStrip.Enabled = true;
                } else {
                    contextMenuStrip.Enabled = false;
                }
                ActionAfterBackup();
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            });
        }


        void IBackupListener.BackupDone(LinkedList<String> errorFilesList) {
            Invoke((MethodInvoker)delegate () {
                pgbFiles.Visible = false;
                tslStatus.Visible = false;
                pgbFiles.Minimum = 0;
                pgbFiles.Maximum = 0;
                rbpCancel.Visible = false;
                tsslFileName.Visible = false;
                UpdateRecentFilesList();
                if (!proccessAborted) {
                    ltvFiles.Items.Clear();
                    UpdateStatusBarData();
                    UpdateProcessingBackupStatus(false);
                } else {
                    UpdateProcessingBackupStatus(false);
                }
                processingBackup = false;
                if (errorFilesList.Count > 0) {
                    new ErrorLogDialog(errorFilesList).ShowDialog();
                }
                if (ltvFiles.Items.Count > 0) {
                    contextMenuStrip.Enabled = true;
                } else {
                    contextMenuStrip.Enabled = false;
                }
                ActionAfterBackup();
            });
        }


        #endregion




        #region Restore events handlers


        void IRestoreListener.ListRestoreFiles(LinkedList<FileInfo> restoreFiles) {
            Invoke((MethodInvoker)delegate () {
                try {
                    ltvFiles.Groups[0].Header = "Arquivos de backup";
                    ltvFiles.Items.Clear();
                    ListViewItem[] listViewItems = new ListViewItem[restoreFiles.Count];
                    int index = 0;
                    foreach (FileInfo fileInfo in restoreFiles) {
                        Dictionary<string, object> info = GetExtensionInfo(fileInfo);
                        int iconIndex = (int)info["icon_index"];
                        string description = (string)info["description"];
                        ListViewItem item = new ListViewItem(
                            new string[] {
                                fileInfo.FullName,
                                fileInfo.CreationTime.ToString(),
                                fileInfo.LastWriteTime.ToString(),
                                Formatter.FormatSize(fileInfo.Length),
                                description
                            },
                            iconIndex
                        );
                        item.Group = ltvFiles.Groups[0];
                        listViewItems[index] = item;
                        index++;
                    }
                    ltvFiles.Items.AddRange(listViewItems);
                } catch (Exception ex) {
                    MessageBox.Show(
                        this,
                        ex.Message,
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                } finally {
                    lblProccessStatus.Visible = false;
                }
                UpdateStatusBarData(); 
            });
        }


        void IRestoreListener.RestoreInitialized(int numberOfFiles) {
            Invoke((MethodInvoker)delegate () {
                tsslFileName.Visible = true;
                tslStatus.Visible = true;
                tslStatus.Text = "    RESTAURANDO: ";
                pgbFiles.Visible = true;
                pgbFiles.Minimum = 0;
                pgbFiles.Value = 0;
                pgbFiles.Maximum = numberOfFiles;
            });
        }


        void IRestoreListener.ProcessingFile(int fileIndex, string file) {
            Invoke((MethodInvoker)delegate () {
                pgbFiles.Value = fileIndex;
                tsslFileName.Text = "    " + Path.GetFileName(file);
            });
        }


        void IRestoreListener.RestoreAbortedByUser() {
            Invoke((MethodInvoker)delegate () {
                proccessAborted = true;
                tsslFileName.Visible = false;
            });
        }


        void IRestoreListener.RestoreAbortedByError(Exception ex) {
            Invoke((MethodInvoker)delegate () {
                proccessAborted = true;
                tsslFileName.Visible = false;
                UpdateProcessingBackupStatus(false);
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            });
        }


        void IRestoreListener.RestoreDone(LinkedList<String> errorFilesList) {
            Invoke((MethodInvoker)delegate () {
                pgbFiles.Visible = false;
                tslStatus.Visible = false;
                pgbFiles.Minimum = 0;
                pgbFiles.Maximum = 0;
                rbpCancel.Visible = false;
                tsslFileName.Visible = false;
                if (!proccessAborted) {
                    ltvFiles.Items.Clear();
                    UpdateStatusBarData();
                    UpdateProcessingBackupStatus(false);
                } else {
                    UpdateProcessingBackupStatus(false);
                }
                processingBackup = false;
                if (errorFilesList.Count > 0) {
                    new ErrorLogDialog(errorFilesList).ShowDialog();
                }
                ActionAfterBackup();
            });
        }


        #endregion




        #region USB events handlers.


        void IUsbEventListener.DeviceInserted(object sender, EventArrivedEventArgs e) {
            UpdateDrivesList();
        }


        void IUsbEventListener.DeviceRemoved(object sender, EventArrivedEventArgs e) {
            UpdateDrivesList();
        }


        #endregion




        #region Window settings


        /// <summary>
        /// Salvar as configurações da tela.
        /// </summary>
        private void SaveConfigurations() {
            try {
                Properties.Settings settings = Properties.Settings.Default;
                settings.MainWindow_ListView_Column_1_Width = ltvFiles.Columns[0].Width;
                settings.MainWindow_ListView_Column_2_Width = ltvFiles.Columns[1].Width;
                settings.MainWindow_ListView_Column_3_Width = ltvFiles.Columns[2].Width;
                settings.MainWindow_ListView_Column_4_Width = ltvFiles.Columns[3].Width;
                settings.MainWindow_ListView_Column_5_Width = ltvFiles.Columns[4].Width;
                settings.Save();
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
        /// Ler as configurações da tela.
        /// </summary>
        private void ReadConfigurations() {
            try {
                Properties.Settings settings = Properties.Settings.Default;
                ltvFiles.Columns[0].Width = settings.MainWindow_ListView_Column_1_Width;
                ltvFiles.Columns[1].Width = settings.MainWindow_ListView_Column_2_Width;
                ltvFiles.Columns[2].Width = settings.MainWindow_ListView_Column_3_Width;
                ltvFiles.Columns[3].Width = settings.MainWindow_ListView_Column_4_Width;
                ltvFiles.Columns[4].Width = settings.MainWindow_ListView_Column_5_Width;
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


        #endregion




        private void rboExit_Click(object sender, EventArgs e) {
            CloseBackupDrive();
        }


        private void romDirectories_Click(object sender, EventArgs e) {
            ShowDirectoriesDialog();
        }


        private void rbbDirectories_Click(object sender, EventArgs e) {
            ShowDirectoriesDialog();
        }


        private void fecharToolStripMenuItem_Click(object sender, EventArgs e) {
            CloseBackupDrive();
        }


        private void romUninstall_Click(object sender, EventArgs e) {
            ShowUninstallDriveDialog();
        }


        private void romProps_Click(object sender, EventArgs e) {
            ShowDriveInfoDialog();
        }


        private void rbbRunBackup_Click(object sender, EventArgs e) {
            DoBackup();  
        }


        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            UsbMonitor.Instance.RevomeListener(this);
        }


        private void rbpBackup_Click(object sender, EventArgs e) {
            ShowSearchUpdatesModeDialog();
        }


        private void rbpBackup_ButtonMoreClick(object sender, EventArgs e) {
            
        }


        private void MainWindow_Load(object sender, EventArgs e) {
            ReadConfigurations();
        }


        private void MainWindow_FormClosing_1(object sender, FormClosingEventArgs e) {
            if (processingBackup) {
                DialogResult dr =  MessageBox.Show(
                    "Um processo está em andamento. Sair assim mesmo?",
                    "Atenção!",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Error
                );
                if (dr == DialogResult.No) {
                    e.Cancel = true;
                }
            }
            SaveConfigurations();
        }


        private void rbbUpdate_Click(object sender, EventArgs e) {
            FindUpdates();
        }


        private void ltvFiles_DoubleClick(object sender, EventArgs e) {
            OpenSelectedFile();
        }


        private void rbbCancelProccess_Click(object sender, EventArgs e) {
            CancelProccess();
        }


        private void rbbHistory_Click(object sender, EventArgs e) {
            ShowBackupHistoryDialog();
        }


        private void rbbRestore_Click(object sender, EventArgs e) {
            ShowSelectDriveDialog();
        }


        private void rbbAbout_Click(object sender, EventArgs e) {
            ShowAboutDialog();
        }


        private void ribbonButton1_Click(object sender, EventArgs e) {
            OpenHelpFile();
        }


        private void tsmiOpenFile_Click(object sender, EventArgs e) {
            OpenSelectedFile();
        }


        private void tsmiOpenFolder_Click(object sender, EventArgs e) {
            OpenSelectedFileFolder();
        }


        private void rbpUpdate_ButtonMoreClick(object sender, EventArgs e) {
            ShowSearchUpdatesModeDialog();
        }


        private void rbpBackup_ButtonMoreClick_1(object sender, EventArgs e) {
            ShowActionAfterBackupDialog();
        }

 
    }

}
