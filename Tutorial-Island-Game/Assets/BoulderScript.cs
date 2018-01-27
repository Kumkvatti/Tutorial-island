using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private int HP = 3;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getHit(int s){
	    Debug.Log("got hit by '" + s + "'.");
	    this.HP -= s;
        animator.SetInteger("Brokenness", 3 - this.HP);
        // If you put destroying of gameobject here when s==3, for some reason collision box exists
        if( this.HP == 0 ){
			GetComponent<BoxCollider2D>().enabled = false;
        }
        return s;
	}
}
