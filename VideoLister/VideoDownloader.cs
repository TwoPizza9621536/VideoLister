// SPDX-FileCopyrightText: Copyright (c) 2021-2022, Samuel Wu
//
// SPDX-License-Identifier: BSD-3-Clause
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Threading.Tasks;

namespace VideoListerLibrary
{
    /// <summary>
    /// Get liked video meta-data using YouTube Data API v3.
    /// </summary>
    public class VideoDownloader
    {
        public static string PageToken { get; set; }
        public static string PlayListId { set; get; }

        public static async Task<PlaylistItemListResponse>
            GetPlaylistItemAsync(YouTubeService youtubeService)
        {
            PlaylistItemsResource.ListRequest request =
                youtubeService.PlaylistItems.List("snippet");
            request.PlaylistId = PlayListId;
            request.MaxResults = 50;
            request.PageToken = PageToken;

            return await request.ExecuteAsync();
        }
    }
}
