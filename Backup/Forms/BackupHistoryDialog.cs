using System;
using Backup.Drive;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Backup.Utils;
using Backup.Windows;

namespace Backup.Forms {

    /// <summary>
    /// Diálogo para consulta do histórico de backups.
    /// </summary>
    public partial class BackupHistoryDialog : Form {


        // Parser do arquivo de log de backup.
        private LogParser parser;

        // Unidade de Backup selecionada na tela principal.
        private Drive.Drive drive;

        // Entradas do arquivo ZIP.
        private List<string> logFileEntries;

        // Índice do registro de backup selecionado.
        private int index;
        

        /// <summary>
        /// Contructor da classe.
        /// </summary>
        /// <param name="drive">Unidade de Backup selecionada na tela principal.</param>
        /// <param name="index">Índice do registro de log a ser exibido.</param>
        public BackupHistoryDialog(Drive.Drive drive, int index = -1) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            this.drive = drive;
            bool logExists = false;
            if (drive.LogFile.Exists()) {
                logFileEntries = drive.LogFile.ReadEntries();
                if (logFileEntries.Count > 0) {
                    logExists = true;
                    if (index >= 0) {
                        SetLogIndex(index);
                    } else {
                        SetLogIndex(logFileEntries.Count - 1);
                    }
                    tsbNumber2.Text = logFileEntries.Count.ToString();
                }
            }
            if (!logExists) {
                tslBackupTime.Text = "[NENHUM]";
                tslNumFiles.Text = "[NENHUM]";
                tsbFirst.Enabled = false;
                tsbPrevious.Enabled = false;
                tsbNext.Enabled = false;
                tsbLast.Enabled = false; 
            }
        }


        /// <summary>
        /// Posiciona o cursor no registro de backup com o índice especificado.
        /// </summary>
        /// <param name="index">Índice do registro de log.</param>
        private void SetLogIndex(int index) {
            try {
                this.index = index;
                tsbFirst.Enabled = index > 0;
                tsbPrevious.Enabled = tsbFirst.Enabled;
                tsbLast.Enabled = index < logFileEntries.Count - 1;
                tsbNext.Enabled = tsbLast.Enabled;
                tsbNumber1.Text = (this.index + 1).ToString();
                string logEntry = logFileEntries[index];
                PrintLogFile(logEntry);
            } catch (Exception ex) {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        /// <summary>
        /// Imprime o registro de backup na tela.
        /// </summary>
        /// <param name="logEntry">Texto do registro de backup.</param>
        private void PrintLogFile(string logEntry) {
            Cursor = Cursors.WaitCursor;
            string text = drive.LogFile.Read(logEntry);
            parser = null;
            parser = new LogParser(text);
            tslBackupTime.Text = parser.BackupTime.ToString() +
            (parser.IsPartialBackup ? " (PARCIAL)" : "");
            tslNumFiles.Text = parser.FilesList.Count.ToString();
            ltvFiles.Items.Clear();
            ListViewItem[] listViewItems = new ListViewItem[parser.FilesList.Count];
            for (int i = 0; i < parser.FilesList.Count; i++) {
                FileMetadata metadata = parser.FilesList[i];
                ListViewItem item = new ListViewItem(
                    new string[] {
                        metadata.SourcePath,
                        metadata.CreationTime.ToString(),
                        metadata.LastModifiedTime.ToString(),
                        Formatter.FormatSize(metadata.Size),
                        metadata.BackupTime.ToString()
                    },
                    -1
                );
                switch (metadata.Operation) {
                    case 1: {
                        item.Group = ltvFiles.Groups[0];
                    } break;
                    case 2: {
                        item.Group = ltvFiles.Groups[2];
                        item.ForeColor = Color.Green;
                    } break;
                    case 3: {
                        item.Group = ltvFiles.Groups[1];
                        item.ForeColor = Color.Red;
                    } break;
                }
                listViewItems[i] = item;
            }
            ltvFiles.Items.AddRange(listViewItems);
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Posicionar no primeiro registro de backup.
        /// </summary>
        private void First() {
            SetLogIndex(0);
        }


        /// <summary>
        /// Posicionar no registro de backup anterior.
        /// </summary>
        private void Previous() {
            SetLogIndex(index - 1);
        }


        /// <summary>
        /// Posicionar no último registro de backup.
        /// </summary>
        private void Last() {
            SetLogIndex(logFileEntries.Count - 1);
        }


        /// <summary>
        /// Posicionar no próximo registro de backup.
        /// </summary>
        private void Next() {
            SetLogIndex(index + 1);
        }


        /// <summary>
        /// Salvar as configurações da tela.
        /// </summary>
        private void SaveConfigurations() {
            try {
                Properties.Settings settings = Properties.Settings.Default;
                settings.BackupHistoryDialog_ListView_Column_1_Width = ltvFiles.Columns[0].Width;
                settings.BackupHistoryDialog_ListView_Column_2_Width = ltvFiles.Columns[1].Width;
                settings.BackupHistoryDialog_ListView_Column_3_Width = ltvFiles.Columns[2].Width;
                settings.BackupHistoryDialog_ListView_Column_4_Width = ltvFiles.Columns[3].Width;
                settings.BackupHistoryDialog_ListView_Column_5_Width = ltvFiles.Columns[4].Width;
                settings.Save();
            } catch (Exception ex) {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        /// <summary>
        /// Ler as configurações da tela.
        /// </summary>
        private void ReadConfigurations() {
            try {
                Properties.Settings settings = Properties.Settings.Default;
                ltvFiles.Columns[0].Width = settings.BackupHistoryDialog_ListView_Column_1_Width;
                ltvFiles.Columns[1].Width = settings.BackupHistoryDialog_ListView_Column_2_Width;
                ltvFiles.Columns[2].Width = settings.BackupHistoryDialog_ListView_Column_3_Width;
                ltvFiles.Columns[3].Width = settings.BackupHistoryDialog_ListView_Column_4_Width;
                ltvFiles.Columns[4].Width = settings.BackupHistoryDialog_ListView_Column_5_Width;
            } catch (Exception ex) {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void tsbFirst_Click(object sender, EventArgs e) {
            First();
        }


        private void tsbPrevious_Click(object sender, EventArgs e) {
            Previous();
        }


        private void tsbNext_Click(object sender, EventArgs e) {
            Next();
        }


        private void tsbLast_Click(object sender, EventArgs e) {
            Last();
        }


        private void BackupHistoryDialog_Load(object sender, EventArgs e) {
            ReadConfigurations();
        }


        private void BackupHistoryDialog_FormClosing(object sender, FormClosingEventArgs e) {
            SaveConfigurations();
        }


    }

}
