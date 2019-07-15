namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;

    public interface IPhidgetViewModel {
        DeviceID DeviceId { get; }
        string DeviceName { get; }
        int SerialNumber { get; }
        int PortNumber { get; }
        int Channel { get; }
        int Version { get; }
        string ServerHostName { get; }
        ChannelClass ChannelClass { get; }
        string ChannelName { get; }
        ChannelSubclass ChannelSubClass { get; }
        string ChannelClassName { get; }

        bool AddPhidget(IPhidgetViewModel phidgetViewModel);
    }
}
