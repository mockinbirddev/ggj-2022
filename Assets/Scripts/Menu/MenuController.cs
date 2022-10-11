#pragma warning disable 0414
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [SerializeField] private NetworkRunner _networkRunnerPrefab;
    [SerializeField] private PlayerData _playerDataPrefab;

    [SerializeField] private TMP_InputField _nickName;

    // The Placeholder Text is not accessible through the TMP_InputField component so need a direct reference
    [SerializeField] private TextMeshProUGUI _nickNamePlaceholder;

    [SerializeField] private TMP_InputField _roomName;
    [SerializeField] private string _gameSceneName;

    private NetworkRunner _runnerInstance;

    // Update is called once per frame
    void Update()
    {
        
        if(!_nickName.isFocused && !_roomName.isFocused)
        {
            if(Input.GetKeyUp(KeyCode.Tab))
            {
                _roomName.Select();
            }
        }
        else if(_nickName.isFocused)
        {
            if(Input.GetKeyUp(KeyCode.Tab))
            {
                _roomName.Select();
            }
        }
        else if(_roomName.isFocused)
        {
            if(Input.GetKeyUp(KeyCode.Tab))
            {
                _nickName.Select();
            }
        }
    }

    public void StartLobby()
    {
        SetPlayerData();
        PlayerPrefs.Save();
        StartGame(GameMode.Server, PlayerPrefs.GetString("RoomNickname"), _gameSceneName);
    }

    public void JoinLobby()
    {
        SetPlayerData();
        PlayerPrefs.Save();
        StartGame(GameMode.Server, PlayerPrefs.GetString("RoomNickname"), _gameSceneName);
    }
    private void SetPlayerData()
    {
        PlayerPrefs.SetString("PlayerNickname",_nickName.text);
        PlayerPrefs.SetString("RoomNickname",_roomName.text);
    }

    private async void StartGame(GameMode mode, string roomName, string sceneName)
    {
        _runnerInstance = FindObjectOfType<NetworkRunner>();
        if (_runnerInstance == null)
        {
            _runnerInstance = Instantiate(_networkRunnerPrefab);
            _runnerInstance.name = "MenuNetworkRunnerPF";
        }

        // Let the Fusion Runner know that we will be providing user input
        _runnerInstance.ProvideInput = true;

        var startGameArgs = new StartGameArgs()
        {
            GameMode = mode,
            SessionName = roomName,
        };
        await _runnerInstance.StartGame(startGameArgs);
        
        _runnerInstance.SetActiveScene(sceneName);
    }

}
