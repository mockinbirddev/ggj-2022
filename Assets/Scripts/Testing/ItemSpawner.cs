using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ItemSpawner : NetworkBehaviour
{
    public GameObject pizza;
    [SerializeField]
    private float beginningTimeInterval = 1f;
    [SerializeField]
    private float endingingTimeInterval = 4f;


    void Start() {
        StartCoroutine(SpawnItem(pizza));
    }

    IEnumerator SpawnItem(GameObject item)
    {
        while(Runner != null)
        {
            yield return new WaitForSeconds(Random.Range(beginningTimeInterval, endingingTimeInterval));
            Vector2 spawnLocation = GetComponent<CompositeSpawnPoint>().GetSpawnPoint();
            if(Runner != null)
            {
                Runner.Spawn(item, spawnLocation, Quaternion.identity, inputAuthority: null);
            }
        }
    }
}
