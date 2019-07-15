namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;
    using System.Collections.ObjectModel;

    public class VoltageSensorTypes : ReadOnlyCollection<IVoltageSensorTypeViewModel> {
        public VoltageSensorTypes() : base(new IVoltageSensorTypeViewModel[] {
            new GenericVoltageSensorTypeViewModel()
            , new TemperatureTypeSensorTypeViewModel(), new VoltageSensorTypeViewModel(), new PrecisionVoltageSensorOneTypeViewModel(), new PrecisionLightSensorTypeViewModel(), new pHAdapterTypeViewModel()
            , new ORPTypeViewModel(), new FourToTwentyMilliampAdapterTypeViewModel(), new SoundTypeViewModel(), new PrecisionVoltageSensorTwoTypeViewModel(), new OneThousandLuxLightSensorTypeViewModel()
            , new SeventyThousandLuxLightSensorTypeViewModel(), new TenAmpACCurrentSensorTypeViewModel(), new TwentyFiveAmpACCurrentSensorTypeViewModel()
            , new FiftyAmpACCurrentSensorTypeViewModel(), new OneHundredAmpACCurrentSensorTypeViewModel(), new FiftyHertzACVoltageSensorTypeViewModel()
            , new SixtyHertzACVoltageSensorTypeViewModel(), new ZeroToTwohundredVoltDCVoltageSensorTypeViewModel(), new ZeroToSeventyFiveVoltDCVoltageSensorTypeViewModel()
            , new ZeroToTenMilliampDCCurrentSensorTypeViewModel(), new ZeroToOneHundredMilliampDCCurrentSensorTypeViewModel(), new ZeroToOneAmpDCCurrentSensorTypeViewModel()
            , new ACActivePowerOneSensorTypeViewModel(), new ACActivePowerTwoSensorTypeViewModel(), new ACActivePowerThreeSensorTypeViewModel(), new ACActivePowerFourSensorTypeViewModel()
            , new ACActivePowerFiveSensorTypeViewModel(), new ACActivePowerSixSensorTypeViewModel(), new ZeroToFiftyAmpDCCurrentTransducerTypeViewModel(), new ZeroToOneHundredAmpDCCurrentTransducerTypeViewModel()
            , new ZeroToTwoHundredFiftyAmpDCCurrentTransducerTypeViewModel(), new PlusMinusFiftyAmpDCCurrentTransducerTypeViewModel(), new PlusMinusOneHundredAmpDCCurrentTransducerTypeViewModel(), new PlusMinusTwoHundredFiftyAmpDCCurrentTransducerTypeViewModel()
        }) { }
    }

    public interface IVoltageSensorTypeViewModel {
        VoltageSensorType Type { get; }
        int Id { get; }
        string Name { get; }
        string DisplayName { get; }
    }

    public abstract class VoltageSensorTypeBase : IVoltageSensorTypeViewModel {
        public abstract VoltageSensorType Type { get; }

        public int Id { get => (int)Type; }

        public abstract string Name { get; }

        public virtual string DisplayName {
            get {
                var numberValue = ((int)Type).ToString();
                return string.Format("{0} - {1}", numberValue.Substring(0, numberValue.Length - 1), Name);
            }
        }
    }

    public class GenericVoltageSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.Voltage;

        public override string Name => "Generic voltage sensor";

        public override string DisplayName => Name;
    }

    public class TemperatureTypeSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1114;

        public override string Name => "Temperature Sensor";
    }

    public class VoltageSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1117;

        public override string Name => "Voltage Sensor";
    }

    public class PrecisionVoltageSensorOneTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1123;

        public override string Name => "Precision Voltage Sensor";
    }

    public class PrecisionLightSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1127;

        public override string Name => "Precision Light Sensor";
    }

    public class pHAdapterTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1130_pH;

        public override string Name => "pH Adapter";
    }

    public class ORPTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1130_ORP;

        public override string Name => "ORP Adapter";
    }

    public class FourToTwentyMilliampAdapterTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1132;

        public override string Name => "4-20mA Adapter";
    }

    public class SoundTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1133;

        public override string Name => "Sound Sensor";
    }

    public class PrecisionVoltageSensorTwoTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1135;

        public override string Name => "Precision Voltage Sensor";
    }

    public class OneThousandLuxLightSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1142;

        public override string Name => "Light Sensor 1000 lux";
    }

    public class SeventyThousandLuxLightSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_1143;

        public override string Name => "Light Sensor 70000 lux";
    }

    public class TenAmpACCurrentSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3500;

        public override string Name => "AC Current Sensor 10Amp";
    }

    public class TwentyFiveAmpACCurrentSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3501;

        public override string Name => "AC Current Sensor 25Amp";
    }

    public class FiftyAmpACCurrentSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3502;

        public override string Name => "AC Current Sensor 50Amp";
    }

    public class OneHundredAmpACCurrentSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3503;

        public override string Name => "AC Current Sensor 100Amp";
    }

    public class FiftyHertzACVoltageSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3507;

        public override string Name => "AC Voltage Sensor 0-250V (50Hz)";
    }

    public class SixtyHertzACVoltageSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3508;

        public override string Name => "AC Voltage Sensor 0-250V (60Hz)";
    }

    public class ZeroToTwohundredVoltDCVoltageSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3509;

        public override string Name => "DC Voltage Sensor 0-250V";
    }

    public class ZeroToSeventyFiveVoltDCVoltageSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3510;

        public override string Name => "DC Voltage Sensor 0-75V";
    }

    public class ZeroToTenMilliampDCCurrentSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3511;

        public override string Name => "DC Current Sensor 0-10mA";
    }

    public class ZeroToOneHundredMilliampDCCurrentSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3512;

        public override string Name => "DC Current Sensor 0-100mA";
    }

    public class ZeroToOneAmpDCCurrentSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3513;

        public override string Name => "DC Current Sensor 0-1A";
    }

    public class ACActivePowerOneSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3514;

        public override string Name => "AC Active Power Sensor 0-250V*0-30A (50Hz)";
    }

    public class ACActivePowerTwoSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3515;

        public override string Name => "AC Active Power Sensor 0-250V*0-30A (60Hz)";
    }

    public class ACActivePowerThreeSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3516;

        public override string Name => "AC Active Power Sensor 0-250V*0-5A (50Hz)";
    }

    public class ACActivePowerFourSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3517;

        public override string Name => "AC Active Power Sensor 0-250V*0-5A (60Hz)";
    }

    public class ACActivePowerFiveSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3518;

        public override string Name => "AC Active Power Sensor 0-110V*0-5A (60Hz)";
    }

    public class ACActivePowerSixSensorTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3519;

        public override string Name => "AC Active Power Sensor 0-110V*0-15A (60Hz)";
    }

    public class ZeroToFiftyAmpDCCurrentTransducerTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3584;

        public override string Name => "0-50A DC Current Transducer";
    }

    public class ZeroToOneHundredAmpDCCurrentTransducerTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3585;

        public override string Name => "0-100A DC Current Transducer";
    }

    public class ZeroToTwoHundredFiftyAmpDCCurrentTransducerTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3586;

        public override string Name => "0-250A DC Current Transducer";
    }

    public class PlusMinusFiftyAmpDCCurrentTransducerTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3587;

        public override string Name => "+-50A DC Current Transducer";
    }

    public class PlusMinusOneHundredAmpDCCurrentTransducerTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3588;

        public override string Name => "+-100A DC Current Transducer";
    }

    public class PlusMinusTwoHundredFiftyAmpDCCurrentTransducerTypeViewModel : VoltageSensorTypeBase {
        public override VoltageSensorType Type => VoltageSensorType.PN_3589;

        public override string Name => "+-250A DC Current Transducer";
    }
}
