namespace PD.Phidget.UserInterface.Configurator.ViewModel {
    using GalaSoft.MvvmLight.Command;
    using PD.Phidget.UserInterface.Configurator.View;
    using PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel;
    using Phidget22;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;

    public class OptionsViewModel : BindableObject, IMaintainableViewModel {
        ILogLevelViewModel selectedLogLevel;

        public OptionsViewModel() {
            Close = new RelayCommand<Window>((window) => {
                window.Close();
            });
        }

        public ObservableCollection<ILogLevelViewModel> LogLevels { get; } = PopulateLogLevels();

        public ILogLevelViewModel SelectedLogLevel {
            get => selectedLogLevel;
            set {
                if (value == selectedLogLevel) return;
                selectedLogLevel = value;
                RaisePropertyChanged("SelectedLogLevel");
            }
        }

        public RelayCommand<Window> Close { get; private set; }

        static ObservableCollection<ILogLevelViewModel> PopulateLogLevels() {
            var collection = new ObservableCollection<ILogLevelViewModel>();
            foreach (var value in new LogLevelViewModels()) {
                collection.Add(value);
            }
            return collection;
        }

        public void ShowMaintenanceWindow() {
            SelectedLogLevel = LogLevels.Where(viewModel => viewModel.LogLevel == LogLevel.Verbose).FirstOrDefault();
            this.ShowMaintenanceWindow<OptionsMaintenanceView>();
        }
    }
}
