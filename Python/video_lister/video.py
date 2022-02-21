# SPDX-FileCopyrightText: 2022 The Video Lister Contributors

# SPDX-License-Identifier: BSD-3-Clause
"""A quick way to store information for videos, like a struct."""


class Video:
    """A class to store the title and the id for YouTube videos."""

    def __init__(self: "Video", video_id: str, video_title: str) -> None:
        self.video_id: str = video_id
        self.video_title: str = video_title

    def to_dict(self: "Video") -> dict[str, str]:
        """Convert the Video object to a readable dictionary.

        Args:
            self (Video): The Video object that stores the title and the id of
            the video.

        Returns:
            dict[str, str]: The Video object as a dictionary.
        """
        return {"Id": self.video_id, "Title": self.video_title}

    @staticmethod
    def to_video(video: dict[str, str]) -> "Video":
        """Convert the json object or dictionary back to a Video object

        Args:
            video (dict[str, str]): The dictionary that constains the keys:
            'Id' and 'Title'.

        Raises:
            ValueError: If dictionary does not contain any of the following
            keys: 'Id' or 'Title'.

        Returns:
            Video: The Video object that was converted from a dictionary.
        """
        if "Id" in video and "Title" in video:
            return Video(video["Id"], video["Title"])

        raise ValueError(
            "The one of the videos does not contain the keys:\n"
            "'Id' or 'Title'"
        )
