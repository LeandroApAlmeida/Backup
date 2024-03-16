using System.Collections.Generic;
using System.ComponentModel;
using System.Management;

namespace Backup.Environment {

    /// <summary>
    /// Processo em segundo plano que monitora os eventos de inserção/remoção de
    /// dispositivos periféricos nas portas USB do computador.
    /// </summary>
    public class UsbMonitor {


        // Processo em segundo plano.
        private BackgroundWorker backgroundWorker;

        // Lista dos ouvintes de eventos das portas USB.
        private List<IUsbEventListener> listeners;

        // Intância única da classe.
        private static UsbMonitor instance = new UsbMonitor();


        /// <summary>
        /// Constructor private para não permitir a criação de múltiplas instâncias da classe.
        /// </summary>
        private UsbMonitor() {
            listeners = new List<IUsbEventListener>();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(bgwDriveDetector_DoWork);
            backgroundWorker.RunWorkerAsync();
        }


        /// <summary>
        /// Adicionar um ouvinte de eventos nas portas USB.
        /// </summary>
        /// <param name="listener">Ouvinte de eventos a ser adicionado.</param>
        public void AddListener(IUsbEventListener listener) {
            listeners.Add(listener);
        }


        /// <summary>
        /// Remover um ouvinte de eventos nas portas USB.
        /// </summary>
        /// <param name="listener">Ouvinte de eventos a ser removido</param>
        public void RevomeListener(IUsbEventListener listener) {
            listeners.Remove(listener);
        }


        /// <summary>
        /// Obter a instância única da classe.
        /// </summary>
        public static UsbMonitor Instance {
            get {
                return instance;
            }
        }


        /// <summary>
        /// Iniciar o monitoramento das portas USB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwDriveDetector_DoWork(object sender, DoWorkEventArgs e) {
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += DeviceInsertedEvent;
            insertWatcher.Start();
            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += DeviceRemovedEvent;
            removeWatcher.Start();
        }


        /// <summary>
        /// Notificação de evento de periférico inserido numa porta USB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e) {
            foreach (IUsbEventListener listener in listeners) {
                listener.DeviceInserted(sender, e);
            }
        }


        /// <summary>
        /// Notificação de evento de periférico removido de uma porta USB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e) {
            foreach (IUsbEventListener listener in listeners) {
                listener.DeviceRemoved(sender, e);
            }
        }


    }

}
