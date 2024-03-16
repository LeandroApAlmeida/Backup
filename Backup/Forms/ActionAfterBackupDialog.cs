using System;
using System.Windows.Forms;

namespace Backup.Forms {

    public partial class ActionAfterBackupDialog : Form {


        private int actionCode;


        public ActionAfterBackupDialog(int actionCode) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            this.actionCode = actionCode;
            switch (actionCode) {
                case 1: rbNone.Checked = true; break;
                case 2: rbShutdown.Checked = true; break;
            }
        }


        public int ActionCode {
            get {
                return actionCode;
            }
        }


        private void btnOk_Click(object sender, EventArgs e) {
            if (rbNone.Checked) {
                actionCode = 1;
            } else {
                actionCode = 2;
            }
            Close();
        }


    }

}
