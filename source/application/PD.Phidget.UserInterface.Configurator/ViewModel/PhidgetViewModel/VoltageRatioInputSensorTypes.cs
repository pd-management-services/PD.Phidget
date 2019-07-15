namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;
    using System.Collections.ObjectModel;

    public interface IVoltageRatioInputSensorTypes {
        IVoltageRatioSensorTypeViewModel GenericRatiometricSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel IRDistanceAdapterWithSharpDistanceSensor2D120XViewModel { get; }
        IVoltageRatioSensorTypeViewModel IRDistanceAdapterWithSharpDistanceSensor2Y0A21ViewModel { get; }
        IVoltageRatioSensorTypeViewModel IRDistanceAdapterWithSharpDistanceSensor2Y0A02ViewModel { get; }
        IVoltageRatioSensorTypeViewModel IRReflectiveSensor5mmViewModel { get; }
        IVoltageRatioSensorTypeViewModel IRReflectiveSensor10mmViewModel { get; }
        IVoltageRatioSensorTypeViewModel VibrationSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel LightSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel ForceSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel HumiditySensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel MagneticSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel RotationSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel TouchSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel MotionSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel Slider60ViewModel { get; }
        IVoltageRatioSensorTypeViewModel MiniJoyStickSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel PressureSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel MultiturnRotationSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel FiftyAmpCurrentSensorACViewModel { get; }
        IVoltageRatioSensorTypeViewModel FiftyAmpCurrentSensorDCViewModel { get; }
        IVoltageRatioSensorTypeViewModel TwentyAmpCurrentSensorACViewModel { get; }
        IVoltageRatioSensorTypeViewModel TwentyAmpCurrentSensorDCViewModel { get; }
        IVoltageRatioSensorTypeViewModel FlexiForceAdapterViewModel { get; }
        IVoltageRatioSensorTypeViewModel VoltageDividerViewModel { get; }
        IVoltageRatioSensorTypeViewModel ThirtyAmpCurrentSensorACViewModel { get; }
        IVoltageRatioSensorTypeViewModel ThirtyAmpCurrentSensorDCViewModel { get; }
        IVoltageRatioSensorTypeViewModel PrecisionTemperatureSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel HumiditySensor2ViewModel { get; }
        IVoltageRatioSensorTypeViewModel TemperatureSensor2ViewModel { get; }
        IVoltageRatioSensorTypeViewModel DifferentialAirPressureSensorPlusMinus25kPaViewModel { get; }
        IVoltageRatioSensorTypeViewModel MaxBotixEZ1SonarSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel TouchSensor2ViewModel { get; }
        IVoltageRatioSensorTypeViewModel ThinForceSensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel SwitchableVoltageDividerViewModel { get; }
        IVoltageRatioSensorTypeViewModel DifferentialAirPressureSensorPlusMinus2kPaViewModel { get; }
        IVoltageRatioSensorTypeViewModel DifferentialAirPressureSensorPlusMinus7kPaViewModel { get; }
        IVoltageRatioSensorTypeViewModel DifferentialAirPressureSensor50kPaViewModel { get; }
        IVoltageRatioSensorTypeViewModel DifferentialAirPressureSensor100kPaViewModel { get; }
        IVoltageRatioSensorTypeViewModel AbsoluteAirPressureSensor20To400kPaViewModel { get; }
        IVoltageRatioSensorTypeViewModel AbsoluteAirPressureSensor15To115kPaViewModel { get; }
        IVoltageRatioSensorTypeViewModel IRReflectiveSensor1To4mmViewModel { get; }
        IVoltageRatioSensorTypeViewModel CompressionLoadCell0To4AndOneHalfkgViewModel { get; }
        IVoltageRatioSensorTypeViewModel CompressionLoadCell0ToElevenPointThreekgViewModel { get; }
        IVoltageRatioSensorTypeViewModel CompressionLoadCell0ToTwentyTwoPointSevenkgViewModel { get; }
        IVoltageRatioSensorTypeViewModel CompressionLoadCell0ToFortyFivePointThreekgViewModel { get; }
        IVoltageRatioSensorTypeViewModel RelativeHumiditySensorViewModel { get; }
        IVoltageRatioSensorTypeViewModel SharpDistanceSensor4To30cmViewModel { get; }
        IVoltageRatioSensorTypeViewModel SharpDistanceSensor10To80cmViewModel { get; }
        IVoltageRatioSensorTypeViewModel SharpDistanceSensor20To150cmViewModel { get; }
    }

    public interface IVoltageRatioSensorTypeViewModel {
        VoltageRatioSensorType Type { get; }
        int Id { get; }
        string Name { get; }
        string DisplayName { get; }
    }

    public class VoltageRatioInputSensorTypes : ReadOnlyCollection<IVoltageRatioSensorTypeViewModel>, IVoltageRatioInputSensorTypes {
        public VoltageRatioInputSensorTypes() : base(new IVoltageRatioSensorTypeViewModel[] {
              new GenericRatiometricSensorViewModel()
            , new IRDistanceAdapterWithSharpDistanceSensor2D120XViewModel()
            , new IRDistanceAdapterWithSharpDistanceSensor2Y0A21ViewModel()
            , new IRDistanceAdapterWithSharpDistanceSensor2Y0A02ViewModel()
            , new IRReflectiveSensor5mmViewModel()
            , new IRReflectiveSensor10mmViewModel()
            , new VibrationSensorViewModel()
            , new LightSensorViewModel()
            , new ForceSensorViewModel()
            , new HumiditySensorVoltageRatioSensorViewModel ()
            , new MagneticSensorViewModel()
            , new RotationSensorViewModel()
            , new TouchSensorViewModel()
            , new MotionSensorViewModel()
            , new Slider60ViewModel()
            , new MiniJoyStickSensorViewModel()
            , new PressureSensorViewModel()
            , new MultiturnRotationSensorViewModel()
            , new FiftyAmpCurrentSensorACViewModel()
            , new FiftyAmpCurrentSensorDCViewModel()
            , new TwentyAmpCurrentSensorACViewModel()
            , new TwentyAmpCurrentSensorDCViewModel()
            , new FlexiForceAdapterViewModel()
            , new VoltageDividerViewModel()
            , new ThirtyAmpCurrentSensorACViewModel()
            , new ThirtyAmpCurrentSensorDCViewModel()
            , new PrecisionTemperatureSensorViewModel()
            , new HumiditySensor2ViewModel()
            , new TemperatureSensor2ViewModel()
            , new DifferentialAirPressureSensorPlusMinus25kPaViewModel()
            , new MaxBotixEZ1SonarSensorViewModel()
            , new TouchSensor2ViewModel()
            , new ThinForceSensorViewModel()
            , new SwitchableVoltageDividerViewModel()
            , new DifferentialAirPressureSensorPlusMinus2kPaViewModel()
            , new DifferentialAirPressureSensorPlusMinus7kPaViewModel()
            , new DifferentialAirPressureSensor50kPaViewModel()
            , new DifferentialAirPressureSensor100kPaViewModel()
            , new AbsoluteAirPressureSensor20To400kPaViewModel()
            , new AbsoluteAirPressureSensor15To115kPaViewModel()
            , new IRReflectiveSensor1To4mmViewModel()
            , new CompressionLoadCell0To4AndOneHalfkgViewModel()
            , new CompressionLoadCell0ToElevenPointThreekgViewModel()
            , new CompressionLoadCell0ToTwentyTwoPointSevenkgViewModel()
            , new CompressionLoadCell0ToFortyFivePointThreekgViewModel()
            , new RelativeHumiditySensorViewModel()
            , new SharpDistanceSensor4To30cmViewModel()
            , new SharpDistanceSensor10To80cmViewModel()
            , new SharpDistanceSensor20To150cmViewModel()
        }) { }

        public IVoltageRatioSensorTypeViewModel GenericRatiometricSensorViewModel => base[0];
        public IVoltageRatioSensorTypeViewModel IRDistanceAdapterWithSharpDistanceSensor2D120XViewModel => base[1];
        public IVoltageRatioSensorTypeViewModel IRDistanceAdapterWithSharpDistanceSensor2Y0A21ViewModel => base[2];
        public IVoltageRatioSensorTypeViewModel IRDistanceAdapterWithSharpDistanceSensor2Y0A02ViewModel => base[3];
        public IVoltageRatioSensorTypeViewModel IRReflectiveSensor5mmViewModel => base[4];
        public IVoltageRatioSensorTypeViewModel IRReflectiveSensor10mmViewModel => base[5];
        public IVoltageRatioSensorTypeViewModel VibrationSensorViewModel => base[6];
        public IVoltageRatioSensorTypeViewModel LightSensorViewModel => base[7];
        public IVoltageRatioSensorTypeViewModel ForceSensorViewModel => base[8];
        public IVoltageRatioSensorTypeViewModel HumiditySensorViewModel => base[9];
        public IVoltageRatioSensorTypeViewModel MagneticSensorViewModel => base[10];
        public IVoltageRatioSensorTypeViewModel RotationSensorViewModel => base[11];
        public IVoltageRatioSensorTypeViewModel TouchSensorViewModel => base[12];
        public IVoltageRatioSensorTypeViewModel MotionSensorViewModel => base[13];
        public IVoltageRatioSensorTypeViewModel Slider60ViewModel => base[14];
        public IVoltageRatioSensorTypeViewModel MiniJoyStickSensorViewModel => base[15];
        public IVoltageRatioSensorTypeViewModel PressureSensorViewModel => base[16];
        public IVoltageRatioSensorTypeViewModel MultiturnRotationSensorViewModel => base[17];
        public IVoltageRatioSensorTypeViewModel FiftyAmpCurrentSensorACViewModel => base[18];
        public IVoltageRatioSensorTypeViewModel FiftyAmpCurrentSensorDCViewModel => base[19];
        public IVoltageRatioSensorTypeViewModel TwentyAmpCurrentSensorACViewModel => base[20];
        public IVoltageRatioSensorTypeViewModel TwentyAmpCurrentSensorDCViewModel => base[21];
        public IVoltageRatioSensorTypeViewModel FlexiForceAdapterViewModel => base[22];
        public IVoltageRatioSensorTypeViewModel VoltageDividerViewModel => base[23];
        public IVoltageRatioSensorTypeViewModel ThirtyAmpCurrentSensorACViewModel => base[24];
        public IVoltageRatioSensorTypeViewModel ThirtyAmpCurrentSensorDCViewModel => base[25];
        public IVoltageRatioSensorTypeViewModel PrecisionTemperatureSensorViewModel => base[26];
        public IVoltageRatioSensorTypeViewModel HumiditySensor2ViewModel => base[27];
        public IVoltageRatioSensorTypeViewModel TemperatureSensor2ViewModel => base[28];
        public IVoltageRatioSensorTypeViewModel DifferentialAirPressureSensorPlusMinus25kPaViewModel => base[29];
        public IVoltageRatioSensorTypeViewModel MaxBotixEZ1SonarSensorViewModel => base[30];
        public IVoltageRatioSensorTypeViewModel TouchSensor2ViewModel => base[31];
        public IVoltageRatioSensorTypeViewModel ThinForceSensorViewModel => base[32];
        public IVoltageRatioSensorTypeViewModel SwitchableVoltageDividerViewModel => base[33];
        public IVoltageRatioSensorTypeViewModel DifferentialAirPressureSensorPlusMinus2kPaViewModel => base[34];
        public IVoltageRatioSensorTypeViewModel DifferentialAirPressureSensorPlusMinus7kPaViewModel => base[35];
        public IVoltageRatioSensorTypeViewModel DifferentialAirPressureSensor50kPaViewModel => base[36];
        public IVoltageRatioSensorTypeViewModel DifferentialAirPressureSensor100kPaViewModel => base[37];
        public IVoltageRatioSensorTypeViewModel AbsoluteAirPressureSensor20To400kPaViewModel => base[38];
        public IVoltageRatioSensorTypeViewModel AbsoluteAirPressureSensor15To115kPaViewModel => base[39];
        public IVoltageRatioSensorTypeViewModel IRReflectiveSensor1To4mmViewModel => base[40];
        public IVoltageRatioSensorTypeViewModel CompressionLoadCell0To4AndOneHalfkgViewModel => base[41];
        public IVoltageRatioSensorTypeViewModel CompressionLoadCell0ToElevenPointThreekgViewModel => base[42];
        public IVoltageRatioSensorTypeViewModel CompressionLoadCell0ToTwentyTwoPointSevenkgViewModel => base[43];
        public IVoltageRatioSensorTypeViewModel CompressionLoadCell0ToFortyFivePointThreekgViewModel => base[44];
        public IVoltageRatioSensorTypeViewModel RelativeHumiditySensorViewModel => base[45];
        public IVoltageRatioSensorTypeViewModel SharpDistanceSensor4To30cmViewModel => base[46];
        public IVoltageRatioSensorTypeViewModel SharpDistanceSensor10To80cmViewModel => base[47];
        public IVoltageRatioSensorTypeViewModel SharpDistanceSensor20To150cmViewModel => base[48];
    }

    public abstract class VoltageRatioSensorTypeViewModelBase : IVoltageRatioSensorTypeViewModel {
        public abstract VoltageRatioSensorType Type { get; }

        public int Id { get => (int)Type; }

        public abstract string Name { get; }

        public virtual string DisplayName => $"{Type.ToString().Substring(3, 4)} - {Name}";
    }

    public class GenericRatiometricSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.VoltageRatio;

        public override string Name => "Generic ratiometric sensor";

        public override string DisplayName => Name;
    }

    public class IRDistanceAdapterWithSharpDistanceSensor2D120XViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1101_Sharp2D120X;

        public override string Name => "IR Distance Adapter, with Sharp Distance Sensor 2D120X (4-30cm)";
    }

    public class IRDistanceAdapterWithSharpDistanceSensor2Y0A21ViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1101_Sharp2Y0A21;

        public override string Name => "IR Distance Adapter, with Sharp Distance Sensor 2Y0A21 (10-80cm)";
    }

    public class IRDistanceAdapterWithSharpDistanceSensor2Y0A02ViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1101_Sharp2Y0A21;

        public override string Name => "IR Distance Adapter, with Sharp Distance Sensor 2Y0A02 (20-150cm)";
    }

    public class IRReflectiveSensor5mmViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1102;

        public override string Name => "IR Reflective Sensor 5mm";
    }

    public class IRReflectiveSensor10mmViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1103;

        public override string Name => "IR Reflective Sensor 10mm";
    }

    public class VibrationSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1104;

        public override string Name => "Vibration Sensor";
    }

    public class LightSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1105;

        public override string Name => "Light Sensor";
    }

    public class ForceSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1106;

        public override string Name => "Force Sensor";
    }

    public class HumiditySensorVoltageRatioSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1107;

        public override string Name => "Humidity Sensor";
    }

    public class MagneticSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1108;

        public override string Name => "Magnetic Sensor";
    }

    public class RotationSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1109;

        public override string Name => "Rotation Sensor";
    }

    public class TouchSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1110;

        public override string Name => "Touch Sensor";
    }

    public class MotionSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1111;

        public override string Name => "Motion Sensor";
    }

    public class Slider60ViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1112;

        public override string Name => "Slider 60";
    }

    public class MiniJoyStickSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1113;

        public override string Name => "Mini Joy Stick Sensor";
    }

    public class PressureSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1115;

        public override string Name => "Pressure Sensor";
    }

    public class MultiturnRotationSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1116;

        public override string Name => "Multi-turn Rotation Sensor";
    }

    public class FiftyAmpCurrentSensorACViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1118_AC;

        public override string Name => "50Amp Current Sensor AC";
    }

    public class FiftyAmpCurrentSensorDCViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1118_DC;

        public override string Name => "50Amp Current Sensor DC";
    }

    public class TwentyAmpCurrentSensorACViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1119_AC;

        public override string Name => "20Amp Current Sensor AC";
    }

    public class TwentyAmpCurrentSensorDCViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1119_DC;

        public override string Name => "20Amp Current Sensor DC";
    }

    public class FlexiForceAdapterViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1120;

        public override string Name => "FlexiForce Adapter";
    }

    public class VoltageDividerViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1121;

        public override string Name => "Voltage Divider";
    }

    public class ThirtyAmpCurrentSensorACViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1122_AC;

        public override string Name => "30 Amp Current Sensor AC";
    }

    public class ThirtyAmpCurrentSensorDCViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1122_DC;

        public override string Name => "30 Amp Current Sensor DC";
    }

    public class PrecisionTemperatureSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1124;

        public override string Name => "Precision Temperature Sensor";
    }

    public class HumiditySensor2ViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1125_Humidity;

        public override string Name => "Humidity Sensor";
    }

    public class TemperatureSensor2ViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1125_Temperature;

        public override string Name => "Temperature Sensor";
    }

    public class DifferentialAirPressureSensorPlusMinus25kPaViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1126;

        public override string Name => "Differential Air Pressure Sensor +- 25kPa";
    }

    public class MaxBotixEZ1SonarSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1128;

        public override string Name => "MaxBotix EZ-1 Sonar Sensor";
    }

    public class TouchSensor2ViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1129;

        public override string Name => "Touch Sensor";
    }

    public class ThinForceSensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1131;

        public override string Name => "Thin Force Sensor";
    }

    public class SwitchableVoltageDividerViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1134;

        public override string Name => "Switchable Voltage Divider";
    }

    public class DifferentialAirPressureSensorPlusMinus2kPaViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1136;

        public override string Name => "Differential Air Pressure Sensor +-2 kPa";
    }

    public class DifferentialAirPressureSensorPlusMinus7kPaViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1137;

        public override string Name => "Differential Air Pressure Sensor +-7 kPa";
    }

    public class DifferentialAirPressureSensor50kPaViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1138;

        public override string Name => "Differential Air Pressure Sensor 50 kPa";
    }

    public class DifferentialAirPressureSensor100kPaViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1139;

        public override string Name => "Differential Air Pressure Sensor 100 kPa";
    }

    public class AbsoluteAirPressureSensor20To400kPaViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1140;

        public override string Name => "Absolute Air Pressure Sensor 20-400 kPa";
    }

    public class AbsoluteAirPressureSensor15To115kPaViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1141;

        public override string Name => "Absolute Air Pressure Sensor 15-115 kPa";
    }

    public class IRReflectiveSensor1To4mmViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_1146;

        public override string Name => "IR Reflective Sensor 1-4mm";
    }

    public class CompressionLoadCell0To4AndOneHalfkgViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_3120;

        public override string Name => "Compression Load Cell (0-4.5 kg)";
    }

    public class CompressionLoadCell0ToElevenPointThreekgViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_3121;

        public override string Name => "Compression Load Cell (0-11.3 kg)";
    }

    public class CompressionLoadCell0ToTwentyTwoPointSevenkgViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_3122;

        public override string Name => "Compression Load Cell (0-22.7 kg)";
    }

    public class CompressionLoadCell0ToFortyFivePointThreekgViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_3123;

        public override string Name => "Compression Load Cell (0-45.3 kg)";
    }

    public class RelativeHumiditySensorViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_3130;

        public override string Name => "Relative Humidity Sensor";
    }

    public class SharpDistanceSensor4To30cmViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_3120;

        public override string Name => "Sharp Distance Sensor (4-30cm)";
    }

    public class SharpDistanceSensor10To80cmViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_3121;

        public override string Name => "Sharp Distance Sensor (10-80cm)";
    }

    public class SharpDistanceSensor20To150cmViewModel : VoltageRatioSensorTypeViewModelBase {
        public override VoltageRatioSensorType Type => VoltageRatioSensorType.PN_3122;

        public override string Name => "Sharp Distance Sensor (20-150cm)";
    }
}
