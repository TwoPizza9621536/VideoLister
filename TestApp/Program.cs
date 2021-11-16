// SPDX-FileCopyrightText: Copyright (c) 2021, Samuel Wu
//
// SPDX-License-Identifier: BSD-3-Clause
using Google.Apis.YouTube.v3;
using LikedVideoLister;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestApp
{
    /// <summary>
    /// The console application for listing liked videos from YouTube.
    /// </summary>
    class Program
    {
        static async Task Main()
        {
            // Write welcome message and license information
            Console.WriteLine("LikedVideoLister");
            Console.WriteLine("=============================================");
            Console.WriteLine(
                "Welcome, this is a program that lists all liked " +
                "videos from YouTube.\nThis program is licensed under the " +
                "BSD 3-Clause License.\n\nBy using this program, you" +
                "automatically agree to the Google's and YouTube's ToS" +
                "and Privacy Policy.");

            // Ask the user if they want to continue
            Console.Write(
                "Do you want to use this program, press 'Y' for " +
                "yes and 'N' for no: ");
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

            // Download the video information using the LikedVideosLister
            // library
            try
            {
                Console.WriteLine("\nPlease wait. Downloading videos.\n");
                VideoDownloader Downloader = new VideoDownloader();
                YouTubeService youtubeService =
                    await Downloader.GetAuthCredentials();
                JObject JsonObject =
                    await VideoDownloader.GetVideos(youtubeService);
                IList<Video> Videos = JsonDecoder.DecodeJson(JsonObject);

                Console.WriteLine("     Video Title     |     Video ID      ");
                Console.WriteLine("=========================================");

                int ListIndex = 0;
                for (int I = 0; I < 50; I++)
                {
                    for (int J = ListIndex;
                        J < (int)Videos.Count - ListIndex;
                        J++)
                    {
                        Console.WriteLine(
                            "{0} | {1}",
                            Videos[J].Title,
                            Videos[J].Id);
                    }
                    Console.WriteLine("Press enter to continue...");
                    while (Console.ReadKey().Key != ConsoleKey.Enter) ;
                    ListIndex += 50;
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
                    "You will need an Internet connection to use " +
                    "this application.");
                Console.WriteLine(E.Message);
            }

            // Exits the application
            Console.WriteLine("Done. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
