// SPDX-FileCopyrightText: Copyright (c) 2021-2022, Samuel Wu
//
// SPDX-License-Identifier: BSD-3-Clause
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace VideoListerLibrary
{
    public class AuthenticationCredentials
    {
        /// <summary>
        /// Gets YouTube credential using OAuth 2.0.
        /// </summary>
        /// <exception cref="FileNotFoundException"/>
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

            return new YouTubeService(
                new BaseClientService.Initializer()
                {
                    HttpClientInitializer = Credential,
                    ApplicationName = GetType().ToString()
                });
        }
    }
}
