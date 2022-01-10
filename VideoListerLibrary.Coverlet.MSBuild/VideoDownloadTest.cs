/* Start of SPDX identifier expressions
 * SPDX-FileCopyrightText: 2021-2022 Samuel Wu
 * SPDX-License-Identifier: BSD-3-Clause
 * End of SPDX identifier expressions
 */

using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace VideoListerLibrary.Coverlet
{
    /// <summary>
    ///   Unit tests to check if the down-loader is working as intended.
    /// </summary>
    public class VideoDownloadTest
    {
        private readonly string _testDirectory;
        private readonly string _playlist;
        private readonly AuthCredentials _credentials;

        /// <summary>
        ///   A constructor that sets all the variable when the tests are run.
        /// </summary>
        public VideoDownloadTest()
        {
            _testDirectory = Path.Combine(Directory.GetCurrentDirectory(), "tests");
            _playlist = "PLFsQleAWXsj_4yDeebiIADdH5FMayBiJo";
            _credentials = new AuthCredentials();
        }

        /// <summary>
        ///   <para>
        ///     Check if it can download a single page from a play-list and
        ///     gives the same videos from the play-list.
        ///   </para>
        ///   <para>
        ///     Asserts True if the result matches the expected output.
        ///   </para>
        /// </summary>
        [Fact]
        public async Task SinglePageTest()
        {
            VideoDownloader.YoutubeService = await _credentials.GetAuthCredentials();
            VideoDownloader.PlayListId = _playlist;

            var result = await VideoDownloader.GetPlaylist();
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                MaxDepth = 64,
                AllowTrailingCommas = false
            };
            string json = JsonSerializer.Serialize(result, options);

            using (StreamReader reader = new StreamReader(Path.Combine(_testDirectory, "../../../SinglePageTest.json")))
            {
                string expectedData = reader.ReadToEnd().TrimEnd();
                Assert.Equal(expectedData, json);
            }
        }
    }
}
