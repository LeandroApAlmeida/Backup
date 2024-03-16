namespace Backup.Forms {
    partial class SearchUpdatesDialog {
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
            this.rbtDate = new System.Windows.Forms.RadioButton();
            this.rbtHash = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtDate
            // 
            this.rbtDate.AutoSize = true;
            this.rbtDate.Checked = true;
            this.rbtDate.Location = new System.Drawing.Point(12, 28);
            this.rbtDate.Name = "rbtDate";
            this.rbtDate.Size = new System.Drawing.Size(206, 17);
            this.rbtDate.TabIndex = 1;
            this.rbtDate.TabStop = true;
            this.rbtDate.Text = "Data da última modificação do arquivo";
            this.rbtDate.UseVisualStyleBackColor = true;
            // 
            // rbtHash
            // 
            this.rbtHash.AutoSize = true;
            this.rbtHash.Location = new System.Drawing.Point(12, 61);
            this.rbtHash.Name = "rbtHash";
            this.rbtHash.Size = new System.Drawing.Size(221, 17);
            this.rbtHash.TabIndex = 2;
            this.rbtHash.TabStop = true;
            this.rbtHash.Text = "Comparação do hash dos arquivos (lento)";
            this.rbtHash.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(313, 116);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SearchUpdatesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 151);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rbtHash);
            this.Controls.Add(this.rbtDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchUpdatesDialog";
            this.ShowIcon = false;
            this.Text = "VERIFICAR AS ATUALIZAÇÕES PELA:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbtDate;
        private System.Windows.Forms.RadioButton rbtHash;
        private System.Windows.Forms.Button btnOK;
    }
}