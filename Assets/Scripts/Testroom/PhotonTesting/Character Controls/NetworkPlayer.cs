#pragma warning disable 0108
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer local {get; set;}
    public static int playersIn = 0;
    // Start is called before the first frame update
    public override void Spawned()
    {
        if(Runner.SessionInfo.IsOpen == false)
        {
            Runner.SetActiveScene("Menu");
        }
        playersIn++;
        //Check this to make sure this doesn't run on every client
        if(Object.HasInputAuthority)
        {
            local = this;
            
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
}
