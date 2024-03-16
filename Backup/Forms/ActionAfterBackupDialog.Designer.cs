namespace Backup.Forms {
    partial class ActionAfterBackupDialog {
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
            this.btnOk = new System.Windows.Forms.Button();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbShutdown = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(340, 102);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(71, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(12, 26);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(98, 17);
            this.rbNone.TabIndex = 1;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "Nenhuma ação";
            this.rbNone.UseVisualStyleBackColor = true;
            // 
            // rbShutdown
            // 
            this.rbShutdown.AutoSize = true;
            this.rbShutdown.Location = new System.Drawing.Point(12, 60);
            this.rbShutdown.Name = "rbShutdown";
            this.rbShutdown.Size = new System.Drawing.Size(131, 17);
            this.rbShutdown.TabIndex = 3;
            this.rbShutdown.TabStop = true;
            this.rbShutdown.Text = "Desligar o computador";
            this.rbShutdown.UseVisualStyleBackColor = true;
            // 
            // ActionAfterBackupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 137);
            this.Controls.Add(this.rbShutdown);
            this.Controls.Add(this.rbNone);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionAfterBackupDialog";
            this.ShowIcon = false;
            this.Text = "AÇÃO APÓS O TÉRMINO DO BACKUP:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbShutdown;
    }
}