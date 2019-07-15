namespace PD.Phidget.UserInterface.Configurator.ViewModel {
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class ObservableCollectionExtensions { //Reference: https://stackoverflow.com/questions/19112922/sort-observablecollectionstring-through-c-sharp
        public static void Sort<T>(this ObservableCollection<T> collection, Comparison<T> comparison) {
            var sortableList = new List<T>(collection);
            sortableList.Sort(comparison);

            for (int i = 0; i < sortableList.Count; i++) {
                collection.Move(collection.IndexOf(sortableList[i]), i);
            }
        }
    }
}
