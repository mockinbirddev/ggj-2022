using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Item : NetworkBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" || other.tag == "Red Team" || other.tag == "Blue Team")
        {
            Debug.Log("Pizza Acquired!");
            other.GetComponent<NetworkCharacterController>().pizzaAmmo++;
            Debug.Log(other.GetComponent<NetworkCharacterController>().pizzaAmmo);
            Destroy(this.gameObject);
        }
    }
}
