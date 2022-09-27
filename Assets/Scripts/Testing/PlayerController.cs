using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movement_speed = 10f;
    [SerializeField]
    private Rigidbody2D _rigid_body;
    private Vector2 movement_direction;

    // Update is called once per frame
    void Update()
    {
        Movement_Input();
    }
    
    private void FixedUpdate() 
    {
        Player_Movement();
    }

    private void Movement_Input()
    {
        float move_x_axis = Input.GetAxisRaw("Horizontal");
        float move_y_axis = Input.GetAxisRaw("Vertical");

        movement_direction = new Vector2(move_x_axis, move_y_axis);

        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if(Input.GetKeyDown("r"))
        {
            Other();
        }
    }

    public void Player_Movement()
    {
        _rigid_body.velocity = new Vector2(movement_direction.x * movement_speed, movement_direction.y * movement_speed);
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }

    public void Other()
    {
        Debug.Log("Attack");
    }
}
