#pragma warning disable 0108
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkCharacterController : NetworkBehaviour
{

    public Rigidbody2D rigidbody2D;
    public float speed = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        if(rigidbody2D == null) rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction) 
    {
        direction = direction.normalized;
        Vector2 movementVelocity = new Vector2(direction.x * speed,direction.y * speed);
        rigidbody2D.velocity = movementVelocity;
    }
}
