namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using PD.Phidget.UserInterface.Configurator.View;
    using Phidget22;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class DictionaryViewModel : MaintainablePhidgetViewModelBase<Dictionary> {
        string serverName;
        string hostName;
        string address;
        ILogLevelViewModel selectedLogLevel;

        public DictionaryViewModel(Dictionary phidget) : base(phidget) { }

        public override string AttachmentInfo => throw new System.NotImplementedException();

        public override bool AddPhidget(IPhidgetViewModel viewModel) { return false; }

        public string ServerName {
            get => serverName;
            private set {
                serverName = value;
                RaisePropertyChanged("ServerName");
            }
        }

        public string HostName {
            get => hostName;
            private set {
                hostName = value;
                RaisePropertyChanged("HostName");
            }
        }

        public string Address {
            get => address;
            private set {
                address = value;
                RaisePropertyChanged("Address");
            }
        }

        public ObservableCollection<ILogLevelViewModel> LogLevels { get; } = PopulateLogLevels();

        public ILogLevelViewModel SelectedLogLevel {
            get => selectedLogLevel;
            set {
                if (value == selectedLogLevel) return;
                selectedLogLevel = value;
                RaisePropertyChanged("SelectedLogLevel");
            }
        }

        static ObservableCollection<ILogLevelViewModel> PopulateLogLevels() {
            var collection = new ObservableCollection<ILogLevelViewModel>();
            foreach (var value in new LogLevelViewModels()) {
                collection.Add(value);
            }
            return collection;
        }

        public override void ShowMaintenanceWindow() {
            base.ShowMaintenanceWindow();

            phidget.Attach += (o, e) => {
                if (o is Dictionary) {
                    var dictionary = o as Dictionary;
                    ServerName = dictionary.ServerUniqueName;
                    HostName = dictionary.ServerHostname;
                    Address = dictionary.ServerPeerName;
                    SelectedLogLevel = LogLevels.Where(viewModel => viewModel.LogLevel == LogLevel.Info).FirstOrDefault(); //Not sure if you can pick this up from somewhere specifically.
                }
            };
            phidget.Detach += (o, e) => { };
            this.ShowMaintenanceWindow<DictionaryMaintenanceWindow>();
            phidget.Open();
        }

        protected override void HandleDetachFromPhidgetSpecificEvents() { }
    }
}
