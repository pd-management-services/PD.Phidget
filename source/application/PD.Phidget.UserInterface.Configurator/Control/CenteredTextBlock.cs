namespace PD.Phidget.UserInterface.Configurator.Control {
    using System.Windows;
    using System.Windows.Controls;

    public class CenteredTextBlock : TextBlock {
        // Please do not remove constructor, allows WPF design view to be rendered properly: http://stackoverflow.com/questions/10500805/rendering-derived-user-control-in-designer-view
        public CenteredTextBlock() : base() {
            this.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}
