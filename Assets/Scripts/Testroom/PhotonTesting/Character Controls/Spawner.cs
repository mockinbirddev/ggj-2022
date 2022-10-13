using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class Spawner : MonoBehaviour, INetworkRunnerCallbacks
{
    //Other Components
    CharacterInputHandler characterInputHandler;
    public NetworkPlayer playerPrefab;
    public List<NetworkPlayer> playerPrefabPool;

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player) 
    { 
        Debug.Log(runner.SessionInfo.Name);
        Debug.Log(PlayerPrefs.GetString("RoomNickname"));
        if(runner.IsServer)
        {
            int prefIndex = UnityEngine.Random.Range(0,7);
            playerPrefab = playerPrefabPool[UnityEngine.Random.Range(0,7)];
            // Debug.Log(playerPrefab.name);
            // Debug.Log("Index is " + prefIndex.ToString());
            // Debug.Log(playerPrefabPool.Count);
            runner.Spawn(playerPrefab, Utils.GetRandomSpawnPoint(), Quaternion.identity, player);
            playerPrefabPool.Remove(playerPrefabPool[prefIndex]);
            // foreach(NetworkPlayer ntPlayer in playerPrefabPool)
            // {
            //     Debug.Log(ntPlayer.name);
            // }
            // Debug.Log(playerPrefabPool.Count);
        }
        else
        {
            Debug.Log("OnPlayerJoined");
        }
    }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
    public void OnInput(NetworkRunner runner, NetworkInput input) 
    {
        if(characterInputHandler == null && NetworkPlayer.local != null)
        {
            characterInputHandler = NetworkPlayer.local.GetComponent<CharacterInputHandler>();
        }

        if(characterInputHandler != null)
        {
            input.Set(characterInputHandler.GetNetworkInput());
        }
    }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) {Debug.Log("OnShutdown");} 
    public void OnConnectedToServer(NetworkRunner runner) {Debug.Log("OnConnectedToServer");}
    public void OnDisconnectedFromServer(NetworkRunner runner) {Debug.Log("OnDisconnectedFromServer");}
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) {Debug.Log("OnConnectRequest");}
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) {Debug.Log("OnConnectFailed");}
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) {}
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }
    public void OnSceneLoadDone(NetworkRunner runner) { }
    public void OnSceneLoadStart(NetworkRunner runner) { }
}
