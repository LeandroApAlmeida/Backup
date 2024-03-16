using Backup.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Backup {

    internal static class Program {

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

    }

}
