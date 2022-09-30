using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ItemSpawner : NetworkBehaviour
{
    public GameObject pizza;
    [SerializeField]
    private NetworkRunner runner;
    public bool hasSpawned = false;
    public float currenTime = 0f;
    private float prevTime = 0f;
    // Start is called before the first frame update
    private void Awake() 
    {
        if(runner == null) runner = GetComponent<NetworkRunner>();
    }
    public override void FixedUpdateNetwork()
    {
        currenTime += Time.deltaTime;
        if((currenTime-prevTime) > 3f)
        {
            prevTime = currenTime;
            Vector2 spawnLocation = GetComponent<CompositeSpawnPoint>().GetSpawnPoint();
            runner.Spawn(pizza, spawnLocation, Quaternion.identity, inputAuthority: null);
        }
    }
}
