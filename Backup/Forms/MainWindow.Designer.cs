namespace Backup.Forms {
    partial class MainWindow {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Arquivos novos", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Arquivos excluídos", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Arquivos atualizados", System.Windows.Forms.HorizontalAlignment.Left);
            this.ribbon = new System.Windows.Forms.Ribbon();
            this.romSelectDrive = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.rsUninstall = new System.Windows.Forms.RibbonSeparator();
            this.romUninstall = new System.Windows.Forms.RibbonOrbMenuItem();
            this.rsDirectories = new System.Windows.Forms.RibbonSeparator();
            this.romDirectories = new System.Windows.Forms.RibbonOrbMenuItem();
            this.rsRestore = new System.Windows.Forms.RibbonSeparator();
            this.romProps = new System.Windows.Forms.RibbonOrbMenuItem();
            this.rboClose = new System.Windows.Forms.RibbonOrbOptionButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.rbpBackup = new System.Windows.Forms.RibbonPanel();
            this.rbbRunBackup = new System.Windows.Forms.RibbonButton();
            this.rbpUpdate = new System.Windows.Forms.RibbonPanel();
            this.rbbUpdate = new System.Windows.Forms.RibbonButton();
            this.rbpHistory = new System.Windows.Forms.RibbonPanel();
            this.rbbHistory = new System.Windows.Forms.RibbonButton();
            this.rbpLocal = new System.Windows.Forms.RibbonPanel();
            this.rbbDirectories = new System.Windows.Forms.RibbonButton();
            this.rbpRestore = new System.Windows.Forms.RibbonPanel();
            this.rbbRestore = new System.Windows.Forms.RibbonButton();
            this.rbpCancel = new System.Windows.Forms.RibbonPanel();
            this.rbbCancelProccess = new System.Windows.Forms.RibbonButton();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbbAbout = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonLabel2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel3 = new System.Windows.Forms.RibbonLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblLastBackupDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNumFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgbFiles = new System.Windows.Forms.ToolStripProgressBar();
            this.lblProccessStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.ltvFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.imlFiles = new System.Windows.Forms.ImageList(this.components);
            this.object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f = new System.Windows.Forms.RibbonOrbMenuItem();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ribbon.CaptionBarVisible = false;
            this.ribbon.Cursor = System.Windows.Forms.Cursors.Default;
            this.ribbon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Minimized = false;
            this.ribbon.Name = "ribbon";
            // 
            // 
            // 
            this.ribbon.OrbDropDown.BorderRoundness = 8;
            this.ribbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon.OrbDropDown.MenuItems.Add(this.romSelectDrive);
            this.ribbon.OrbDropDown.MenuItems.Add(this.rsUninstall);
            this.ribbon.OrbDropDown.MenuItems.Add(this.romUninstall);
            this.ribbon.OrbDropDown.MenuItems.Add(this.rsDirectories);
            this.ribbon.OrbDropDown.MenuItems.Add(this.romDirectories);
            this.ribbon.OrbDropDown.MenuItems.Add(this.rsRestore);
            this.ribbon.OrbDropDown.MenuItems.Add(this.romProps);
            this.ribbon.OrbDropDown.Name = "";
            this.ribbon.OrbDropDown.OptionItems.Add(this.rboClose);
            this.ribbon.OrbDropDown.RecentItemsCaption = "Backups Recentes:";
            this.ribbon.OrbDropDown.Size = new System.Drawing.Size(527, 257);
            this.ribbon.OrbDropDown.TabIndex = 0;
            this.ribbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010_Extended;
            this.ribbon.OrbText = "Unidade de Backup";
            // 
            // 
            // 
            this.ribbon.QuickAccessToolbar.DropDownButtonItems.Add(this.ribbonButton2);
            this.ribbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon.Size = new System.Drawing.Size(889, 109);
            this.ribbon.TabIndex = 0;
            this.ribbon.Tabs.Add(this.ribbonTab1);
            this.ribbon.Tabs.Add(this.ribbonTab3);
            this.ribbon.TabSpacing = 3;
            this.ribbon.Text = "ribbon1";
            // 
            // romSelectDrive
            // 
            this.romSelectDrive.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.romSelectDrive.DropDownItems.Add(this.ribbonButton3);
            this.romSelectDrive.Image = global::Backup.Properties.Resources.find_24;
            this.romSelectDrive.LargeImage = global::Backup.Properties.Resources.find_24;
            this.romSelectDrive.Name = "romSelectDrive";
            this.romSelectDrive.SmallImage = global::Backup.Properties.Resources.find_24;
            this.romSelectDrive.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.romSelectDrive.Text = "Selecionar";
            this.romSelectDrive.ToolTip = "";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "C:\\";
            // 
            // rsUninstall
            // 
            this.rsUninstall.Name = "rsUninstall";
            // 
            // romUninstall
            // 
            this.romUninstall.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.romUninstall.Image = global::Backup.Properties.Resources.uninstall_24;
            this.romUninstall.LargeImage = global::Backup.Properties.Resources.uninstall_24;
            this.romUninstall.Name = "romUninstall";
            this.romUninstall.SmallImage = global::Backup.Properties.Resources.uninstall_24;
            this.romUninstall.Text = "Desinstalar";
            this.romUninstall.ToolTip = "";
            this.romUninstall.Click += new System.EventHandler(this.romUninstall_Click);
            // 
            // rsDirectories
            // 
            this.rsDirectories.Name = "rsDirectories";
            // 
            // romDirectories
            // 
            this.romDirectories.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.romDirectories.Image = global::Backup.Properties.Resources.data_24;
            this.romDirectories.LargeImage = global::Backup.Properties.Resources.data_24;
            this.romDirectories.Name = "romDirectories";
            this.romDirectories.SmallImage = global::Backup.Properties.Resources.data_24;
            this.romDirectories.Text = "Diretórios";
            this.romDirectories.ToolTip = "";
            this.romDirectories.Click += new System.EventHandler(this.romDirectories_Click);
            // 
            // rsRestore
            // 
            this.rsRestore.Name = "rsRestore";
            // 
            // romProps
            // 
            this.romProps.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.romProps.Image = global::Backup.Properties.Resources.config_24;
            this.romProps.LargeImage = global::Backup.Properties.Resources.config_24;
            this.romProps.Name = "romProps";
            this.romProps.SmallImage = global::Backup.Properties.Resources.config_24;
            this.romProps.Text = "Propriedades";
            this.romProps.ToolTip = "";
            this.romProps.Click += new System.EventHandler(this.romProps_Click);
            // 
            // rboClose
            // 
            this.rboClose.Image = ((System.Drawing.Image)(resources.GetObject("rboClose.Image")));
            this.rboClose.LargeImage = ((System.Drawing.Image)(resources.GetObject("rboClose.LargeImage")));
            this.rboClose.Name = "rboClose";
            this.rboClose.SmallImage = ((System.Drawing.Image)(resources.GetObject("rboClose.SmallImage")));
            this.rboClose.Text = "Fechar";
            this.rboClose.Click += new System.EventHandler(this.rboExit_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Teste";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.rbpBackup);
            this.ribbonTab1.Panels.Add(this.rbpUpdate);
            this.ribbonTab1.Panels.Add(this.rbpHistory);
            this.ribbonTab1.Panels.Add(this.rbpLocal);
            this.ribbonTab1.Panels.Add(this.rbpRestore);
            this.ribbonTab1.Panels.Add(this.rbpCancel);
            this.ribbonTab1.Text = "Backup";
            this.ribbonTab1.ToolTip = "";
            this.ribbonTab1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ribbonTab1.ToolTipTitle = "Backup";
            // 
            // rbpBackup
            // 
            this.rbpBackup.Items.Add(this.rbbRunBackup);
            this.rbpBackup.Name = "rbpBackup";
            this.rbpBackup.Text = "Backup";
            this.rbpBackup.ButtonMoreClick += new System.EventHandler(this.rbpBackup_ButtonMoreClick_1);
            // 
            // rbbRunBackup
            // 
            this.rbbRunBackup.Image = global::Backup.Properties.Resources.run_backup_32;
            this.rbbRunBackup.LargeImage = global::Backup.Properties.Resources.run_backup_32;
            this.rbbRunBackup.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbRunBackup.Name = "rbbRunBackup";
            this.rbbRunBackup.SmallImage = global::Backup.Properties.Resources.run_backup_32;
            this.rbbRunBackup.ToolTip = "";
            this.rbbRunBackup.Click += new System.EventHandler(this.rbbRunBackup_Click);
            // 
            // rbpUpdate
            // 
            this.rbpUpdate.Items.Add(this.rbbUpdate);
            this.rbpUpdate.Name = "rbpUpdate";
            this.rbpUpdate.Text = "Atualizar  ";
            this.rbpUpdate.ButtonMoreClick += new System.EventHandler(this.rbpUpdate_ButtonMoreClick);
            // 
            // rbbUpdate
            // 
            this.rbbUpdate.Image = global::Backup.Properties.Resources.find_32;
            this.rbbUpdate.LargeImage = global::Backup.Properties.Resources.find_32;
            this.rbbUpdate.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbUpdate.Name = "rbbUpdate";
            this.rbbUpdate.SmallImage = global::Backup.Properties.Resources.find_32;
            this.rbbUpdate.ToolTip = "";
            this.rbbUpdate.Click += new System.EventHandler(this.rbbUpdate_Click);
            // 
            // rbpHistory
            // 
            this.rbpHistory.ButtonMoreVisible = false;
            this.rbpHistory.Items.Add(this.rbbHistory);
            this.rbpHistory.Name = "rbpHistory";
            this.rbpHistory.Text = "Histórico";
            // 
            // rbbHistory
            // 
            this.rbbHistory.Image = ((System.Drawing.Image)(resources.GetObject("rbbHistory.Image")));
            this.rbbHistory.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbbHistory.LargeImage")));
            this.rbbHistory.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbHistory.Name = "rbbHistory";
            this.rbbHistory.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbbHistory.SmallImage")));
            this.rbbHistory.Text = "";
            this.rbbHistory.ToolTip = "";
            this.rbbHistory.Click += new System.EventHandler(this.rbbHistory_Click);
            // 
            // rbpLocal
            // 
            this.rbpLocal.ButtonMoreEnabled = false;
            this.rbpLocal.ButtonMoreVisible = false;
            this.rbpLocal.Items.Add(this.rbbDirectories);
            this.rbpLocal.Name = "rbpLocal";
            this.rbpLocal.Text = "Local";
            // 
            // rbbDirectories
            // 
            this.rbbDirectories.Image = global::Backup.Properties.Resources.storage_32;
            this.rbbDirectories.LargeImage = global::Backup.Properties.Resources.storage_32;
            this.rbbDirectories.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbDirectories.Name = "rbbDirectories";
            this.rbbDirectories.SmallImage = global::Backup.Properties.Resources.storage_32;
            this.rbbDirectories.ToolTip = "";
            this.rbbDirectories.Click += new System.EventHandler(this.rbbDirectories_Click);
            // 
            // rbpRestore
            // 
            this.rbpRestore.ButtonMoreVisible = false;
            this.rbpRestore.Items.Add(this.rbbRestore);
            this.rbpRestore.Name = "rbpRestore";
            this.rbpRestore.Text = "Restaurar";
            // 
            // rbbRestore
            // 
            this.rbbRestore.Image = global::Backup.Properties.Resources.restore_32;
            this.rbbRestore.LargeImage = global::Backup.Properties.Resources.restore_32;
            this.rbbRestore.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbRestore.Name = "rbbRestore";
            this.rbbRestore.SmallImage = global::Backup.Properties.Resources.restore_32;
            this.rbbRestore.Text = "";
            this.rbbRestore.ToolTip = "";
            this.rbbRestore.Click += new System.EventHandler(this.rbbRestore_Click);
            // 
            // rbpCancel
            // 
            this.rbpCancel.ButtonMoreVisible = false;
            this.rbpCancel.Items.Add(this.rbbCancelProccess);
            this.rbpCancel.Name = "rbpCancel";
            this.rbpCancel.Text = "Cancelar";
            // 
            // rbbCancelProccess
            // 
            this.rbbCancelProccess.Image = global::Backup.Properties.Resources.cancel_32;
            this.rbbCancelProccess.LargeImage = global::Backup.Properties.Resources.cancel_32;
            this.rbbCancelProccess.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbCancelProccess.Name = "rbbCancelProccess";
            this.rbbCancelProccess.SmallImage = global::Backup.Properties.Resources.cancel_32;
            this.rbbCancelProccess.ToolTip = "";
            this.rbbCancelProccess.Click += new System.EventHandler(this.rbbCancelProccess_Click);
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Panels.Add(this.ribbonPanel1);
            this.ribbonTab3.Panels.Add(this.ribbonPanel2);
            this.ribbonTab3.Text = "Ajuda";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.rbbAbout);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Sobre";
            // 
            // rbbAbout
            // 
            this.rbbAbout.Image = global::Backup.Properties.Resources.about_32;
            this.rbbAbout.LargeImage = global::Backup.Properties.Resources.about_32;
            this.rbbAbout.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbAbout.Name = "rbbAbout";
            this.rbbAbout.SmallImage = global::Backup.Properties.Resources.about_32;
            this.rbbAbout.Click += new System.EventHandler(this.rbbAbout_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.ribbonButton1);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Text = "Manual";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::Backup.Properties.Resources.help_32;
            this.ribbonButton1.LargeImage = global::Backup.Properties.Resources.help_32;
            this.ribbonButton1.MinimumSize = new System.Drawing.Size(65, 0);
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton1_Click);
            // 
            // ribbonLabel2
            // 
            this.ribbonLabel2.Name = "ribbonLabel2";
            this.ribbonLabel2.Text = "Unidade de Backup (F:)";
            // 
            // ribbonLabel3
            // 
            this.ribbonLabel3.Name = "ribbonLabel3";
            this.ribbonLabel3.Text = "Drive do Windows (F:)";
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLastBackupDate,
            this.lblNumFiles,
            this.tslStatus,
            this.pgbFiles,
            this.lblProccessStatus,
            this.tsslFileName});
            this.statusStrip.Location = new System.Drawing.Point(0, 544);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(889, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblLastBackupDate
            // 
            this.lblLastBackupDate.Name = "lblLastBackupDate";
            this.lblLastBackupDate.Size = new System.Drawing.Size(101, 17);
            this.lblLastBackupDate.Text = "[last backup data]";
            // 
            // lblNumFiles
            // 
            this.lblNumFiles.Name = "lblNumFiles";
            this.lblNumFiles.Size = new System.Drawing.Size(67, 17);
            this.lblNumFiles.Text = "[num. files]";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(46, 17);
            this.tslStatus.Text = "[status]";
            // 
            // pgbFiles
            // 
            this.pgbFiles.Name = "pgbFiles";
            this.pgbFiles.Size = new System.Drawing.Size(250, 16);
            this.pgbFiles.Step = 1;
            // 
            // lblProccessStatus
            // 
            this.lblProccessStatus.Image = global::Backup.Properties.Resources.load_gif_16;
            this.lblProccessStatus.Name = "lblProccessStatus";
            this.lblProccessStatus.Size = new System.Drawing.Size(16, 17);
            // 
            // tsslFileName
            // 
            this.tsslFileName.AutoToolTip = true;
            this.tsslFileName.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.tsslFileName.Name = "tsslFileName";
            this.tsslFileName.Size = new System.Drawing.Size(74, 17);
            this.tsslFileName.Text = "tsslFileName";
            // 
            // ltvFiles
            // 
            this.ltvFiles.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.ltvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltvFiles.AutoArrange = false;
            this.ltvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.ltvFiles.ContextMenuStrip = this.contextMenuStrip;
            this.ltvFiles.FullRowSelect = true;
            listViewGroup1.Header = "Arquivos novos";
            listViewGroup1.Name = "lvgCreateFiles";
            listViewGroup2.Header = "Arquivos excluídos";
            listViewGroup2.Name = "lvgDeletedFiles";
            listViewGroup3.Header = "Arquivos atualizados";
            listViewGroup3.Name = "lvgUpdatedFiles";
            this.ltvFiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.ltvFiles.HideSelection = false;
            this.ltvFiles.LargeImageList = this.imlFiles;
            this.ltvFiles.Location = new System.Drawing.Point(0, 106);
            this.ltvFiles.MultiSelect = false;
            this.ltvFiles.Name = "ltvFiles";
            this.ltvFiles.Size = new System.Drawing.Size(889, 435);
            this.ltvFiles.SmallImageList = this.imlFiles;
            this.ltvFiles.TabIndex = 2;
            this.ltvFiles.UseCompatibleStateImageBehavior = false;
            this.ltvFiles.View = System.Windows.Forms.View.Details;
            this.ltvFiles.DoubleClick += new System.EventHandler(this.ltvFiles_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Arquivo";
            this.columnHeader1.Width = 608;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data da criação";
            this.columnHeader2.Width = 159;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data da alteração";
            this.columnHeader3.Width = 134;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tamanho";
            this.columnHeader4.Width = 118;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tipo de arquivo";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenFile,
            this.toolStripSeparator1,
            this.tsmiOpenFolder});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(220, 82);
            // 
            // tsmiOpenFile
            // 
            this.tsmiOpenFile.AutoSize = false;
            this.tsmiOpenFile.Image = global::Backup.Properties.Resources.file_32;
            this.tsmiOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiOpenFile.Name = "tsmiOpenFile";
            this.tsmiOpenFile.Size = new System.Drawing.Size(203, 34);
            this.tsmiOpenFile.Text = "Abrir o Arquivo";
            this.tsmiOpenFile.Click += new System.EventHandler(this.tsmiOpenFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // tsmiOpenFolder
            // 
            this.tsmiOpenFolder.Image = global::Backup.Properties.Resources.folder32;
            this.tsmiOpenFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiOpenFolder.Name = "tsmiOpenFolder";
            this.tsmiOpenFolder.Size = new System.Drawing.Size(219, 38);
            this.tsmiOpenFolder.Text = "Abrir o Local do Arquivo";
            this.tsmiOpenFolder.Click += new System.EventHandler(this.tsmiOpenFolder_Click);
            // 
            // imlFiles
            // 
            this.imlFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlFiles.ImageStream")));
            this.imlFiles.TransparentColor = System.Drawing.Color.Transparent;
            this.imlFiles.Images.SetKeyName(0, "drive_20.png");
            // 
            // object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f
            // 
            this.object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f.Image = global::Backup.Properties.Resources.find_24;
            this.object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f.LargeImage = global::Backup.Properties.Resources.find_24;
            this.object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f.Name = "object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f";
            this.object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f.SmallImage = global::Backup.Properties.Resources.find_24;
            this.object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f.Text = "Selecionar";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 566);
            this.Controls.Add(this.ltvFiles);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ribbon);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BACKUP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing_1);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonPanel rbpBackup;
        private System.Windows.Forms.RibbonOrbOptionButton rboClose;
        private System.Windows.Forms.RibbonButton rbbRunBackup;
        private System.Windows.Forms.RibbonPanel rbpHistory;
        private System.Windows.Forms.RibbonButton rbbHistory;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonSeparator rsUninstall;
        private System.Windows.Forms.RibbonOrbMenuItem romUninstall;
        private System.Windows.Forms.RibbonOrbMenuItem romProps;
        private System.Windows.Forms.RibbonPanel rbpUpdate;
        private System.Windows.Forms.RibbonButton rbbUpdate;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem4;
        private System.Windows.Forms.RibbonLabel ribbonLabel2;
        private System.Windows.Forms.RibbonLabel ribbonLabel3;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem6;
        private System.Windows.Forms.RibbonOrbMenuItem romSelectDrive;
        private System.Windows.Forms.RibbonOrbMenuItem object_9dd98f0d_2cd2_4aab_8a57_52c170958b7f;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonSeparator rsDirectories;
        private System.Windows.Forms.RibbonOrbMenuItem romDirectories;
        private System.Windows.Forms.RibbonSeparator rsRestore;
        private System.Windows.Forms.RibbonPanel rbpLocal;
        private System.Windows.Forms.RibbonButton rbbDirectories;
        private System.Windows.Forms.RibbonPanel rbpRestore;
        private System.Windows.Forms.RibbonButton rbbRestore;
        private System.Windows.Forms.ListView ltvFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.ImageList imlFiles;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripStatusLabel lblLastBackupDate;
        private System.Windows.Forms.ToolStripStatusLabel lblNumFiles;
        private System.Windows.Forms.RibbonPanel rbpCancel;
        private System.Windows.Forms.RibbonButton rbbCancelProccess;
        private System.Windows.Forms.RibbonPanel rbpVisualStyle;
        private System.Windows.Forms.ToolStripProgressBar pgbFiles;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.ToolStripStatusLabel lblProccessStatus;
        private System.Windows.Forms.RibbonButton rbbAbout;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFolder;
        private System.Windows.Forms.ToolStripStatusLabel tsslFileName;
        private System.Windows.Forms.RibbonOrbOptionButton rboEject;
    }
}

