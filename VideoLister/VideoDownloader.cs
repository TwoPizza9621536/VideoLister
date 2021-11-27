// SPDX-FileCopyrightText: Copyright (c) 2021, Samuel Wu
//
// SPDX-License-Identifier: BSD-3-Clause
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace VideoLister
{
    /// <summary>
    /// Get liked video meta-data using YouTube Data API v3.
    /// </summary>
    public class VideoDownloader
    {
        /// <summary>
        /// Gets YouTube credential using OAuth 2.0.
        /// </summary>
        /// <returns>
        /// YouTube OAuth 2.0 Credential.
        /// </returns>

        private static bool IsMine { get; set; }

        [STAThread]
        public async Task<YouTubeService> GetAuthCredentials()
        {
            UserCredential Credential;
            using (FileStream Stream = new FileStream(
                "client_secret.json",
                FileMode.Open,
                FileAccess.Read))
            {
                Credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(Stream).Secrets,
                    new[] { YouTubeService.Scope.YoutubeReadonly },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(this.GetType().ToString()));
            }

            YouTubeService youtubeService = new YouTubeService(
                new BaseClientService.Initializer()
                {
                    HttpClientInitializer = Credential,
                    ApplicationName = GetType().ToString()
                });

            return youtubeService;
        }

        /// <summary>
        /// Gets video meta-data from a playlist.
        /// </summary>
        /// <param name="youtubeService">
        /// YouTube OAuth 2.0 Credential.
        /// </param>
        /// <param name="PlayListId">
        /// The Id of the playlist.
        /// </param>
        /// <returns>
        /// Playlist of videos as a List.
        /// </returns>
        public static async Task<List<Video>> GetVideos(
            YouTubeService youtubeService,
            string PlayListId)
        {
            List<Video> Videos = new List<Video>();

            // Get the list of liked videos and add it to a list
            string nextPageToken = "";
            while (nextPageToken != null)
            {
                PlaylistItemsResource.ListRequest playlistItemsListRequest
                    = youtubeService.PlaylistItems.List("snippet");
                playlistItemsListRequest.PlaylistId = PlayListId;
                playlistItemsListRequest.MaxResults = 50;
                playlistItemsListRequest.PageToken = nextPageToken;

                PlaylistItemListResponse playlistItemsListResponse =
                    await playlistItemsListRequest.ExecuteAsync();

                foreach (PlaylistItem playlistItem in
                    playlistItemsListResponse.Items)
                {
                    Video VideoItem = new Video
                    {
                        Title = playlistItem.Snippet.Title,
                        Id = playlistItem.Snippet.ResourceId.VideoId
                    };
                    Videos.Add(VideoItem);
                }
                nextPageToken = playlistItemsListResponse.NextPageToken;
            }
            return Videos;
        }

        /// <summary>
        /// Gets the
        /// </summary>
        /// <param name="youtubeService"></param>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public async Task<List<Channel>> GetChannels(
            YouTubeService youtubeService,
            string channelId)
        {
            List<Channel> Channels = new List<Channel>();
            ChannelsResource.ListRequest channelsListRequest =
                youtubeService.Channels.List("contentDetails");

            ChannelListResponse channelsListResponse =
                await channelsListRequest.ExecuteAsync();

            foreach (Channel channel in channelsListResponse.Items) Channels.Add(channel);
            return Channels;
        }

        public static async Task<List<Playlist>> GetPlaylists(
            YouTubeService youtubeService)
        {
            List<Playlist> Playlists = new List<Playlist>();
            PlaylistsResource.ListRequest playlistListRequest = youtubeService.Playlists.List("snippet");
            if (IsMine) playlistListRequest.Mine = IsMine;
            else playlistListRequest. ;

            PlaylistListResponse playlistListResponse = await playlistListRequest.ExecuteAsync();

            foreach (Playlist playlist in playlistListResponse.Items) Playlists.Add(playlist);
            return Playlists;
        }
    }
}
