namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using PD.Phidget.UserInterface.Configurator.View;
    using Phidget22;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class ThermocoupleInputViewModel : MaintainablePhidgetViewModelBase<TemperatureSensor> {
        string temperature;
        IThermocoupleTypeViewModel selectedThermocoupleType;

        public ThermocoupleInputViewModel(TemperatureSensor phidget) : base(phidget) { }

        public ObservableCollection<IThermocoupleTypeViewModel> ThermocoupleTypes { get; } = PopulateThermocoupleTypes();

        public IThermocoupleTypeViewModel SelectedThermocoupleType {
            get => selectedThermocoupleType;
            set {
                if (value == selectedThermocoupleType) return;
                selectedThermocoupleType = value;
                RaisePropertyChanged("SelectedThermocoupleType");
            }
        }

        static ObservableCollection<IThermocoupleTypeViewModel> PopulateThermocoupleTypes() {
            var collection = new ObservableCollection<IThermocoupleTypeViewModel>();
            foreach (var value in new ThermocoupleTypesViewModel()) {
                collection.Add(value);
            }
            return collection;
        }

        public override string AttachmentInfo => $"{phidget.Parent.DeviceFirmwareUpgradeString} - {phidget.Parent.DeviceName}";

        public override bool AddPhidget(IPhidgetViewModel viewModel) { return false; }

        public string Temperature {
            get => temperature;
            private set {
                if (value == temperature) return;
                temperature = value;
                RaisePropertyChanged("Temperature");
            }
        }

        public double MinChangeTrigger => phidget.MinTemperatureChangeTrigger;

        public double MaxChangeTrigger => phidget.MaxTemperatureChangeTrigger;

        public double ChangeTrigger {
            get => phidget.TemperatureChangeTrigger;
            set {
                if (value == phidget.TemperatureChangeTrigger) return;
                phidget.TemperatureChangeTrigger = value;
                RaisePropertyChanged("ChangeTrigger");
            }
        }

        public int MinDataInterval => phidget.MinDataInterval;

        public int MaxDataInterval => phidget.MaxDataInterval;

        public int DataInterval {
            get => phidget.DataInterval;
            set {
                if (value == phidget.DataInterval) return;
                phidget.DataInterval = value;
                RaisePropertyChanged("DataInterval");
            }
        }

        protected override void HandleError() {
            base.HandleError();
            Temperature = "???";
        }

        public override void ShowMaintenanceWindow() {
            base.ShowMaintenanceWindow();

            phidget.Attach += (o, e) => {
                if(o is TemperatureSensor) {
                    var sensor = o as TemperatureSensor;
                    SelectedThermocoupleType = ThermocoupleTypes.Where(x => x.Type == sensor.ThermocoupleType).FirstOrDefault();
                    RaisePropertyChanged("MinChangeTrigger");
                    RaisePropertyChanged("MaxChangeTrigger");
                    RaisePropertyChanged("MinDataInterval");
                    RaisePropertyChanged("MaxDataInterval");
                }
            };
            phidget.Detach += (o, e) => { };
            phidget.TemperatureChange += (o, e) => {
                Temperature = e.Temperature.ToString() + " °C";
                RaisePropertyChanged("DataInterval");
                RaisePropertyChanged("ChangeTrigger");
            };
            this.ShowMaintenanceWindow<ThermocoupleInputMaintenanceWindow>();
            phidget.Open();
        }

        protected override void HandleDetachFromPhidgetSpecificEvents() {
            phidget.TemperatureChange += null;
        }
    }
}
