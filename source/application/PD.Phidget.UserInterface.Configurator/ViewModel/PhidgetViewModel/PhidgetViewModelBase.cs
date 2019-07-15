namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;

    public abstract class PhidgetViewModelBase<T> : BindableObject, IPhidgetViewModel where T : Phidget {
        protected readonly T phidget;

        public PhidgetViewModelBase(T phidget) {
            this.phidget = phidget;
        }

        public virtual string Info => $"{DeviceId} {DeviceName} {ServerHostName} {SerialNumber} Hub Port: {PortNumber} {Version} {Channel} {ChannelClassName} {ChannelName} + {phidget.DeviceVINTID} {phidget.IsChannel} {phidget.IsLocal} {phidget.IsRemote}  {phidget.Attached} {phidget.ServerPeerName} {phidget.ServerUniqueName}";

        public DeviceID DeviceId => phidget.DeviceID;

        public string DeviceName => phidget.DeviceName;

        public Phidget Parent => phidget.Parent;

        public bool Remote => phidget.IsRemote;

        public string ServerHostName => phidget.ServerHostname;

        public int SerialNumber => phidget.DeviceSerialNumber;

        public int PortNumber => phidget.HubPort;

        public int Version => phidget.DeviceVersion;

        public int Channel => phidget.Channel;

        public ChannelClass ChannelClass => phidget.ChannelClass;

        public string ChannelClassName => phidget.ChannelClassName;

        public string ChannelName => phidget.ChannelName;

        public ChannelSubclass ChannelSubClass => phidget.ChannelSubclass;

        public virtual bool AddPhidget(IPhidgetViewModel viewModel) { return false; }
    }
}
