# Gw2Sharp
[![GitLab Pipeline](https://img.shields.io/gitlab/pipeline/archomeda/Gw2Sharp/master.svg?label=GitLab%20Pipeline&logo=gitlab)](https://gitlab.com/Archomeda/Gw2Sharp/pipelines)
[![AppVeyor tests](https://img.shields.io/appveyor/tests/Archomeda/Gw2Sharp.svg?label=AppVeyor%20Tests&logo=appveyor)](https://ci.appveyor.com/project/Archomeda/Gw2Sharp)

Gw2Sharp is a .NET wrapper library for the [official Guild Wars 2 API](https://wiki.guildwars2.com/wiki/API) written in C#.
It uses the latest C# 8.0 features like Nullable Reference Types because they're awesome.

This library has been written to be as close as possible to the official API structure, with a few exceptions to make life easier.

## Features
Check the [features on GitHub pages](https://archomeda.github.io/Gw2Sharp/master/features.html) for the list of features.

## Requirements
This project targets .NET Standard 2.0.
It supports the C# 8.0 Nullable Reference Types feature for your convenience (which is available since Visual Studio 2019), but it's not required when consuming the library.

## Installing
You can find the library on [NuGet](https://www.nuget.org/packages/Gw2Sharp/), or you can install it by running the following command in the package manager:

```powershell
Install-Package Gw2Sharp
```

## Usage
### Basic usage
```cs
using Gw2Sharp.WebApi;
using Gw2Sharp.WebApi.V2;

// Make a connection with optionally: an access token, language.
var connection = new Connection("optional-access-token", Locale.English);

// Make a client and pass the connection to it
var client = new Gw2WebApiClient(connection);

// Get all item ids
var ids = await client.V2.Items.Ids();

// Get a single item
var item = await client.V2.Items.Get(123);

// Get multiple items
var items = await client.V2.Items.Many(new[] { 123, 456 });

// Get items by page
var page = await client.V2.Items.Page(5);

// Getting all items is not supported by the API.
// Any other endpoint that does support it, it will work as follows:
var all = await client.V2.Colors.All();
```

For more information, check out the [guides](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html).

### Caching
By default, API requests are cached in memory.
You can override this by passing it to the `Connection` constructor.
There are two cache methods provided in `Gw2Sharp.WebApi.Caching`: `NullCacheMethod` and `MemoryCacheMethod`.
You can create your own cache method by implementing the `ICacheMethod` interface or by inheriting from the abstract `BaseCacheMethod` class.

## Compiling
Visual Studio 2019 or later is required.
There are no specific build instructions.

## Contributing
Contributing is always welcome, but please keep them in scope of this project.
I'm looking for all contributions that fixes bugs.
But regarding implementing new features, it's better to raise an issue first explaining why that new feature should be added.

If you're adding something new, do add some tests for it as well.
I'm aiming for this project to be as stable as possible.