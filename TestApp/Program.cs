// SPDX-FileCopyrightText: Copyright (c) 2021, Samuel Wu
//
// SPDX-License-Identifier: BSD-3-Clause
using Google.Apis.YouTube.v3;
using LikedVideoLister;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("LikedVideoLister");
            Console.WriteLine("================");

            try
            {
                VideoDownloader Downloader = new VideoDownloader();
                YouTubeService youtubeService =
                    await Downloader.GetAuthCredentials();
                JObject JsonObject =
                    await VideoDownloader.GetVideos(youtubeService);

                using (StreamWriter JsonFile = File.CreateText("videos.json"))
                {
                    JsonFile.WriteLine(JsonObject.ToString());
                }
            }
            catch (FileNotFoundException e)
            {
                Console.Write("To use this Application, you will need a ");
                Console.Write("\"client_secret.json\" in the application's ");
                Console.WriteLine("directory.");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Got liked videos. See \"videos.json\" file");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
