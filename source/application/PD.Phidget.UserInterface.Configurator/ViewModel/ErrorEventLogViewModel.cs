namespace PD.Phidget.UserInterface.Configurator.ViewModel {
    using GalaSoft.MvvmLight.Command;
    using Phidget22;
    using System;
    using System.Windows;

    public class ErrorEventLogViewModel : BindableObject {
        Phidget phidget;
        string errorMessages;
        string lastErrorMessage;
        int repeatedLastErrorMessageCount;
        int errorCount = 0;

        public ErrorEventLogViewModel(Phidget phidget) {
            this.phidget = phidget;

            this.phidget.Error += (o, e) => {
                if(lastErrorMessage != e.Description) {
                    repeatedLastErrorMessageCount = 0;
                    ErrorMessages += $"{DateTime.Now:MMMM dd, yyyy H:mm:ss tt} - {e.Description}{Environment.NewLine}";
                } else {

                    repeatedLastErrorMessageCount++;
                    if (repeatedLastErrorMessageCount % 100 == 0) {
                        ErrorMessages += $"last message repeated {repeatedLastErrorMessageCount} times{Environment.NewLine}";
                    }
                }
                lastErrorMessage = e.Description;
                ErrorCount++;
            };

            Close = new RelayCommand<Window>((window) => {
                this.phidget.Error += null;
                window.Close();
            });

            ClearLogs = new RelayCommand(() => {
                lastErrorMessage = "";
                ErrorCount = 0;
                ErrorMessages = "";
            });
        }

        public RelayCommand<Window> Close { get; private set; }

        public RelayCommand ClearLogs { get; private set; }

        public int ErrorCount {
            get => errorCount;
            private set {
                errorCount = value;
                RaisePropertyChanged("ErrorCount");
            }
        }

        public string ErrorMessages {
            get => errorMessages;
            private set {
                errorMessages = value;
                RaisePropertyChanged("ErrorMessages");
            }
        }

    }
}
