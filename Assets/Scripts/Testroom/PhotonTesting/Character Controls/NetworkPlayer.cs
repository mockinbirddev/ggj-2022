#pragma warning disable 0108
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer local {get; set;}
    public static int playersIn = 0;
    public TextMeshProUGUI playerNicknameTM;
    [Networked(OnChanged = nameof(OnNickNameChanged))]
    public NetworkString<_16> networkNickname {get; set;}
    // Start is called before the first frame update
    public override void Spawned()
    {
        playersIn++;
        //Check this to make sure this doesn't run on every client
        if(Object.HasInputAuthority)
        {
            local = this;
            RPC_NickName(PlayerPrefs.GetString("PlayerNickname"));
            
            Debug.Log("Spawned local player");
            Debug.Log("There are " +playersIn.ToString()+" players");
        }
        else
        {
            Debug.Log("Spawned Remote Player");
            Debug.Log("There are " +playersIn.ToString()+" players");
        } 
        
        if(playersIn == 6) 
        {
            Runner.SessionInfo.IsOpen = false;
            Debug.Log("Room is now closed");
        }
        if(playersIn < 6 && playersIn > 0) 
        {
            Runner.SessionInfo.IsOpen = true;
            Debug.Log("Room is now open");
        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        playersIn--;
        if(player == Object.HasInputAuthority) Runner.Despawn(Object);
        if(playersIn == 0)
        {
            Runner.Shutdown();
        }
        
    }
    static void OnNickNameChanged(Changed<NetworkPlayer> changed)
    {
        changed.Behaviour.OnNickNameChanged();
    }

    private void OnNickNameChanged()
    {
        playerNicknameTM.text = networkNickname.ToString();
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void RPC_NickName(string nickName, RpcInfo info = default)
    {
        this.networkNickname = nickName;
    }
}
