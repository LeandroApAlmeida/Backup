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
            this.rsProps = new System.Windows.Forms.RibbonSeparator();
            this.romMode = new System.Windows.Forms.RibbonOrbMenuItem();
            this.rbtModeBackup = new System.Windows.Forms.RibbonButton();
            this.rbtModeRestore = new System.Windows.Forms.RibbonButton();
            this.rboClose = new System.Windows.Forms.RibbonOrbOptionButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.rbtBackup = new System.Windows.Forms.RibbonTab();
            this.rbpBackup = new System.Windows.Forms.RibbonPanel();
            this.rbbRunBackup = new System.Windows.Forms.RibbonButton();
            this.rbpSearchBackupUpdates = new System.Windows.Forms.RibbonPanel();
            this.rbbSearchBackupUpdates = new System.Windows.Forms.RibbonButton();
            this.rbpBackupHistory = new System.Windows.Forms.RibbonPanel();
            this.rbbBackupHistory = new System.Windows.Forms.RibbonButton();
            this.rbpSourceDirectories = new System.Windows.Forms.RibbonPanel();
            this.rbbSourceDirectories = new System.Windows.Forms.RibbonButton();
            this.rbpCancelBackup = new System.Windows.Forms.RibbonPanel();
            this.rbbCancelBackup = new System.Windows.Forms.RibbonButton();
            this.rbtRestore = new System.Windows.Forms.RibbonTab();
            this.rbpSelectRestoreDrive = new System.Windows.Forms.RibbonPanel();
            this.rbbSelectRestoreDrive = new System.Windows.Forms.RibbonButton();
            this.rbpRunRestore = new System.Windows.Forms.RibbonPanel();
            this.rbbRunRestore = new System.Windows.Forms.RibbonButton();
            this.rbpCancelRestore = new System.Windows.Forms.RibbonPanel();
            this.rbbCancelRestore = new System.Windows.Forms.RibbonButton();
            this.rbtHelp = new System.Windows.Forms.RibbonTab();
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
            this.ribbon.OrbDropDown.MenuItems.Add(this.rsProps);
            this.ribbon.OrbDropDown.MenuItems.Add(this.romMode);
            this.ribbon.OrbDropDown.Name = "";
            this.ribbon.OrbDropDown.OptionItems.Add(this.rboClose);
            this.ribbon.OrbDropDown.RecentItemsCaption = "Backups Recentes:";
            this.ribbon.OrbDropDown.Size = new System.Drawing.Size(527, 304);
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
            this.ribbon.Tabs.Add(this.rbtBackup);
            this.ribbon.Tabs.Add(this.rbtRestore);
            this.ribbon.Tabs.Add(this.rbtHelp);
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
            // rsProps
            // 
            this.rsProps.Name = "rsProps";
            // 
            // romMode
            // 
            this.romMode.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.romMode.DropDownItems.Add(this.rbtModeBackup);
            this.romMode.DropDownItems.Add(this.rbtModeRestore);
            this.romMode.Image = global::Backup.Properties.Resources.view_24;
            this.romMode.LargeImage = global::Backup.Properties.Resources.view_24;
            this.romMode.Name = "romMode";
            this.romMode.SmallImage = global::Backup.Properties.Resources.view_24;
            this.romMode.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.romMode.Text = "Modo";
            // 
            // rbtModeBackup
            // 
            this.rbtModeBackup.CheckedGroup = "";
            this.rbtModeBackup.CheckOnClick = true;
            this.rbtModeBackup.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtModeBackup.Image = ((System.Drawing.Image)(resources.GetObject("rbtModeBackup.Image")));
            this.rbtModeBackup.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtModeBackup.LargeImage")));
            this.rbtModeBackup.Name = "rbtModeBackup";
            this.rbtModeBackup.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtModeBackup.SmallImage")));
            this.rbtModeBackup.Text = "Backup";
            this.rbtModeBackup.Click += new System.EventHandler(this.rbtViewBackup_Click);
            // 
            // rbtModeRestore
            // 
            this.rbtModeRestore.CheckedGroup = "";
            this.rbtModeRestore.CheckOnClick = true;
            this.rbtModeRestore.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.rbtModeRestore.Image = ((System.Drawing.Image)(resources.GetObject("rbtModeRestore.Image")));
            this.rbtModeRestore.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbtModeRestore.LargeImage")));
            this.rbtModeRestore.Name = "rbtModeRestore";
            this.rbtModeRestore.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbtModeRestore.SmallImage")));
            this.rbtModeRestore.Text = "Restore";
            this.rbtModeRestore.Click += new System.EventHandler(this.rbtViewRestore_Click);
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
            // rbtBackup
            // 
            this.rbtBackup.Name = "rbtBackup";
            this.rbtBackup.Panels.Add(this.rbpBackup);
            this.rbtBackup.Panels.Add(this.rbpSearchBackupUpdates);
            this.rbtBackup.Panels.Add(this.rbpBackupHistory);
            this.rbtBackup.Panels.Add(this.rbpSourceDirectories);
            this.rbtBackup.Panels.Add(this.rbpCancelBackup);
            this.rbtBackup.Text = "Backup";
            this.rbtBackup.ToolTip = "";
            this.rbtBackup.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.rbtBackup.ToolTipTitle = "Backup";
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
            // rbpSearchBackupUpdates
            // 
            this.rbpSearchBackupUpdates.Items.Add(this.rbbSearchBackupUpdates);
            this.rbpSearchBackupUpdates.Name = "rbpSearchBackupUpdates";
            this.rbpSearchBackupUpdates.Text = "Atualizar  ";
            this.rbpSearchBackupUpdates.ButtonMoreClick += new System.EventHandler(this.rbpUpdate_ButtonMoreClick);
            // 
            // rbbSearchBackupUpdates
            // 
            this.rbbSearchBackupUpdates.Image = global::Backup.Properties.Resources.find_32;
            this.rbbSearchBackupUpdates.LargeImage = global::Backup.Properties.Resources.find_32;
            this.rbbSearchBackupUpdates.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbSearchBackupUpdates.Name = "rbbSearchBackupUpdates";
            this.rbbSearchBackupUpdates.SmallImage = global::Backup.Properties.Resources.find_32;
            this.rbbSearchBackupUpdates.ToolTip = "";
            this.rbbSearchBackupUpdates.Click += new System.EventHandler(this.rbbUpdate_Click);
            // 
            // rbpBackupHistory
            // 
            this.rbpBackupHistory.ButtonMoreVisible = false;
            this.rbpBackupHistory.Items.Add(this.rbbBackupHistory);
            this.rbpBackupHistory.Name = "rbpBackupHistory";
            this.rbpBackupHistory.Text = "Histórico";
            // 
            // rbbBackupHistory
            // 
            this.rbbBackupHistory.Image = ((System.Drawing.Image)(resources.GetObject("rbbBackupHistory.Image")));
            this.rbbBackupHistory.LargeImage = ((System.Drawing.Image)(resources.GetObject("rbbBackupHistory.LargeImage")));
            this.rbbBackupHistory.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbBackupHistory.Name = "rbbBackupHistory";
            this.rbbBackupHistory.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbbBackupHistory.SmallImage")));
            this.rbbBackupHistory.Text = "";
            this.rbbBackupHistory.ToolTip = "";
            this.rbbBackupHistory.Click += new System.EventHandler(this.rbbHistory_Click);
            // 
            // rbpSourceDirectories
            // 
            this.rbpSourceDirectories.ButtonMoreEnabled = false;
            this.rbpSourceDirectories.ButtonMoreVisible = false;
            this.rbpSourceDirectories.Items.Add(this.rbbSourceDirectories);
            this.rbpSourceDirectories.Name = "rbpSourceDirectories";
            this.rbpSourceDirectories.Text = "Local";
            // 
            // rbbSourceDirectories
            // 
            this.rbbSourceDirectories.Image = global::Backup.Properties.Resources.storage_32;
            this.rbbSourceDirectories.LargeImage = global::Backup.Properties.Resources.storage_32;
            this.rbbSourceDirectories.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbSourceDirectories.Name = "rbbSourceDirectories";
            this.rbbSourceDirectories.SmallImage = global::Backup.Properties.Resources.storage_32;
            this.rbbSourceDirectories.ToolTip = "";
            this.rbbSourceDirectories.Click += new System.EventHandler(this.rbbDirectories_Click);
            // 
            // rbpCancelBackup
            // 
            this.rbpCancelBackup.ButtonMoreVisible = false;
            this.rbpCancelBackup.Items.Add(this.rbbCancelBackup);
            this.rbpCancelBackup.Name = "rbpCancelBackup";
            this.rbpCancelBackup.Text = "Cancelar";
            // 
            // rbbCancelBackup
            // 
            this.rbbCancelBackup.Image = global::Backup.Properties.Resources.cancel_32;
            this.rbbCancelBackup.LargeImage = global::Backup.Properties.Resources.cancel_32;
            this.rbbCancelBackup.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbCancelBackup.Name = "rbbCancelBackup";
            this.rbbCancelBackup.SmallImage = global::Backup.Properties.Resources.cancel_32;
            this.rbbCancelBackup.ToolTip = "";
            this.rbbCancelBackup.Click += new System.EventHandler(this.rbbCancelProccess_Click);
            // 
            // rbtRestore
            // 
            this.rbtRestore.Name = "rbtRestore";
            this.rbtRestore.Panels.Add(this.rbpSelectRestoreDrive);
            this.rbtRestore.Panels.Add(this.rbpRunRestore);
            this.rbtRestore.Panels.Add(this.rbpCancelRestore);
            this.rbtRestore.Text = "Restore";
            // 
            // rbpSelectRestoreDrive
            // 
            this.rbpSelectRestoreDrive.ButtonMoreVisible = false;
            this.rbpSelectRestoreDrive.Items.Add(this.rbbSelectRestoreDrive);
            this.rbpSelectRestoreDrive.Name = "rbpSelectRestoreDrive";
            this.rbpSelectRestoreDrive.Text = "Selecionar";
            // 
            // rbbSelectRestoreDrive
            // 
            this.rbbSelectRestoreDrive.Image = global::Backup.Properties.Resources.drive_32;
            this.rbbSelectRestoreDrive.LargeImage = global::Backup.Properties.Resources.drive_32;
            this.rbbSelectRestoreDrive.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbSelectRestoreDrive.Name = "rbbSelectRestoreDrive";
            this.rbbSelectRestoreDrive.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbbSelectRestoreDrive.SmallImage")));
            this.rbbSelectRestoreDrive.Click += new System.EventHandler(this.ribbonButton4_Click);
            // 
            // rbpRunRestore
            // 
            this.rbpRunRestore.Items.Add(this.rbbRunRestore);
            this.rbpRunRestore.Name = "rbpRunRestore";
            this.rbpRunRestore.Text = "Restaurar";
            this.rbpRunRestore.ButtonMoreClick += new System.EventHandler(this.rbpRunRestore_ButtonMoreClick);
            // 
            // rbbRunRestore
            // 
            this.rbbRunRestore.Image = global::Backup.Properties.Resources.run_backup_32;
            this.rbbRunRestore.LargeImage = global::Backup.Properties.Resources.run_backup_32;
            this.rbbRunRestore.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbRunRestore.Name = "rbbRunRestore";
            this.rbbRunRestore.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbbRunRestore.SmallImage")));
            this.rbbRunRestore.Click += new System.EventHandler(this.rbbRunRestore_Click);
            // 
            // rbpCancelRestore
            // 
            this.rbpCancelRestore.ButtonMoreEnabled = false;
            this.rbpCancelRestore.ButtonMoreVisible = false;
            this.rbpCancelRestore.FlowsTo = System.Windows.Forms.RibbonPanelFlowDirection.Left;
            this.rbpCancelRestore.Items.Add(this.rbbCancelRestore);
            this.rbpCancelRestore.Name = "rbpCancelRestore";
            this.rbpCancelRestore.Text = "Cancelar";
            // 
            // rbbCancelRestore
            // 
            this.rbbCancelRestore.Image = global::Backup.Properties.Resources.cancel_32;
            this.rbbCancelRestore.LargeImage = global::Backup.Properties.Resources.cancel_32;
            this.rbbCancelRestore.MinimumSize = new System.Drawing.Size(65, 0);
            this.rbbCancelRestore.Name = "rbbCancelRestore";
            this.rbbCancelRestore.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbbCancelRestore.SmallImage")));
            // 
            // rbtHelp
            // 
            this.rbtHelp.Name = "rbtHelp";
            this.rbtHelp.Panels.Add(this.ribbonPanel1);
            this.rbtHelp.Panels.Add(this.ribbonPanel2);
            this.rbtHelp.Text = "Ajuda";
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
        private System.Windows.Forms.RibbonPanel rbpBackupHistory;
        private System.Windows.Forms.RibbonButton rbbBackupHistory;
        private System.Windows.Forms.RibbonTab rbtBackup;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonSeparator rsUninstall;
        private System.Windows.Forms.RibbonOrbMenuItem romUninstall;
        private System.Windows.Forms.RibbonOrbMenuItem romProps;
        private System.Windows.Forms.RibbonPanel rbpSearchBackupUpdates;
        private System.Windows.Forms.RibbonButton rbbSearchBackupUpdates;
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
        private System.Windows.Forms.RibbonPanel rbpSourceDirectories;
        private System.Windows.Forms.RibbonButton rbbSourceDirectories;
        private System.Windows.Forms.RibbonPanel rbpRestore;
        private System.Windows.Forms.ListView ltvFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.RibbonTab rbtHelp;
        private System.Windows.Forms.ImageList imlFiles;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripStatusLabel lblLastBackupDate;
        private System.Windows.Forms.ToolStripStatusLabel lblNumFiles;
        private System.Windows.Forms.RibbonPanel rbpCancelBackup;
        private System.Windows.Forms.RibbonButton rbbCancelBackup;
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
        private System.Windows.Forms.RibbonTab rbtRestore;
        private System.Windows.Forms.RibbonPanel rbpSelectRestoreDrive;
        private System.Windows.Forms.RibbonButton rbbSelectRestoreDrive;
        private System.Windows.Forms.RibbonOrbMenuItem romMode;
        private System.Windows.Forms.RibbonButton rbtModeBackup;
        private System.Windows.Forms.RibbonButton rbtModeRestore;
        private System.Windows.Forms.RibbonSeparator rsProps;
        private System.Windows.Forms.RibbonPanel rbpRunRestore;
        private System.Windows.Forms.RibbonButton rbbRunRestore;
        private System.Windows.Forms.RibbonPanel rbpCancelRestore;
        private System.Windows.Forms.RibbonButton rbbCancelRestore;
    }
}

