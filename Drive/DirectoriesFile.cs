using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

namespace Backup.Drive {

    /// <summary>
    /// 
    /// Arquivo XML com a lista dos diretórios locais sob controle de backup. O formato do arquivo
    /// é o seguinte:
    /// 
    /// <example>
    /// <code>
    /// 
    /// <i>
    /// &lt;?xml version="1.0" encoding="utf-8"?&gt;
    /// 
    /// &lt;backup-directories&gt;
    /// 
    ///     &lt;directory&gt;C:\Teste1&lt;/directory&gt;
    ///     &lt;directory&gt;C:\Teste2&lt;/directory&gt;
    ///     &lt;directory&gt;C:\Teste3&lt;/directory&gt;
    ///     ...
    ///     ...
    ///     
    /// &lt;/backup-directories&gt;
    /// </i>
    /// 
    /// </code>
    /// </example>
    /// 
    /// Nodos:
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>backup-directories:</u></b> Nodo raiz.
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>directory:</u></b> Nodo diretório local sob controle de backup.
    /// 
    /// </summary>
    public class DirectoriesFile: InstallationFile {


        public DirectoriesFile(string path): base(path) {
        }


        /// <summary>
        /// Gravar o arquivo.
        /// </summary>
        /// <param name="backupDirectories">Diretórios locais sob controle de backup.</param>
        public void Write(LinkedList<string> backupDirectories) {
            try {
                SetHidden(false);
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.OmitXmlDeclaration = false;
                xws.CloseOutput = true;
                xws.Indent = true;
                XElement[] directories = new XElement[backupDirectories.Count];
                for (int i = 0; i < backupDirectories.Count; i++) {
                    directories[i] = new XElement("directory", backupDirectories.ElementAt(i));
                }
                using (XmlWriter writer = XmlWriter.Create(path, xws)) {
                    XElement root = new XElement("backup-directories", directories);
                    root.Save(writer);
                }
            } finally {
                SetHidden(true);
            }
        }


        /// <summary>
        /// Ler o arquivo.
        /// </summary>
        /// <returns>Lista de diretórios locais sob controle de backup.</returns>
        public List<string> Read() {
            List<string> list = new List<string>();
            if (Exists()) {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode node = doc.SelectSingleNode("backup-directories");
                XmlNodeList directoryNode = node.SelectNodes("directory");
                for (int i = 0; i < directoryNode.Count; i++) {
                    list.Add(directoryNode.Item(i).InnerText);
                }
            }
            return list;
        }


    }

}
