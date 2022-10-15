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
    [SerializeField] private TMP_InputField _nickName;
    [SerializeField] private TMP_InputField _roomName;
    //Enter this in the inspector
    [SerializeField] public string scene;


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
        SceneManager.LoadScene(scene);
    }

    public void JoinLobby()
    {
        SetPlayerData();
        PlayerPrefs.Save();
        SceneManager.LoadScene(scene);
    }
    private void SetPlayerData()
    {
        PlayerPrefs.SetString("PlayerNickname",_nickName.text);
        PlayerPrefs.SetString("RoomNickname",_roomName.text);
    }

    
}
