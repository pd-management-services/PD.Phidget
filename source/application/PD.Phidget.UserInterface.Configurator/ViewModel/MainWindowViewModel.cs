namespace PD.Phidget.UserInterface.Configurator.ViewModel {
    using GalaSoft.MvvmLight.Command;
    using PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel;
    using Phidget22;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Windows;

    public class MainWindowViewModel : BindableObject {
        readonly Manager manager = new Manager();
        readonly IPhidgetViewModelBuilder viewModelBuilder = new PhidgetViewModelBuilder();

        public MainWindowViewModel() {
            Net.EnableServerDiscovery(ServerType.DeviceRemote);
            Net.ServerAdded += (e) => {
                App.Current.Dispatcher.Invoke((Action)delegate { // https://stackoverflow.com/questions/18331723/this-type-of-collectionview-does-not-support-changes-to-its-sourcecollection-fro
                    var server = new PhidgetServerViewModel(e.Server);
                    PhidgetServers.Add(server);
                    PhidgetServers.Sort((a, b) => { return a.Name.CompareTo(b.Name); }); //Reference: https://stackoverflow.com/questions/19112922/sort-observablecollectionstring-through-c-sharp
                });
            };
            manager.Attach += (o, e) => {
                App.Current.Dispatcher.Invoke((Action)delegate { // https://stackoverflow.com/questions/18331723/this-type-of-collectionview-does-not-support-changes-to-its-sourcecollection-fro-fro
                    foreach (var server in PhidgetServers)
                    {
                        var phidgitViewModel = viewModelBuilder.Create(e.Channel);
                        server.AddPhidget(viewModelBuilder.Create(e.Channel));

                        if (phidgitViewModel is FourTimesThermocouplePhidgetViewModel)
                            server.AddPhidget(viewModelBuilder.Create(e.Channel, false));
                    }
                });
            };

            manager.Open();

            TreeviewSelectedItemChanged = new RelayCommand<object>(viewModel => {
                if (!(viewModel is IMaintainableViewModel)) return;
                ((IMaintainableViewModel)viewModel).ShowMaintenanceWindow();
            });

            WindowClosingCommand = new RelayCommand<CancelEventArgs>((args) => {
                manager.Attach += null;
                manager.Detach += null;
                manager.Close();
            });

            NetworkServerSelected = new RelayCommand<IPhidgetServerViewModel>(x => {
                Process.Start("http://" + x.IPAddress);
            });

            OpenURLMenuCommand = new RelayCommand<string>((value) => { Process.Start(value); });

            OpenAboutWindow = new RelayCommand(() => { this.ShowAboutWindow(); });

            OpenOptionsWindow = new RelayCommand(() => { this.ShowOptionsWindow(); });

            OpenLogs = new RelayCommand(() => {
                var basePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                Process.Start(Directory.Exists(basePath + @"\logs\") ? basePath + @"\logs\" : basePath);
            });

            ExitMenuCommand = new RelayCommand(() => { Application.Current.Shutdown(); });
        }

        public RelayCommand<CancelEventArgs> WindowClosingCommand { get; private set; }

        public RelayCommand ExitMenuCommand { get; private set; }

        public RelayCommand OpenLogs { get; private set; }
        
        public RelayCommand OpenAboutWindow { get; private set; }

        public RelayCommand OpenOptionsWindow { get; private set; }

        public RelayCommand<string> OpenURLMenuCommand { get; private set; }

        public RelayCommand<object> TreeviewSelectedItemChanged { get; private set; }

        public RelayCommand<IPhidgetServerViewModel> NetworkServerSelected { get; private set; }

        public ObservableCollection<IPhidgetServerViewModel> PhidgetServers { get; } = new ObservableCollection<IPhidgetServerViewModel>();
    }
}
