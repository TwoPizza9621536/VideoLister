/*
 * SPDX-FileCopyrightText: 2022 The Video Lister Contributors
 *
 * SPDX-License-Identifier: BSD-3-Clause
 */
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace VideoLister.Gui
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            button.Content = "Hello, Avalonia";
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
