using Backup.Utils;
using Backup.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using DriveType = Backup.Windows.DriveType;

namespace Backup.Drive {

    /// <summary>
    /// 
    /// Classe que representa um drive do Windows. Um drive pode ser tanto um dispositivo
    /// físico quanto uma partição lógica. Pode ser também um dispositivo interno (HD, SSD) ou 
    /// externo (HD/SSD externo, MMC, pendrive, etc).
    /// 
    /// <br></br><br></br>
    /// 
    /// Um drive pode ser instalado como uma Unidade de Backup. Para isso será necessário
    /// criar uma estrutura de arquivos na raiz deste drive que indica a instalação. Normalmente
    /// uma unidade de Backup é algum dispositivo externo de memória como HD externo, por exemplo,
    /// que será conectado a uma porta USB. Mas pode ser um drive de rede também.
    /// 
    /// <br></br><br></br>
    /// 
    /// A instalação cria a seguinte estrutura de arquivos na raiz do drive:
    /// 
    /// <br></br><br></br>
    /// 
    /// <i><u>.BackupDriveInstallation</u></i>: Diretório raiz da instalação.
    /// 
    /// <br></br><br></br>
    /// 
    /// <i><u>.BackupDriveInstallation\BackupDriveInfo.xml</u></i>: Arquivo com as informações sobre 
    /// a Unidade de Backup como o UID (identificador único) e a data da instalação.
    /// 
    /// <br></br><br></br>
    /// 
    /// <i><u>.BackupDriveInstallation\BackupDirectories.xml</u></i>: Arquivo com a lista dos diretórios
    /// locais sob controle de backup na Unidade de Backup.
    /// 
    /// <br></br><br></br>
    /// 
    /// <i><u>.BackupDriveInstallation\LastBackupData.xml</u></i>: Arquivo com os dados sobre o último
    /// backup realizado na Unidade de Backup.
    /// 
    /// <br></br><br></br>
    /// 
    /// <i><u>.BackupDriveInstallation\BackupHistory.zip</u></i>: Arquivo de registro dos backups (log).
    /// 
    /// <br></br><br></br>
    /// 
    /// <i><u>BackupDrive.ico</u></i>: Ícone da Unidade de Backup no Windows Explorer.
    /// 
    /// <br></br><br></br>
    /// 
    /// <i><u>Autorun.inf</u></i>: Arquivo para configuração do ícone da Unidade de backup.
    /// 
    /// <br></br><br></br>
    /// 
    /// <i><u>Leia-me.txt</u></i>: Arquivo de instruções para o usuário.
    /// 
    /// <br></br><br></br>
    /// 
    /// O principal arquivo da estrutura é <i><u>.BackupDriveInstallation\BackupDriveInfo.xml</u></i>. 
    /// Uma Unidade de Backup estará instalada somente se este arquivo estiver na instalação.
    /// 
    /// </summary>
    public partial class Drive {


        // Diretório de instalação.
        private readonly InstallationDirectory installationDirectory;

        // Informações do drive do Windows.
        private readonly DriveInfo driveInfo;

        // Arquivo com dos diretórios locais para backup.
        private readonly DirectoriesFile directoriesFile;

        // Arquivo de instalação da Unidade de Backup.
        private readonly DriveInfoFile installationFile;

        // Arquivo com os dados do último backup.
        private readonly LastBackupFile lastBackupFile;

        // Arquivo de log dos backups.
        private readonly BackupLogFile backupLogFile;

        // Arquivo Leia-me.
        private readonly ReadmeFile readmeFile;

        // Arquivo Autorun.inf.
        private readonly AutorunFile autorunFile;

        // Arquivo de ícone.
        private readonly IconFile iconFile;

        // Diretório de destino do backup na Unidade de Backup.
        private readonly DirectoryInfo backupDirectory;

        // Diretórios locais sob controle de backup.
        private readonly LinkedList<string> localDirectoriesList;

        // Lista dos arquivos locais a serem criados na Unidade de Backup.
        private readonly LinkedList<FileInfo> createdFilesList;

        // Lista dos arquivos a serem excluídos da Unidade de Backup.
        private readonly LinkedList<FileInfo> deletedFilesList;

        // Lista dos arquivos locais a serem modificados na Unidade de Backup.
        private readonly LinkedList<FileInfo> updatedFilesList;

        // Lista dos arquivos locais com erro de acesso ou outro problema.
        private readonly LinkedList<DamageInfo> damagedFilesList;

        // Lista dos diretórios locais a serem criados na Unidade de Backup.
        private readonly LinkedList<string> createdDirectoriesList;

        // Lista dos diretórios locais a serem excluídos da Unidade de Backup.
        private readonly LinkedList<string> deletedDirectoriesList;

        // Lista dos diretórios raiz.
        private readonly LinkedList<string> rootDirectoriesList;

        // Entradas de Log em formato texto codificado.
        private readonly LinkedList<string> logEntriesList;

        // Lista de arquivos a serem restaurados.
        private readonly LinkedList<DriveFiles> restoreFilesList;

        private List<Drive> targetDrivesList;

        // Tipo do drive. Os tipos são: INTERNO, EXTERNO E REDE.
        private readonly DriveType driveType;

        // Mutex que controla o bloqueio da Unidade de Backup.
        private Mutex mutex;

        // Identificador único da Unidade de Backup.
        private string uid;

        // Data da instalação da Unidade de Backup.
        private DateTime installationTime;

        // Data do último backup realizado na Unidade de Backup.
        private DateTime lastBackupTime;

        // Status de backup parcial.
        private bool isPartialBackup;

        // Status de backup realizado.
        private bool haveLastBackupTime;

        // Status de Unidade de Backup instalada.
        private bool isInstalled;

        // Status de backup abortado pelo usuário.
        private bool abortedProcess;

        // Status de processo em execução.
        private bool isProcessing;

        // Quantidade de bytes a serem liberados no backup.
        private long bytesToRelease;

        // Quantidade de bytes a serem escritos no backup.
        private long bytesToRecord;

        // Status de bloqueio da Unidade de Backup.
        private bool isLocked;


