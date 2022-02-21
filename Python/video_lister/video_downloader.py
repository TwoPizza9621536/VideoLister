# SPDX-FileCopyrightText: 2022 The Video Lister Contributors

# SPDX-License-Identifier: BSD-3-Clause
"""A method to get video metadata from a playlist."""

from typing import Any

from video_lister import Video


class VideoDownloader:
    """Gets video meta-data using YouTube Data API v3."""

    def __init__(self: "VideoDownloader") -> None:
        self.playlist_id: str = ""
        self.auth_credentials: Any = None

    def get_single_page(self: "VideoDownloader",
                        page_token: str = "") -> Any:
        """Asynchronously download 50 video meta-data at a time as a
        play-list item list.

        Args:
            self (VideoDownloader): The VideoDownloader object to download
            videos.
            page_token (str, optional): _description_. Defaults to an empty
            string.

        Returns:
            Any: The meta-data for the 50 videos in the list.
        """

        return self.auth_credentials.playlistItems().list(
            maxResults=50,
            pageToken=page_token,
            part="snippet",
            playlistId=self.playlist_id
        ).execute()

    def get_video_list(self: "VideoDownloader") -> list[Video]:
        """Recursively download meta-data from a play-list using
        'get_single_page'.

        Args:
            self (VideoDownloader): The VideoDownloader object to download
            videos.

        Returns:
            list[Video]: A list of videos from a play-list.
        """

        videos = []
        page_token = ""

        while page_token is not None:
            response = self.get_single_page(page_token)

            for video in response["items"]:
                videos.append(
                    Video(
                        video["snippet"]["resourceId"]["videoId"],
                        video["snippet"]["title"]
                    )
                )

            page_token = (response["nextPageToken"]
                          if "nextPageToken" in response
                          else None)

        return videos
