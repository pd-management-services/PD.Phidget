namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using PD.Phidget.UserInterface.Configurator.View;
    using Phidget22;

    public class DigitalInputViewModel : MaintainablePhidgetViewModelBase<DigitalInput> {

        public DigitalInputViewModel(DigitalInput phidget) : base(phidget) { }

        public override string AttachmentInfo => $"{phidget.Parent.Parent.DeviceSKU} - {phidget.Parent.Parent.DeviceName}";

        public override bool AddPhidget(IPhidgetViewModel viewModel) { return false; }

        public bool State { get => phidget.State; }

        public override void ShowMaintenanceWindow() {
            phidget.StateChange += (o, e) => {
                RaisePropertyChanged("State");
            };
            phidget.Attach += (o, e) => {
                RaisePropertyChanged("State");
            };
            phidget.Detach += (o, e) => { };
            this.ShowMaintenanceWindow<DigitalInputMaintenanceWindow>();
            phidget.Open();
        }

        protected override void HandleDetachFromPhidgetSpecificEvents() {
            phidget.StateChange += null;
        }
    }
}
