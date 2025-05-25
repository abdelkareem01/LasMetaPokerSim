using Fusion;
using Fusion.Sockets;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FusionLogger : BaseNetworkRunnerCallbacks
{
    public override void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log($"[Fusion] Connected to server successfully! Current active players: " + runner.ActivePlayers.ToString());
    }

    public override void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.Log($"[Fusion] Failed to connect to server! Reason: " + reason);
    }

    public override void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        Debug.Log($"[Fusion] Disconnected from server. Reason: " + reason);
    }

    public override void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log($"[Fusion] Player joined: {player}");
    }

    public override void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log($"[Fusion] Player left: {player}");
    }

    public override void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log($"[Fusion] Network runner was shutdown. Reason: {shutdownReason}");
    }

    public override void OnSceneLoadDone(NetworkRunner runner) 
    {
        Debug.Log($"[Fusion] Scene loaded: {runner.TryGetSceneInfo(out NetworkSceneInfo info)}");
    }

    public override void OnSceneLoadStart(NetworkRunner runner)
    {
        Debug.Log($"[Fusion] Loading new scene");
    }
}
