using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backup.Drive;
using Backup.Utils;
using Backup.Windows;

namespace Backup.Forms {

    /// <summary>
    /// Diálogo para exibição dos arquivos que apresentaram erro no processamento.
    /// </summary>
    public partial class ErrorLogDialog : Form {


        /// <summary>
        /// Constructor da classe.
        /// </summary>
        /// <param name="errorFilesList">Lista dos arquivos que apresentaram erro no processamento.</param>
        public ErrorLogDialog(LinkedList<DamageInfo> errorFilesList) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            ListFiles(errorFilesList);
        }


        private void ListFiles(LinkedList<DamageInfo> errorFilesList) {
            try {
                ListViewItem[] listViewItems = new ListViewItem[errorFilesList.Count];
                int index = 0;
                foreach (DamageInfo damageData in errorFilesList) {
                    ListViewItem item = new ListViewItem(
                        new string[] {
                            damageData.FilePath,
                            damageData.ErrorMessage
                        },
                        0
                    );
                    listViewItems[index] = item;
                    index++;
                }
                ltvFiles.Items.AddRange(listViewItems);
                tsslNumberOfFiles.Text = "NÚMERO DE ARQUIVOS: " + errorFilesList.Count.ToString();
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


        private void OpenSelectedFile() {
            Cursor = Cursors.WaitCursor;
            int index = ltvFiles.SelectedIndices[0];
            string path = ltvFiles.Items[index].Text;
            WindowsSystem.OpenFileWithDefaultProgram(path);
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Abrir o diretório de um arquivo e selecionar o mesmo neste diretório.
        /// </summary>
        private void OpenSelectedFileFolder() {
            Cursor = Cursors.WaitCursor;
            int index = ltvFiles.SelectedIndices[0];
            string path = ltvFiles.Items[index].Text;
            WindowsSystem.OpenFileFolder(path);
            Cursor = Cursors.Default;
        }


        private void SaveConfigurations() {
            try {
                Properties.Settings settings = Properties.Settings.Default;
                settings.ErrorLogDialog_ListView_Column_1_Width = ltvFiles.Columns[0].Width;
                settings.ErrorLogDialog_ListView_Column_2_Width = ltvFiles.Columns[1].Width;
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


        private void ReadConfigurations() {
            try {
                Properties.Settings settings = Properties.Settings.Default;
                ltvFiles.Columns[0].Width = settings.ErrorLogDialog_ListView_Column_1_Width;
                ltvFiles.Columns[1].Width = settings.ErrorLogDialog_ListView_Column_2_Width;
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


        private void ltvFiles_DoubleClick(object sender, EventArgs e) {
            OpenSelectedFile();
        }


        private void tsmiOpenFile_Click(object sender, EventArgs e) {
            OpenSelectedFile();
        }


        private void tsmiOpenFileFolder_Click(object sender, EventArgs e) {
            OpenSelectedFileFolder();
        }


        private void ErrorLogDialog_Load(object sender, EventArgs e) {
            ReadConfigurations();
        }


        private void ErrorLogDialog_FormClosing(object sender, FormClosingEventArgs e) {
            SaveConfigurations();
        }


    }

}