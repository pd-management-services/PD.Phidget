namespace PD.Phidget.UserInterface.Configurator.Converter {
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class SensorInputTreeNodeMultiValueConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            return string.Format("{0, -110} Channel: {2, 2}", "Hub Port - " + values[0], null, values[1]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
