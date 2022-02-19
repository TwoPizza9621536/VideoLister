# .NET library

To include the .NET library run:

```bash
dotnet add package VideoListerLibrary
```

This adds a reference to tell `dotnet` to add the library to the project file,
and downloads the library ready to be used in your project.

## Usage

The following examples will be using C# 9.0's Top-Level Statement.

To download the first 50 videos from a playlist, write this:

```cs
using VideoListerLibrary;

// Sets up authentication to get videos.
var auth = new AuthCredentials
VideoDownloader.AuthCredentials = await auth.GetAuthCredentials();

// Set the playlist you want to download.
VideoDownloader.PlayListId = "PLAYLIST_ID"

// Returns a object that contains the first 50 videos from a playlist.
var videos = await GetSinglePage();
```

To download an entire playlist, write this:

```cs
using VideoListerLibrary;

// Sets up authentication to get videos.
var auth = new AuthCredentials
VideoDownloader.AuthCredentials = await auth.GetAuthCredentials();

// Set the playlist you want to download.
VideoDownloader.PlayListId = "PLAYLIST_ID"

// Returns a IList of videos with a title and id.
var videos = await GetVideoList()
```

Make sure you replace `PLAYLIST_ID` with the actual id.

## Testing

To test the library, run:

```bash
cd VideoListerLibrary.Tests
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
```

These commands go to the directory of the test project and run the test. The
test will produce a report of how much of the code is covered under a test.

Use [ReportGenerator](https://github.com/danielpalme/ReportGenerator) to see the
report by running this:

```bash
reportgenerator \
-reports:"coverage.cobertura.xml" \
-targetdir:"coveragereport" \
-reporttypes:Html
```

Then open the index.html file in the `coveragereport` directory.

---

SPDX-FileCopyrightText: 2022 The Video Lister Contributors

SPDX-License-Identifier: CC0-1.0

---
