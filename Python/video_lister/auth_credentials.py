# SPDX-FileCopyrightText: 2022 The Video Lister Contributors

# SPDX-License-Identifier: BSD-3-Clause
"""A method to get YouTube user data for public and private playlists.
Requires a client secret data from cloud console."""

from typing import Any

from google_auth_oauthlib.flow import InstalledAppFlow
from googleapiclient.discovery import build


def get_auth_credentials(client_secret: str = "client_secret.json") -> Any:
    """The credentials needed to get personal play list, e.g. liked
    videos.

    Args:
        client_secret (str, optional): A string to the filename of the client
        secret. Defaults to "client_secret.json".

    Returns:
        Any: The OAuth 2.0 used to getvideo meta-data.
    """

    credentials = InstalledAppFlow.from_client_secrets_file(
        client_secret, ["https://www.googleapis.com/auth/youtube.readonly"]
    ).run_console()

    return build("youtube", "v3", credentials=credentials)
