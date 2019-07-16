namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;

    public class PhidgetViewModelBuilder : IPhidgetViewModelBuilder {
        //Reference: https://stackoverflow.com/questions/56904776/casting-abstract-type-object-to-derived-type
        public IPhidgetViewModel Create(Phidget phidget) {
            return CreateViewModel((dynamic)phidget);
        }

        public IPhidgetViewModel Create(Phidget phidget, bool makeFourTimesThermocouplePhidgetViewModel) {
            if (makeFourTimesThermocouplePhidgetViewModel)
                return CreateViewModel((dynamic)phidget);

            return CreateThermoPhidgetViewModelViewModel((dynamic)phidget);
        }

        IPhidgetViewModel CreateViewModel(TemperatureSensor phidget) {
            try {
                var type = phidget.ThermocoupleType;
                return new FourTimesThermocouplePhidgetViewModel(phidget);
            } catch { }
            return CreateThermoPhidgetViewModelViewModel(phidget);
        }

        IPhidgetViewModel CreateThermoPhidgetViewModelViewModel(TemperatureSensor phidget) {
            if (phidget.ChannelName == "Thermocouple Input") return new ThermocoupleInputViewModel(phidget);
            return new TemperatureSensorViewModel(phidget);
        }

        IPhidgetViewModel CreateViewModel(HumiditySensor phidget) {
            var phigitViewModel = new HumidityPhidgetViewModel(phidget);
            if (phidget.DeviceClassName == "Humidity Phidget") return new HumidityPhidgetViewModel(phidget);
            phigitViewModel.AddPhidget(new HumiditySensorViewModel(phidget));
            return phigitViewModel;
        }

        IPhidgetViewModel CreateViewModel(Hub phidget) {


            return new PhidgetHubViewModel(phidget);
        }

        IPhidgetViewModel CreateViewModel(Dictionary phidget) {
            return new DictionaryViewModel(phidget);
        }

        IPhidgetViewModel CreateViewModel(VoltageInput phidget) {
            if (phidget.ChannelClass == ChannelClass.VoltageInput && phidget.Parent.DeviceID == DeviceID.PN_TMP1101) {
                return new ThermocoupleVoltageInputViewModel(phidget);
            }
            return new VoltageInputViewModel(phidget);
        }

        IPhidgetViewModel CreateViewModel(DigitalInput phidget) {
            return new DigitalInputViewModel(phidget);
        }

        IPhidgetViewModel CreateViewModel(DigitalOutput phidget) {
            return new DigitalOutputViewModel(phidget);
        }

        IPhidgetViewModel CreateViewModel(VoltageRatioInput phidget) {
            return new VoltageRatioInputViewModel(phidget);
        }

        IPhidgetViewModel CreateViewModel(SoundSensor phidget) {
            return new SoundSensorViewModel(phidget);
        }

        IPhidgetViewModel CreateViewModel(Phidget phidget) {
            return new GenericPhidgetViewModel(phidget);
        }
    }
}
