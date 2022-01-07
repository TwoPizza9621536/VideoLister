// SPDX-FileCopyrightText: Copyright (c) 2021, Samuel Wu
//
// SPDX-License-Identifier: BSD-3-Clause
using System;
using System.IO;
using System.Net.Http;
using System.Resources;
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
            ResourceManager rm =
                new ResourceManager("TestApp.Properties.en-US",
                                    typeof(Program).Assembly);
            Console.Write(rm.GetString("Title"));
            Console.Write(rm.GetString("Prompt"));
            while (true)
            {
                ConsoleKey input = Console.ReadKey().Key;
                if (input == ConsoleKey.N)
                    Environment.Exit(1);
                else if (input == ConsoleKey.Y)
                    break;
                Console.WriteLine();
                Console.Write(rm.GetString("continuePrompt"));
            }

            try
            {
                Console.WriteLine(rm.GetString("downloadPrompt"));
                AuthCredentials credentials = new AuthCredentials();
                await credentials.GetAuthCredentials();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(rm.GetString("fileNotFound"));
                Console.WriteLine(e.Message);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(rm.GetString("noInternetConnection"));
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(rm.GetString("exitPrompt"));
            Console.ReadKey();
        }
    }
}
