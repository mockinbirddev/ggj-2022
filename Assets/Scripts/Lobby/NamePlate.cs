using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;
public class NamePlate : NetworkBehaviour
{
    public TextMeshProUGUI playerNicknameTM;
    // Line 12 allows you to change the name on the network through OnNicknameChanged(Changed<NamePlate> changed)
    //Line 13 is the network string that shows up on the server
    [Networked(OnChanged = nameof(OnNicknameChanged))]
    public NetworkString<_16> playerNicknameNetwork {get; set;}
    public NetworkPlayer playerName;
    public NamePlateSpawner _namePlateSpawner;
    public RectTransform[] namePlate;
    public GameObject positions;
    public int playersJoined = 0;
    public static NamePlate local {get; set;}

    private void Start() 
    {
        GameObject ntRunnerPF = GameObject.Find("Lobby Network Runner");
        _namePlateSpawner = ntRunnerPF.GetComponent<NamePlateSpawner>();
        namePlate = _namePlateSpawner.namePlate;
        positions = GameObject.Find("Players Joined Positions");
        NetworkPlayer playerName = GetComponent<NetworkPlayer>();
        playerNicknameTM.text = PlayerPrefs.GetString("PlayerNickname");
        Debug.Log("Nameplate: " + playerNicknameTM.text);
        playerName.transform.SetParent(positions.transform);
        playerName.transform.localScale = namePlate[playersJoined+1].localScale;
        playerName.transform.position = namePlate[playersJoined+1].transform.position;
        playersJoined++;
        Debug.Log(PlayerPrefs.GetString("PlayerNickname") + " has spawned");
    }

    public override void Spawned()
    {
        //Check this to make sure this doesn't run on every client
        if(Object.HasInputAuthority)
        {
            NamePlate local = this;
            Debug.Log("Spawned local player");
            RPC_SetNickname(PlayerPrefs.GetString("PlayerNickname"));
        }
        else Debug.Log("Spawned Remote Player");
    }

    // //This function lets OnNicknameChanged() customize the network name
    static void OnNicknameChanged(Changed<NamePlate> changed)
    {
        changed.Behaviour.OnNicknameChanged();
    }

    private void OnNicknameChanged()
    {
        playerNicknameTM.text = playerNicknameNetwork.ToString();
    }

    // //RPC stuff here, the class must be/inherit network behaviour to do this
    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void RPC_SetNickname(string nickname, RpcInfo info = default)
    {
        this.playerNicknameNetwork = nickname;
    }
}
