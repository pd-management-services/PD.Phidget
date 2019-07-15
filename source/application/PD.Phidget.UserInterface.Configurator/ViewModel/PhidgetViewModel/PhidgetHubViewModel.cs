namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Phidget22;

    public class PhidgetHubViewModel : PhidgetViewModelBase<Hub> {
        public PhidgetHubViewModel(Hub hub) : base(hub) {
            for(int portNumber = 0; portNumber < hub.HubPortCount; portNumber++) {
                Ports.Add(new PhidgetHubPortViewModel(portNumber));
            }
        }

        public ObservableCollection<IPhidgetHubPortViewModel> Ports { get; } = new ObservableCollection<IPhidgetHubPortViewModel>();

        public override bool AddPhidget(IPhidgetViewModel viewModel) {
            if(viewModel.SerialNumber == SerialNumber) {
                if (!Ports.Any(port => port.AddPhidget(viewModel))) throw new ArgumentException($"Can't find a port to add '{viewModel.DeviceName}' to");
                return true;
            }
            return false;
        }
    }
}
