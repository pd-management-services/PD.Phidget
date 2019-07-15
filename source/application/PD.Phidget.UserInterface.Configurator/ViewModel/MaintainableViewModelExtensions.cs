namespace PD.Phidget.UserInterface.Configurator.ViewModel {
    using PD.Phidget.UserInterface.Configurator.View;
    using System;
    using System.Windows;
    using Phidget22;

    public static class MaintainableViewModelExtensions {
        public static void ShowMaintenanceWindow<T>(this IMaintainableViewModel viewModel) where T : Window, new() { //Reference: https://stackoverflow.com/questions/25845689/opening-new-window-in-mvvm-wpf
            var window = new T {
                DataContext = viewModel
            };
            window.Activate(); //Reference: https://stackoverflow.com/questions/257587/bring-a-window-to-the-front-in-wpf
            window.Topmost = true;
            window.Show();
        }

        public static void ShowErrorEventLogWindow(this IMaintainableViewModel viewmodel, Phidget phidget) {
            App.Current.Dispatcher.Invoke((Action)delegate {
                var window = new ErrorEventLogWindow() { DataContext = new ErrorEventLogViewModel(phidget) };
                window.Activate();
                window.Topmost = true;
                window.Show();
            });
        }

        public static void ShowAboutWindow(this MainWindowViewModel viewmodel) {
            App.Current.Dispatcher.Invoke((Action)delegate { // https://stackoverflow.com/questions/18331723/this-type-of-collectionview-does-not-support-changes-to-its-sourcecollection-fro
                var window = new AboutWindow() { DataContext = new AboutViewModel() };
                window.Activate();
                window.Topmost = true;
                window.Show();
            });
        }

        public static void ShowOptionsWindow(this MainWindowViewModel viewmodel) {
            App.Current.Dispatcher.Invoke((Action)delegate { // https://stackoverflow.com/questions/18331723/this-type-of-collectionview-does-not-support-changes-to-its-sourcecollection-fro
                new OptionsViewModel().ShowMaintenanceWindow();
            });
        }
    }
}
