namespace PD.Phidget.UserInterface.Configurator.ViewModel {
    using GalaSoft.MvvmLight.Command;
    using System.Windows;

    public class AboutViewModel : BindableObject {

        public AboutViewModel() {
            Close = new RelayCommand<Window>((window) => {
                window.Close();
            });
        }

        public RelayCommand<Window> Close { get; private set; }

        public string LibraryInformation { get { return Phidget22.Phidget.LibraryVersion; } }
    }
}
