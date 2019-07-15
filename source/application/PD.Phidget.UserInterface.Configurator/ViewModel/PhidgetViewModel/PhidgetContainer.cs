namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class PhidgetContainer : BindableObject {
        IEnumerable<IPhidgetViewModel> items = new Collection<IPhidgetViewModel>();
        string name;

        public string Name {
            get => name;
            set {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public IEnumerable<IPhidgetViewModel> Items {
            get => items;
            set {
                items = value;
                RaisePropertyChanged("Items");
            }
        }
    }
}
