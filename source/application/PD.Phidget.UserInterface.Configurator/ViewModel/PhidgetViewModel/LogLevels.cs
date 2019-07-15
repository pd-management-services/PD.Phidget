namespace PD.Phidget.UserInterface.Configurator.ViewModel.PhidgetViewModel {
    using Phidget22;
    using System.Collections.ObjectModel;

    public interface ILogLevelViewModels {
        ILogLevelViewModel Critical { get; }
        ILogLevelViewModel Error { get; }
        ILogLevelViewModel Warning { get; }
        ILogLevelViewModel Info { get; }
        ILogLevelViewModel Debug { get; }
        ILogLevelViewModel Verbose { get; }
    }

    public class LogLevelViewModels : ReadOnlyCollection<ILogLevelViewModel>, ILogLevelViewModels {
        public LogLevelViewModels() : base(new ILogLevelViewModel[] {
            new CriticalLogLevelViewModel()
            , new ErrorLogLevelViewModel()
            , new WarningLogLevelViewModel()
            , new InfoLogLevelViewModel()
            , new DebugLogLevelViewModel()
            , new VerboseLogLevelViewModel() }) { }

        public ILogLevelViewModel Critical => base[0];

        public ILogLevelViewModel Error => base[1];

        public ILogLevelViewModel Warning => base[2];

        public ILogLevelViewModel Info => base[3];

        public ILogLevelViewModel Debug => base[4];

        public ILogLevelViewModel Verbose => base[5];
    }

    public interface ILogLevelViewModel {
        int Id { get; }
        LogLevel LogLevel { get; }
        string DisplayName { get; }
    }

    public abstract class LogLevelViewModelBase : ILogLevelViewModel {

        public int Id { get { return (int)LogLevel; } }

        public abstract LogLevel LogLevel { get; }

        public abstract string DisplayName { get; }
    }

    public class CriticalLogLevelViewModel : LogLevelViewModelBase {
        public override LogLevel LogLevel => LogLevel.Critical;

        public override string DisplayName => "Critical";
    }

    public class ErrorLogLevelViewModel : LogLevelViewModelBase {
        public override LogLevel LogLevel => LogLevel.Error;

        public override string DisplayName => "Error";
    }

    public class WarningLogLevelViewModel : LogLevelViewModelBase {
        public override LogLevel LogLevel => LogLevel.Warning;

        public override string DisplayName => "Warning";
    }

    public class InfoLogLevelViewModel : LogLevelViewModelBase {
        public override LogLevel LogLevel => LogLevel.Info;

        public override string DisplayName => "Info";
    }

    public class DebugLogLevelViewModel : LogLevelViewModelBase {
        public override LogLevel LogLevel => LogLevel.Debug;

        public override string DisplayName => "Debug";
    }

    public class VerboseLogLevelViewModel : LogLevelViewModelBase {
        public override LogLevel LogLevel => LogLevel.Verbose;

        public override string DisplayName => "Verbose";
    }
}
