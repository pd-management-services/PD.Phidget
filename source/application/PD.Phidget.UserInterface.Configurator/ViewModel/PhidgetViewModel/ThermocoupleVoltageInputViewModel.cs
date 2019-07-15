namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;
    using PD.Phidget.UserInterface.Configurator.View;

    public class ThermocoupleVoltageInputViewModel : MaintainablePhidgetViewModelBase<VoltageInput> {
        public ThermocoupleVoltageInputViewModel(VoltageInput phidget) : base(phidget) { }

        public override string AttachmentInfo => $"{phidget.Parent.Parent.DeviceSKU} - {phidget.Parent.Parent.DeviceName}";

        public double Voltage => phidget.Voltage;

        public double MaxChangeTrigger => 0.09;

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
            get => phidget.VoltageChangeTrigger;
            set {
                if (value == phidget.VoltageChangeTrigger) return;
                phidget.VoltageChangeTrigger = value;
                RaisePropertyChanged("ChangeTrigger");
            }
        }

        public int MaxDataInterval => 6000;

        public int MinDataInterval => 20;

        public override bool AddPhidget(IPhidgetViewModel viewModel) { return false; }

        public override void ShowMaintenanceWindow() {
            base.ShowMaintenanceWindow();

            phidget.Attach += (o, e) => {
                RaisePropertyChanged("MinChangeTrigger");
                RaisePropertyChanged("MaxChangeTrigger");
                RaisePropertyChanged("MinDataInterval");
                RaisePropertyChanged("MaxDataInterval");
            };
            phidget.Detach += (o, e) => { };
            phidget.VoltageChange += (o, e) => {
                RaisePropertyChanged("DataInterval");
                RaisePropertyChanged("ChangeTrigger");
                RaisePropertyChanged("Voltage");
            };
            this.ShowMaintenanceWindow<ThermocoupleVoltageInputMaintenanceWindow>();
            phidget.Open();

        }

        protected override void HandleDetachFromPhidgetSpecificEvents() {
            phidget.VoltageChange += null;
        }
    }
}
