namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;
    using System.Collections.ObjectModel;

    public interface IThermocoupleTypesViewModel {
        IThermocoupleTypeViewModel J { get; }
        IThermocoupleTypeViewModel K { get; }
        IThermocoupleTypeViewModel E { get; }
        IThermocoupleTypeViewModel T { get; }
    }

    public class ThermocoupleTypesViewModel : ReadOnlyCollection<IThermocoupleTypeViewModel>, IThermocoupleTypesViewModel {
        public ThermocoupleTypesViewModel() : base(new IThermocoupleTypeViewModel[] {
            new JThermocoupleTypeViewModel()
            , new KThermocoupleTypeViewModel()
            , new EThermocoupleTypeViewModel()
            , new TThermocoupleTypeViewModel()
        }) { }

        public IThermocoupleTypeViewModel J => base[0];

        public IThermocoupleTypeViewModel K => base[1];

        public IThermocoupleTypeViewModel E => base[2];

        public IThermocoupleTypeViewModel T => base[3];
    }

    public interface IThermocoupleTypeViewModel {
        int Id { get; }
        ThermocoupleType Type { get; }
        string DisplayName { get; }
    }

    public abstract class ThermocoupleTypeViewModelBase : IThermocoupleTypeViewModel {

        public int Id => (int)Type;

        public abstract ThermocoupleType Type { get; }

        public virtual string DisplayName  => $"{Type}-Type";
    }

    public class KThermocoupleTypeViewModel : ThermocoupleTypeViewModelBase {
        public override ThermocoupleType Type => ThermocoupleType.K;
    }

    public class EThermocoupleTypeViewModel : ThermocoupleTypeViewModelBase {
        public override ThermocoupleType Type => ThermocoupleType.E;
    }

    public class JThermocoupleTypeViewModel : ThermocoupleTypeViewModelBase {
        public override ThermocoupleType Type => ThermocoupleType.J;
    }

    public class TThermocoupleTypeViewModel : ThermocoupleTypeViewModelBase {
        public override ThermocoupleType Type => ThermocoupleType.T;
    }
}
