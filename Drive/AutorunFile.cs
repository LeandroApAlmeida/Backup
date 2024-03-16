using System.IO;

namespace Backup.Drive {

    /// <summary>
    /// Arquivo de autorun para configurar o ícone da Unidade de Backup no Windows
    /// Explorer. As instruções são:
    /// 
    /// <br><br></br></br>
    /// 
    /// <example>
    /// <code>
    /// [autorun]
    /// icon=BackupDrive.icon
    /// </code>
    /// </example>
    /// 
    /// </summary>
    public class AutorunFile: InstallationFile {


        public AutorunFile(string path): base(path) {
        }


        /// <summary>
        /// Gravar o arquivo na raiz da Unidade de Backup. 
        /// </summary>
        /// <param name="iconFileName">Nome do arquivo de ícone.</param>
        public void Write(string iconFileName) {
            using (StreamWriter sw = new StreamWriter(path, false)) {
                sw.WriteLine("[autorun]");
                sw.WriteLine("icon=" + iconFileName);
            }
            SetHidden(true);
        }


    }

}
