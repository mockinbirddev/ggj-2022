using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Pizza Acquired!");
        Destroy(this.gameObject);
    }
}
