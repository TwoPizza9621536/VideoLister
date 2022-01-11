/*
 * SPDX-FileCopyrightText: 2021-2022 Samuel Wu
 *
 * SPDX-License-Identifier: BSD-3-Clause
 */

using Gtk;
using System;

namespace TestGUI
{
    internal class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.Init();

            var App = new Application("org.TestGUI.TestGUI", GLib.ApplicationFlags.None);
            App.Register(GLib.Cancellable.Current);

            var Win = new MainWindow();
            App.AddWindow(Win);

            var menu = new GLib.Menu();
            menu.AppendItem(new GLib.MenuItem("Help", "app.help"));
            menu.AppendItem(new GLib.MenuItem("About", "app.about"));
            menu.AppendItem(new GLib.MenuItem("Quit", "app.quit"));
            App.AppMenu = menu;

            var AboutAction = new GLib.SimpleAction("About", null);
            AboutAction.Activated += AboutActivated;
            App.AddAction(AboutAction);

            Win.ShowAll();
            Application.Run();
        }

        private static void AboutActivated(object sender, EventArgs e)
        {
            var about = new AboutDialog();
            about.Show();
            about.Close();
        }
    }
}
