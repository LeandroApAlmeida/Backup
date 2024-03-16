using Backup.Drive;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using Backup.Utils;
using System;

namespace Backup.Drive {

    /// <summary>
    /// 
    /// Arquivo XML com os dados de restore da Unidade de Backup. O formato do arquivo
    /// é o seguinte:
    /// 
    /// <example>
    /// <code>
    /// 
    /// <i>
    /// &lt;?xml version="1.0" encoding="utf-8"?&gt;
    /// 
    /// &lt;restore-info&gt;
    /// 
    ///     &lt;source-drive-id&gt;BDI#J3P0P5R0D9V0&lt;/source-drive-id&gt;
    ///     &lt;target-drive-id&gt;D:&lt;/target-drive-id&gt;
    ///     &lt;restore-time&gt;04092023104644&lt;/restore-time&gt;
    ///     
    /// &lt;/restore-info&gt;
    /// </i>
    /// 
    /// </code>
    /// </example>
    /// 
    /// Nodos:
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>restore-info:</u></b> Nodo raiz.
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>source-drive-id:</u></b> Nodo identificador da Unidade de Backup.
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>target-drive-id:</u></b> Nodo identificador do drive de destino.
    /// 
    /// <br><br></br></br>
    /// 
    /// <b><u>restore-time:</u></b> Nodo data do início do restore.
    /// 
    /// </summary>
    public class RestoreFile : InstallationFile {


        public RestoreFile(string path) : base(path) {
        }


        /// <summary>
        /// Gravar o arquivo.
        /// </summary>
        /// <param name="sourceDriveId">Identificar da Unidade de Backup.</param>
        /// <param name="targetDriveId">Identificador do drive de destino</param>
        /// <param name="restoreTime">Data do início do restore.</param>
        public void Write(string sourceDriveId, string targetDriveId, DateTime restoreTime) {
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = false;
            xws.CloseOutput = true;
            xws.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(path, xws)) {
                XElement srcId = new XElement("source-drive-id", sourceDriveId);
                XElement tgtId = new XElement("target-drive-id", targetDriveId);
                XElement time = new XElement("restore-time", Formatter.FormatDate(restoreTime));
                XElement root = new XElement("restore-info", srcId, tgtId, time);
                root.Save(writer);
            }
            SetHidden(true);
        }


        /// <summary>
        /// Ler o arquivo. As chaves do Dictionary são:
        /// <br><br></br></br>
        /// <i><u>source-drive-id:</u></i> Identificador da Unidade de Backup (string).
        /// <br><br></br></br>
        /// <i><u>target-drive-id:</u></i> Identificador do drive de destino (string).
        /// <br><br></br></br>
        /// <i><u>restore-time:</u></i> Data de início do restore (DateTime).
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<string, object> Read() {
            if (Exists()) {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode node = doc.SelectSingleNode("restore-info");
                XmlNodeList srcIdNode = node.SelectNodes("source-drive-id");
                dictionary["source-drive-id"] = srcIdNode.Item(0).InnerText;
                XmlNodeList tgtIdNode = node.SelectNodes("target-drive-id");
                dictionary["target-drive-id"] = tgtIdNode.Item(0).InnerText;
                XmlNodeList timeNode = node.SelectNodes("restore-time");
                dictionary["restore-time"] = Formatter.FormatDate(timeNode.Item(0).InnerText);
                return dictionary;
            } else {
                return null;
            }
        }


    }

}