namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;

    public interface IPhidgetViewModelBuilder {
        IPhidgetViewModel Create(Phidget phidget);
        IPhidgetViewModel Create(Phidget phidget, bool makeFourTimesThermocouplePhidgetViewModel);
    }
}
