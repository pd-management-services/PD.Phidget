namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using System.Collections.ObjectModel;

    public interface IPhidgetServerViewModel {
        string Name { get; }
        string HostName { get; }
        string IPAddress { get; }
        /*
        string MACAddress { get; }
        int Version { get; }
        string Firmware { get; }
        */
        int CommunicationPort { get; }
        ObservableCollection<IPhidgetViewModel> Phidgets { get; }
        int Flags { get; }
        void AddPhidget(IPhidgetViewModel phidgetViewModel);
    }
}
