﻿// SPDX-FileCopyrightText: Copyright (c) 2021, Samuel Wu
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
                    new FileDataStore(GetType().ToString()));
            }

            return new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = Credential,
                    ApplicationName = GetType().ToString()
                });
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

            string nextPageToken = "";
            while (nextPageToken != null)
            {
                PlaylistItemsResource.ListRequest Request
                    = youtubeService.PlaylistItems.List("snippet");
                Request.PlaylistId = PlayListId;
                Request.MaxResults = 50;
                Request.PageToken = nextPageToken;

                PlaylistItemListResponse Response =
                    await Request.ExecuteAsync();

                foreach (PlaylistItem playlistItem in Response.Items)
                {
                    Video VideoItem = new Video(
                        playlistItem.Snippet.ResourceId.VideoId,
                        playlistItem.Snippet.Title);
                    Videos.Add(VideoItem);
                }
                nextPageToken = Request.PageToken;
            }

            return Videos;
        }
    }
}
