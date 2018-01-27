using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class completeLevel : MonoBehaviour {


	// Use this for initialization
	void Start () {
	    Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active s is '" + scene.name + "'.");
	}
	
    void OnTriggerStay2D(Collider2D col) {
    	Debug.Log("colin '" + col.gameObject.name + "'.");

        if(col.gameObject.name == "Pete"){
	       GetComponent<scenemanager>().nextLevel();
        }
    }
}

