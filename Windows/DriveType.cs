using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.Windows {

    /// <summary>
    /// Tipo do drive.
    /// </summary>
    public enum DriveType {
        /// <summary>
        /// Drive interno ao computador.
        /// </summary>
        INTERNAL,
        /// <summary>
        /// Drive externo ao computador.
        /// </summary>
        EXTERNAL,
        /// <summary>
        /// Drive de rede.
        /// </summary>
        NETWORK
    }

}
