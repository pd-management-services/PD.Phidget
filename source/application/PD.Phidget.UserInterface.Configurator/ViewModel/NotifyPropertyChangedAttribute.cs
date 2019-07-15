namespace PD.Phidget.UserInterface.Configurator.ViewModel {
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class NotifyPropertyChangedAttribute : Attribute {

        public NotifyPropertyChangedAttribute() { }
    }
}
