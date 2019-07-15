namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using PD.Phidget.UserInterface.Configurator.View;
    using Phidget22;
    using System.Collections.ObjectModel;

    public class VoltageInputViewModel : MaintainablePhidgetViewModelBase<VoltageInput> {

        public VoltageInputViewModel(VoltageInput phidget) : base(phidget) { }

        public override bool AddPhidget(IPhidgetViewModel viewModel) { return false; }

        public override string AttachmentInfo=> $"{phidget.Parent.Parent.DeviceSKU} - {phidget.Parent.Parent.DeviceName}";

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
            this.ShowMaintenanceWindow<VoltageInputMaintenanceWindow>();
            phidget.Open();
        }

        public VoltageSensorType SelectedSensorType => phidget.SensorType;

        public double Voltage => phidget.Voltage;

        public double MaxChangeTrigger => 5;

        public double MinChangeTrigger => 0;

        public int MaxDataInterval => 6000;

        public int MinDataInterval => 1;

        public ObservableCollection<IVoltageSensorTypeViewModel> SensorTypes { get; } = PopulateSensorTypes();

        static ObservableCollection<IVoltageSensorTypeViewModel> PopulateSensorTypes() {
            var collection = new ObservableCollection<IVoltageSensorTypeViewModel>();
            foreach (var value in new VoltageSensorTypes()) {
                collection.Add(value);
            }
            return collection;
        }
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

        protected override void HandleDetachFromPhidgetSpecificEvents() {
            phidget.PropertyChange += null;
            phidget.SensorChange += null;
            phidget.VoltageChange += null;
        }
    }
}
