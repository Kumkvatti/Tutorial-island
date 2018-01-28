using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object

	private GameObject Pete;
	private GameObject DialogueManager;
	private GameObject Canvas;
	private GameObject EventButton;


	private Vector3 offset;         //Private variable to store the offset distance between the player and camera
	private bool active;

	public bool skip = false;

	void Start ()
	{

			GameObject.Find("Main Camera").GetComponent<Camera>().enabled = false;
			Pete = GameObject.FindGameObjectWithTag("Pete");
			DialogueManager = GameObject.Find("DialogueManager");
			Canvas = GameObject.Find("Canvas");
			EventButton = GameObject.Find("EventButton");
			active = false;

			Pete.SetActive(false);
			DialogueManager.SetActive(false);
			Canvas.SetActive(false);
			EventButton.SetActive(false);
			//Calculate and store the offset value by getting the distance between the player's position and camera's position.

	}

	void Update ()
	{
		if(GameObject.Find("Stunt Pete"))
		{
			if ((GameObject.Find("Stunt Pete").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Still") && !active) || skip)
			{
				GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;
				GameObject.FindGameObjectWithTag("Stunt").SetActive(false);
				GameObject.Find("radio").SetActive(false);
				Pete.SetActive(true);
				DialogueManager.SetActive(true);
				Canvas.SetActive(true);
				EventButton.SetActive(true);
				GameObject.Find("Skipper").SetActive(false);
				active = true;
			}
		}
	}
}
