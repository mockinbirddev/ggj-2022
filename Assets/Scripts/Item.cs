using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static int hasPizza = 0;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (this.tag == "pizza") {
            Debug.Log("Slice of pizza picked up!");
            hasPizza = hasPizza + 1;
            Destroy(this.gameObject);
        } 
        Debug.Log("The number of slices of pizza I have now is" + hasPizza);
        Destroy(this.gameObject);
    }
}
