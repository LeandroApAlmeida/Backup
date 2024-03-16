using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using Backup.Utils;

namespace Backup.Drive {

    /// <summary>
    /// 
    /// Arquivo XML com os dados sobre o último backup realizado na Unidade de Backup. O formato
    /// do arquivo é o seguinte:
    /// 
    /// <example>
    /// <code>
    /// 
    /// <i>
    /// &lt;?xml version="1.0" encoding="utf-8"?&gt;
    /// 
    /// &lt;last-backup-data&gt;
    /// 
    ///     &lt;backup-time&gt;04092023104644;/backup-time&gt;
    ///     &lt;partial&gt;True&lt;/partial&gt;
    ///     
    /// &lt;/last-backup-data&gt;
    /// </i>
    /// 
    /// </code>
    /// </example>
    /// 
    /// Nodos:
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>last-backup-data:</u></b> Nodo raiz.
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>backup-time:</u></b> Nodo data e hora do backup.
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>partial:</u></b> Nodo backup parcial.
    /// 
    /// </summary>
    public class LastBackupFile: InstallationFile {


        public LastBackupFile(string path): base(path) {
        }


        /// <summary>
        /// Gravar o arquivo.
        /// </summary>
        /// <param name="dateTime">Data do backup.</param>
        /// <param name="isPartial">Status de backup parcial.</param>
        public void Write(DateTime dateTime, bool isPartial) {
            try {
                SetHidden(false);
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.OmitXmlDeclaration = false;
                xws.CloseOutput = true;
                xws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(path, xws)) {
                    string dateStr = Formatter.FormatDate(dateTime);
                    XElement date = new XElement("backup-time", dateStr);
                    XElement partial = new XElement("partial", isPartial.ToString());
                    XElement root = new XElement("last-backup-data", date, partial);
                    root.Save(writer);
                }
            } finally {
                SetHidden(true);
            }
        }


        /// <summary>
        /// Ler os dados do arquivo. As chaves do Dictionary são:
        /// <br><br></br></br>
        /// <i><u>backup-time:</u></i> Data do último Backup (DateTime).
        /// <br><br></br></br>
        /// <i><u>partial:</u></i> Status de backup parcial (Boolean).
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<string, object> Read() {
            if (Exists()) {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode node = doc.SelectSingleNode("last-backup-data");
                XmlNodeList dateNode = node.SelectNodes("backup-time");
                string dateStr = dateNode.Item(0).InnerText;
                XmlNodeList uidNode = node.SelectNodes("partial");
                bool uid = bool.Parse(uidNode.Item(0).InnerText);
                dictionary["backup-time"] = Formatter.FormatDate(dateStr);
                dictionary["partial"] = uid;
                return dictionary;
            } else {
                return null;
            }
        }


    }
    
}
