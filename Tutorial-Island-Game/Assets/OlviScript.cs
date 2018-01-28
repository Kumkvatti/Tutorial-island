using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlviScript : MonoBehaviour {

	private GameObject pete;
	private Animator animator;

	// Use this for initialization
	void Start () {
    animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		pete = GameObject.FindGameObjectWithTag("Pete");
		//Debug.Log(pete.transform.position.x);
		//Debug.Log(transform.position.x);
		if (pete)
		{
			if (pete.transform.position.x >= transform.position.x)
				animator.SetBool("Drinked", true);
		}
	}
}
