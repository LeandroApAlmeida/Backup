using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.Drive {

    public class DamageInfo {


        private string filePath;

        private string errorMessage;


        public DamageInfo(string filePath, string errorMessage) {
            this.filePath = filePath;
            this.errorMessage = errorMessage;
        }


        public string FilePath {
            get {
                return filePath;
            }
        }


        public string ErrorMessage {
            get {
                return errorMessage;
            }
        }


    }

}
