using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Throw : MonoBehaviour {
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Hello");
        }
    }
    
}