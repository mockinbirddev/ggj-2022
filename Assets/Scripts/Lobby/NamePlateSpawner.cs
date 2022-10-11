using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class NamePlateSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
    //Other Components
    CharacterInputHandler characterInputHandler;
    public NetworkPlayer playerPrefab;
    public GameObject positions;
    //Text transforms are stored in RectTransform class. Network
    public RectTransform[] namePlate;
    public int playersJoined = 0;
    public NetworkRunner _networkRunner;
    public string _gameSceneName;

    private void Start() {
        positions = GameObject.Find("Players Joined Positions");
        //This includes the parent for some reason
        namePlate = positions.transform.GetComponentsInChildren<RectTransform>();
        if(_networkRunner == null)
        {
            _networkRunner = FindObjectOfType<NetworkRunner>();
            _networkRunner.name = "Lobby Network Runner";
            // Debug.Log(_networkRunner.name);
            // SpawnName(_networkRunner);
        }
        if(GameObject.Find("Network Runner") != null)
        {
            Destroy(GameObject.Find("Network Runner"));
        }
        Debug.Log(PlayerPrefs.GetString("PlayerNickname"));
        StartGame(GameMode.AutoHostOrClient, PlayerPrefs.GetString("RoomNickname",_gameSceneName),_gameSceneName);
    }


    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player) 
    { 
        Debug.Log("Player has joined.");
        if(runner.IsServer)
        {
            NetworkPlayer playerName = runner.Spawn(playerPrefab, Vector3.zero, Quaternion.identity);
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

    async void StartGame(GameMode mode, string roomName, string sceneName)
{
  // Create the Fusion runner and let it know that we will be providing user input
  _networkRunner.ProvideInput = true;

  // Start or join (depends on gamemode) a session with a specific name
  await _networkRunner.StartGame(new StartGameArgs()
  {
    GameMode = mode,
    SessionName = "TestRoom",
    Scene = SceneManager.GetActiveScene().buildIndex,
    SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
  });}
}