        /// <summary>
        /// Carrega os dados sobre o drive se for uma Unidade de Backup.
        /// </summary>
        /// <param name="driveInfo">Informações sobre o drive.</param>
        /// <param name="type">Tipo de drive.</param>
        public Drive(DriveInfo driveInfo, DriveType type) {
            this.driveInfo = driveInfo;
            this.driveType = type;
            this.isLocked = false;
            mutex = null;
            // Todas as listas são do tipo LinkedList de modo a ter maior eficiência no
            // processo de preenchimento já que as listas encadeadas não exigem arranjos
            // contínuos na memória e realocação quando a quantidade de itens for 
            // ultrapassada, o que é extremamente custoso em termos de desempenho. Como
            // não sabe-se de antemão quantos arquivos novos, excluídos ou alterados vão
            // preencher as respectivas listas, então o ideal é alocar dinâmicamente as
            // posições da lista conforme o processo de busca realiza a triagem.
            createdFilesList = new LinkedList<FileInfo>();
            deletedFilesList = new LinkedList<FileInfo>();
            updatedFilesList = new LinkedList<FileInfo>();
            damagedFilesList = new LinkedList<DamageInfo>();
            createdDirectoriesList = new LinkedList<string>();
            deletedDirectoriesList = new LinkedList<string>();
            rootDirectoriesList = new LinkedList<string>();
            logEntriesList = new LinkedList<string>();
            restoreFilesList = new LinkedList<DriveFiles>();
            targetDrivesList = new List<Drive>();
            // Arquivos da instalação da Unidade de Backup.
            installationDirectory = new InstallationDirectory(driveInfo.Name + ".BackupDriveInstallation");
            directoriesFile = new DirectoriesFile(installationDirectory.Path + @"\BackupDirectories.xml");
            installationFile = new DriveInfoFile(installationDirectory.Path + @"\BackupDriveInfo.xml");
            lastBackupFile = new LastBackupFile(installationDirectory.Path + @"\LastBackupData.xml");
            backupLogFile = new BackupLogFile(installationDirectory.Path + @"\BackupHistory.zip");
            readmeFile = new ReadmeFile(driveInfo.Name + "Leia-me.txt");
            autorunFile = new AutorunFile(driveInfo.Name + "Autorun.inf");
            iconFile = new IconFile(driveInfo.Name + "BackupDrive.ico");
            // Diretório de destino do backup.
            backupDirectory = new DirectoryInfo(driveInfo.Name + @"\backup");
            // Verifica se é uma Unidade de Backup. Se for, carrega todos os dados sobre
            // a mesma, definidos durante a instalação ou na configuração da mesma.
            isInstalled = installationFile.Exists();
            if (isInstalled) {
                Dictionary<string, object> installationData = installationFile.Read();
                uid = (string)installationData["uid"];
                // Aqui, cria um mutex de acordo com o UID da Unidade de Backup. O mutex
                // controla o acesso exclusivo àquela unidade para evitar que múltiplos
                // processos possam ler e gravar arquivos simultâneamente nela, levando a
                // potenciais problemas na verificação e atualização dos arquivos.
                // Com o mutex obtido na chamada ao método Lock(), outro processo só terá
                // acesso ao drive quando este for liberado, ou quando a instância que o
                // obteve for liberada da memória.
                mutex = new Mutex(false, uid);
                installationTime = (DateTime)installationData["installation-time"];
                if (lastBackupFile.Exists()) {
                    Dictionary<string, object> lastBackData = lastBackupFile.Read();
                    lastBackupTime = (DateTime)lastBackData["backup-time"];
                    isPartialBackup = (bool)lastBackData["partial"];
                    haveLastBackupTime = true;
                } else {
                    haveLastBackupTime = false;
                }
                localDirectoriesList = new LinkedList<string>();
                if (directoriesFile.Exists()) {
                    foreach (string directory in directoriesFile.Read()) {
                        localDirectoriesList.AddLast(directory);
                    }
                }
            }
        }


        /// <summary>
        /// Destructor da classe. Libera o Mutex para a alocação por outro processo.
        /// </summary>
        ~Drive() {
            if (mutex != null) {
                Unlock();
                mutex?.Dispose();
            }
        }


        /// <summary>
        /// Instalar a Unidade de Backup. Na instalação os seguintes arquivos serão criados na raiz 
        /// do drive:
        /// <br></br><br></br>
        /// <i><u>.BackupDriveInstallation</u></i>: Diretório raiz da instalação.
        /// <br></br><br></br>
        /// <i><u>.BackupDriveInstallation\BackupDriveInfo.xml</u></i>: Arquivo com as informações sobre 
        /// a Unidade de Backup como o UID (identificador único) e a data da instalação.
        /// <br></br><br></br>
        /// <i><u>BackupDrive.ico</u></i>: Ícone da Unidade de Backup no Windows Explorer.
        /// <br></br><br></br>
        /// <i><u>Autorun.inf</u></i>: Arquivo para configuração do ícone da Unidade de Backup.
        /// <br></br><br></br>
        /// 
        /// </summary>
        ///
        /// <exception cref="Exception"></exception>
        public void Install() {
            CheckPermission(false, true, true);
            StringBuilder sb = new StringBuilder(16);
            sb.Append("BDI#");
            Random rnd = new Random();
            char[] alphabet = new char[] {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };
            char[] decimalDigits = new char[] {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
            };
            int length = 12;
            for (int i = 1; i <= length; i++) {
                char c = (i % 2 == 1 ? alphabet[rnd.Next(26)] : decimalDigits[rnd.Next(10)]);
                sb.Append(c);
            }
            uid = sb.ToString();
            installationDirectory.Create();
            installationTime = DateTime.Now;
            installationFile.Write(installationTime, uid);
            iconFile.Write();
            autorunFile.Write(Path.GetFileName(iconFile.Path));
            // Cria o Mutex.
            mutex = new Mutex(false, uid);
            isInstalled = true;
        }


        /// <summary>
        /// Desinstalar a Unidade de Backup. Todos os arquivos de instalação serão removidos,
        /// exceto o log de backup, se se optar por mantê-lo após a desinstalação.
        /// </summary>
        /// <param name="keepBackupLog">True, mantém o log de backup. False, exclui o log de
        /// backup.</param>
        /// <exception cref="Exception">Erro ao excluir os arquivos.</exception>
        public void Uninstall(bool keepBackupLog) {
            CheckPermission(true, true, true);
            try {
                installationDirectory.SetHidden(false);
                installationFile.Delete();
                lastBackupFile.Delete();
                directoriesFile.Delete();
                readmeFile.Delete();
                iconFile.Delete();
                autorunFile.Delete();
                if (!keepBackupLog) {
                    backupLogFile.Delete();
                    installationDirectory.Delete();
                }
                isInstalled = false;
            } finally {
                installationDirectory.SetHidden(true);
            }
        }


