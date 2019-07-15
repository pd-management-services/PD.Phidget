namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using PD.Phidget.UserInterface.Configurator.View;
    using Phidget22;

    public class HumiditySensorViewModel : MaintainablePhidgetViewModelBase<HumiditySensor> {
        public HumiditySensorViewModel(HumiditySensor phidget) : base(phidget) { }

        public override string AttachmentInfo => $"{phidget.DeviceFirmwareUpgradeString} - {phidget.DeviceName}";

        public double Humidity => phidget.Humidity;

        public double MaxChangeTrigger => 100;

        public double MinChangeTrigger => 0;

        public int DataInterval {
            get => phidget.DataInterval;
            set {
                if (value == phidget.DataInterval) return;
                phidget.DataInterval = value;
                RaisePropertyChanged("DataInterval");
            }
        }

        public double ChangeTrigger {
            get => phidget.HumidityChangeTrigger;
            set {
                if (value == phidget.HumidityChangeTrigger) return;
                phidget.HumidityChangeTrigger = value;
                RaisePropertyChanged("ChangeTrigger");
            }
        }

        public int MaxDataInterval => 60000;

        public int MinDataInterval => 500;

        public override void ShowMaintenanceWindow() {
            base.ShowMaintenanceWindow();

            phidget.Attach += (o, e) => {
                RaisePropertyChanged("MinChangeTrigger");
                RaisePropertyChanged("MaxChangeTrigger");
                RaisePropertyChanged("MinDataInterval");
                RaisePropertyChanged("MaxDataInterval");
            };
            phidget.Detach += (o, e) => { };
            phidget.HumidityChange += (o, e) => {
                RaisePropertyChanged("DataInterval");
                RaisePropertyChanged("ChangeTrigger");
                RaisePropertyChanged("Humidity");
            };
            this.ShowMaintenanceWindow<HumiditySensorInputMaintenanceWindow>();
            phidget.Open();
        }

        protected override void HandleDetachFromPhidgetSpecificEvents() {
            phidget.HumidityChange += null;
        }
    }
}
