namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using System.Collections.ObjectModel;
    using System.Linq;
    using Phidget22;

    public class PhidgetServerViewModel : BindableObject, IPhidgetServerViewModel {
        readonly PhidgetServer server;

        public PhidgetServerViewModel(PhidgetServer server) {
            this.server = server;
            RaisePropertyChanged("IPAddress");
            RaisePropertyChanged("Name");
            RaisePropertyChanged("HostName");
            RaisePropertyChanged("CommunicationPort");
        }

        public string Name { get => server.Name; }

        public string HostName { get => server.Hostname; }

        public string IPAddress { get => server.Address; }

        public int CommunicationPort { get => server.Port; }

        public int Flags { get => server.Flags; }

        public ObservableCollection<IPhidgetViewModel> Phidgets { get; } = new ObservableCollection<IPhidgetViewModel>();

        public void AddPhidget(IPhidgetViewModel phidgetViewModel) {
            if (phidgetViewModel.ServerHostName == server.Hostname) {
                if (!(Phidgets.Any(x => x.AddPhidget(phidgetViewModel)))) {
                    Phidgets.Add(phidgetViewModel);
                }
            }
        }
    }
}
