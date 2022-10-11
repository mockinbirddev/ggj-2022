using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Item : NetworkBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Debug.Log("Pizza Acquired!");
            Destroy(this.gameObject);
        }
    }
}
