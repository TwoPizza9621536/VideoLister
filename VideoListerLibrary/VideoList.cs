/*
 * SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors
 *
 * SPDX-License-Identifier: BSD-3-Clause
 */

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VideoListerLibrary
{
    /// <summary>
    ///   A class to store the title, id of the videos.
    /// </summary>
    public class VideoList
    {
        /// <summary>
        ///   The schema that the video list is going to be in.
        /// </summary>
        /// <value>
        ///   An URL that points to a JSON schema.
        /// </value>
        [JsonPropertyName("$Schema")]
        public string Schema { get; set; }

        /// <summary>
        ///   A reference to the play-list that the videos belongs to
        /// </summary>
        /// <value>
        ///   A long list of characters that represents the play-list in the
        ///   URL.
        /// </value>
        public string PlaylistId { get; set; }

        /// <summary>
        ///   The name of the play-list that the videos belongs to
        /// </summary>
        /// <value>
        ///   The title of the play-list.
        /// </value>
        public string PlaylistName { get; set; }

        /// <summary>
        ///   The variable to the list of videos.
        /// </summary>
        /// <value>
        ///   A IList of the <see cref="Video"/>.
        /// </value>
        public IList<Video> Videos { set; get; }
    }
}
