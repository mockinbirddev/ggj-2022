#pragma warning disable 0108
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    public static NetworkPlayer local {get; set;}
    // Start is called before the first frame update
    public override void Spawned()
    {
        //Check this to make sure this doesn't run on every client
        if(Object.HasInputAuthority)
        {
            local = this;
            Debug.Log("Spawned local player");
        }
        else Debug.Log("Spawned Remote Player");
    }

    public void PlayerLeft(PlayerRef player)
    {
        if(player == Object.HasInputAuthority) Runner.Despawn(Object);
    }
}
