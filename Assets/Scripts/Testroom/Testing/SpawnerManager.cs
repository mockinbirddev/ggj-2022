using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class SpawnerManager : NetworkBehaviour
{
    public NetworkBehaviour itemSpawner;
    public override void FixedUpdateNetwork()
    {
        if(Runner !=null)
        {
            Runner.Spawn(itemSpawner,Vector2.zero,Quaternion.identity, inputAuthority: null);
            this.gameObject.SetActive(false);
        }
    }
}
