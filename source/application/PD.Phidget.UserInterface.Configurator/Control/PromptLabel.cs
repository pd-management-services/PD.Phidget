namespace PD.Phidget.UserInterface.Configurator.Control {
    using System.Windows.Controls;

    public class PromptLabel : Label {
        bool promptAdded = false;

        // Please do not remove constructor, allows WPF design view to be rendered properly: http://stackoverflow.com/questions/10500805/rendering-derived-user-control-in-designer-view
        public PromptLabel() : base() { }

        protected override void OnContentChanged(object oldContent, object newContent) {
            base.OnContentChanged(oldContent, newContent);

            if (!promptAdded) {
                promptAdded = true;
                Content = $"{newContent}: ";

            } else {
                promptAdded = false;
            }
        }
    }
}
