namespace PD.Phidget.UserInterface.Configurator.Converter {
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    //Reference: https://stackoverflow.com/questions/4099960/binding-off-visibility-of-another-element-and-inverting
    public class InvertVisibilityConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (targetType == typeof(Visibility)) {
                return ((Visibility)value == Visibility.Collapsed) ? Visibility.Visible : Visibility.Collapsed;
            }
            throw new InvalidOperationException("Converter can only convert to value of type Visibility.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
