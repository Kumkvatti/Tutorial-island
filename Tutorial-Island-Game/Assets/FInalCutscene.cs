using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCutscene : MonoBehaviour {

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
			//Calculate and store the offset value by getting the distance between the player's position and camera's position.4


			GameObject.FindGameObjectWithTag("Stunt").GetComponent<Animator>().SetBool("End", true);
			GameObject.Find("Fader").GetComponent<FaderScript>().SetScreenOverlayColor(Color.black);
			GameObject.Find("Fader").GetComponent<FaderScript>().StartFade(new Color(0,0,0,0), 5.0f);

	}

	void Update ()
	{
		if(GameObject.Find("Stunt Pete"))
		{
			if ((GameObject.Find("Stunt Pete").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Still") && !active) || skip)
			{

			}
		}
	}
}
