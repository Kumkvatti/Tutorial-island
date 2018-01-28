using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BoulderScript : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public int HP = 0;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getHit(int s){
	    Debug.Log("got hit by '" + s + "' with " + this.HP +" hp.");
        animator.SetInteger("Brokenness", 3 + Math.Min(0,s-this.HP));
        // If you put destroying of gameobject here when s==3, for some reason collision box exists
        if( this.HP <= s ){
			GetComponent<BoxCollider2D>().enabled = false;
        }
        return s;
	}
}
