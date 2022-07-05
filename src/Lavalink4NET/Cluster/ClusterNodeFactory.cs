using Lavalink4NET.Integrations;
using Lavalink4NET.Logging;

namespace Lavalink4NET.Cluster;

/// <summary>
///     A factory used to create cluster nodes.
/// </summary>
/// <param name="cluster">the cluster</param>
/// <param name="options">the node options for connecting</param>
/// <param name="client">the discord client</param>
/// <param name="logger">the logger</param>
/// <param name="cache">an optional cache that caches track requests</param>
/// <param name="id">the node number</param>
public delegate T ClusterNodeFactory<T>(
    LavalinkCluster cluster, LavalinkNodeOptions options, IDiscordClientWrapper client,
    int id, IIntegrationCollection integrationCollection, ILogger? logger = null, ILavalinkCache? cache = null)
    where T : LavalinkClusterNode;