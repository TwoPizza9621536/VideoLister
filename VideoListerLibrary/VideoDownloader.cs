/* Start of SPDX identifier expressions
 * SPDX-FileCopyrightText: 2021-2022 Samuel Wu
 * SPDX-License-Identifier: BSD-3-Clause
 * End of SPDX identifier expressions
 */

using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoListerLibrary
{
    /// <summary>
    ///   Asynchronously gets video meta-data using YouTube Data API v3.
    /// </summary>
    public class VideoDownloader
    {
        /// <summary>
        ///   The token to get the next set of videos in a play list.
        /// </summary>
        public static string PageToken { get; set; }

        /// <summary>
        ///   The play-list that is requested to get videos from.
        /// </summary>
        public static string PlayListId { get; set; }

        /// <summary>
        ///   <see cref="AuthCredentials"/>
        ///   that is needed to get videos.
        /// </summary>
        public static YouTubeService YoutubeService { get; set; }

        /// <summary>
        ///   Asynchronously download 50 video meta-data at a time as a
        ///   play-list item list.
        /// </summary>
        /// <returns>
        ///   The meta-data for the 50 videos in the list.
        /// </returns>
        public static async Task<PlaylistItemListResponse> GetPlaylist()
        {
            PlaylistItemsResource.ListRequest request =
                YoutubeService.PlaylistItems.List("snippet");
            request.PlaylistId = PlayListId;
            request.MaxResults = 50;
            request.PageToken = PageToken;

            return await request.ExecuteAsync();
        }

        /// <summary>
        ///   Recursively download meta-data from a play-list using
        ///   <see cref="GetPlaylist"/>.
        /// </summary>
        /// <returns>
        ///   A list of videos from a play-list.
        /// </returns>
        public static async Task<IList<Video>> GetVideoList()
        {
            IList<Video> videos = new List<Video>();
            while (PageToken != null)
            {
                PlaylistItemListResponse response = await GetPlaylist();
                IList<PlaylistItem> videoItems = response.Items;
                foreach (PlaylistItem item in videoItems)
                {
                    videos.Add(new Video
                    {
                        Title = item.Snippet.Title,
                        Id = item.Id
                    });
                }
                PageToken = response.NextPageToken;
            }
            return videos;
        }
    }
}
