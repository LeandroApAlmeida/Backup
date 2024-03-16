using Backup.Utils;
using System;
using System.Collections.Generic;

namespace Backup.Drive {

    /// <summary>
    /// Um arquivo de Log de backup é um arquivo texto UTF-8, com o seguinte formato:
    /// 
    /// <example>
    /// <code>
    /// Backup Time: [Backup Time]
    /// Is Partial: [True/False]
    /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
    /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
    /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
    /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
    /// ...
    /// ...
    /// </code>
    /// </example>
    /// 
    /// Onde:
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>Backup Time: [Backup Time]</u></i>: Data do backup.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>Is Partial: [True/False]</u></i>: Status de backup parcial. True, o backup
    /// foi parcial. False, o backup foi completo.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]</u></i>:
    /// Registro de backup de um arquivo.
    /// 
    /// <br><br></br></br>
    /// 
    /// Onde:
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[M]</u></i>: Modo de operação de backup. Sendo:
    /// 
    /// <br><br></br></br>
    /// 
    /// 1- Arquivo criado 
    /// <br></br>
    /// 2- Arquivo excluído
    /// <br></br>
    /// 3- Arquivo modificado
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>$</u></i>: Caracter ASCII número 1, não imprimível.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Source Path]</u></i>: Path do arquivo de origem.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Target Path]</u></i>: Path do arquivo de destino.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Creation Time]</u></i>: Data da criação do arquivo.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Modif. Time]</u></i>: Data da modificação do arquivo.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Size]</u></i>: Tamanho do arquivo.
    /// 
    /// <br><br></br></br>
    /// 
    /// <i><u>[Backup Time]</u></i>: Data do backup do arquivo.
    /// 
    /// <br><br></br></br>
    /// 
    /// A função desta classe é extrair as informações sobre o backup realizado
    /// com base nas instruções codificadas neste arquivo de acordo com os 
    /// campos relacionados.
    /// </summary>
    public class LogParser {


        // Arquivos processados no backup.
        private readonly List<FileMetadata> filesMetadataList;

        // Data do backup.
        private readonly DateTime backupTime;

        // Status de backup parcial.
        private readonly bool partialBackup;


        /// <summary>
        /// Constructor da classe. Fará a tradução do log de backup.
        /// </summary>
        /// <param name="logFileText">Texto codificado.</param>
        public LogParser(string logFileText) {
            filesMetadataList = new List<FileMetadata>();
            string[] lines = logFileText.Replace("\r", "").Split(new char[] {'\n'});  
            backupTime = Formatter.FormatDate(lines[0].Substring(13, lines[0].Length - 13));
            partialBackup = bool.Parse(lines[1].Substring(12, lines[1].Length - 12));
            for (int i = 2; i < lines.Length; i++) {
                string line = lines[i];
                if (line != null && line.Length > 0) {
                    string[] fields = line.Split(new char[] { '\u0001' });
                    int operation = int.Parse(fields[0]);
                    string targetFile = fields[1];
                    string sourceFile = fields[2];
                    DateTime creationTime = Formatter.FormatDate(fields[3]);
                    DateTime lastModifiedTime = Formatter.FormatDate(fields[4]);
                    long fileSize = long.Parse(fields[5]);
                    DateTime fileBackupTime = Formatter.FormatDate(fields[6]);
                    FileMetadata fileMetadata = new FileMetadata(
                        operation,
                        targetFile,
                        sourceFile,
                        creationTime,
                        fileBackupTime,
                        lastModifiedTime,
                        fileSize
                    );
                    filesMetadataList.Add(fileMetadata);
                }
            }

        }


        /// <summary>
        /// Data da realização do backup.
        /// </summary>
        public DateTime BackupTime {
            get {
                return backupTime;
            }
        }


        /// <summary>
        /// Status do backup. True, o backup foi parcial. False, o backup foi completo.
        /// </summary>
        public bool IsPartialBackup {
            get {
                return partialBackup;
            }
        }


        /// <summary>
        /// Lista dos arquivos processados no backup.
        /// </summary>
        public List<FileMetadata> FilesList {
            get {
                return filesMetadataList;
            }
        }


    }

}
