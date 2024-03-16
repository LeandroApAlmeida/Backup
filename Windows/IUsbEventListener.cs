using System.Management;

namespace Backup.Environment {

    /// <summary>
    /// Define um ouvinte de eventos nas portas USB.
    /// </summary>
    public interface IUsbEventListener {

        /// <summary>
        /// Evento de dispositivo periférico conectado a uma porta USB.
        /// </summary>
        void DeviceInserted(object sender, EventArrivedEventArgs e);

        /// <summary>
        /// Evento de dispositivo periférico desconectado de uma porta USB.
        /// </summary>
        void DeviceRemoved(object sender, EventArrivedEventArgs e);

    }

}
