/*
 * SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors
 *
 * SPDX-License-Identifier: BSD-3-Clause
 */

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;

namespace VideoListerLibrary
{
    /// <summary>
    ///   The credentials needed to get personal play list, e.g. liked videos.
    /// </summary>
    public class AuthCredentials
    {
        /// <summary>
        ///   Asynchronously gets YouTube credential using OAuth 2.0.
        /// </summary>
        /// <param name="clientFile">
        ///   A string to the filename of the client secret. The default value
        ///   is "client_secret.json"
        /// </param>
        /// <returns>
        ///   <para>
        ///     The OAuth 2.0 and <see cref="YouTubeService" /> used to get
        ///     video meta-data.
        ///   </para>
        /// </returns>
        /// <exception cref="FileNotFoundException" />
        [STAThread]
        public async Task<YouTubeService> GetAuthCredentials(string clientFile = "client_secret.json")
        {
            UserCredential Credential;
            using (FileStream Stream = new FileStream(
                clientFile,
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
    }
}
