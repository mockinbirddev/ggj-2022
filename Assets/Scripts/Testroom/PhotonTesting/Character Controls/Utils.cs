using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector2 GetRandomSpawnPoint()
    {
        return new Vector2(Random.Range(-9,9), Random.Range(-4,4));
    }
}
