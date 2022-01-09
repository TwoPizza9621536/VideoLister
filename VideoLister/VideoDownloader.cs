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
    /// <include file='docs/VideoDownloader.xml' path='Namespace/Class'/>
    public class VideoDownloader
    {
        /// <include file='docs/VideoDownloader.xml' path='Namespace/Class/Property[@name="PageToken"]'/>
        public static string PageToken { get; set; }

        /// <include file='docs/VideoDownloader.xml' path='Namespace/Class/Property[@name="PlayListId"]'/>
        public static string PlayListId { get; set; }

        /// <include file='docs/VideoDownloader.xml' path='Namespace/Class/Property[@name="YoutubeService"]'/>
        public static YouTubeService YoutubeService { get; set; }

        /// <include file='docs/VideoDownloader.xml' path='Namespace/Class/Method[@name="GetPlaylistItemListResponse"]'/>
        public static async Task<PlaylistItemListResponse> GetPlaylistItemListResponse()
        {
            PlaylistItemsResource.ListRequest request =
                YoutubeService.PlaylistItems.List("snippet");
            request.PlaylistId = PlayListId;
            request.MaxResults = 50;
            request.PageToken = PageToken;

            return await request.ExecuteAsync();
        }

        /// <include file='docs/VideoDownloader.xml' path='Namespace/Class/Method[@name="GetPlaylistItemLists"]' />
        public static async Task<IList<PlaylistItemListResponse>> GetPlaylistItemLists()
        {
            IList<PlaylistItemListResponse> playlistLists =
                new List<PlaylistItemListResponse>();
            while (PageToken != null)
            {
                PlaylistItemListResponse response =
                    await GetPlaylistItemListResponse();
                playlistLists.Add(response);
                PageToken = response.NextPageToken;
            }

            return playlistLists;
        }

        /// <include file='docs/VideoDownloader.xml' path='Namespace/Class/Method[@name="GetVideoList"]'/>
        public static async Task<IList<Video>> GetVideoList()
        {
            IList<Video> videos = new List<Video>();
            while (PageToken != null)
            {
                PlaylistItemListResponse response = await GetPlaylistItemListResponse();
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
