﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public int frameCounter = 0;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // private Animator animator;

    // Use this for initialization
    void Awake ()

    {
        animator =  GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer> ();
        // animator = GetComponent<Animator> ();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (Input.GetButtonDown ("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonUp ("Jump"))
        {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if (Input.GetButtonDown ("Horizontal")) {
            velocity.x = jumpTakeOffSpeed * Input.GetAxis("Horizontal");
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // animator.SetBool ("grounded", grounded);
        // animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;


    }

    void Update ()
    {
      ComputeVelocity();
      if (targetVelocity.x != 0 )
      {
        animator.SetBool("Walking", true);
      }
      else
      {
        animator.SetBool("Walking", false);
      }

      if (Input.GetButtonDown("Fire1")){
        GameObject.Find("boulder").GetComponent<BoulderScript>().getHit(2);
        Debug.Log("got hit by adasdsa3");
      }
    }
}
