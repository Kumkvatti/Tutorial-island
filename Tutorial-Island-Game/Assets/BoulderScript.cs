using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getHit(int s){
	    Debug.Log("got hit by '" + s + "'.");
        animator.SetInteger("Brokenness", s);
        // If you put destroying of gameobject here when s==3, for some reason collision box exists
        return s;
	}
}
