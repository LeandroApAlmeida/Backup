namespace Backup.Forms {
    partial class PowerOffTimeDialog {
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelShutdown = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.bntShutdownNow = new System.Windows.Forms.Button();
            this.timChronometer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seu computador será desligado assim que o cronômetro chegar\r\nà contagem zero.\r\n";
            // 
            // btnCancelShutdown
            // 
            this.btnCancelShutdown.Location = new System.Drawing.Point(12, 163);
            this.btnCancelShutdown.Name = "btnCancelShutdown";
            this.btnCancelShutdown.Size = new System.Drawing.Size(199, 35);
            this.btnCancelShutdown.TabIndex = 2;
            this.btnCancelShutdown.Text = "Não desligar o computador";
            this.btnCancelShutdown.UseVisualStyleBackColor = true;
            this.btnCancelShutdown.Click += new System.EventHandler(this.btnCancelShutdown_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(143, 80);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(145, 55);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "00:00";
            // 
            // bntShutdownNow
            // 
            this.bntShutdownNow.Location = new System.Drawing.Point(217, 163);
            this.bntShutdownNow.Name = "bntShutdownNow";
            this.bntShutdownNow.Size = new System.Drawing.Size(199, 35);
            this.bntShutdownNow.TabIndex = 4;
            this.bntShutdownNow.Text = "Desligar o computador agora";
            this.bntShutdownNow.UseVisualStyleBackColor = true;
            this.bntShutdownNow.Click += new System.EventHandler(this.bntShutdownNow_Click);
            // 
            // timChronometer
            // 
            this.timChronometer.Interval = 1000;
            this.timChronometer.Tick += new System.EventHandler(this.timChronometer_Tick);
            // 
            // PoweroffTimeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 214);
            this.Controls.Add(this.bntShutdownNow);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnCancelShutdown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PoweroffTimeDialog";
            this.Text = "DESLIGAMENTO AUTOMÁTICO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelShutdown;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button bntShutdownNow;
        private System.Windows.Forms.Timer timChronometer;
    }
}