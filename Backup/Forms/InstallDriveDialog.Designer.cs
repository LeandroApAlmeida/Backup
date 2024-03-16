namespace Backup.Forms {
    partial class InstallDriveDialog {
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbbDrive = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbLabel = new System.Windows.Forms.TextBox();
            this.cbbFileSystemFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.lblFormatting = new System.Windows.Forms.Label();
            this.rbLocalDrive = new System.Windows.Forms.RadioButton();
            this.rbNetworkDrive = new System.Windows.Forms.RadioButton();
            this.rbNoFormatDrive = new System.Windows.Forms.RadioButton();
            this.rbFormatDrive = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DRIVE:";
            // 
            // cbbDrive
            // 
            this.cbbDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDrive.FormattingEnabled = true;
            this.cbbDrive.Items.AddRange(new object[] {
            "teste1",
            "tests2"});
            this.cbbDrive.Location = new System.Drawing.Point(95, 27);
            this.cbbDrive.Name = "cbbDrive";
            this.cbbDrive.Size = new System.Drawing.Size(220, 21);
            this.cbbDrive.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "RÓTULO:";
            // 
            // txbLabel
            // 
            this.txbLabel.Location = new System.Drawing.Point(95, 98);
            this.txbLabel.Name = "txbLabel";
            this.txbLabel.Size = new System.Drawing.Size(220, 20);
            this.txbLabel.TabIndex = 3;
            // 
            // cbbFileSystemFormat
            // 
            this.cbbFileSystemFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFileSystemFormat.FormattingEnabled = true;
            this.cbbFileSystemFormat.Location = new System.Drawing.Point(95, 63);
            this.cbbFileSystemFormat.Name = "cbbFileSystemFormat";
            this.cbbFileSystemFormat.Size = new System.Drawing.Size(220, 21);
            this.cbbFileSystemFormat.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "FORMATO:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(429, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnInstall.Location = new System.Drawing.Point(313, 228);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(110, 25);
            this.btnInstall.TabIndex = 7;
            this.btnInstall.Text = "Instalar";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // lblFormatting
            // 
            this.lblFormatting.AutoSize = true;
            this.lblFormatting.Location = new System.Drawing.Point(12, 240);
            this.lblFormatting.Name = "lblFormatting";
            this.lblFormatting.Size = new System.Drawing.Size(133, 13);
            this.lblFormatting.TabIndex = 8;
            this.lblFormatting.Text = "Formatando o dispositivo...";
            this.lblFormatting.Visible = false;
            // 
            // rbLocalDrive
            // 
            this.rbLocalDrive.AutoSize = true;
            this.rbLocalDrive.Checked = true;
            this.rbLocalDrive.Location = new System.Drawing.Point(3, 3);
            this.rbLocalDrive.Name = "rbLocalDrive";
            this.rbLocalDrive.Size = new System.Drawing.Size(75, 17);
            this.rbLocalDrive.TabIndex = 9;
            this.rbLocalDrive.TabStop = true;
            this.rbLocalDrive.Text = "Drive local";
            this.rbLocalDrive.UseVisualStyleBackColor = true;
            this.rbLocalDrive.CheckedChanged += new System.EventHandler(this.rbLocalDrive_CheckedChanged);
            // 
            // rbNetworkDrive
            // 
            this.rbNetworkDrive.AutoSize = true;
            this.rbNetworkDrive.Location = new System.Drawing.Point(105, 3);
            this.rbNetworkDrive.Name = "rbNetworkDrive";
            this.rbNetworkDrive.Size = new System.Drawing.Size(94, 17);
            this.rbNetworkDrive.TabIndex = 10;
            this.rbNetworkDrive.Text = "Drive de Rede";
            this.rbNetworkDrive.UseVisualStyleBackColor = true;
            this.rbNetworkDrive.CheckedChanged += new System.EventHandler(this.rbNetworkDrive_CheckedChanged);
            // 
            // rbNoFormatDrive
            // 
            this.rbNoFormatDrive.AutoSize = true;
            this.rbNoFormatDrive.Checked = true;
            this.rbNoFormatDrive.Location = new System.Drawing.Point(3, 3);
            this.rbNoFormatDrive.Name = "rbNoFormatDrive";
            this.rbNoFormatDrive.Size = new System.Drawing.Size(89, 17);
            this.rbNoFormatDrive.TabIndex = 11;
            this.rbNoFormatDrive.TabStop = true;
            this.rbNoFormatDrive.Text = "Não Formatar";
            this.rbNoFormatDrive.UseVisualStyleBackColor = true;
            this.rbNoFormatDrive.CheckedChanged += new System.EventHandler(this.rbFormatDrive_CheckedChanged);
            // 
            // rbFormatDrive
            // 
            this.rbFormatDrive.AutoSize = true;
            this.rbFormatDrive.Location = new System.Drawing.Point(105, 3);
            this.rbFormatDrive.Name = "rbFormatDrive";
            this.rbFormatDrive.Size = new System.Drawing.Size(66, 17);
            this.rbFormatDrive.TabIndex = 12;
            this.rbFormatDrive.Text = "Formatar";
            this.rbFormatDrive.UseVisualStyleBackColor = true;
            this.rbFormatDrive.CheckedChanged += new System.EventHandler(this.rbNoFormatDrive_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbNoFormatDrive);
            this.panel1.Controls.Add(this.rbFormatDrive);
            this.panel1.Location = new System.Drawing.Point(333, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 23);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbLocalDrive);
            this.panel2.Controls.Add(this.rbNetworkDrive);
            this.panel2.Location = new System.Drawing.Point(333, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 23);
            this.panel2.TabIndex = 14;
            // 
            // InstallDriveDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 264);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFormatting);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbFileSystemFormat);
            this.Controls.Add(this.txbLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbDrive);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallDriveDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INSTALAR UNIDADE DE BACKUP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstallDriveDialog_FormClosing);
            this.Load += new System.EventHandler(this.InstallDriveDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbDrive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbLabel;
        private System.Windows.Forms.ComboBox cbbFileSystemFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Label lblFormatting;
        private System.Windows.Forms.RadioButton rbLocalDrive;
        private System.Windows.Forms.RadioButton rbNetworkDrive;
        private System.Windows.Forms.RadioButton rbNoFormatDrive;
        private System.Windows.Forms.RadioButton rbFormatDrive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}