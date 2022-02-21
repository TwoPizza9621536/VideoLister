# SPDX-FileCopyrightText: 2022 The Video Lister Contributors

# SPDX-License-Identifier: BSD-3-Clause
"""A template to store the list of videos from a playlist into json."""

from typing import Any

from video_lister import Video


class VideoList:
    """A class to store the videos with the playlist name and id."""

    def __init__(self: "VideoList", playlist_id: str, playlist_name: str,
                 videos: list[Video]) -> None:
        self.schema: str = "https://twopizza9621536.github.io" \
                           "/schema/json/videolist.json"
        self.playlist_id: str = playlist_id
        self.playlist_name: str = playlist_name
        self.videos: list[Video] = videos

    def to_dict(self: "VideoList") -> dict[str, Any]:
        """Convert the VideoList object to a dictionary for json usage.

        Args:
            self (VideoList): The VideoList object that stores the videos in a
            schema.

        Returns:
            dict[str, Any]: The VideoList object as a dictionary.
        """
        videos_list = []

        for video in self.videos:
            videos_list.append(video.to_dict())

        return {
            "$Schema": self.schema,
            "PlaylistId": self.playlist_id,
            "PlaylistName": self.playlist_name,
            "Videos": videos_list
        }

    @staticmethod
    def to_video_list(data: dict[str, Any]) -> "VideoList":
        """Convert the formatted json data back to a VideoList object.

        Args:
            data (dict[str, Any]): The dictionary that constains the keys:
            'PlaylistId', 'PlaylistName' and 'Videos'.

        Raises:
            ValueError: If dictionary does not contain any of the following
            keys: 'PlaylistId', 'PlaylistName' or 'Videos'.

        Returns:
            VideoList: The VideoList object that was converted from a
            dictionary from json.
        """

        if ("PlaylistId" in data and "PlaylistName" in data
                and "Videos" in data):
            video_list = []
            for video in data["Videos"]:
                video_list.append(Video.to_video(video))

            return VideoList(data["PlaylistId"], data["PlaylistName"],
                             video_list)

        raise ValueError("The parsed data does not contain one or more of the "
                         "following keys:\n"
                         "'PlaylistId', 'PlaylistName' or 'Videos'")
