namespace Backup.Forms {
    partial class DriveInfoDialog {
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
            this.lvDriveInfo = new System.Windows.Forms.ListView();
            this.chData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvDriveInfo
            // 
            this.lvDriveInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDriveInfo.AutoArrange = false;
            this.lvDriveInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chData,
            this.chValue});
            this.lvDriveInfo.GridLines = true;
            this.lvDriveInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvDriveInfo.LabelWrap = false;
            this.lvDriveInfo.Location = new System.Drawing.Point(12, 12);
            this.lvDriveInfo.MultiSelect = false;
            this.lvDriveInfo.Name = "lvDriveInfo";
            this.lvDriveInfo.ShowGroups = false;
            this.lvDriveInfo.Size = new System.Drawing.Size(624, 347);
            this.lvDriveInfo.TabIndex = 0;
            this.lvDriveInfo.TileSize = new System.Drawing.Size(168, 30);
            this.lvDriveInfo.UseCompatibleStateImageBehavior = false;
            this.lvDriveInfo.View = System.Windows.Forms.View.Details;
            // 
            // chData
            // 
            this.chData.Text = "";
            this.chData.Width = 177;
            // 
            // chValue
            // 
            this.chValue.Text = "";
            this.chValue.Width = 260;
            // 
            // DriveInfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 371);
            this.Controls.Add(this.lvDriveInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriveInfoDialog";
            this.Text = "[about]";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvDriveInfo;
        private System.Windows.Forms.ColumnHeader chData;
        private System.Windows.Forms.ColumnHeader chValue;
    }
}