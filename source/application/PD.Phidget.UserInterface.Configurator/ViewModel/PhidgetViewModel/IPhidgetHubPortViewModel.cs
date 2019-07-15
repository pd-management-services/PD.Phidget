namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using System.Collections.ObjectModel;

    public interface IPhidgetHubPortViewModel {
        string Name { get; }
        int PortNumber { get; }
        ObservableCollection<IPhidgetViewModel> Phidgets { get; }
        bool AddPhidget(IPhidgetViewModel viewModel);
    }
}
