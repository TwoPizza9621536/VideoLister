﻿/* Start of SPDX identifier expressions
 * SPDX-FileCopyrightText: 2021-2022 Samuel Wu
 * SPDX-License-Identifier: BSD-3-Clause
 * End of SPDX identifier expressions
 */

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