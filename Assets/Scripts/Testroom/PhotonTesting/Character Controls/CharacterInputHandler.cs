using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterInputHandler : MonoBehaviour
{
    public Vector2 movementInputVector = Vector2.zero;
    bool isThrowButtonPressed = false;
    public enum characterFacing{
        Up,
        Down,
        Left,
        Right
    }
    [SerializeField] public characterFacing direction;
    // Update is called once per frame
    void Update()
    {
        movementInputVector.x = Input.GetAxisRaw("Horizontal");
        movementInputVector.y = Input.GetAxisRaw("Vertical");
        
        ShootOff();
    }
    public void ShootOff()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction = characterFacing.Up;
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction = characterFacing.Down;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = characterFacing.Left;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = characterFacing.Right;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isThrowButtonPressed = true;
        }
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.movementInput = movementInputVector;
        networkInputData.isThrowButtonPressed = isThrowButtonPressed;

        isThrowButtonPressed = false;
        return networkInputData;
    }
}
