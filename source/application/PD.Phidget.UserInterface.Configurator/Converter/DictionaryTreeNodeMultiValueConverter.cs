namespace PD.Phidget.UserInterface.Configurator.Converter {
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class DictionaryTreeNodeMultiValueConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            return string.Format("{0, -97} Serial #: {1, 13} Channel: {2, 1} Version: {3, 3}","Server Monitoring/Control Dictionary", values[0], values[1], values[2]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
