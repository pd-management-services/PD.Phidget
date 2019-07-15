namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using GalaSoft.MvvmLight.Command;
    using PD.Phidget.UserInterface.Configurator.View;
    using Phidget22;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class SoundSensorViewModel : MaintainablePhidgetViewModelBase<SoundSensor> {
        ISPLRangeViewModel selectedSPLRange;
        int speakerBeepFrequency = 1000;

        public SoundSensorViewModel(SoundSensor phidget) : base(phidget) {
            BeepSpeaker = new RelayCommand(() => {
                Console.Beep(SpeakerBeepFrequency, 2500);
            });
        }

        public override string AttachmentInfo => $"{phidget.DeviceFirmwareUpgradeString} - {phidget.DeviceName}";

        public RelayCommand BeepSpeaker { get; private set; }

        public ObservableCollection<ISPLRangeViewModel> SPLRanges { get; } = PopulateSPLRanges();

        static ObservableCollection<ISPLRangeViewModel> PopulateSPLRanges() {
            var collection = new ObservableCollection<ISPLRangeViewModel>();
            foreach (var value in new SPLRanges()) {
                collection.Add(value);
            }
            return collection;
        }

        public ISPLRangeViewModel SelectedSPLRange {
            get => selectedSPLRange;
            set {
                if (value == selectedSPLRange) return;
                selectedSPLRange = value;
                RaisePropertyChanged("SelectedSPLRange");
            }
        }

        public double MinChangeTrigger {
            get => phidget.MinSPLChangeTrigger;
        }

        public double MaxChangeTrigger {
            get => phidget.MaxSPLChangeTrigger;
        }

        public double ChangeTrigger {
            get => phidget.SPLChangeTrigger;
            set {
                if (value == phidget.SPLChangeTrigger) return;
                phidget.SPLChangeTrigger = value;
                RaisePropertyChanged("ChangeTrigger");
            }
        }

        public int MinDataInterval {
            get => phidget.MinDataInterval;
        }

        public int MaxDataInterval {
            get => phidget.MaxDataInterval;
        }

        public int DataInterval {
            get => phidget.DataInterval;
            set {
                if (value == phidget.DataInterval) return;
                phidget.DataInterval = value;
                RaisePropertyChanged("DataInterval");
            }
        }

        public double dB => phidget.dB;

        public double dBA => phidget.dBA;

        public double dBC => phidget.dBC;

        public double OctaveOne => phidget.Octaves[0];

        public double OctaveTwo => phidget.Octaves[1];

        public double OctaveThree => phidget.Octaves[2];

        public double OctaveFour => phidget.Octaves[3];

        public double OctaveFive => phidget.Octaves[4];

        public double OctaveSix => phidget.Octaves[5];

        public double OctaveSeven => phidget.Octaves[6];

        public double OctaveEight => phidget.Octaves[7];

        public double OctaveNine => phidget.Octaves[8];

        public double OctaveTen => phidget.Octaves[9];

        public int SpeakerBeepFrequency {
            get => speakerBeepFrequency;
            set {
                if (value == speakerBeepFrequency) return;
                speakerBeepFrequency = value;
                RaisePropertyChanged("SpeakerBeepFrequency");
            }
        }

        public int MinSpeakerBeepFrequency { get => 37; }

        public int MaxSpeakerBeepFrequency { get => 8000; }

        public override bool AddPhidget(IPhidgetViewModel viewModel) { return false; }

        public override void ShowMaintenanceWindow() {
            base.ShowMaintenanceWindow();

            phidget.Attach += (o, e) => {
                var sensor = o as SoundSensor;
                if(sensor != null) {
                    SelectedSPLRange = SPLRanges.Where(x => x.Range == sensor.SPLRange).FirstOrDefault();
                    RaisePropertyChanged("MinChangeTrigger");
                    RaisePropertyChanged("MaxChangeTrigger");
                    RaisePropertyChanged("MinDataInterval");
                    RaisePropertyChanged("MaxDataInterval");
                }
            };
            phidget.Detach += (o, e) => { };
            phidget.SPLChange += (o, e) => {
                var sensor = o as SoundSensor;
                if (sensor != null) {
                    SelectedSPLRange = SPLRanges.Where(x => x.Range == sensor.SPLRange).FirstOrDefault();
                    RaisePropertyChanged("dB");
                    RaisePropertyChanged("dBA");
                    RaisePropertyChanged("dBC");
                    RaisePropertyChanged("OctaveOne");
                    RaisePropertyChanged("OctaveTwo");
                    RaisePropertyChanged("OctaveThree");
                    RaisePropertyChanged("OctaveFour");
                    RaisePropertyChanged("OctaveFive");
                    RaisePropertyChanged("OctaveSix");
                    RaisePropertyChanged("OctaveSeven");
                    RaisePropertyChanged("OctaveEight");
                    RaisePropertyChanged("OctaveNine");
                    RaisePropertyChanged("OctaveTen");
                    RaisePropertyChanged("DataInterval");
                    RaisePropertyChanged("ChangeTrigger");
                }
            };
            this.ShowMaintenanceWindow<SoundSensorMaintenanceWindow>();
            phidget.Open();
        }

        protected override void HandleDetachFromPhidgetSpecificEvents() {
            phidget.SPLChange += null;
        }
    }
}
