/* Start of SPDX identifier expressions
 * SPDX-FileCopyrightText: 2021-2022 Samuel Wu
 * SPDX-License-Identifier: BSD-3-Clause
 * End of SPDX identifier expressions
 */

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
    /// <include file='docs/AuthCredentials.xml' path='Namespace/Class[@name="AuthCredentials"]/Member' />
    public class AuthCredentials
    {
        /// <include file='docs/AuthCredentials.xml' path='Namespace/Class/Method[@name="GetAuthCredentials"]'/>
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
    }
}
