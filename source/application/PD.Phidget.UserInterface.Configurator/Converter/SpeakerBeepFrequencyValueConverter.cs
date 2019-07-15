namespace PD.Phidget.UserInterface.Configurator.Converter {
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class SpeakerBeepFrequencyValueConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return $"{value} Hz";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
