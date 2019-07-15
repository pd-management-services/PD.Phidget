namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using PD.Phidget.UserInterface.Configurator.View;
    using Phidget22;

    public class AddressingInformationViewModel : BindableObject, IMaintainableViewModel {
        Phidget phidget;

        public AddressingInformationViewModel(Phidget phidget) {
            this.phidget = phidget;
        }

        public int DeviceHubSerialNumber => phidget.DeviceSerialNumber;

        public int HubPort => phidget.HubPort;

        public int DeviceChannel => phidget.Channel;

        public bool IsHubPortDevice => phidget.IsHubPortDevice;

        public ChannelClass ChannelClass => phidget.ChannelClass;

        public string NetworkServer => phidget.ServerHostname;

        public string IPAddressAndPort => phidget.ServerPeerName;

        public void ShowMaintenanceWindow() {
            this.ShowMaintenanceWindow<AddressingInformationWindow>();
        }
    }
}
