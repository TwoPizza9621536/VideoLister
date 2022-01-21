/*
 * SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors
 *
 * SPDX-License-Identifier: BSD-3-Clause
 */

using CommandLine.Text;
using System.Collections.Generic;

namespace VideoLister
{
    internal class Options
    {
        [Usage(ApplicationAlias = "VideoLister")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>()
                {
                    new Example("Get and list videos from YouTube", new Options {} )
                };
            }
        }
    }
}
