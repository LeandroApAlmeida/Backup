using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;

namespace Backup.Windows {


    /// <summary>
    /// Classe para acesso nativo à API do Microsoft Windows e execução de 
    /// querys WMI (Windows Management Instrumentation). Também serve para o 
    /// uso de programas do sistema como CMD, PowerShell e Windows Explorer.
    /// </summary>
    public static class WindowsSystem {




        #region Windows drives management


        /// <summary>
        /// Obter a lista com todos os drives de acordo com o critério definido.
        /// </summary>
        /// <param name="driveType">Tipo do drive.</param>
        /// <returns>Lista com todos os drives de acordo com o critério.</returns>
        public static List<DriveInfo> GetDrives(DriveType driveType) {
            var drives = DriveInfo.GetDrives();
            var drivesList = new List<DriveInfo>();
            if (driveType != DriveType.NETWORK) {
                var allPhysicalDisks = new ManagementObjectSearcher(
                    "select MediaType, DeviceID from Win32_DiskDrive"
                ).Get();
                foreach (var physicalDisk in allPhysicalDisks) {
                    var allPartitionsOnPhysicalDisk = new ManagementObjectSearcher(
                        $"associators of {{Win32_DiskDrive.DeviceID='{physicalDisk["DeviceID"]}'}} where AssocClass = Win32_DiskDriveToDiskPartition"
                    ).Get();
                    foreach (var partition in allPartitionsOnPhysicalDisk) {
                        if (partition == null) {
                            continue;
                        }
                        var allLogicalDisksOnPartition = new ManagementObjectSearcher(
                            $"associators of {{Win32_DiskPartition.DeviceID='{partition["DeviceID"]}'}} where AssocClass = Win32_LogicalDiskToPartition"
                        ).Get();
                        foreach (var logicalDisk in allLogicalDisksOnPartition) {
                            if (logicalDisk == null) {
                                continue;
                            }
                            var driveInfo = drives.Where(x => x.Name.StartsWith(
                                logicalDisk["Name"] as string,
                                StringComparison.OrdinalIgnoreCase)
                            ).FirstOrDefault();
                            if (driveInfo != null) {
                                var mediaType = (physicalDisk["MediaType"] as string).ToLowerInvariant();
                                if (driveType == DriveType.EXTERNAL) {
                                    if (mediaType.Contains("external") || mediaType.Contains("removable")) {
                                        drivesList.Add(driveInfo);
                                    }
                                } else if (driveType == DriveType.INTERNAL) {
                                    if (mediaType.Contains("fixed")) {
                                        drivesList.Add(driveInfo);
                                    }
                                }
                            }
                        }
                    }
                }
            } else {
                var networkDrives = new ManagementObjectSearcher(
                    "select * from Win32_MappedLogicalDisk"
                );
                foreach (ManagementObject drive in networkDrives.Get()) {
                    foreach (DriveInfo driveInfo in drives) {
                        string id = drive["DeviceID"].ToString();
                        if (driveInfo.Name.Substring(0, 2).Equals(id)) {
                            drivesList.Add(driveInfo);
                        }
                    }
                }
            }
            return drivesList;
        }


        /// <summary>
        /// Formatar um drive.
        /// </summary>
        /// <param name="letter">Letra do drive. Exemplo: E:</param>
        /// <param name="fileSystem">Formato do sistema de arquivos.</param>
        /// <param name="label">Rótulo do drive</param>
        public static void FormatDrive(string letter, string fileSystem, string label) {
            if (label.Contains(" ")) {
                label = label.Replace(" ", "_");
            }
            bool quickFormat = true;
            bool enableCompression = false;
            int? clusterSize = null;
            var psi = new ProcessStartInfo();
            psi.FileName = "format.com";
            psi.WorkingDirectory = System.Environment.SystemDirectory;
            psi.Arguments = "/FS:" + fileSystem + " /Y" + " /V:" + label +
            (quickFormat ? " /Q" : "") +
            ((fileSystem == "NTFS" && enableCompression) ? " /C" : "") +
            (clusterSize.HasValue ? " /A:" + clusterSize.Value : "") + " " + letter;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardInput = false;
            var process = Process.Start(psi);
            // Precisa esperar até terminar a formatação, pois após, serão gravados
            // os arquivos da instalação da Unidade de Backup.
            process.WaitForExit();
        }


