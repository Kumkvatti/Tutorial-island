using System.Linq;
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

    private List<KeyCode> Punch0 = new List<KeyCode>(new KeyCode[] { KeyCode.Q,  KeyCode.W, KeyCode.E } );
    private List<KeyCode> Punch1 = new List<KeyCode>(new KeyCode[] { KeyCode.Alpha6,  KeyCode.Alpha1, KeyCode.Alpha8, KeyCode.C, KeyCode.H} );
    private List<KeyCode> Punch2 = new List<KeyCode>(new KeyCode[] { KeyCode.C,  KeyCode.A, KeyCode.A, KeyCode.Z, KeyCode.M, KeyCode.N} );
    private List<List<KeyCode>> Punches =  new List<List<KeyCode>>();
    
    private List<int> Combos = new List<int>(new int[] { 0, 0, 0 } );
    // private int[,] Combos = new int[3,2] { {0,0}, {0,0}, {0,0} };
    // private int expected = 0;


    // Use this for initialization
    void Awake ()
    {
        Punches.Add(Punch0);
        Punches.Add(Punch1);
        Punches.Add(Punch2);

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

      boulder = GameObject.FindGameObjectWithTag("Boulder");
      if(boulder){
        
        int maxIndex = this.Combos.IndexOf(this.Combos.Max());
        Debug.Log("Maxing at " + maxIndex);
        Debug.Log("for " + this.Punches[maxIndex][this.Combos[maxIndex]]);

        if (this.TryPunch(maxIndex)){
            for (int i = this.Combos.Count-1; i >= 0; i--){
                this.TryPunch(i);
            }
        }
      }
    }
    bool TryPunch(int i){
      boulder = GameObject.FindGameObjectWithTag("Boulder");
      if (boulder.transform.position.x - 2.5 < transform.position.x && Input.GetKeyDown(this.Punches[i][this.Combos[i]])  )
        {
            animator.SetBool("Punching", true);
            Invoke("EndPunch",0.1f);
            int store = this.Combos[i] + 1;
            this.Combos = new List<int>(new int[] { 0, 0, 0 } );
            this.Combos[i] = store;
            Debug.Log("Collided with boulder!");
            boulder = GameObject.FindGameObjectWithTag("Boulder");

            if (boulder != null)
            {
                boulder.GetComponent<BoulderScript>().getHit(this.Combos[i]);
                if (this.Combos[i] >= this.Punches[i].Count){
                    this.Combos[i] = 0;
                }
                return false;
            }
        }
        return true;
    }

    void EndPunch()
    {
        animator.SetBool("Punching",false);
    }
}
