using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnZoneTemplate : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract Vector2 SpawnPoint();
}
