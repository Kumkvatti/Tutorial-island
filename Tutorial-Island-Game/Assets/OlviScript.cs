using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlviScript : MonoBehaviour {

	private GameObject pete;
	private Animator animator;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		pete = GameObject.FindGameObjectWithTag("Pete");
		if (pete.transform.position.x >= transform.position.x)
			animator.SetBool("Drinked", true);
	}
}
