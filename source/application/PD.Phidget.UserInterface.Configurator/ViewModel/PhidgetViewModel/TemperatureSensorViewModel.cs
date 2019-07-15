namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using PD.Phidget.UserInterface.Configurator.View;
    using Phidget22;

    public class TemperatureSensorViewModel : MaintainablePhidgetViewModelBase<TemperatureSensor> {
        double temperature;

        public TemperatureSensorViewModel(TemperatureSensor phidget) : base(phidget) { }

        public TemperatureSensor Phidget => base.phidget as TemperatureSensor;
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

        public int MinDataInterval => 1;

        public int MaxDataInterval => 6000;

        public int DataInterval {
            get => phidget.DataInterval;
            set {
                if (value == phidget.DataInterval) return;
                phidget.DataInterval = value;
                RaisePropertyChanged("DataInterval");
            }
        }

        public override string AttachmentInfo => $"{phidget.Parent.DeviceFirmwareUpgradeString} - {phidget.Parent.DeviceName}";

        public double Temperature {
            get => temperature;
            private set {
                if (value == temperature) return;
                temperature = value;
                RaisePropertyChanged("Temperature");
            }
        }

        public override bool AddPhidget(IPhidgetViewModel viewModel) { return false; }

        public override void ShowMaintenanceWindow() {
            base.ShowMaintenanceWindow();

            phidget.TemperatureChange += (o, e) => {
                Temperature = e.Temperature;
                RaisePropertyChanged("DataInterval");
                RaisePropertyChanged("ChangeTrigger");
            };
            phidget.Attach += (o, e) => {
                RaisePropertyChanged("MinChangeTrigger");
                RaisePropertyChanged("MaxChangeTrigger");
                RaisePropertyChanged("MinDataInterval");
                RaisePropertyChanged("MaxDataInterval");
            };
            phidget.Detach += (o, e) => { };
            this.ShowMaintenanceWindow<TemperatureSensorMaintenanceWindow>();
            phidget.Open();
        }

        protected override void HandleDetachFromPhidgetSpecificEvents() {
            phidget.TemperatureChange += null;
        }
    }
}
