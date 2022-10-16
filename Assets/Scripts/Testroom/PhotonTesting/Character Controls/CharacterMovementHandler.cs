using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CharacterMovementHandler : NetworkBehaviour
{
    //Other component
    NetworkCharacterController networkCharacterController;
    [SerializeField] private PizzaProjectileHandler pizza;
    [SerializeField] private ExitMenu exitMenu;
    

    private void Awake() 
    {
        networkCharacterController = GetComponent<NetworkCharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        //Gets input from the network 
        if (GetInput(out NetworkInputData networkInputData))
        {
            Vector2 movementDirection = transform.right * networkInputData.movementInput.x + transform.up * networkInputData.movementInput.y;
            movementDirection.Normalize();
            networkCharacterController.Move(movementDirection);

            if(networkInputData.isThrowButtonPressed) networkCharacterController.Throw(pizza);
            if(networkInputData.isEscKeyPressed) networkCharacterController.ExitingMenu(exitMenu);
        }

    }
}
