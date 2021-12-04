// SPDX-FileCopyrightText: Copyright (c) 2021, Samuel Wu
//
// SPDX-License-Identifier: BSD-3-Clause
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using VideoLister;

namespace TestApp
{
    /// <summary>
    /// Test application to list videos from YouTube.
    /// </summary>
    internal class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Video Lister Test Application.");

            // Ask the user if they want test the library
            Console.Write("Do you want to test the library, Y or N: ");
            while (true)
            {
                ConsoleKey input = Console.ReadKey().Key;
                if (input == ConsoleKey.N)
                    Environment.Exit(1);
                else if (input == ConsoleKey.Y)
                    break;
                Console.WriteLine();
                Console.Write("Please press 'Y' or 'N': ");
            }

            // Download video information using the LikedVideosLister library
            try
            {
                Console.WriteLine("\nPlease wait. Downloading videos.");
                VideoDownloader Downloader = new VideoDownloader();
                YouTubeService youtubeService =
                    await Downloader.GetAuthCredentials();
                List<Video> Videos =
                    await VideoDownloader.GetVideos(
                        youtubeService,
                        "PLFsQleAWXsj_4yDeebiIADdH5FMayBiJo");

                Console.WriteLine("Writing results to videos.json");
                JObject EncodedJson = JsonCodec.EncodeJson(Videos);

                using (StreamWriter JsonFile = File.CreateText("videos.json"))
                using (JsonTextWriter Writer = new JsonTextWriter(JsonFile))
                {
                    EncodedJson.WriteTo(Writer);
                }
            }
            catch (FileNotFoundException E)
            {
                Console.WriteLine(
                    "To use this Application, you will need a " +
                    "\"client_secret.json\" in the application's directory.");
                Console.WriteLine(E.Message);
            }
            catch (HttpRequestException E)
            {
                Console.WriteLine(
                    "You will need an Internet connection to use this " +
                    "application.");
                Console.WriteLine(E.Message);
            }
            // Exits the application
            Console.WriteLine("Done. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
