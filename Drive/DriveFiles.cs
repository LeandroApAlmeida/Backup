using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.Drive {

    public class DriveFiles {


        private readonly String targetDrive;

        private readonly LinkedList<FileInfo> filesList;


        public DriveFiles(String targetDrive) {
            filesList = new LinkedList<FileInfo>();
            this.targetDrive = targetDrive;  
        }


        public String TargetDrive {
            get {
                return targetDrive;
            }
        }


        public LinkedList<FileInfo> Files {
            get {
                return filesList;
            } 
        }


    }

}
