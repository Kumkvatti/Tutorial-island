using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour {

	// Use this for initialization
	public int level = 1;

	void Start () {

        // SceneManager.MergeScenes("MainScene","Scene0");
        SceneManager.MergeScenes(SceneManager.GetSceneByName("MainScene"), SceneManager.GetSceneByName("Scene0"));
	}
	

    void nextLevel()
    {
        //level += 1;
        //SceneManager.MergeScenes(level);
    }
}
