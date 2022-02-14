/*
 * SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors
 *
 * SPDX-License-Identifier: BSD-3-Clause
 */

using System.Collections.Generic;

namespace VideoListerLibrary
{
    /// <summary>
    ///   A class to store the title and the id for YouTube videos.
    /// </summary>
    public class Video
    {
        /// <summary>
        ///   The id of the video.
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

        /// <summary>
        ///   Returns the Video object as a dictionary.
        /// </summary>
        /// <returns>
        ///   IDictionary&lt;string,string&gt;
        ///   <see cref="IDictionary{TKey, TValue}" />
        /// </returns>
        public IDictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>
            {
                { "Title", Title },
                { "Id", Id }
            };
        }
    }
}
