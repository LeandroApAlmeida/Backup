using Backup.Drive;
using System.Windows.Forms;
using static Backup.Environment.WindowsSystem;

namespace Backup.Forms {

    /// <summary>
    /// Tela para configurar o modo de detecção de alteração nos arquivos locais
    /// sob controle de backup.
    /// </summary>
    public partial class SearchUpdatesDialog : Form {


        /// <summary>
        /// Constructor da classe.
        /// </summary>
        public SearchUpdatesDialog() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            int mode = Properties.Settings.Default.SearchUpdatesMode;
            switch (mode) {
                case Drive.Drive.LAST_UPDATE_DATE_MODE: rbtDate.Checked = true; break;
                case Drive.Drive.MD5_HASH_MODE: rbtHash.Checked = true; break;
                default: rbtDate.Checked = true; break;
            }
        }


        private void btnOK_Click(object sender, System.EventArgs e) {
            if (rbtDate.Checked) {
                Properties.Settings.Default.SearchUpdatesMode = Drive.Drive.LAST_UPDATE_DATE_MODE;
            } else {
                Properties.Settings.Default.SearchUpdatesMode = Drive.Drive.MD5_HASH_MODE;
            }
            Properties.Settings.Default.Save();
            Close();
        }

    
        private void btnCancel_Click(object sender, System.EventArgs e) {
            Close();
        }


    }

}
