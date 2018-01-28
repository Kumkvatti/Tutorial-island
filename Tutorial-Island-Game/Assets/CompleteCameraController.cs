using UnityEngine;
using System.Collections;
using System;

public class CompleteCameraController : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object

    private GameObject Pete;
    private GameObject DialogueManager;
    private GameObject Canvas;
    private GameObject EventButton;


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private bool active;

    // Use this for initialization
    void Start ()
    {
        offset = transform.position - player.transform.position;

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
        if (GameObject.Find("Stunt Pete").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Still") && !active)
        {
          GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;
          GameObject.FindGameObjectWithTag("Stunt").SetActive(false);
          GameObject.Find("radio").SetActive(false);
          Pete.SetActive(true);
          DialogueManager.SetActive(true);
          Canvas.SetActive(true);
          EventButton.SetActive(true);
          active = true;
        }
      }
    }

    // LateUpdate is called after Update each frame
    void LateUpdate ()
    {

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(Math.Min(86, Math.Max(player.transform.position.x + offset.x, 0)), 0, -10);
        //transform.position = new Vector3(transform.position.x, 1);


    }
}
