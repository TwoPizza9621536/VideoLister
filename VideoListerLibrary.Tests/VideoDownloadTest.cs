/*
 * SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors
 *
 * SPDX-License-Identifier: BSD-3-Clause
 */

using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace VideoListerLibrary.Tests
{
    /// <summary>
    ///   Unit tests to check if the down-loader is working as intended.
    /// </summary>
    public class VideoDownloadTest
    {
        /// <summary>
        /// The credential we need to run the test.
        /// </summary>
        private readonly AuthCredentials _credentials;

        /// <summary>
        ///   The play-list that we are checking against the test data.
        /// </summary>
        private readonly string _playlist;

        /// <summary>
        ///   Set the configuration of the <see cref="JsonSerializer"/> to the
        ///   options we want to test against with.
        /// </summary>
        private readonly JsonSerializerOptions _options;

        /// <summary>
        ///   The schema we wanted the data to check against.
        /// </summary>
        private readonly string _schema;

        /// <summary>
        ///   A constructor that sets all the variable we defined when the tests
        ///   are run.
        /// </summary>
        public VideoDownloadTest()
        {
            _credentials = new AuthCredentials();
            _playlist = "PLFsQleAWXsj_4yDeebiIADdH5FMayBiJo";
            _options = new JsonSerializerOptions
            {
                AllowTrailingCommas = false,
                WriteIndented = true
            };
            _schema = "https://twopizza9621536.github.io/schema/json/videolist.json";
        }

        /// <summary>
        ///   <para>
        ///     Check if it can download an entire play-list (which include
        ///     downloading a single page) and if the list is correct.
        ///   </para>
        ///   <para>
        ///     Asserts True if the result matches the expected output.
        ///   </para>
        /// </summary>
        [Fact]
        public async Task VideoListTest()
        {
            VideoDownloader.YoutubeService = await _credentials.GetAuthCredentials();
            VideoDownloader.PlayListId = _playlist;

            var result = await VideoDownloader.GetVideoList();
            VideoList list = new VideoList()
            {
                Schema = _schema,
                PlaylistId = _playlist,
                PlaylistName = "important videos",
                Videos = result
            };
            var json = JsonSerializer.Serialize(list, _options);
            using (StreamReader reader = new StreamReader("../../../tests/VideoListTest.json"))
            {
                string expectedData = reader.ReadToEnd().TrimEnd();
                Assert.Equal(expectedData, json);
            }
        }
    }
}
