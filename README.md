<!-- Banner -->
<a href="https://github.com/angelobreuer/Lavalink4NET/">
	<img src="https://i.imgur.com/e1jv23h.png"/>
</a>

<!-- Center badges -->
<p align="center">
	
<!-- CodeFactor.io Badge -->
<a href="https://www.codefactor.io/repository/github/angelobreuer/lavalink4net">
	<img alt="CodeFactor.io" src="https://www.codefactor.io/repository/github/angelobreuer/lavalink4net/badge?style=for-the-badge" />	
</a>

<!-- Releases Badge -->
<a href="https://github.com/angelobreuer/Lavalink4NET/releases">
	<img alt="GitHub tag (latest SemVer)" src="https://img.shields.io/github/tag/angelobreuer/Lavalink4NET.svg?label=RELEASE&style=for-the-badge">
</a>

<!-- GitHub issues Badge -->
<a href="https://github.com/angelobreuer/Lavalink4NET/issues">
	<img alt="GitHub issues" src="https://img.shields.io/github/issues/angelobreuer/Lavalink4NET.svg?style=for-the-badge">	
</a>

<br/>

<!-- AppVeyor CI (master) Badge -->
<a href="https://ci.appveyor.com/project/angelobreuer/lavalink4net">
	<img alt="AppVeyor" src="https://img.shields.io/appveyor/ci/angelobreuer/Lavalink4NET?style=for-the-badge">
</a>	


<!-- AppVeyor CI (Development) Badge -->
<a href="https://github.com/angelobreuer/Lavalink4NET/tree/dev">
	<img alt="AppVeyor" src="https://img.shields.io/appveyor/ci/angelobreuer/Lavalink4NET/dev?label=development&style=for-the-badge">
</a>

</p>

[Lavalink4NET](https://github.com/angelobreuer/Lavalink4NET) is a [Lavalink](https://github.com/Frederikam/Lavalink) wrapper with node clustering, caching and custom players for .NET with support for [Discord.Net](https://github.com/RogueException/Discord.Net) and [DSharpPlus](https://github.com/DSharpPlus/DSharpPlus/).

### Features
- 🔌 **Asynchronous Interface**
- ⚖️ **Node Clustering / Load Balancing**
- ✳️ **Extensible**
- 🎤 **Lyrics**
- 🗳️ **Queueing / Voting-System**
- 🎵 **Track Decoding**
- 🔄 **Auto-Reconnect and Resuming**
- 📝 **Logging** *(optional)*
- ⚡ **Request Caching** *(optional)*
- ⏱️ **Inactivity Tracking** *(optional)*
- ➕ **Compatible with [DSharpPlus](https://github.com/DSharpPlus/DSharpPlus) and [Discord.Net](https://github.com/discord-net/Discord.Net).**
  
<span>&nbsp;&nbsp;&nbsp;</span>*and a lot more...*

### NuGet
- Download [Lavalink4NET Core ![NuGet - Lavalink4NET Core](https://img.shields.io/nuget/vpre/Lavalink4NET.svg?style=flat-square)](https://www.nuget.org/packages/Lavalink4NET/) 
- Download [Lavalink4NET for Discord.Net ![NuGet - Lavalink4NET Discord.Net](https://img.shields.io/nuget/vpre/Lavalink4NET.Discord.Net.svg?style=flat-square)](https://www.nuget.org/packages/Lavalink4NET.Discord.NET/) 
- Download [Lavalink4NET for DSharpPlus ![NuGet - Lavalink4NET DSharpPlus](https://img.shields.io/nuget/vpre/Lavalink4NET.DSharpPlus.svg?style=flat-square)](https://www.nuget.org/packages/Lavalink4NET.DSharpPlus/)
- Download [Lavalink4NET MemoryCache ![NuGet - Lavalink4NET MemoryCache](https://img.shields.io/nuget/vpre/Lavalink4NET.MemoryCache.svg?style=flat-square)](https://www.nuget.org/packages/Lavalink4NET.MemoryCache/)

### Prerequisites
- One or more Lavalink Nodes
- .NET Core >= 2.0

### Getting Started

You can use Lavalink4NET in 3 different modes: **Cluster**, **Node** and **Rest**.
- [**Cluster**](https://github.com/angelobreuer/Lavalink4NET/wiki/Cluster) is useful for combining a bunch of nodes to one to load balance.
- [**Node**](https://github.com/angelobreuer/Lavalink4NET/wiki/Node) is useful when you have a small discord bot with one Lavalink Node.
- [**Rest**](https://github.com/angelobreuer/Lavalink4NET/wiki/Tracks) is useful when you only want to resolve tracks.


##### Using the constructor

Here is an example, how you can create the AudioService for a single node:
```csharp
var audioService = new LavalinkNode(new LavalinkNodeOptions
{
	RestUri = "http://localhost:8080/",
	WebSocketUri = "ws://localhost:8080/",
	Password = "youshallnotpass"
}, new DiscordClientWrapper(client));
```

##### Usage with Dependency Injection / IoC *(recommended)*

```csharp
var serviceProvider = new ServiceCollection
	.AddSingleton<IAudioService, LavalinkNode>()	
	.AddSingleton<IDiscordClientWrapper, DiscordClientWrapper>();
	.AddSingleton(new LavalinkNodeOptions {[...]})
	[...]
	.BuildServiceProvider();
	
var audioService = serviceProvider.GetRequiredService<IAudioService>();

// Do not forget disposing the service provider!
```
Lookup the LavalinkNodeOptions in the **`application.yml`** of your Lavalink Node(s).

##### Initializing the node

**Before** using the service you have to initialize it, this can be done
using the Ready event of your discord client implementation:

```csharp
client.Ready += () => audioService.InitializeAsync();
```

##### Joining a voice channel and playing a track

```csharp
// get player
var player = _audioService.GetPlayer<LavalinkPlayer>(guildId) 
    ?? await _audioService.JoinAsync(guildId, voiceChannelId);

// resolve a track from youtube
var myTrack = await _audioService.GetTrackAsync("<search query>", SearchMode.YouTube);

// play track
await player.PlayAsync(myTrack);
```

For **more documentation, see: [Lavalink4NET Wiki](https://github.com/angelobreuer/Lavalink4NET/wiki)** or you could also **take a look at [Upcoming Features](https://github.com/angelobreuer/Lavalink4NET/projects?query=is%3Aopen)**.

___

### Dependencies
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) *(for Payload Serialization)*
