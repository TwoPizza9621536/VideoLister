/*
 * SPDX-FileCopyrightText: 2021-2022 Samuel Wu
 *
 * SPDX-License-Identifier: BSD-3-Clause
 */

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
