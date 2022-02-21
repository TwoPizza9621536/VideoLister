# .NET library

To include the .NET library run:

```bash
pip install video-lister
```

This adds a reference to tell `pip` to add the library to the environment
and downloads the library ready to be used in your project.

## Usage

To download the first 50 videos from a playlist, write this:

```py
from video_lister import get_auth_credentials
from video_lister import VideoDownloader

# Sets up authentication to get videos.
auth = auth_credentials()
video_downloader = VideoDownloader()
video_downloader.auth_credentials = auth

# Set the playlist you want to download.
video_downloader.playlist_id = "PLAYLIST_ID"

# Returns a object that contains the first 50 videos from a playlist.
videos = video_downloader.get_single_page()
```

To download an entire playlist, write this:

```py
from video_lister import get_auth_credentials
from video_lister import VideoDownloader

# Sets up authentication to get videos.
auth = auth_credentials()
video_downloader = VideoDownloader()
video_downloader.auth_credentials = auth

# Set the playlist you want to download.
video_downloader.playlist_id = "PLAYLIST_ID"

# Returns a list of videos with a title and id.
videos = video_downloader.get_video_list()
```

Make sure you replace `PLAYLIST_ID` with the actual id.

## Testing

To test the library, run:

```bash
cd tests
coverage rum -m unittest test_video_downloader
coverage html
```

These commands go to the directory of the test project and run the test. The
test will produce a report of how much of the code is covered under a test.
Coverage also can convert the report into html.

Then open the index.html file in the `htmlcov` directory.

---

SPDX-FileCopyrightText: 2022 The Video Lister Contributors

SPDX-License-Identifier: CC0-1.0

---
