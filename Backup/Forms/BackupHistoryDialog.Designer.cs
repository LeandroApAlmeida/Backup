namespace Backup.Forms {
    partial class BackupHistoryDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Arquivos novos", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Arquivos excluídos", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Arquivos atualizados", System.Windows.Forms.HorizontalAlignment.Left);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbPrevious = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbNumber1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsbNumber2 = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tslDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslBackupTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslNumFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.ltvFiles = new System.Windows.Forms.ListView();
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCreationTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastUpdateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBackupTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFirst,
            this.tsbPrevious,
            this.tsbNext,
            this.tsbLast,
            this.toolStripLabel1,
            this.tsbNumber1,
            this.toolStripLabel2,
            this.tsbNumber2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(945, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbFirst
            // 
            this.tsbFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFirst.Image = global::Backup.Properties.Resources.first_16;
            this.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.Size = new System.Drawing.Size(23, 22);
            this.tsbFirst.Click += new System.EventHandler(this.tsbFirst_Click);
            // 
            // tsbPrevious
            // 
            this.tsbPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrevious.Image = global::Backup.Properties.Resources.previous_16;
            this.tsbPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrevious.Name = "tsbPrevious";
            this.tsbPrevious.Size = new System.Drawing.Size(23, 22);
            this.tsbPrevious.Click += new System.EventHandler(this.tsbPrevious_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNext.Image = global::Backup.Properties.Resources.next_16;
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(23, 22);
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbLast
            // 
            this.tsbLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLast.Image = global::Backup.Properties.Resources.last_16;
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(23, 22);
            this.tsbLast.Click += new System.EventHandler(this.tsbLast_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(10, 22);
            this.toolStripLabel1.Text = " ";
            // 
            // tsbNumber1
            // 
            this.tsbNumber1.AcceptsReturn = true;
            this.tsbNumber1.AcceptsTab = true;
            this.tsbNumber1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsbNumber1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 0);
            this.tsbNumber1.Name = "tsbNumber1";
            this.tsbNumber1.ReadOnly = true;
            this.tsbNumber1.Size = new System.Drawing.Size(50, 23);
            this.tsbNumber1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(21, 22);
            this.toolStripLabel2.Text = "DE";
            // 
            // tsbNumber2
            // 
            this.tsbNumber2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tsbNumber2.Margin = new System.Windows.Forms.Padding(1, 2, 1, 0);
            this.tsbNumber2.Name = "tsbNumber2";
            this.tsbNumber2.ReadOnly = true;
            this.tsbNumber2.Size = new System.Drawing.Size(50, 23);
            this.tsbNumber2.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslDate,
            this.tslBackupTime,
            this.toolStripStatusLabel1,
            this.tslNumFiles});
            this.statusStrip.Location = new System.Drawing.Point(0, 576);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(945, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tslDate
            // 
            this.tslDate.Name = "tslDate";
            this.tslDate.Size = new System.Drawing.Size(106, 17);
            this.tslDate.Text = "DATA DO BACKUP:";
            // 
            // tslBackupTime
            // 
            this.tslBackupTime.Name = "tslBackupTime";
            this.tslBackupTime.Size = new System.Drawing.Size(38, 17);
            this.tslBackupTime.Text = "[date]";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(158, 17);
            this.toolStripStatusLabel1.Text = "      NÚMERO DE ARQUIVOS: ";
            // 
            // tslNumFiles
            // 
            this.tslNumFiles.Name = "tslNumFiles";
            this.tslNumFiles.Size = new System.Drawing.Size(64, 17);
            this.tslNumFiles.Text = "[num files]";
            // 
            // ltvFiles
            // 
            this.ltvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFile,
            this.chCreationTime,
            this.chLastUpdateTime,
            this.chSize,
            this.chBackupTime});
            this.ltvFiles.FullRowSelect = true;
            listViewGroup1.Header = "Arquivos novos";
            listViewGroup1.Name = "lvgCreatedFiles";
            listViewGroup2.Header = "Arquivos excluídos";
            listViewGroup2.Name = "lvgDeletedFiles";
            listViewGroup3.Header = "Arquivos atualizados";
            listViewGroup3.Name = "lvgUpdatedFiles";
            this.ltvFiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.ltvFiles.HideSelection = false;
            this.ltvFiles.Location = new System.Drawing.Point(0, 28);
            this.ltvFiles.Name = "ltvFiles";
            this.ltvFiles.Size = new System.Drawing.Size(945, 545);
            this.ltvFiles.TabIndex = 2;
            this.ltvFiles.UseCompatibleStateImageBehavior = false;
            this.ltvFiles.View = System.Windows.Forms.View.Details;
            // 
            // chFile
            // 
            this.chFile.Text = "Arquivo";
            this.chFile.Width = 459;
            // 
            // chCreationTime
            // 
            this.chCreationTime.Text = "Data de Criação";
            this.chCreationTime.Width = 113;
            // 
            // chLastUpdateTime
            // 
            this.chLastUpdateTime.Text = "Data da Atualização";
            this.chLastUpdateTime.Width = 123;
            // 
            // chSize
            // 
            this.chSize.Text = "Tamanho";
            // 
            // chBackupTime
            // 
            this.chBackupTime.Text = "Data do Backup";
            this.chBackupTime.Width = 100;
            // 
            // BackupHistoryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 598);
            this.Controls.Add(this.ltvFiles);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BackupHistoryDialog";
            this.Text = "HISTÓRICO DOS BACKUPS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackupHistoryDialog_FormClosing);
            this.Load += new System.EventHandler(this.BackupHistoryDialog_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.ToolStripButton tsbPrevious;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsbNumber1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tsbNumber2;
        private System.Windows.Forms.ToolStripStatusLabel tslDate;
        private System.Windows.Forms.ToolStripStatusLabel tslBackupTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tslNumFiles;
        private System.Windows.Forms.ListView ltvFiles;
        private System.Windows.Forms.ColumnHeader chFile;
        private System.Windows.Forms.ColumnHeader chCreationTime;
        private System.Windows.Forms.ColumnHeader chLastUpdateTime;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ColumnHeader chBackupTime;
    }
}