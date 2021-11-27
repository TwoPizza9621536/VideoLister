using Gtk;

namespace TestGUI
{
    internal class MainWindow : Window
    {
        public MainWindow() : this(new Builder("MainWindow.glade"))
        {
        }

        private MainWindow(Builder builder) :
            base(builder.GetRawOwnedObject("MainWindow"))
        {
        }

        private static void OnActivated(object sender, DeleteEventArgs e)
        {
            Application.Quit();
        }
    }
}
