using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
public class PizzaProjectileHandler : NetworkBehaviour
{
    public NetworkObject networkObject;
    public CharacterInputHandler _characterInputHandler;
    public float speed = 20f;
    public AudioSource _hit;
    public void Start()
    {
        networkObject = GetComponent<NetworkObject>();
    }

    public override void FixedUpdateNetwork()
    {
        if(_characterInputHandler.direction == CharacterInputHandler.characterFacing.Up)
        {
            transform.position += transform.up * Runner.DeltaTime * speed;
        }
        else if(_characterInputHandler.direction == CharacterInputHandler.characterFacing.Down)
        {
            transform.position += -transform.up * Runner.DeltaTime * speed;
        }
        else if(_characterInputHandler.direction == CharacterInputHandler.characterFacing.Left)
        {
            transform.position += -transform.right * Runner.DeltaTime * speed;
        }
        else if(_characterInputHandler.direction == CharacterInputHandler.characterFacing.Right)
        {
            transform.position += transform.right * Runner.DeltaTime * speed;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collision happened");
            _hit.Play();
            Destroy(this.gameObject);
        }

        if(this.tag != other.gameObject.tag)
        {
            Debug.Log("Pizza has landed");
            _hit.Play();
            if(other.gameObject.GetComponent<NetworkCharacterController>() != null)
            {
                other.gameObject.GetComponent<NetworkCharacterController>().GetPoints();
            }
            Runner.Despawn(networkObject);
        }
    }

}
