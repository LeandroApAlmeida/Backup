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
            this.lbErrorFilesList = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslNumberOfFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbErrorFilesList
            // 
            this.lbErrorFilesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbErrorFilesList.ForeColor = System.Drawing.Color.Red;
            this.lbErrorFilesList.FormattingEnabled = true;
            this.lbErrorFilesList.HorizontalScrollbar = true;
            this.lbErrorFilesList.Location = new System.Drawing.Point(0, 0);
            this.lbErrorFilesList.Name = "lbErrorFilesList";
            this.lbErrorFilesList.Size = new System.Drawing.Size(979, 576);
            this.lbErrorFilesList.TabIndex = 0;
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
            // ErrorLogDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 594);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbErrorFilesList);
            this.Name = "ErrorLogDialog";
            this.Text = "ARQUIVOS COM ERRO:";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbErrorFilesList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslNumberOfFiles;
    }
}