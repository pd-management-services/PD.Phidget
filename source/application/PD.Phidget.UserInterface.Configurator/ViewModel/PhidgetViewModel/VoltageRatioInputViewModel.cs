namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using System.Collections.ObjectModel;
    using System.Linq;
    using PD.Phidget.UserInterface.Configurator.View;
    using Phidget22;

    public class VoltageRatioInputViewModel : MaintainablePhidgetViewModelBase<VoltageRatioInput> {
        IVoltageRatioSensorTypeViewModel selectedSensorType;

        public VoltageRatioInputViewModel(VoltageRatioInput phidget) : base(phidget) { }

        public double VoltageRatio => phidget.VoltageRatio;

        public double MinChangeTrigger => phidget.MinVoltageRatioChangeTrigger;

        public double MaxChangeTrigger => phidget.MaxVoltageRatioChangeTrigger;

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

        public double ChangeTrigger {
            get => phidget.VoltageRatioChangeTrigger;
            set {
                if (value == phidget.VoltageRatioChangeTrigger) return;
                phidget.VoltageRatioChangeTrigger = value;
                RaisePropertyChanged("ChangeTrigger");
            }
        }

        public string formattedSensorValue;

        public string FormattedSensorValue {
            get { return formattedSensorValue; }
            set {
                if (value == formattedSensorValue) return;
                formattedSensorValue = value;
                RaisePropertyChanged("FormattedSensorValue");
            }
        }

        public ObservableCollection<IVoltageRatioSensorTypeViewModel> VoltageRatioInputSensorTypes { get; } = PopulateVoltageRatioInputSensorTypes();

        public IVoltageRatioSensorTypeViewModel SelectedSensorType {
            get => selectedSensorType;
            set {
                if (value == selectedSensorType) return;
                selectedSensorType = value;
                phidget.SensorType = selectedSensorType.Type;
                FormattedSensorValue = "";
                RaisePropertyChanged("SelectedSensorType");
            }
        }

        static ObservableCollection<IVoltageRatioSensorTypeViewModel> PopulateVoltageRatioInputSensorTypes() {
            var collection = new ObservableCollection<IVoltageRatioSensorTypeViewModel>();
            foreach (var value in new VoltageRatioInputSensorTypes()) {
                collection.Add(value);
            }
            return collection;
        }

        public override string AttachmentInfo => $"{phidget.Parent.Parent.DeviceFirmwareUpgradeString.Substring(0, phidget.Parent.Parent.DeviceFirmwareUpgradeString.Length - 2)} - {phidget.Parent.Parent.DeviceName}";

        public override void ShowMaintenanceWindow() {
            base.ShowMaintenanceWindow();
            phidget.Attach += (o, e) => {
                if (o is VoltageRatioInput) {
                    var sensor = o as VoltageRatioInput;
                    SelectedSensorType = VoltageRatioInputSensorTypes.Where(x => x.Type == sensor.SensorType).FirstOrDefault();
                    RaisePropertyChanged("MinChangeTrigger");
                    RaisePropertyChanged("MaxChangeTrigger");
                    RaisePropertyChanged("MinDataInterval");
                    RaisePropertyChanged("MaxDataInterval");
                }
            };
            phidget.Detach += (o, e) => { };
            phidget.SensorChange += (o, e) => {
                FormattedSensorValue = $"{e.SensorValue} {e.SensorUnit.Symbol}";
            };
            phidget.VoltageRatioChange += (o, e) => {
                if (o is VoltageRatioInput) {
                    var sensor = o as VoltageRatioInput;
                    RaisePropertyChanged("VoltageRatio");
                    ChangeTrigger = sensor.VoltageRatioChangeTrigger;
                    DataInterval = sensor.DataInterval;
                }
            };
            this.ShowMaintenanceWindow<VoltageRatioInputMaintenanceWindow>();
            phidget.Open();
        }

        protected override void HandleDetachFromPhidgetSpecificEvents() {
            phidget.SensorChange += null;
            phidget.VoltageRatioChange += null;
        }
    }
}
