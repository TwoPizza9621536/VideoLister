// SPDX-FileCopyrightText: Copyright (c) 2021, Samuel Wu
//
// SPDX-License-Identifier: BSD-3-Clause
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LikedVideoLister
{
    /// <summary>
    /// A downloader to get liked video meta-data using YouTube Data API v3.
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
        /// Gets video metadata from the liked videos playlist.
        /// </summary>
        /// <param name="youtubeService">
        /// YouTube OAuth 2.0 Credential.
        /// </param>
        /// <returns>
        /// List of liked videos as json.
        /// </returns>
        public static async Task<JObject> GetVideos(
            YouTubeService youtubeService)
        {
            ChannelsResource.ListRequest channelsListRequest =
                youtubeService.Channels.List("contentDetails");
            channelsListRequest.Mine = true;

            ChannelListResponse channelsListResponse =
                await channelsListRequest.ExecuteAsync();

            List<Video> Videos = new List<Video>();

            // Get the list of liked videos and add it to a list
            foreach (Channel channel in channelsListResponse.Items)
            {
                string likedListId =
                    channel.ContentDetails.RelatedPlaylists.Likes;
                string nextPageToken = "";
                while (nextPageToken != null)
                {
                    PlaylistItemsResource.ListRequest playlistItemsListRequest
                        = youtubeService.PlaylistItems.List("snippet");
                    playlistItemsListRequest.PlaylistId = likedListId;
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
            }

            // Converts the list to a json object
            string RawJson = JsonConvert.SerializeObject(Videos);
            string JsonSchema = "$Schema";
            string SchemaURI =
                "https://twopizza9621536.github.io/schema/json/videolist.json";

            JArray JsonArray = JArray.Parse(RawJson);
            JObject JsonObject = new JObject
            {
                { JsonSchema, SchemaURI }
            };
            JsonObject["Videos"] = JsonArray;
            return JsonObject;
        }
    }

    /// <summary>
    /// A json decoder for the videos
    /// </summary>
    public class JsonDecoder
    {
        /// <summary>
        /// Decodes json object to a immutable list
        /// </summary>
        /// <param name="JsonObject">The json object to decode</param>
        /// <returns>A immutable list of decoded objects</returns>
        public static IList<Video> DecodeJson(JObject JsonObject)
        {
            JArray JsonArray = (JArray)JsonObject["Videos"];
            IList<Video> Videos = JsonArray.ToObject<IList<Video>>();
            return Videos;
        }
    }

    /// <summary>
    /// Organize the video's title and id.
    /// </summary>
    public class Video
    {
        public string Title { get; set; }
        public string Id { get; set; }
    }
}
