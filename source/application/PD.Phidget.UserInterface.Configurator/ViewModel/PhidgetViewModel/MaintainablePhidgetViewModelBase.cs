namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using System.ComponentModel;
    using GalaSoft.MvvmLight.Command;
    using Phidget22;

    public abstract class MaintainablePhidgetViewModelBase<T> : PhidgetViewModelBase<T>, IMaintainableViewModel where T : Phidget {
        bool errorWindowShown;

        protected MaintainablePhidgetViewModelBase(T phidget) : base(phidget) {
            WindowClosingCommand = new RelayCommand<CancelEventArgs>((args) => {
                phidget.Attach += null;
                phidget.Detach += null;
                phidget.Error += null;
                HandleDetachFromPhidgetSpecificEvents();
            });

            OpenAddressingInformation = new RelayCommand(() => {
                new AddressingInformationViewModel(this.phidget).ShowMaintenanceWindow();
            }, true);
        }

        public abstract string AttachmentInfo { get; }

        public RelayCommand<CancelEventArgs> WindowClosingCommand { get; }

        public RelayCommand OpenAddressingInformation { get; }

        protected abstract void HandleDetachFromPhidgetSpecificEvents();

        protected virtual void HandleError() {
            this.ShowErrorEventLogWindow(phidget);
            errorWindowShown = true;
        }

        public virtual void ShowMaintenanceWindow() {
            phidget.Error += (o, e) => {
                if (!errorWindowShown) {
                    HandleError();
                }
            };
        }
    }
}