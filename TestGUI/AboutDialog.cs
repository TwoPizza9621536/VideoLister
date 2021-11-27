using Gtk;

namespace TestGUI
{
    internal class AboutDialog : Window
    {
        public AboutDialog() : this(new Builder("MainWindow.glade"))
        {
        }

        private AboutDialog(Builder builder) :
            base(builder.GetRawOwnedObject("AboutDialog"))
        {
        }
    }
}
