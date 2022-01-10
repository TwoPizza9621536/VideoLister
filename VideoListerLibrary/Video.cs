﻿/* Start of SPDX identifier expressions
 * SPDX-FileCopyrightText: 2021-2022 Samuel Wu
 * SPDX-License-Identifier: BSD-3-Clause
 * End of SPDX identifier expressions
 */

namespace VideoListerLibrary
{
    /// <summary>
    ///   A class for YouTube videos.
    /// </summary>
    public class Video
    {
        /// <summary>
        ///  The id of the video.
        /// </summary>
        /// <value>
        ///   A long list of characters that represents the video in the URL.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        ///   The title of the video.
        /// </summary>
        /// <value>
        ///   A string that consist of at least 5 characters.
        /// </value>
        public string Title { get; set; }
    }
}