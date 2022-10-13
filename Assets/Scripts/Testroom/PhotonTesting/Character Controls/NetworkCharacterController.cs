#pragma warning disable 0108
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkCharacterController : NetworkBehaviour
{

    public Rigidbody2D rigidbody2D;
    public float speed = 5f;
    public Animator _animator;
    // Start is called before the first frame update
    void Awake()
    {
        if(rigidbody2D == null) rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction) 
    {
        direction = direction.normalized;
        Vector2 movementVelocity = new Vector2(direction.x * speed,direction.y * speed);
        CharacterAnimator(rigidbody2D.velocity,_animator);
        rigidbody2D.velocity = movementVelocity;
        
    }

    public void CharacterAnimator(Vector2 velocity, Animator animator)
    {
        if((Mathf.Abs(velocity.y) > 0 && velocity.x == 0) || (Mathf.Abs(velocity.y) > 0 && Mathf.Abs(velocity.x) > 0))
        {
            animator.SetBool("isHorizontal", false);
            animator.SetBool("isVertical", true);
            animator.SetBool("isIdle", false);
            animator.SetFloat("Speed", velocity.y);
            if(velocity.y > 0) 
            {
                animator.SetBool("isUp", true);
            }
            else 
            {
                animator.SetBool("isUp", false);
            }
        }
        else if(Mathf.Abs(velocity.x) > 0 && velocity.y == 0)
        {
            animator.SetBool("isVertical", false);
            animator.SetBool("isHorizontal", true);
            animator.SetBool("isIdle", false);
            animator.SetFloat("Speed", velocity.x);
            if(velocity.x > 0) 
            {
                animator.SetBool("isRight", true);
            }
            else 
            {
                animator.SetBool("isRight", false);
            }
        }

        if(velocity.x == 0 && velocity.y == 0)
        {
            animator.SetFloat("Speed", 0);
            animator.SetBool("isRight", false);
            animator.SetBool("isUp", false);
            animator.SetBool("isIdle", true);
        }
    }
}
