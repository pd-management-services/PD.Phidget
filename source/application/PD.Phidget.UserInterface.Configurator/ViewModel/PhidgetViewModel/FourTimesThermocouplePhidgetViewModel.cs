namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using System;
    using System.Collections.ObjectModel;
    using Phidget22;

    public class FourTimesThermocouplePhidgetViewModel : PhidgetViewModelBase<TemperatureSensor> {
        public FourTimesThermocouplePhidgetViewModel(TemperatureSensor temperatureSensor) : base(temperatureSensor) { }

        public ObservableCollection<IPhidgetViewModel> TemperatureSensorInputs { get; } = new ObservableCollection<IPhidgetViewModel>();

        public ObservableCollection<IPhidgetViewModel> VoltageInputs { get; } = new ObservableCollection<IPhidgetViewModel>();

        public ObservableCollection<IPhidgetViewModel> TemperatureSensors { get; } = new ObservableCollection<IPhidgetViewModel>();

        public override bool AddPhidget(IPhidgetViewModel viewModel) {
            if (viewModel is TemperatureSensorViewModel || viewModel is ThermocoupleInputViewModel) {
                if (viewModel.Channel >= phidget.GetDeviceChannelCount(ChannelClass.TemperatureSensor)) throw new ArgumentException($"Can't find a channel to add '{viewModel.DeviceName}' to");
                TemperatureSensorInputs.Add(viewModel);
                TemperatureSensorInputs.Sort((a, b) => { return a.Channel.CompareTo(b.Channel); });
                return true;
            } else if (viewModel is ThermocoupleVoltageInputViewModel) {
                if (viewModel.Channel >= phidget.GetDeviceChannelCount(ChannelClass.VoltageInput)) throw new ArgumentException($"Can't find a channel to add '{viewModel.DeviceName}' to");
                VoltageInputs.Add(viewModel);
                VoltageInputs.Sort((a, b) => { return a.Channel.CompareTo(b.Channel); });
                return true;
            }
            return true;
        }
    }
}
