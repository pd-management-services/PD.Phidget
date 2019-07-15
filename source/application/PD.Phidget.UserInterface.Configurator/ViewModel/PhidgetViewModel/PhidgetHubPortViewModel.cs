namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using System.Collections.ObjectModel;
    using System.Linq;

    public class PhidgetHubPortViewModel : BindableObject, IPhidgetHubPortViewModel {
        public PhidgetHubPortViewModel(int number) {
            PortNumber = number;
            RaisePropertyChanged("Name");
            RaisePropertyChanged("PortNumber");
        }

        public ObservableCollection<IPhidgetViewModel> Phidgets { get; } = new ObservableCollection<IPhidgetViewModel>();

        public string Name => $"Port {PortNumber}";

        public int PortNumber { get; private set; }

        public bool AddPhidget(IPhidgetViewModel viewModel) {
            if (viewModel.PortNumber == PortNumber) {
                if (!Phidgets.Any(phidget => phidget.AddPhidget(viewModel)))
                Phidgets.Add(viewModel);
                Phidgets.Sort((a, b) => { return a.DeviceName.CompareTo(b.DeviceName); });
                return true;
            }
            return false;
        }
    }
}
