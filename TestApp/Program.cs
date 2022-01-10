/* Start of SPDX identifier expressions
 * SPDX-FileCopyrightText: 2021-2022 Samuel Wu
 * SPDX-License-Identifier: BSD-3-Clause
 * End of SPDX identifier expressions
 */

using System;
using System.IO;
using System.Net.Http;
using System.Resources;
using System.Text.Json;
using System.Threading.Tasks;
using VideoListerLibrary;

namespace TestApp
{
    /// <summary>
    /// Test application to list videos from YouTube.
    /// </summary>
    internal class Program
    {
        private static async Task Main()
        {
            AuthCredentials credentials = new AuthCredentials();
            VideoDownloader.YoutubeService = await credentials.GetAuthCredentials();
            VideoDownloader.PlayListId = "PLFsQleAWXsj_4yDeebiIADdH5FMayBiJo";
            var result = await VideoDownloader.GetPlaylistItemListResponse();
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                MaxDepth = 64,
                AllowTrailingCommas = false
            };
            string json = JsonSerializer.Serialize(result, options);
            using (StreamWriter writer = new StreamWriter("result.json"))
            {
                writer.WriteLine(json.ToString());
            }
        }
    }
}
