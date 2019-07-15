namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;
    using System.Collections.ObjectModel;

    public interface ISPLRangesViewModel {
        ISPLRangeViewModel OneHundredTwoDecibelSPLRange { get; }
        ISPLRangeViewModel EightyTwoDecibelSPLRange { get; }
    }

    public interface ISPLRangeViewModel {
        int Id { get; }
        SPLRange Range { get; }
        string DisplayName { get; }
    }

    public abstract class SPLRangeViewModelBase : ISPLRangeViewModel {
        public int Id => (int)Range;

        public abstract SPLRange Range { get; }

        public abstract string DisplayName { get; }
    }

    public class OneHundredTwoDecibelSPLRange : SPLRangeViewModelBase {
        public override SPLRange Range => SPLRange.dB_102;

        public override string DisplayName => "102 dB";
    }

    public class EightyTwoDecibelSPLRange : SPLRangeViewModelBase {
        public override SPLRange Range => SPLRange.dB_82;

        public override string DisplayName => "82 dB";
    }

    public class SPLRanges : ReadOnlyCollection<ISPLRangeViewModel>, ISPLRangesViewModel {
        public SPLRanges() : base(new ISPLRangeViewModel[] {
            new OneHundredTwoDecibelSPLRange()
            , new EightyTwoDecibelSPLRange()
        }) { }

        public ISPLRangeViewModel OneHundredTwoDecibelSPLRange => base[0];

        public ISPLRangeViewModel EightyTwoDecibelSPLRange => base[1];
    }
}
