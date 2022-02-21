# SPDX-FileCopyrightText: 2022 The Video Lister Contributors

# SPDX-License-Identifier: BSD-3-Clause
"""Unit Test for the 'video_downloader' module."""

from unittest import TestCase
import json

from video_lister import get_auth_credentials
from video_lister import VideoDownloader
from video_lister import VideoList
from video_lister import Video

TEST_PLAYLIST_DATA = "VideoListTest.json"
PLAYLIST_ID = "PLFsQleAWXsj_4yDeebiIADdH5FMayBiJo"


class VideoDownloaderTest(TestCase):
    """Unit tests to check if the down-loader is working as intended."""

    def test_get_video_list(self: "VideoDownloaderTest") -> None:
        """Check if it can download an entire play-list and if the list is
        correct.

        Args:
            self (VideoDownloaderTest): The test object to test
            'video_downloader'.
        """

        credentials = get_auth_credentials()

        video_downloader = VideoDownloader()
        video_downloader.playlist_id = PLAYLIST_ID
        video_downloader.auth_credentials = credentials
        video_list = video_downloader.get_video_list()

        playlist = VideoList(PLAYLIST_ID, "important videos", video_list)

        with open(TEST_PLAYLIST_DATA, encoding="utf-8") as test_file:
            json_data = json.loads(test_file.read())

        VideoList.to_video_list(json_data)
        self.assertEqual(json.dumps(playlist.to_dict()), json.dumps(json_data))

    def test_to_object_exceptions(self: "VideoDownloaderTest") -> None:
        """Test exceptions if there are missing keys or values.

        Args:
            self (VideoDownloaderTest): The test object to test
            exceptions in 'video_downloader'.
        """
        dict_to_video_data = {"Title": "Testing 123"}
        dict_to_video_list_data = {"PlaylistId": "ABC1DEF2GHI3JKL4MNO5"}

        with self.assertRaises(ValueError):
            Video.to_video(dict_to_video_data)

        with self.assertRaises(ValueError):
            VideoList.to_video_list(dict_to_video_list_data)
