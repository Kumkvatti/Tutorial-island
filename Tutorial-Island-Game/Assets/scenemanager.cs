using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class scenemanager : MonoBehaviour {

	// Use this for initialization
	public int TargetLevel = 0;

	void Start () {
        this.nextLevel();
        // SceneManager.MergeScenes("MainScene","Scene0");
        // SceneManager.MergeScenes(SceneManager.GetSceneByName("MainScene"), SceneManager.GetSceneByName("MainScene"));
	}
	

    void nextLevel() {
    	string s = "Scene" + TargetLevel;

        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active scene is '" + scene.name + "'.");
        Debug.Log("loading '" + s + "'.");

    	if (scene != SceneManager.GetSceneByName("MainScene")){
    		SceneManager.LoadScene("MainScene" );
			SceneManager.LoadScene(s, LoadSceneMode.Additive);
		}
    }
}
