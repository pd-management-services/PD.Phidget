namespace PD.Phidget.UserInterface.Configurator.Converter {
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Data;
    using PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel;

    //Reference: http://www.hardcodet.net/2008/12/heterogeneous-wpf-treeview
    public class HumidityPhidgetViewModelChildTreeNodeMultiValueConverter : IMultiValueConverter { 
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            //this is the collection that gets all top level items
            var items = new List<object>();

            for (int i = 0; i < values.Length; i++) {
                //make sure were working with collections from here...
                var childs = values[i] as IEnumerable<IPhidgetViewModel> ?? new List<IPhidgetViewModel> { values[i] as IPhidgetViewModel };

                foreach (var child in childs) { items.Add(child); }
            }

            return items;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}