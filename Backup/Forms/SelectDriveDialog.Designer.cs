namespace Backup.Forms {
    partial class SelectDriveDialog {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDriveDialog));
            this.ltvDrives = new System.Windows.Forms.ListView();
            this.chDriveName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTotalSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFreeSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFsFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ltvDrives
            // 
            this.ltvDrives.CheckBoxes = true;
            this.ltvDrives.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDriveName,
            this.chTotalSpace,
            this.chFreeSpace,
            this.chFsFormat});
            this.ltvDrives.FullRowSelect = true;
            this.ltvDrives.HideSelection = false;
            this.ltvDrives.LargeImageList = this.imageList;
            this.ltvDrives.Location = new System.Drawing.Point(5, 5);
            this.ltvDrives.MultiSelect = false;
            this.ltvDrives.Name = "ltvDrives";
            this.ltvDrives.Size = new System.Drawing.Size(632, 296);
            this.ltvDrives.SmallImageList = this.imageList;
            this.ltvDrives.TabIndex = 0;
            this.ltvDrives.UseCompatibleStateImageBehavior = false;
            this.ltvDrives.View = System.Windows.Forms.View.Details;
            // 
            // chDriveName
            // 
            this.chDriveName.Text = "Drive";
            this.chDriveName.Width = 295;
            // 
            // chTotalSpace
            // 
            this.chTotalSpace.Text = "Espaço Total";
            this.chTotalSpace.Width = 88;
            // 
            // chFreeSpace
            // 
            this.chFreeSpace.Text = "Espaço Livre";
            this.chFreeSpace.Width = 92;
            // 
            // chFsFormat
            // 
            this.chFsFormat.Text = "Formato";
            this.chFsFormat.Width = 78;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "hard_disk_32.png");
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(520, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(404, 308);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(110, 25);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Restaurar";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // SelectDriveDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 343);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ltvDrives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectDriveDialog";
            this.Text = "SELECIONAR O(S) DRIVE(S) DE DESTINO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ltvDrives;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ColumnHeader chDriveName;
        private System.Windows.Forms.ColumnHeader chTotalSpace;
        private System.Windows.Forms.ColumnHeader chFreeSpace;
        private System.Windows.Forms.ColumnHeader chFsFormat;
        private System.Windows.Forms.ImageList imageList;
    }
}