# VideoLister

A .NET library to list videos from YouTube in a playlist. Provides an
abstraction layer to have a better time coding.

## Table of Contents

- [Getting Started](#getting-started)
  - [Usage](#usage)
- [Development](#development)
  - [Testing](#testing)
- [Changelog](#changelog)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

To include this library in your project run:

```bash
dotnet add package VideoListerLibrary
```

This adds a reference to tell `dotnet` to add the library to the project file,
and downloads the library for it to be used in your project.

### Usage

The following examples will be using C# 9.0's Top-Level Statement.

To download the first 50 videos from a playlist, write this:

```cs
using VideoListerLibrary;

// Sets up authentication to get videos.
var auth = new AuthCredentials
VideoDownloader.AuthCredentials = await auth.GetAuthCredentials();

// Returns a object that contains the first 50 videos from a playlist.
var videos = await GetSinglePage();
```

To download a entire playlist, write this:

```cs
using VideoListerLibrary;

// Sets up authentication to get videos.
var auth = new AuthCredentials
VideoDownloader.AuthCredentials = await auth.GetAuthCredentials();

// Returns a IList of videos with a title and id.
var videos = await GetVideoList()
```

## Development

In order to get started you must have .Net SDK that supports .Net Standard 2.0
or later. Some projects requires .NET 5 or later.

```bash
git clone https://github.com/TwoPizza9621536/VideoLister.git
cd VideoLister
dotnet build
```

This will download the repository and build the library and all the application
that it comes with.

To run the applications, go into the directory the application, then run:

```bash
dotnet run
```

This will build (if the `build` command has not yet been run) and runs the
application, depending on which application a GUI will appears in the console
or as a window.

### Testing

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

## Changelog

[All the changes made to this project](CHANGELOG.md).

## Contributing

Pull Requests are welcome, but there are requirements before the code is merged
in to the main branch. See the [contributing guidelines](CONTRIBUTING.md) before
pulling. For major changes, please open an issue first to discuss what you would
like to change.

Please make sure to update tests as appropriate. This project uses the Developer
Certificate of Origin for submitting code. Add yourself to the
[contributors list](CONTRIBUTORS.md) so can you will be credited.

## License

This project is licensed under the BSD 3-Clause license using SPDX identifier
expressions like this:

```text
SPDX-FileCopyrightText: 2021-2022 The Video Lister Contributors

SPDX-License-Identifier: BSD-3-Clause
```

See [LICENSE](LICENSE) for the full text.

Additionally you are subjected under Google's and YouTube's ToS and Privacy
Policy for APIs and Services.

This project uses third party libraries, see
[ThirdPartyLicenses.txt](ThirdPartyLicenses.txt).
