namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;

    public class GenericPhidgetViewModel : PhidgetViewModelBase<Phidget> {
        public GenericPhidgetViewModel(Phidget phidget) : base(phidget) { }

        public override bool AddPhidget(IPhidgetViewModel viewModel) { return false; }
    }
}
