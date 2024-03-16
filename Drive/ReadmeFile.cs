using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Backup.Drive {

    /// <summary>
    /// Arquivo Leia-me com as informações sobre a Unidade de Backup.
    /// </summary>
    public class ReadmeFile: InstallationFile {


        public ReadmeFile(string path): base(path) {
        }


        /// <summary>
        /// Gravar o arquivo.
        /// </summary>
        /// <param name="backupDirs">Lista de diretórios para backup.</param>
        public void Write(LinkedList<string> backupDirs) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Diretórios sob supervisão neste dispositivo de backup:");
            sb.Append("\n");
            foreach (string backupDir in backupDirs) {
                sb.Append("\n");
                sb.Append(">");
                sb.Append(path.Substring(3, path.Length - 3));
            }
            sb.Append("\n\n");
            sb.Append("Não copie quaisquer arquivos para estes diretórios");
            sb.Append("\n");
            sb.Append("pois estes serão removidos da próxima vez que você");
            sb.Append("\n");
            sb.Append("realizar o backup.");
            using (StreamWriter sw = new StreamWriter(path)) {
                sw.Write(sb.ToString());
            }
        }


    }

}
