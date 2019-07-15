namespace PD.Phidget.UserInterface.Configurator.Converter {
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class ChangeTriggerVoltageRatioValueConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return $"{(double)value:0.000} V/V";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
