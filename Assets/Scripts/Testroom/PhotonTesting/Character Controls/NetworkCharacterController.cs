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
    public GameObject pizza;
    public int pizzaAmmo = 0;
    public Transform[] projectileSpawnpoint;
    public AudioSource _throwSound;
    public int points = 0;
    
    
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

    public void GetPoints()
    {
        points += 20;
    }

    public void Throw(PizzaProjectileHandler projectile)
    {
        CharacterInputHandler inputDirection = GetComponent<CharacterInputHandler>();
        if(pizzaAmmo > 0)
        {
            _throwSound.Play();
        }
        if(pizzaAmmo > 0)
        {
            if(inputDirection.direction == CharacterInputHandler.characterFacing.Up)
            {
                PizzaProjectileHandler proj = Runner.Spawn(projectile, projectileSpawnpoint[0].position, Quaternion.identity);
                proj._characterInputHandler = this.GetComponent<CharacterInputHandler>();
                proj.tag = this.tag;
                pizzaAmmo--;
                Debug.Log(pizzaAmmo);
            }
            else if(inputDirection.direction == CharacterInputHandler.characterFacing.Down)
            {
                PizzaProjectileHandler proj = Runner.Spawn(projectile, projectileSpawnpoint[1].position, Quaternion.identity);
                proj._characterInputHandler = this.GetComponent<CharacterInputHandler>();
                proj.tag = this.tag;
                pizzaAmmo--;
                Debug.Log(pizzaAmmo);
            }
            else if(inputDirection.direction == CharacterInputHandler.characterFacing.Left)
            {
                PizzaProjectileHandler proj = Runner.Spawn(projectile, projectileSpawnpoint[2].position, Quaternion.identity);
                proj._characterInputHandler = this.GetComponent<CharacterInputHandler>();
                proj.tag = this.tag;
                pizzaAmmo--;
                Debug.Log(pizzaAmmo);
            }
            else if(inputDirection.direction == CharacterInputHandler.characterFacing.Right)
            {
                PizzaProjectileHandler proj = Runner.Spawn(projectile, projectileSpawnpoint[3].position, Quaternion.identity);
                proj._characterInputHandler = this.GetComponent<CharacterInputHandler>();
                proj.tag = this.tag;
                pizzaAmmo--;
                Debug.Log(pizzaAmmo);
            }
        }
        
            
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
