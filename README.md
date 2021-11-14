# LikedVideoLister-dotnet

A lister for liked videos from YouTube in .NET C# if you hate the web app or
mobile app. This is created because I now have no plans for the Python version,
.NET has a better platform support for mobile and C# is a better language to
work with JSON data than Python with the .NET library that is provided.

## Dependencies

### The Library

- .NET Core 2.1 or .NET Framework 4.6.1 (.NET Standard 2) or later
- Visual Studio 2019 or later (Optional)
  - Google's and YouTube's API and libraries
    - Google.Apis.YouTube.v3
    - Newtonsoft.Json
- Also an internet connection to download the videos

### Console Application (TestApp)

- .NET Core 3.1 or later
- The Library

### Blazor WebAssembly Application (BlazorApp)

- .NET 5.0 or later
  - The Library

### The GUI (MAUI) Application (MauiApp)

- .NET Core 6 or later
- Visual Studio 2022 or later
  - The Library

## Setup

### Visual Studio

Use Visual Studio and click on the solution file.

Then click `Build` to build the projects.

Open the project you want to run, then click `Run Without Debugging` to
run the application.

### .NET SDK

For .NET SDK use the following `dotnet` command in the solution directory:

```bash
dotnet build
```

Then use `dotnet run` to run the application in the project directory.

## License

This application is licensed under the BSD 3 Clause License.

Additionally you are subjected under Google's and YouTube's ToS and Privacy
Policy for APIs and Services. The libraries are under the Apache Version 2.0
license.

Newtonsoft.Json is licensed under the MIT License.

See the `LICENSE` file for the licenses.

```markdown
BSD 3-Clause License

Copyright (c) 2021, Samuel Wu
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its
   contributors may be used to endorse or promote products derived from
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
```
