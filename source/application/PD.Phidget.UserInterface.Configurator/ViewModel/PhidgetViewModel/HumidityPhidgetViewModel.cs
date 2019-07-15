namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using System;
    using System.Collections.ObjectModel;
    using Phidget22;

    public class HumidityPhidgetViewModel : PhidgetViewModelBase<HumiditySensor> {
        public HumidityPhidgetViewModel(HumiditySensor humiditySensor) : base(humiditySensor) { }

        public ObservableCollection<IPhidgetViewModel> HumiditySensors { get; } = new ObservableCollection<IPhidgetViewModel>();

        public ObservableCollection<IPhidgetViewModel> TemperatureSensors { get; } = new ObservableCollection<IPhidgetViewModel>();

        public override bool AddPhidget(IPhidgetViewModel viewModel) {
            if (viewModel is TemperatureSensorViewModel || viewModel is ThermocoupleInputViewModel) {
                if (viewModel.Channel >= phidget.GetDeviceChannelCount(ChannelClass.TemperatureSensor)) throw new ArgumentException($"Can't find a channel to add '{viewModel.DeviceName}' to");
                TemperatureSensors.Add(viewModel);
                TemperatureSensors.Sort((a, b) => { return a.Channel.CompareTo(b.Channel); });
                return true;
            } else if (viewModel is HumiditySensorViewModel) {
                if (viewModel.Channel >= phidget.GetDeviceChannelCount(ChannelClass.HumiditySensor)) throw new ArgumentException($"Can't find a channel to add '{viewModel.DeviceName}' to");
                HumiditySensors.Add(viewModel);
                HumiditySensors.Sort((a, b) => a.Channel.CompareTo(b.Channel));
                return true;
            }
            return true;
        }
    }
}