using Backup.Drive;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.IO;
using System.Windows.Markup;

namespace Backup.Forms {

    /// <summary>
    /// Diálogo para a manutenção dos diretórios locais para backup na Unidade de Backup.
    /// </summary>
    internal partial class DirectoriesDialog : Form {


        private const String defaultText = "Opcional: Arraste o(s) diretório(s) do Windows Explorer e solte na lista.";

        // Unidade de Backup selecionada na tela principal.
        private readonly Drive.Drive drive;


        /// <summary>
        /// Contructor da classe.
        /// </summary>
        /// <param name="drive">Unidade de Backup selecionada na tela principal.</param>
        public DirectoriesDialog(Backup.Drive.Drive drive) {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            this.drive = drive;
            tslHint.Text = defaultText;
            UpdateDirectories();
        }


        /// <summary>
        /// Atualizar a lista de diretórios para backup.
        /// </summary>
        private void UpdateDirectories() {
            lsbDirectories.Items.Clear();
            LinkedList<string> directories = drive.SourceDirectories;
            lsbDirectories.Items.AddRange(directories.ToArray());
            if (lsbDirectories.Items.Count > 0) {
                lsbDirectories.SelectedIndex = 0;
                btnDelete.Enabled = true;
            } else {
                btnDelete.Enabled = false;
            }
        }


        /// <summary>
        /// Adicionar um novo diretório para backup.
        /// </summary>
        private void AddDirectory() {
            Cursor = Cursors.WaitCursor;
            try {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "Selecione o diretório para controle de backup.";
                dialog.ShowNewFolderButton = false;
                dialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
                DialogResult dr = dialog.ShowDialog();
                if (dr == DialogResult.OK) {
                    AddDirectory(dialog.SelectedPath);
                    UpdateDirectories();
                }
            } catch (Exception ex) {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            Cursor = Cursors.Default;
        }


        private void AddDirectory(string directoryPath) {
            List<string> excludedList = drive.InsertSourceDirectory(directoryPath);
            if (excludedList.Count > 0) {
                MessageBox.Show(
                    this,
                    "Impossível inserir o diretório selecionado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        /// <summary>
        /// Remover os diretórios selecionados.
        /// </summary>
        private void RemoveDirectory() {
            Cursor = Cursors.WaitCursor;
            try {
                DialogResult dr = MessageBox.Show(
                    this,
                    "Excluir os diretórios selecionados?",
                    "Atenção!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (dr == DialogResult.Yes) {
                    List<string> deletedDirectories = new List<string>();
                    foreach (object item in lsbDirectories.SelectedItems) {
                        deletedDirectories.Add((string)item);
                    }
                    drive.DeleteSourceDirectories(deletedDirectories);
                    UpdateDirectories();
                }
            } catch (Exception ex) {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            Cursor = Cursors.Default;
        }


        private void btnInsert_Click(object sender, EventArgs e) {
            AddDirectory();
        }


        private void btnCancel_Click(object sender, EventArgs e) {
            RemoveDirectory();
        }


        private void btnInsert_MouseEnter(object sender, EventArgs e) {
            tslHint.Text = "Inserir um diretório";
        }


        private void btnInsert_MouseLeave(object sender, EventArgs e) {
            tslHint.Text = defaultText;
        }


        private void btnDelete_MouseEnter(object sender, EventArgs e) {
            tslHint.Text = "Remover os diretórios selecionados";
        }


        private void btnDelete_MouseLeave(object sender, EventArgs e) {
            tslHint.Text = defaultText;
        }


        private void btnInsert_Click_1(object sender, EventArgs e) {
            AddDirectory();
        }


        private void btnDelete_Click(object sender, EventArgs e) {
            RemoveDirectory();
        }


        private void lsbDirectories_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.All;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }


        private void lsbDirectories_DragDrop(object sender, DragEventArgs e) {
            string[] directories = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string directory in directories) {
                if (File.GetAttributes(directory).HasFlag(FileAttributes.Directory)) {
                    AddDirectory(directory);
                }
            }
            UpdateDirectories();
        }


    }

}
