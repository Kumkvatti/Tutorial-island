using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController1 : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object

	private GameObject Pete;
	private GameObject DialogueManager;
	private GameObject Canvas;
	private GameObject EventButton;
	private GameObject Text1;
	private GameObject Text2;


	private Vector3 offset;         //Private variable to store the offset distance between the player and camera
	private bool active;

	public bool skip = false;

	void Start ()
	{

			Pete = GameObject.FindGameObjectWithTag("Pete");
			DialogueManager = GameObject.Find("DialogueManager");
			Canvas = GameObject.Find("Canvas");
			EventButton = GameObject.Find("EventButton");
			active = false;

			Pete.SetActive(false);
			DialogueManager.SetActive(false);
			//Calculate and store the offset value by getting the distance between the player's position and camera's position.

			GameObject.FindGameObjectWithTag("Stunt").GetComponent<Animator>().SetBool("End", true);
			Text1 = GameObject.Find("Text1");
			Text1.SetActive(false);
			Text2 = GameObject.Find("Text2");
			Text2.SetActive(false);
			GameObject.Find("Fader").GetComponent<FaderScript>().SetScreenOverlayColor(Color.black);
			GameObject.Find("Fader").GetComponent<FaderScript>().StartFade(new Color(0,0,0,0), 10.0f);
			Canvas.SetActive(false);

	}

	void Update ()
	{
		if(GameObject.Find("Stunt Pete"))
		{
			if ((GameObject.Find("Stunt Pete").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Still Waiting")))
			{
				Text1.SetActive(true);
			}
			if ((GameObject.Find("Stunt Pete").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Still Waiting!")))
			{
				Text1.SetActive(false);
			}
			if ((GameObject.Find("Stunt Pete").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("More Waiting")))
			{
				Text2.SetActive(true);
			}
			if ((GameObject.Find("Stunt Pete").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Pause")))
			{
				Text2.SetActive(false);
			}
		}
	}
}
