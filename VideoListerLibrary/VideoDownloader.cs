/*
 * SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors
 *
 * SPDX-License-Identifier: BSD-3-Clause
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
        ///   The play-list that is requested to get videos from.
        /// </summary>
        /// <value>
        ///   A long string of characters that represents the play-list that the
        ///   videos belong to.
        /// </value>
        public static string PlayListId { get; set; }

        /// <summary>
        ///   OAuth2 data that is needed to get videos.
        /// </summary>
        /// <value>
        ///   <see cref="AuthCredentials" /> from Google.
        /// </value>
        public static YouTubeService YoutubeService { get; set; }

        /// <summary>
        ///   Asynchronously download 50 video meta-data at a time as a
        ///   play-list item list.
        /// </summary>
        /// <param name="pageToken">
        ///   The token to get the next page. The default value is an empty
        ///   string.
        /// </param>
        /// <returns>
        ///   The meta-data for the 50 videos in the list.
        /// </returns>
        public static async Task<PlaylistItemListResponse> GetPlaylist(string pageToken = "")
        {
            PlaylistItemsResource.ListRequest request =
                YoutubeService.PlaylistItems.List("snippet");
            request.PlaylistId = PlayListId;
            request.MaxResults = 50;
            request.PageToken = pageToken;

            return await request.ExecuteAsync();
        }

        /// <summary>
        ///   Recursively download meta-data from a play-list using
        ///   <see cref="GetPlaylist" />.
        /// </summary>
        /// <returns>
        ///   A list of videos from a play-list.
        /// </returns>
        public static async Task<IList<Video>> GetVideoList()
        {
            IList<Video> videos = new List<Video>();
            string PageToken = "";
            while (PageToken != null)
            {
                PlaylistItemListResponse response = await GetPlaylist(PageToken);
                IList<PlaylistItem> videoItems = response.Items;
                foreach (PlaylistItem item in videoItems)
                {
                    videos.Add(new Video
                    {
                        Title = item.Snippet.Title,
                        Id = item.Snippet.ResourceId.VideoId
                    });
                }
                PageToken = response.NextPageToken;
            }
            return videos;
        }
    }
}
