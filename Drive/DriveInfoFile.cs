using Backup.Utils;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Backup.Drive {

    /// <summary>
    /// 
    /// Arquivo XML com os dados da instalação da Unidade de Backup. O formato do arquivo
    /// é o seguinte:
    /// 
    /// <example>
    /// <code>
    /// 
    /// <i>
    /// &lt;?xml version="1.0" encoding="utf-8"?&gt;
    /// 
    /// &lt;backup-drive-info&gt;
    /// 
    ///     &lt;installation-time&gt;04092023104644&lt;/installation-time&gt;
    ///     &lt;uid&gt;BDI#U3T6C1V2W8X2&lt;/uid&gt;
    ///     
    /// &lt;/backup-drive-info&gt;
    /// </i>
    /// 
    /// </code>
    /// </example>
    /// 
    /// Nodos:
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>backup-drive-info:</u></b> Nodo raiz.
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>installation-time:</u></b> Nodo data da instalação da Unidade de Backup.
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>uid:</u></b> Nodo identificador único da Unidade de Backup.
    /// 
    /// </summary>
    public class DriveInfoFile: InstallationFile {


        public DriveInfoFile(string path): base(path) {
        }


        /// <summary>
        /// Gravar o arquivo.
        /// </summary>
        /// <param name="installationTime">Data da instalação da Unidade de Backup.</param>
        /// <param name="uid">Identificador da Unidade de Backup.</param>
        public void Write(DateTime installationTime, string uid) {
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = false;
            xws.CloseOutput = true;
            xws.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(path, xws)) {
                string dateStr = Formatter.FormatDate(installationTime);
                XElement date = new XElement("installation-time", dateStr);
                XElement id = new XElement("uid", uid);
                XElement root = new XElement("backup-drive-info", date, id);
                root.Save(writer);
            }
            SetHidden(true);
        }


        /// <summary>
        /// Ler o arquivo. As chaves do Dictionary são:
        /// <br><br></br></br>
        /// <i><u>installation-time:</u></i> Data da instalação da Unidade de Backup (DateTime).
        /// <br><br></br></br>
        /// <i><u>uid:</u></i> Identificador da Unidade de Backup (string).
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<string, object> Read() {
            if (Exists()) {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode node = doc.SelectSingleNode("backup-drive-info");
                XmlNodeList dateNode = node.SelectNodes("installation-time");
                string dateStr = dateNode.Item(0).InnerText;
                XmlNodeList uidNode = node.SelectNodes("uid");
                string uid = uidNode.Item(0).InnerText;
                dictionary["installation-time"] = Formatter.FormatDate(dateStr);
                dictionary["uid"] = uid;
                return dictionary;
            } else {
                return null;
            }
        }


    }

}
