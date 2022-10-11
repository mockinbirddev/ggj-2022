using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterInputHandler : MonoBehaviour
{
    public Vector2 movementInputVector = Vector2.zero;
    public NetworkObject networkObect;

    private void Start() 
    {
        networkObect = GetComponent<NetworkObject>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInputVector.x = Input.GetAxisRaw("Horizontal");
        movementInputVector.y = Input.GetAxisRaw("Vertical");
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.movementInput = movementInputVector;
        return networkInputData;
    }
}
