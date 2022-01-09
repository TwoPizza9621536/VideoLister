# VideoListerLibrary

A lister for videos from YouTube in .NET C# if you hate the web app or mobile
app.

This is the main implementation of the library.

## Dependencies

- .NET Core/Framework that is defined in .NET Standard 2 or later
- Visual Studio 2019, 2022 or later (Optional)

### The Library

- Google's and YouTube's API and libraries
  - [Google.Apis.YouTube.v3](https://developers.google.com/youtube/v3/)
- Also an Internet connection to get the videos

### Console Application (TestApp)

- .NET Core 3.1 or later
- The Library

### The GUI Application (TestGUI{.PLATFORM})

- .NET Core 5 or later
  - The Library
  - WPF and WinFroms (Windows Only)
  - [GtkSharp](https://github.com/GtkSharp/GtkSharp)

## Setup

### Visual Studio

Use Visual Studio and click on the solution file.

Then click `Build` to build the projects.

Open and select the project you want to run,
then click `Run Without Debugging` to run the application.

### .NET SDK

For .NET SDK use the following `dotnet` command in the solution directory:

```bash
dotnet build
```

Then use `dotnet run` to run the application in the project directory.

## License

This application is licensed under the BSD 3-Clause License using SPDX License
Identifiers.

To use them put comments relative at the top in the source file with these exact
expressions:

```text
SPDX-FileCopyrightText: 2021-2022 Samuel Wu
SPDX-License-Identifier: BSD-3-Clause
```

Additionally you are subjected under Google's and YouTube's ToS and Privacy
Policy for APIs and Services. The libraries and snippets are under the Apache
Version 2.0 license.

GtkSharp is under the LGPLv2 license.

See the `LICENSE` file for the license and `ThirdPartyLicenses.txt` for third
party software, dependences and/or libraries.
