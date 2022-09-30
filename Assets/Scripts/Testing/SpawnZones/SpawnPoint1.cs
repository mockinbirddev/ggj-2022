using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint1 : SpawnZoneTemplate
{
    public override Vector2 SpawnPoint()
    {
        Vector2 spawnPoint = new Vector2(Random.Range(0,10),Random.Range(0,4));
        return spawnPoint;
    }
}
