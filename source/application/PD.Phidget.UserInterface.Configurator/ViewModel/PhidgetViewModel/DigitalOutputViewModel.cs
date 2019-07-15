namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using GalaSoft.MvvmLight.Command;
    using PD.Phidget.UserInterface.Configurator.View;
    using Phidget22;

    public class DigitalOutputViewModel : MaintainablePhidgetViewModelBase<DigitalOutput> {

        public DigitalOutputViewModel(DigitalOutput phidget) : base(phidget) {
            ToggleOnOff = new RelayCommand(() => {
                State = !State;
            });
        }

        public override string AttachmentInfo => $"{phidget.Parent.Parent.DeviceSKU} - {phidget.Parent.Parent.DeviceName}";

        public RelayCommand ToggleOnOff { get; private set; }

        public bool State {
            get => phidget.State;
            set {
                if (value == phidget.State) return;
                phidget.State = value;
                RaisePropertyChanged("State");
                RaisePropertyChanged("DutyCycle");
            }
        }

        public double MinDutyCycle { get => phidget.MinDutyCycle; }

        public double MaxDutyCycle { get => phidget.MaxDutyCycle; }

        public double DutyCycle {
            get => phidget.DutyCycle;
            set {
                if (value == phidget.DutyCycle) return;
                phidget.DutyCycle = value;
                RaisePropertyChanged("DutyCycle");
            }
        }

        public override bool AddPhidget(IPhidgetViewModel viewModel) { return false; }

        public override void ShowMaintenanceWindow() {
            phidget.PropertyChange += (o, e) => {
                RaisePropertyChanged("DutyCycle");
            };
            phidget.Attach += (o, e) => {
                RaisePropertyChanged("MinDutyCycle");
                RaisePropertyChanged("MaxDutyCycle");
            };
            phidget.Detach += (o, e) => { };
            this.ShowMaintenanceWindow<DigitalOutputMaintenanceWindow>();
            phidget.Open();
        }

        protected override void HandleDetachFromPhidgetSpecificEvents() {
            phidget.PropertyChange += null;
        }
    }
}
