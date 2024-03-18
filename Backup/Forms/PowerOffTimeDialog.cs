using Backup.Environment;
using Backup.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backup.Forms {

    /// <summary>
    /// Diálogo para desligamento automático do computador. No constructor será
    /// definido o tempo de desligamento, no mínimo 5 segundos e no máximo 5
    /// minutos. Não passando nenhum parâmetro, o intervalo padrão é de 1 minuto.
    /// </summary>
    public partial class PowerOffTimeDialog : Form {


        // Intervalo em segundos até o desligamento do computador.
        private int secondsInterval;
        

        /// <summary>
        /// Constructor da classe. Recebe o número de segundos até o desligamento
        /// do computador.
        /// </summary>
        /// <param name="secondsInterval">Número de segundos para o desligamento do
        /// computador.</param>
        /// <exception cref="ArgumentException">Intervalo fora do padrão.</exception>
        public PowerOffTimeDialog(int secondsInterval = 60) {
            if (secondsInterval < 5 || secondsInterval > 300) {
                throw new ArgumentException(
                    "Intervalo deve estar entre 5 segundos e 5 minutos"
                );
            }
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            int minutes = (secondsInterval / 60);
            int seconds = (secondsInterval % 60);
            lblTime.Text = Formatter.FormatInt(minutes, 2) + ":" +
            Formatter.FormatInt(seconds, 2);
            this.secondsInterval = secondsInterval;
            timChronometer.Interval = 1000;
            timChronometer.Start();
        }


        /// <summary>
        /// Desliga o computador.
        /// </summary>
        private void PowerOff() {
            WindowsSystem.Shutdown();
        }


        private void timChronometer_Tick(object sender, EventArgs e) {
            secondsInterval--;
            if (secondsInterval > 0) {
                int minutes = (secondsInterval / 60);
                int seconds = (secondsInterval % 60);
                lblTime.Text = Formatter.FormatInt(minutes, 2) + ":" + 
                Formatter.FormatInt(seconds, 2);
            } else {
                timChronometer.Stop();
                PowerOff();
            }
        }


        private void btnCancelShutdown_Click(object sender, EventArgs e) {
            timChronometer.Stop();
            Close();
        }


        private void bntShutdownNow_Click(object sender, EventArgs e) {
            timChronometer.Stop();
            PowerOff();
        }


    }

}