        /// <summary>
        /// Formatar o drive, apagando todos os arquivos que estavam gravados neste,
        /// caso seja um drive removível (não habilitado para drives de rede e
        /// drives locais).
        /// </summary>
        /// <param name="fileSystemFormat">Formato do sistema de arquivos</param>
        /// <param name="label">Rótulo do drive.</param>
        public void Format(string fileSystemFormat, string label) {
            if (driveType == DriveType.EXTERNAL) {
                WindowsSystem.FormatDrive(
                    driveInfo.Name.Substring(0, 2),
                    fileSystemFormat,
                    label
                );
            }
        }


        public bool Eject() {
            return WindowsSystem.Eject(Letter);
        }


        /// <summary>
        /// Buscar pelos arquivos a serem atualizados na Unidade de Backup. A chamada a
        /// este método dispara uma Thread que fará a busca de modo assíncrono, sendo que
        /// cada etapa do processo será notificada aos ouvintes em chamadas de eventos 
        /// específicas de acordo com a interface <i>ISearchFilesListener</i>.
        /// </summary>
        /// <param name="listeners">Ouvintes do processo de busca.</param>
        public void SearchBackupUpdatesAsynk(int mode, params ISearchBackupUpdatesListener[] listeners) {
            lock (this) {
                if (!isProcessing) {
                    Thread thread = new Thread(() => {SearchBackupUpdates(mode, listeners);});
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
        }


        /// <summary>
        /// Buscar por arquivos novos, removidos ou alterados nos diretórios locais e que
        /// deverão ser copiados para ou excluídos da Unidade de Backup. Também verifica
        /// na Unidade de Backup se há arquivos que não coincidem com os dos diretórios
        /// locais, para excluí-los.
        /// </summary>
        /// <param name="listeners">Ouvintes do processo de busca.</param>
        private void SearchBackupUpdates(int mode, params ISearchBackupUpdatesListener[] listeners) {
            isProcessing = true;
            abortedProcess = false;
            try {
                CheckPermission(true, true, true);
                // Verifica se a lista de diretórios para backup não está vazia.
                bool empty = true;
                foreach (string directory in localDirectoriesList) {
                    if (Directory.Exists(directory)) {
                        empty = false;
                        break;
                    }
                }
                if (empty) {
                    throw new Exception("Lista de diretórios para backup está vazia.");
                }
                // Total de arquivos a serem processados tanto nos diretórios locais quanto
                // nos diretórios da Unidade de Backup.
                int totalFiles = 0;
                foreach (string directory in localDirectoriesList) {
                    totalFiles += CountFiles(directory);
                    string targetDirectory = RelativePath(directory);
                    if (Directory.Exists(targetDirectory)) {
                        totalFiles += CountFiles(targetDirectory);
                    }
                }
                CheckIfTheProcessHasBeenAborted();
                foreach (ISearchBackupUpdatesListener listener in listeners) {
                    listener.SearchInitialized(totalFiles);
                }
                ReleaseCounters();
                int currentStep = 1;
                foreach (string localDirectory in localDirectoriesList) {
                    CheckIfTheProcessHasBeenAborted();
                    if (!Directory.Exists(localDirectory)) continue;
                    // Lista os arquivos na raiz do diretório de backup a serem criados
                    // ou atualizados na Unidade de Backup.
                    string[] files1 = Directory.GetFiles(localDirectory);
                    foreach (string file in files1) {
                        CheckIfTheProcessHasBeenAborted();
                        foreach (ISearchBackupUpdatesListener listener in listeners) {
                            listener.ProcessingFile(currentStep, file);
                        }
                        try {
                            FileInfo fileInfo = new FileInfo(file);
                            string targetFile = RelativePath(file);
                            if (!File.Exists(targetFile)) {
                                bytesToRecord += fileInfo.Length;
                                createdFilesList.AddLast(fileInfo);
                            } else {
                                FileInfo targetInfo = new FileInfo(targetFile);
                                if (UpdatedFile(fileInfo, targetInfo, mode)) {
                                    bytesToRecord += fileInfo.Length - targetInfo.Length;
                                    updatedFilesList.AddLast(fileInfo);
                                }
                            }
                        } catch (Exception ex) {
                            damagedFilesList.AddLast(new DamageInfo(file, ex.Message));
                        } finally {
                            currentStep++;
                        }
                    }
                    CheckIfTheProcessHasBeenAborted();
                    // Lista os arquivos nos subdiretórios do diretório de backup a serem
                    // criados ou atualizados na Unidade de Backup.
                    LinkedList<string> subdirectories1 = new LinkedList<string>();
                    ListSubdirectoriesTree(localDirectory, subdirectories1);
                    foreach (string subdirectory in subdirectories1) {
                        CheckIfTheProcessHasBeenAborted();
                        string targetSubdirectory = RelativePath(subdirectory);
                        if (!Directory.Exists(targetSubdirectory)) {
                            createdDirectoriesList.AddLast(subdirectory);
                        }
                        string[] files2 = Directory.GetFiles(subdirectory);
                        foreach (string file in files2) {
                            CheckIfTheProcessHasBeenAborted();
                            foreach (ISearchBackupUpdatesListener listener in listeners) {
                                listener.ProcessingFile(currentStep, file);
                            }
                            try {
                                FileInfo fileInfo = new FileInfo(file);
                                string targetFile = RelativePath(file);
                                if (!File.Exists(targetFile)) {
                                    bytesToRecord += fileInfo.Length;
                                    createdFilesList.AddLast(fileInfo);
                                } else {
                                    FileInfo targetInfo = new FileInfo(targetFile);
                                    if (UpdatedFile(fileInfo, targetInfo, mode)) {
                                        bytesToRecord += fileInfo.Length - targetInfo.Length;
                                        updatedFilesList.AddLast(fileInfo);
                                    }
                                }
                            } catch (Exception ex) {
                                damagedFilesList.AddLast(new DamageInfo(file, ex.Message));
                            } finally {
                                currentStep++;
                            }
                        }
                    }
                    CheckIfTheProcessHasBeenAborted();
                    // Os diretórios raiz na hierarquia do diretório de backup são
                    // colocados em lista separada para que sejam criados primeiro, 
                    // caso eles não tenham um correspondente na Unidade de Backup.
                    string targetDirectory = RelativePath(localDirectory);
                    if (!Directory.Exists(targetDirectory)) {
                        createdDirectoriesList.AddFirst(localDirectory);
                        DirectoryInfo parent = Directory.GetParent(localDirectory);
                        while (parent != null) {
                            CheckIfTheProcessHasBeenAborted();
                            string directory = RelativePath(parent.FullName);
                            if (!Directory.Exists(directory)) {
                                if (!rootDirectoriesList.Contains(parent.FullName)) {
                                    rootDirectoriesList.AddFirst(parent.FullName);
                                }
                            }
                            parent = Directory.GetParent(parent.FullName);
                        }
                        // Se não há correspondente na Unidade de Backup, não haverá
                        // arquivos e subdiretórios a excluir dela, por isso ignora
                        // as próximas etapas, passando já para a verificação do 
                        // próximo diretório.
                        continue;
                    }
                    CheckIfTheProcessHasBeenAborted();
                    // Lista os arquivos a excluir da raiz do diretório de destino na
                    // Unidade de Backup.
                    string[] files3 = Directory.GetFiles(targetDirectory);
                    foreach (string file in files3) {
                        CheckIfTheProcessHasBeenAborted();
                        foreach (ISearchBackupUpdatesListener listener in listeners) {
                            listener.ProcessingFile(currentStep, file);
                        }
                        try {
                            string localFile = RelativePath(localDirectory, file);
                            if (!File.Exists(localFile)) {
                                // Arquivo na raiz do diretório de destino e sem equivalente
                                // no diretório local.
                                FileInfo fileInfo = new FileInfo(file);
                                bytesToRelease += fileInfo.Length;
                                deletedFilesList.AddLast(fileInfo);
                            }
                        } catch (Exception ex) {
                            damagedFilesList.AddLast(new DamageInfo(file, ex.Message));
                        } finally {
                            currentStep++;
                        }
                    }
                    CheckIfTheProcessHasBeenAborted();
                    // Lista os arquivos a excluir nos subdiretórios do diretório de destino na
                    // Unidade de Backup.
                    LinkedList<string> subdirectories2 = new LinkedList<string>();
                    ListSubdirectoriesTree(targetDirectory, subdirectories2);
                    foreach (string subdirectory in subdirectories2) {
                        CheckIfTheProcessHasBeenAborted();
                        string[] files4 = Directory.GetFiles(subdirectory);
                        foreach (string file in files4) {
                            CheckIfTheProcessHasBeenAborted();
                            foreach (ISearchBackupUpdatesListener listener in listeners) {
                                listener.ProcessingFile(currentStep, file);
                            } 
                            try {
                                string localFile = RelativePath(localDirectory, file);
                                if (!File.Exists(localFile)) {
                                    // Arquivo na raiz do subdiretório de destino e sem equivalente
                                    // no subdiretório local.
                                    FileInfo fileInfo = new FileInfo(file);
                                    bytesToRelease += fileInfo.Length;
                                    deletedFilesList.AddLast(fileInfo);
                                }
                            } catch (Exception ex) {
                                damagedFilesList.AddLast(new DamageInfo(file, ex.Message));
                            } finally {
                                currentStep++;
                            }
                        }
                        // Além dos arquivos, se o subdiretório não existe mais no sistema local,
                        // então este deve ser excluído também da Unidade de Backup, para não existir
                        // diretório vazio nela.
                        string localSubdirectory = RelativePath(
                            localDirectory,
                            subdirectory
                        );
                        if (!Directory.Exists(localSubdirectory)) {
                            deletedDirectoriesList.AddLast(subdirectory);
                        }
                    }
                }
                // Notifica todos os ouvintes do processo de busca de atualizações para
                // listar os arquivos novos, excluídos ou modificados, bem como os que
                // apresentaram erro ao serem processados.
                foreach (ISearchBackupUpdatesListener listener in listeners) {
                    listener.SearchFinished(
                        createdFilesList,
                        deletedFilesList,
                        updatedFilesList,
                        damagedFilesList
                    );
                }
            } catch (Exception ex) {
                // Tratamento de exceção no processo de busca.
                if (!abortedProcess) {
                    // Houve um erro e não foi gerado por motivo de cancelamento do 
                    // processo pelo usuário.
                    foreach (ISearchBackupUpdatesListener listener in listeners) {
                        listener.SearchAbortedByError(ex);
                    }
                } else {
                    // Houve um erro, mas ele foi gerado porque o usuário cancelou
                    // o processo.
                    foreach (ISearchBackupUpdatesListener listener in listeners) {
                        listener.SearchAbortedByUser();
                    }
                }
            } finally {
                isProcessing = false;
            }
        }


        /// <summary>
        /// Fazer o backup dos arquivos encontrados na chamada ao método <i>FindUpdates</i>. A 
        /// chamada a este método dispara uma Thread que fará o backup de modo assíncrono, sendo
        /// que cada etapa do processo será notificada aos ouvintes em chamadas de eventos específicas
        /// de acordo com a interface <i>IBackupListener</i>.
        /// </summary>
        /// <param name="listeners">Ouvintes do processo de backup.</param>
        public void PerformBackupAsynk(params IBackupListener[] listeners) {
            lock (this) {
                if (!isProcessing) {
                    Thread thread = new Thread(() => {PerformBackup(listeners);});
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
        }


        /// <summary>
        /// Fazer o backup dos arquivos na Unidade de Backup. Ao fim do processo, a Unidade de
        /// Backup deverá ter a mesma árvore de arquivos que dos diretórios locais sob
        /// controle.
        /// </summary>
        /// <param name="listeners">Ouvintes do processo de backup.</param>
        private void PerformBackup(params IBackupListener[] listeners) {
            isProcessing = true;
            abortedProcess = false;
            try {
                CheckPermission(true, true, true);
                bool copyFiles = !abortedProcess && ((createdFilesList.Count > 0) ||
                (updatedFilesList.Count > 0) || (deletedFilesList.Count > 0));
                if (copyFiles) {
                    logEntriesList.Clear();
                    damagedFilesList.Clear();
                    // Verifica se o volume de dados cabe no espaço vazio a ser alocado
                    // na Unidade de Backup.
                    if (driveInfo.TotalFreeSpace <= (bytesToRecord - bytesToRelease)) {
                        // Não há espaço livre suficiente em disco para gravar os arquivos
                        // novos. Lança um Exception.
                        throw new Exception("Espaço em disco insuficiente para " +
                        "realizar o backup dos arquivos.");
                    }
                    int numberOfFiles = createdFilesList.Count + deletedFilesList.Count +
                    updatedFilesList.Count;
                    // Notifica os ouvintes do início do backup.
                    foreach (IBackupListener listener in listeners) {
                        listener.BackupInitialized(numberOfFiles);
                    }
                    int currentStep = 1;
                    // Exclui os arquivos da Unidade de Backup, liberando espaço
                    // para copiar novos arquivos.
                    foreach (FileInfo fileInfo in deletedFilesList) {
                        CheckIfTheProcessHasBeenAborted();
                        try {
                            foreach (IBackupListener listener in listeners) {
                                listener.ProcessingFile(currentStep, fileInfo.FullName, 2);
                            }
                            DeleteFile(fileInfo.FullName);
                            InsertLogEntry(3, fileInfo, fileInfo.FullName);
                        } catch (Exception ex) {
                            damagedFilesList.AddLast(new DamageInfo(fileInfo.FullName, ex.Message));
                        } finally {
                            currentStep++;
                        }
                    }
                    // Exclui os diretórios da Unidade de Backup.                
                    for (int i = deletedDirectoriesList.Count - 1; i >= 0; i--) {
                        CheckIfTheProcessHasBeenAborted();
                        string directory = deletedDirectoriesList.ElementAt(i);
                        DeleteDirectory(directory);
                    }
                    // Cria os diretórios raiz das hierarquias dos diretórios para
                    // backup.
                    foreach (string directory in rootDirectoriesList) {
                        CheckIfTheProcessHasBeenAborted();
                        string targetDirectory = RelativePath(directory);
                        CreateDirectory(targetDirectory);
                    }
                    // Cria os novos diretórios na Unidade de Backup, preparando
                    // para receber novos arquivos.
                    foreach (string directory in createdDirectoriesList) {
                        CheckIfTheProcessHasBeenAborted();
                        string targetDirectory = RelativePath(directory);
                        CreateDirectory(targetDirectory);
                    }
                    // Copia os arquivos novos no sistema local para a Unidade de Backup.
                    foreach (FileInfo fileInfo in createdFilesList) {
                        CheckIfTheProcessHasBeenAborted();
                        try {
                            string targetFile = RelativePath(fileInfo.FullName);
                            foreach (IBackupListener listener in listeners) {
                                listener.ProcessingFile(currentStep, targetFile, 1);
                            }
                            CopyFile(fileInfo.FullName, targetFile);
                            InsertLogEntry(1, fileInfo, targetFile);
                        } catch (Exception ex) {
                            damagedFilesList.AddLast(new DamageInfo(fileInfo.FullName, ex.Message));
                        } finally {
                            currentStep++;
                        }
                    }
                    // Copia os arquivos alterados no sistema local para a Unidade de
                    // Backup.
                    foreach (FileInfo fileInfo in updatedFilesList) {
                        CheckIfTheProcessHasBeenAborted();
                        try {
                            string targetFile = RelativePath(fileInfo.FullName);
                            foreach (IBackupListener listener in listeners) {
                                listener.ProcessingFile(currentStep, targetFile, 3);
                            }
                            CopyFile(fileInfo.FullName, targetFile);
                            InsertLogEntry(2, fileInfo, targetFile);
                        } catch (Exception ex) {
                            damagedFilesList.AddLast(new DamageInfo(fileInfo.FullName, ex.Message));
                        } finally {
                            currentStep++;
                        }
                    }
                    ReleaseCounters();
                }
            } catch (Exception ex) {
                // Tratamento de exceção no processo de backup.
                if (!abortedProcess) {
                    // Houve um erro e não foi gerado por motivo de cancelamento do 
                    // processo pelo usuário.
                    foreach (IBackupListener listener in listeners) {
                        listener.BackupAbortedByError(ex);
                    }
                } else {
                    // Houve um erro, mas ele foi gerado porque o usuário cancelou
                    // o processo.
                    foreach (IBackupListener listener in listeners) {
                        listener.BackupAbortedByUser();
                    }
                }
            } finally {
                try {
                    if (logEntriesList.Count > 0) {
                        // Grava o log do backup caso pelo menos um arquivo tenha sido alterado
                        // na Unidade de Backup.
                        lastBackupTime = DateTime.Now;
                        isPartialBackup = abortedProcess;
                        haveLastBackupTime = true;
                        backupLogFile.Write(
                            logEntriesList,
                            isPartialBackup,
                            lastBackupTime
                        );
                        lastBackupFile.Write(
                            lastBackupTime,
                            isPartialBackup
                        );  
                    }
                    isProcessing = false;
                    foreach (IBackupListener listener in listeners) {
                        listener.BackupDone(damagedFilesList);
                    }
                } catch (Exception ex) {
                    isProcessing = false;
                    foreach (IBackupListener listener in listeners) {
                        listener.BackupAbortedByError(ex);
                    }
                }
            }
        }


        public void SearchRestoreFilesAsynk(List<Drive> targetDrivesList,
        params ISearchRestoreFilesListener[] listeners) {
            lock (this) {
                if (!isProcessing) {
                    Thread thread = new Thread(() => { 
                        SearchRestoreFiles(targetDrivesList, listeners); 
                    });
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
        }


        /// <summary>
        /// Buscar por arquivos novos, removidos ou alterados nos diretórios locais e que
        /// deverão ser copiados para ou excluídos da Unidade de Backup. Também verifica
        /// na Unidade de Backup se há arquivos que não coincidem com os dos diretórios
        /// locais, para excluí-los.
        /// </summary>
        /// <param name="listeners">Ouvintes do processo de busca.</param>
        private void SearchRestoreFiles(List<Drive> targetDrivesList,
        params ISearchRestoreFilesListener[] listeners) {
            try {
                CheckPermission(true, false, true);
                ReleaseCounters();
                this.targetDrivesList.AddRange(targetDrivesList);
                int totalFiles = 0;
                foreach (Drive drive in targetDrivesList) {
                    totalFiles += CountFiles(String.Concat(backupDirectory.FullName,
                    @"\", drive.Letter[0]));
                }
                CheckIfTheProcessHasBeenAborted();
                foreach (ISearchRestoreFilesListener listener in listeners) {
                    listener.SearchInitialized(totalFiles);
                }
                string[] backupFiles;
                int currentStep = 1;
                foreach (Drive drive in targetDrivesList) {
                    CheckIfTheProcessHasBeenAborted();
                    DriveFiles restoreFiles = new DriveFiles(drive.Letter);
                    LinkedList<string> subdirectories = new LinkedList<string>();
                    string directory = String.Concat(backupDirectory.FullName, @"\", drive.Letter[0]);
                    backupFiles = Directory.GetFiles(directory + @"\");
                    for (int i = 0; i < backupFiles.Length; i++) {
                        string backupFile = backupFiles[i];
                        foreach (ISearchRestoreFilesListener listener in listeners) {
                            listener.ProcessingFile(currentStep, backupFile);
                        }
                        string localFile = RelativePath(drive.Letter + @"\", backupFile);
                        try {
                            FileInfo sourceInfo = new FileInfo(backupFile);
                            FileInfo targetInfo = new FileInfo(localFile);
                            if (targetInfo.Exists) {
                                if (UpdatedFile(sourceInfo, targetInfo, LAST_UPDATE_DATE_MODE)) {
                                    bytesToRecord += sourceInfo.Length - targetInfo.Length;
                                    restoreFiles.Files.AddLast(sourceInfo);
                                }
                            } else {
                                bytesToRecord += sourceInfo.Length;
                                restoreFiles.Files.AddLast(sourceInfo);
                            }
                        } catch (Exception ex) {
                            damagedFilesList.AddLast(new DamageInfo(backupFile, ex.Message));
                        } finally {
                            currentStep++;
                        }
                    }
                    ListSubdirectoriesTree(directory, subdirectories);
                    foreach (string subdirectory in subdirectories) {
                        CheckIfTheProcessHasBeenAborted();
                        backupFiles = Directory.GetFiles(subdirectory);
                        for (int i = 0; i < backupFiles.Length; i++) {
                            CheckIfTheProcessHasBeenAborted();
                            string backupFile = backupFiles[i];
                            foreach (ISearchRestoreFilesListener listener in listeners) {
                                listener.ProcessingFile(currentStep, backupFile);
                            }
                            string localFile = RelativePath(drive.Letter + @"\", backupFile);
                            try {
                                FileInfo sourceInfo = new FileInfo(backupFile);
                                FileInfo targetInfo = new FileInfo(localFile);
                                if (targetInfo.Exists) {
                                    if (UpdatedFile(sourceInfo, targetInfo, LAST_UPDATE_DATE_MODE)) {
                                        bytesToRecord += sourceInfo.Length - targetInfo.Length;
                                        restoreFiles.Files.AddLast(sourceInfo);
                                    }
                                } else {
                                    bytesToRecord += sourceInfo.Length;
                                    restoreFiles.Files.AddLast(sourceInfo);
                                }
                            } catch (Exception ex) {
                                damagedFilesList.AddLast(new DamageInfo(backupFile, ex.Message));
                            } finally {
                                currentStep++;
                            }
                        }
                    }
                    restoreFilesList.AddLast(restoreFiles);
                }
                foreach (ISearchRestoreFilesListener listener in listeners) {
                    listener.SearchFinished(restoreFilesList, damagedFilesList);
                }
            } catch (Exception ex) {
                if (!abortedProcess) {
                    foreach (ISearchRestoreFilesListener listener in listeners) {
                        listener.SearchAbortedByError(ex);
                    }
                } else {
                    foreach (ISearchRestoreFilesListener listener in listeners) {
                        listener.SearchAbortedByUser();
                    }
                }
            } finally {
                isProcessing = false;
            }
        }


        /// <summary>
        /// Fazer a restauração dos arquivos da Unidade de Backup para um drive local do computador. A 
        /// chamada a este método dispara uma Thread que fará o restore de modo assíncrono, sendo
        /// que cada etapa do processo será notificada aos ouvintes em chamadas de eventos específicas
        /// de acordo com a interface <i>RestoreListener</i>.
        /// </summary>
        /// <param name="targetDrivesList">Drive local aonde serão restaurados os arquivos.</param>
        /// <param name="listeners">Ouvintes do processo de restore.</param>
        public void PerformRestoreAsynk(params IRestoreListener[] listeners) {
            lock (this) {
                if (!isProcessing) {
                    Thread thread = new Thread(() => {
                        PerformRestore(listeners);
                    });
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
        }


        /// <summary>
        /// Restaurar os arquivos da Unidade de Backup para o drive local definido. A restauração é
        /// um processo que deve ser completado. Antes que seja, será impossível realizar qualquer
        /// ação na Unidade de backup, sob o risco de perda de arquivos.
        /// </summary>
        /// <param name="targetDrivesList">Drive local de destino.</param>
        /// <param name="listeners">Ouvintes do processo de restore.</param>
        private void PerformRestore(params IRestoreListener[] listeners) {
            isProcessing = true;
            abortedProcess = false;
            try {
                CheckPermission(true, false, true);
                bool copyFiles = !abortedProcess && (restoreFilesList.Count > 0);
                if (copyFiles) {
                    damagedFilesList.Clear();
                    LinkedList<string> directoriesList = new LinkedList<string>();
                    foreach (Drive drive in targetDrivesList ) {
                        CheckIfTheProcessHasBeenAborted();
                        string directory = RelativePath(drive.Letter + @"\");
                        ListSubdirectoriesTree(directory, directoriesList);
                    }
                    int replaceIndex = backupDirectory.FullName.Length;
                    foreach (string directory in directoriesList) {
                        CheckIfTheProcessHasBeenAborted();
                        string targetDrive = directory.Substring(replaceIndex + 1, 1);
                        string targetDirPath = targetDrive + @":\" + directory.Substring(
                            replaceIndex + 3,
                            directory.Length - replaceIndex - 3
                        );
                        if (!Directory.Exists(targetDirPath)) {
                            Directory.CreateDirectory(targetDirPath);
                        }
                    }
                    CheckIfTheProcessHasBeenAborted();
                    SafeRestore.RestoreStarted(this, targetDrivesList);
                    int numOfRestoreFiles = 0;
                    foreach (DriveFiles driveFiles in restoreFilesList ) {
                        numOfRestoreFiles += driveFiles.Files.Count;
                    }
                    foreach (IRestoreListener listener in listeners) {
                        listener.RestoreInitialized(numOfRestoreFiles);
                    }
                    int currentStep = 1;
                    foreach (DriveFiles restoreFiles in restoreFilesList) {
                        CheckIfTheProcessHasBeenAborted();
                        foreach (FileInfo file in restoreFiles.Files) {
                            CheckIfTheProcessHasBeenAborted();
                            foreach (IRestoreListener listener in listeners) {
                                listener.ProcessingFile(currentStep, file.FullName);
                            }
                            try {
                                string directory = RelativePath(
                                    restoreFiles.TargetDrive + @"\",
                                    file.DirectoryName
                                );
                                string targetFile = RelativePath(directory, file.FullName);
                                CopyFile(file.FullName, targetFile);
                            } catch (Exception ex) {
                                damagedFilesList.AddLast(new DamageInfo(file.FullName, ex.Message));
                            } finally {
                                currentStep++;
                            }
                        }
                    }
                    // Exclui o arquivo de controle de restauração.
                    SafeRestore.RestoreDone();
                }
            } catch (Exception ex) {
                // Tratamento de exceção no processo de backup.
                if (!abortedProcess) {
                    // Houve um erro e não foi gerado por motivo de cancelamento do 
                    // processo pelo usuário.
                    foreach (IRestoreListener listener in listeners) {
                        listener.RestoreAbortedByError(ex);
                    }
                } else {
                    // Houve um erro, mas ele foi gerado porque o usuário cancelou
                    // o processo.
                    foreach (IRestoreListener listener in listeners) {
                        listener.RestoreAbortedByUser();
                    }
                }
            } finally {
                try {
                    isProcessing = false;
                    foreach (IRestoreListener listener in listeners) {
                        listener.RestoreDone(damagedFilesList);
                    }
                } catch (Exception ex) {
                    isProcessing = false;
                    foreach (IRestoreListener listener in listeners) {
                        listener.RestoreAbortedByError(ex);
                    }
                }
            }
        }


        /// <summary>
        /// Verificar se pode-se obter permissão para alterar arquivos na Unidade
        /// de Backup. São três condições a serem verificadas:
        /// 
        /// <br><br></br></br>
        /// 
        /// <ol>
        /// 
        /// <li>
        /// <b>Bloqueio da Unidade de Backup</b>: A Unidade de Backup está bloqueada
        /// para o processo corrente. Desta forma, nenhum outro processo poderá alterar
        /// arquivos nela.
        /// </li>
        /// 
        /// <br></br>
        /// 
        /// <li>
        /// <b>Restauração pendente</b>: Uma operação de restauração de arquivos para
        /// o sistema local está pendente. Desta forma, será necessário concluir esta
        /// operação para continuar a usar a Unidade de Backup.
        /// </li>
        /// 
        /// <br></br>
        /// 
        /// <li>
        /// <b>Instalação da Unidade de Backup</b>: A Unidade de Backup está instalada.
        /// A Unidade de Backup está instalada quando um conjunto de arquivos pré definidos
        /// estão presentes na raiz da Unidade de Backup.
        /// </li>
        /// 
        /// </ol>
        /// 
        /// </summary>
        /// <param name="checkLocked"></param>
        /// <param name="checkRestore"></param>
        /// <param name="checkInstalled"></param>
        /// <exception cref="Exception"></exception>
        private void CheckPermission(bool checkLocked, bool checkRestore, bool checkInstalled) {
            if (checkLocked) {
                if (!isLocked) {
                    throw new Exception("Precisa obter o bloqueio da Unidade de Backup.");
                }
            }
            if (checkRestore) {
                if (SafeRestore.IsPendingRestore) {
                    throw new Exception("Restauração de arquivos pendente.");
                }
            }
            if (checkInstalled) {
                if (!isInstalled) {
                    throw new Exception("Dispositivo não está instalado.");
                }
            }
        }


        /// <summary>
        /// Tenta obter o Mutex e travar o acesso à Unidade de Backup. Isto somente
        /// será possível se outra instância do programa ainda não obteve este acesso.
        /// Caso o Mutex já tenha sido obtido, só será possível esta operação caso a
        /// instância que o obteve faça o Unlock, ou o processo seja liberado da 
        /// memória. 
        /// </summary>
        /// <returns>True, obteve o bloqueio da Unidade de Backup. False, não obteve
        /// o bloqueio, pois outro processo já o alocou.</returns>
        public bool Lock() {
            if (mutex != null) {
                if (!mutex.WaitOne(1000, false)) {
                    isLocked = false;
                } else {
                    isLocked = true;
                }
            } else {
                isLocked = true;
            }
            return isLocked;
        }


        /// <summary>
        /// Libera o Mutex da Unidade de Backup. Desta forma, outro processo pode
        /// obtê-lo.
        /// </summary>
        public void Unlock() {
            if (isLocked) {
                if (mutex != null) {
                    mutex?.ReleaseMutex();
                    isLocked = false;
                }
            }
        }


        /// <summary>
        /// Verifica se se obteve o bloqueio da Unidade de Backup.
        /// </summary>
        public bool IsLocked {
            get {
                return isLocked;
            }
        }


        /// <summary>
        /// Verifica se o usuário abortou o processo corrente. Caso tenha abortado,
        /// o método lança uma exceção, que deverá ser capturada e tratada.
        /// </summary>
        /// <exception cref="Exception">Exceção lançada em caso de o usuário ter
        /// abortado o processo.</exception>
        private void CheckIfTheProcessHasBeenAborted() {
            lock (this) {
                if (abortedProcess) {
                    throw new Exception();
                }
            }
        }


        /// <summary>
        /// Libera todos os dados sobre a listagem dos arquivos e zera os contadores
        /// do processo.
        /// </summary>
        private void ReleaseCounters() {
            bytesToRecord = bytesToRelease = 0;
            abortedProcess = false;
            rootDirectoriesList.Clear();
            deletedDirectoriesList.Clear();
            createdDirectoriesList.Clear();
            createdFilesList.Clear();
            deletedFilesList.Clear();
            updatedFilesList.Clear();
            damagedFilesList.Clear();
            restoreFilesList.Clear();
            targetDrivesList.Clear();
        }


        /// <summary>
        /// Insere uma entrada no arquivo de Log. Uma entrada de Log tem o seguinte
        /// formato:
        /// 
        /// <br><br></br></br>
        /// 
        /// <example>
        /// <code>
        /// [M]$[Source Path]$[Target Path]$[Creation Time]$[Modif. Time]$[Size]$[Backup Time]
        /// </code>
        /// </example>
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
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="targetFile"></param>
        /// <param name="sourceFile"></param>
        private void InsertLogEntry(int mode, FileInfo targetFile, string sourceFile) {
            const char TOKEN = '\u0001';
            StringBuilder sb = new StringBuilder();
            sb.Append(mode.ToString());
            sb.Append(TOKEN);
            sb.Append(targetFile.FullName);
            sb.Append(TOKEN);
            sb.Append(sourceFile);
            sb.Append(TOKEN);
            sb.Append(Formatter.FormatDate(targetFile.CreationTime));
            sb.Append(TOKEN);
            sb.Append(Formatter.FormatDate(targetFile.LastWriteTime));
            sb.Append(TOKEN);
            sb.Append(targetFile.Length.ToString());
            sb.Append(TOKEN);
            sb.Append(Formatter.FormatDate(DateTime.Now));
            logEntriesList.AddLast(sb.ToString());
        }


        /// <summary>
        /// Insere os diretórios locais para o backup na Unidade de Backup. Na inserção,
        /// é feito o ordenamento da lista, em ordem crescente do path dos diretórios.
        /// </summary>
        /// <param name="directoriesList">Lista de diretórios as serem inseridos.</param>
        /// <returns>Lista dos diretórios que não foram inseridos.</returns>
        /// <exception cref="Exception"></exception>
        public List<string> InsertSourceDirectories(List<string> directoriesList) {
            CheckPermission(true, true, true);
            List<string> insertedList = new List<string>();
            List<string> excludedList = new List<string>();
            foreach (string directory in directoriesList) {
                bool insert = true;
                foreach (string localDirectory in localDirectoriesList) {
                    String relativePath1 = localDirectory.Substring(2, localDirectory.Length - 2).ToUpper();
                    string parentDir = directory;
                    do {
                        string relativePath2 = parentDir.Substring(2, parentDir.Length - 2).ToUpper();
                        if (relativePath1.ToUpper().Equals(relativePath2)) {
                            insert = false;
                            break;
                        }
                    } while ((parentDir = Path.GetDirectoryName(parentDir)) != null);
                    if (!insert) {
                        break;
                    }
                }
                if (insert) {
                    insertedList.Add(directory);
                } else {
                    excludedList.Add(directory);
                }
            }
            if (insertedList.Count > 0) {
                foreach (string directory in localDirectoriesList) {
                    insertedList.Add(directory);
                }
                insertedList.Sort();
                localDirectoriesList.Clear();
                foreach (string directory in insertedList) {
                    localDirectoriesList.AddLast(directory);   
                }
                directoriesFile.Write(localDirectoriesList);
            }
            readmeFile.Delete();
            readmeFile.Write(localDirectoriesList);
            return excludedList;
        }


        /// <summary>
        /// Inserir um diretório local para o backup na Unidade de Backup.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns>Lista contendo o próprio diretório, se ele não pode ser
        /// inserido.</returns>
        public List<string> InsertSourceDirectory(string directory) {
            List<string> list = new List<string>() { directory };
            return InsertSourceDirectories(list);
        }


        /// <summary>
        /// Excluir diretórios locais que estão na lista de diretórios para
        /// backup na Unidade de Backup.
        /// </summary>
        /// <param name="directoriesList">Lista dos diretórios a serem excluídos.</param>
        /// <exception cref="Exception"></exception>
        public void DeleteSourceDirectories(List<string> directoriesList) {
            CheckPermission(true, true, true);
            foreach (string directory in directoriesList) {
                localDirectoriesList.Remove(directory);
            }
            directoriesFile.Write(localDirectoriesList);
        }


        /// <summary>
        /// Abortar o processo corrente.
        /// </summary>
        public void AbortProcess() {
            lock (this) {
                abortedProcess = true;
            }
        }


        /// <summary>
        /// Obter o arquivo de log de backup.
        /// </summary>
        public BackupLogFile LogFile {
            get {
                return backupLogFile;
            }
        }


        /// <summary>
        /// Obter a lista dos diretórios locais sob controle de backup na
        /// Unidade de Backup.
        /// </summary>
        public LinkedList<string> SourceDirectories {
            get {
                return localDirectoriesList;
            }
        }


        /// <summary>
        /// Obtém os drives locais de origem do backup.
        /// </summary>
        public List<string> SourceDrives {
            get {
                List<string> drivesList = new List<string>();
                List<string> list = new List<string>(Directory.GetDirectories(Letter + @"\backup"));
                foreach (String dir in list) {
                    drivesList.Add(String.Concat(dir.Substring(10, 1), ":"));
                }
                return drivesList;
            }
        }


        /// <summary>
        /// Obter a letra do drive.
        /// </summary>
        public string Letter {
            get {
                return driveInfo.Name.Substring(0, 2);
            }
        }


        /// <summary>
        /// Obter o rótulo do drive.
        /// </summary>
        public string VolumeLabel {
            get {
                if (driveInfo.VolumeLabel != null && !driveInfo.VolumeLabel.Equals("")) {
                    return driveInfo.VolumeLabel;
                } else {
                    return "Unidade de Backup";
                }  
            }
        }


        /// <summary>
        /// Status de Unidade de Backup instalada. Se True, ela está instalada. Se False,
        /// ela não está instalada.
        /// </summary>
        public bool IsInstalled {
            get {
                return isInstalled;
            }
        }


        /// <summary>
        /// Obter a capacidade de armazenamento (em bytes) do drive.
        /// </summary>
        public long Size {
            get {
                return driveInfo.TotalSize;
            }
        }


        /// <summary>
        /// Obter o espaço livre (em bytes) no drive.
        /// </summary>
        public long FreeSpace {
            get {
                return driveInfo.TotalFreeSpace;
            }
        }


        /// <summary>
        /// Obter o Unit Identifier (Indentificar da Unidade) da Unidade de Backup.
        /// </summary>
        public string UID {
            get {
                return uid;
            }
        }


        /// <summary>
        /// Obter a data de instalação da Unidade de Backup.
        /// </summary>
        public DateTime InstallationTime {
            get {
                return installationTime;
            }
        }


        /// <summary>
        /// Obter a data do último backup realizado na Unidade de Backup.
        /// </summary>
        public DateTime LastBackupTime {
            get {
                return lastBackupTime;
            }
        }


        /// <summary>
        /// Status de backup realizado na Unidade de Backup. Se True, já foi realizado
        /// backup na Unidade de backup. Se False, nunca foi realizado backup na Unidade
        /// de Backup.
        /// </summary>
        public bool HaveLastBackupTime {
            get {
                return haveLastBackupTime;
            }
        }


        /// <summary>
        /// Obtém o formato do sistema de arquivos do drive (NTFS, FAT, etc).
        /// </summary>
        public string FileSystemFormat {
            get {
                return driveInfo.DriveFormat;
            }
        }


        /// <summary>
        /// Obter o diretório raiz do drive.
        /// </summary>
        public string RootDirectory {
            get {
                return driveInfo.RootDirectory.FullName;
            }
        }


        /// <summary>
        /// Sobrescrito para retornar a letra do drive.
        /// </summary>
        /// <returns>Letra da Unidade de backup</returns>
        public override string ToString() {
            return driveInfo.Name.Substring(0, 2);
        }


        /// <summary>
        /// Obter a descrição textual do drive.
        /// </summary>
        public string Description {
            get {
                return VolumeLabel + " [ " + driveInfo.Name.Substring(0, 2) + " ]";
            }
        }


        /// <summary>
        /// Obter o tipo do drive.
        /// </summary>
        public DriveType Type {
            get {
                return driveType;
            }
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (!(obj is Drive)) {
                return false;
            }
            return driveInfo.Name.Equals(((Drive)obj).driveInfo.Name);
        }


        public override int GetHashCode() {
            return base.GetHashCode();
        }


    }

}