using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SpawnPointLocation> spawnPoints = new List<SpawnPointLocation>();

    public Vector2 GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0,spawnPoints.Count)].SpawnPoint();
    }
}
