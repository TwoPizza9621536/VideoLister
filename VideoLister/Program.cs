/*
 * SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors
 *
 * SPDX-License-Identifier: BSD-3-Clause
 */

using CommandLine;
using System.IO;
using Terminal.Gui;

namespace VideoLister
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StringWriter helpWriter = new StringWriter();
            Parser parser = new Parser(with => with.HelpWriter = helpWriter);
            parser.ParseArguments<Options>(args)
                .WithParsed(Run);
        }

        private static void Run(Options opts)
        {
            Application.Init();
            Toplevel top = Application.Top;

            Window win = new Window()
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            top.Add(win);

            MenuBar menu = new MenuBar(
                new MenuBarItem[]
                {
                    new MenuBarItem ("_File", new MenuBarItem[]
                    {
                        new MenuBarItem ("_Quit", "", () => { if (Quit()) top.Running = false;})
                    })
                });

            top.Add(menu);

            static bool Quit()
            {
                int n = MessageBox.Query(
                    50,
                    7,
                    "Quit VideoLister",
                    "Do you want to quit this application?",
                    "Yes",
                    "No");
                return n == 0;
            }

            win.Add(
                new Label(3, 18, "Press F9 or ESC plus 9 to activate the menu bar")
            );

            Application.Run();
        }
    }
}
