using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public int frameCounter = 0;
    private int damage = 1;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private GameObject boulder;

    private KeyCode [] Punch0 = new KeyCode[3]  { KeyCode.Q,  KeyCode.W, KeyCode.E };
    private int expected = 0;
    // Use this for initialization
    void Awake ()

    {
        animator =  GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (move.x == 0.0f)
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
        animator.SetBool("Punching", true);
        boulder = GameObject.FindGameObjectWithTag("Boulder");
        boulder.GetComponent<BoulderScript>().getHit(1);
      }
      if (Input.GetButtonUp("Fire1"))
      {
        animator.SetBool("Punching", false);
      }
      Debug.Log(this.Punch0[this.expected]);

      if (GetComponent<PhysicsObject>().collidedBoulder && Input.GetKeyDown(this.Punch0[this.expected])  )
        {
            this.expected += 1;
            Debug.Log("Collided with boulder!");
            boulder = GameObject.FindGameObjectWithTag("Boulder");
            if (boulder != null)
            {
                int current_damage = boulder.GetComponent<BoulderScript>().getHit(1);
            }
        }
    }
}
