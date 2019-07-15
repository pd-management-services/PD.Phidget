namespace PD.Phidget.UserInterface.Configurator.Converter {
    using PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;

    public class FourTimesThermocouplePhidgetViewModelChildTreeNodeMultiValueConverter : IMultiValueConverter { //Reference: http://www.hardcodet.net/2008/12/heterogeneous-wpf-treeview
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            //get folder name listing...
            string folder = parameter as string ?? "";
            var folders = folder.Split(',').Select(f => f.Trim()).ToList();
            //...and make sure there are no missing entries
            while (values.Length > folders.Count) folders.Add(String.Empty);

            //this is the collection that gets all top level items
            var items = new List<object>();

            for (int i = 0; i < values.Length; i++) {
                //make sure were working with collections from here...
                var childs = values[i] as IEnumerable<IPhidgetViewModel> ?? new List<IPhidgetViewModel> { values[i] as IPhidgetViewModel };

                string folderName = folders[i];
                if (folderName != String.Empty) {
                    //create folder item and assign childs
                    var folderItem = new PhidgetContainer { Name = folderName, Items = childs };
                    items.Add(folderItem);
                } else {
                    //if no folder name was specified, move the item directly to the root item
                    foreach (var child in childs) { items.Add(child); }
                }
            }

            return items;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
