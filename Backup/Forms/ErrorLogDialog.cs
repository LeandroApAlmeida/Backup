using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backup.Utils;

namespace Backup.Forms {

    /// <summary>
    /// Diálogo para exibição dos arquivos que apresentaram erro no processamento.
    /// </summary>
    public partial class ErrorLogDialog : Form {


        /// <summary>
        /// Constructor da classe.
        /// </summary>
        /// <param name="errorFilesList">Lista dos arquivos que apresentaram erro no processamento.</param>
        public ErrorLogDialog(LinkedList<String> errorFilesList) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            lbErrorFilesList.Items.AddRange(errorFilesList.ToArray());
            tsslNumberOfFiles.Text = "NÚMERO DE ARQUIVOS: " + Formatter.FormatInt(
                lbErrorFilesList.Items.Count,
                2
            ); 
        }


    }

}