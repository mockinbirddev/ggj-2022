using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
public class SFX : NetworkBehaviour
{
    public Animator animator;
    public AudioSource walk;
    public AudioSource wasHit;
    public AudioSource throwing;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Step()
    {
        walk.Play();
    }
}
