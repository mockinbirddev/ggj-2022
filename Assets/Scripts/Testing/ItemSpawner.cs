using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ItemSpawner : NetworkBehaviour
{
    public GameObject pizza;
    public bool hasSpawned = false;
    public float currenTime = 0f;
    private float prevTime = 0f;
    // Start is called before the first frame update
    private void Awake() 
    {
        if(Runner == null) Runner = GetComponent<NetworkRunner>();
    }
    public override void FixedUpdateNetwork()
    {
        currenTime = Time.time;
        if((currenTime-prevTime) > 3f && currenTime > 5f)
        {
            prevTime = currenTime;
            Vector2 spawnLocation = GetComponent<CompositeSpawnPoint>().GetSpawnPoint();
            Runner.Spawn(pizza, spawnLocation, Quaternion.identity, inputAuthority: null);
        }
    }
}