        #endregion




        #region File system utilities


        /// <summary>
        /// Obter a descrição do arquivo, de acordo com sua extensão.
        /// </summary>
        /// <param name="path">Path do arquivo.</param>
        /// <returns>Descrição do arquivo.</returns>
        public static string GetFileDescription(string path) {
            FileInfo file = new FileInfo(path);
            string ext = file.Extension;
            if (ext.Equals(String.Empty)) {
                return "Unknown";
            }
            string extensionName = (string) Registry.GetValue("HKEY_CLASSES_ROOT\\" + ext, "", ext);
            return (string) Registry.GetValue("HKEY_CLASSES_ROOT\\" + extensionName, "", ext);
        }


        /// <summary>
        /// Estrair o ícone associado a um arquivo, de acordo com a sua extensão.
        /// </summary>
        /// <param name="path">Path do arquivo.</param>
        /// <returns>Ícone associado ao arquivo</returns>
        public static Icon ExtractFileIcon(string path) {
            return Icon.ExtractAssociatedIcon(path);
        }
     

        /// <summary>
        /// Abrir um arquivo com o programa default, de acordo com sua extensão.
        /// </summary>
        /// <param name="filePath">Path do arquivo.</param>
        public static void OpenFileWithDefaultProgram(string filePath) {
            Process.Start(filePath);
        }


        /// <summary>
        /// Ver documentação completa desta chamada de API do Windows disponível em
        /// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shopenfolderandselectitems
        /// </summary>
        [DllImport("shell32.dll", SetLastError = true)]
        private static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, uint cidl, 
        [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, uint dwFlags);

        /// <summary>
        /// Ver documentação completa desta chamada de API do Windows disponível em
        /// https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nf-shlobj_core-shparsedisplayname
        /// </summary>
        [DllImport("shell32.dll", SetLastError = true)]
        private static extern void SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string pszName,
        IntPtr pbc, [Out] out IntPtr ppidl, uint sfgaoIn, [Out] out uint psfgaoOut);

        /// <summary>
        /// Abrir a pasta de um arquivo e selecionar este arquivo dentro desta.
        /// </summary>
        /// <param name="file">Path do arquivo</param>
        public static void OpenFileFolder(string file) {
            FileInfo fileInfo = new FileInfo(file);
            string folderPath = fileInfo.DirectoryName;
            IntPtr nativeFolder;
            uint psfgaoOut;
            SHParseDisplayName(folderPath, IntPtr.Zero, out nativeFolder, 0, out psfgaoOut);
            if (nativeFolder == IntPtr.Zero) {
                return;
            }
            IntPtr nativeFile;
            SHParseDisplayName(file, IntPtr.Zero, out nativeFile, 0, out psfgaoOut);
            IntPtr[] fileArray;
            if (nativeFile == IntPtr.Zero) {
                fileArray = new IntPtr[0];
            } else {
                fileArray = new IntPtr[] { nativeFile };
            }
            SHOpenFolderAndSelectItems(nativeFolder, (uint)fileArray.Length, fileArray, 0);
            Marshal.FreeCoTaskMem(nativeFolder);
            if (nativeFile != IntPtr.Zero) {
                Marshal.FreeCoTaskMem(nativeFile);
            }
        }


        #endregion




        #region Power management


        /// <summary>
        /// Desliga o computador forçando o encerramento de todos os
        /// programas que estão abertos.
        /// </summary>
        public static void Shutdown() {
            var psi = new ProcessStartInfo();
            psi.FileName = "shutdown";
            psi.Arguments = "/s /f /t 0";
            psi.UseShellExecute = true;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardInput = false;
            Process.Start(psi);
        }


        #endregion




        #region Windows


        public static void SetEnviromentVariable() {
            var name = "Path";
            var target = EnvironmentVariableTarget.Machine;
            var oldValue = Environment.GetEnvironmentVariable(name, target);
            if (oldValue == null) {
                String newValue = String.Concat(oldValue, ";", Environment.SystemDirectory);
                Environment.SetEnvironmentVariable(name, newValue, target);
            }
        }


        #endregion




    }


}