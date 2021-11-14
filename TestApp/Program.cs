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
            // Write welcome message and license infomation
            Console.WriteLine("LikedVideoLister");
            Console.WriteLine("==============================================");
            Console.WriteLine(
                "Welcome, this is a program that lists all liked " +
                "videos from youtube.\nThis program is licensed under the " +
                "BSD 3-Clause License.\n\nBy using this program, you" +
                "automatically agree to the Google's and Youtube's ToS" +
                "and Privacy Policy.");

            // Ask the user if they want to continue
            Console.WriteLine(
                "Do you want to use this program, press 'Y' for " +
                "yes and 'N' for no: ");
            ConsoleKey input = new ConsoleKey();
            while (true)
            {
                input = Console.ReadKey().Key;
                Console.WriteLine();
                if (input == ConsoleKey.N)
                    Environment.Exit(1);
                else if (input == ConsoleKey.Y)
                    break;
                Console.WriteLine("Please press 'Y' or 'N': ");
            }

            // Downloader the video infomation using the likedvideoslister
            // library
            try
            {
                Console.WriteLine("Please wait. Downlading videos.\n");
                VideoDownloader Downloader = new VideoDownloader();
                YouTubeService youtubeService =
                    await Downloader.GetAuthCredentials();
                JObject JsonObject =
                    await VideoDownloader.GetVideos(youtubeService);
                IList<Video> Videos = JsonDecoder.DecodeJson(JsonObject);

                Console.WriteLine("     Video Title      |      Video ID     ");
                Console.WriteLine("==========================================");

                int ListIndex = 0;
                for (int I = 0; I < 50; I++)
                {
                    for (int J = ListIndex; J < ((int)Videos.Count); J++)
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
                Console.Write("To use this Application, you will need a ");
                Console.Write("\"client_secret.json\" in the application's ");
                Console.WriteLine("directory.");
                Console.WriteLine(E.Message);
            }
            catch (HttpRequestException E)
            {
                Console.Write("You will need an internet connection to use ");
                Console.WriteLine("this application.");
                Console.WriteLine(E.Message);
            }

            // Exits the application
            Console.WriteLine("Done. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
