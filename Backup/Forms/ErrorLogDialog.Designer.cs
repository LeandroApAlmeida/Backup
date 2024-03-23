namespace Backup.Forms {
    partial class ErrorLogDialog {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorLogDialog));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslNumberOfFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.ltvFiles = new System.Windows.Forms.ListView();
            this.clhFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhErrorMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOpenFileFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslNumberOfFiles});
            this.statusStrip1.Location = new System.Drawing.Point(0, 572);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(979, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslNumberOfFiles
            // 
            this.tsslNumberOfFiles.Name = "tsslNumberOfFiles";
            this.tsslNumberOfFiles.Size = new System.Drawing.Size(36, 17);
            this.tsslNumberOfFiles.Text = "[files]";
            // 
            // ltvFiles
            // 
            this.ltvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhFile,
            this.clhErrorMessage});
            this.ltvFiles.ContextMenuStrip = this.contextMenuStrip;
            this.ltvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltvFiles.FullRowSelect = true;
            this.ltvFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ltvFiles.HideSelection = false;
            this.ltvFiles.LabelWrap = false;
            this.ltvFiles.LargeImageList = this.imageList1;
            this.ltvFiles.Location = new System.Drawing.Point(0, 0);
            this.ltvFiles.MultiSelect = false;
            this.ltvFiles.Name = "ltvFiles";
            this.ltvFiles.Size = new System.Drawing.Size(979, 572);
            this.ltvFiles.SmallImageList = this.imageList1;
            this.ltvFiles.TabIndex = 2;
            this.ltvFiles.UseCompatibleStateImageBehavior = false;
            this.ltvFiles.View = System.Windows.Forms.View.Details;
            this.ltvFiles.DoubleClick += new System.EventHandler(this.ltvFiles_DoubleClick);
            // 
            // clhFile
            // 
            this.clhFile.Text = "Arquivo";
            this.clhFile.Width = 720;
            // 
            // clhErrorMessage
            // 
            this.clhErrorMessage.Text = "Erro";
            this.clhErrorMessage.Width = 331;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenFile,
            this.toolStripMenuItem1,
            this.tsmiOpenFileFolder});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(220, 86);
            // 
            // tsmiOpenFile
            // 
            this.tsmiOpenFile.Image = global::Backup.Properties.Resources.file_32;
            this.tsmiOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiOpenFile.Name = "tsmiOpenFile";
            this.tsmiOpenFile.Size = new System.Drawing.Size(219, 38);
            this.tsmiOpenFile.Text = "Abrir o Arquivo";
            this.tsmiOpenFile.Click += new System.EventHandler(this.tsmiOpenFile_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(216, 6);
            // 
            // tsmiOpenFileFolder
            // 
            this.tsmiOpenFileFolder.Image = global::Backup.Properties.Resources.folder32;
            this.tsmiOpenFileFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiOpenFileFolder.Name = "tsmiOpenFileFolder";
            this.tsmiOpenFileFolder.Size = new System.Drawing.Size(219, 38);
            this.tsmiOpenFileFolder.Text = "Abrir o Local do Arquivo";
            this.tsmiOpenFileFolder.Click += new System.EventHandler(this.tsmiOpenFileFolder_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "file_error.png");
            // 
            // ErrorLogDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 594);
            this.Controls.Add(this.ltvFiles);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ErrorLogDialog";
            this.Text = "ARQUIVOS COM ERRO:";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ErrorLogDialog_FormClosing);
            this.Load += new System.EventHandler(this.ErrorLogDialog_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslNumberOfFiles;
        private System.Windows.Forms.ListView ltvFiles;
        private System.Windows.Forms.ColumnHeader clhFile;
        private System.Windows.Forms.ColumnHeader clhErrorMessage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenFileFolder;
    }
}