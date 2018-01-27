using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<scenemanager>().nextLevel();
        // SceneManager.MergeScenes("MainScene","Scene0");
        // SceneManager.MergeScenes(SceneManager.GetSceneByName("MainScene"), SceneManager.GetSceneByName("MainScene"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
