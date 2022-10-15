using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointLocation : MonoBehaviour
{
    public Vector2 upperLeftCorner;
    public Vector2 lowerRightCorner;
    public Vector2 SpawnPoint()
    {
        Vector2 spawnPoint = new Vector2(Random.Range(upperLeftCorner.x,lowerRightCorner.x),
                                        Random.Range(upperLeftCorner.y,lowerRightCorner.y));
        return spawnPoint;
    }
}
