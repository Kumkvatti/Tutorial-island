using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipScript : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}

	void Update () {
      	if (Input.GetKeyDown(KeyCode.X))
        {
					Debug.Log("Pressed");
					GameObject Cutscene = GameObject.Find("Cutscene Camera");
					if (Cutscene)
						Cutscene.GetComponent<CutsceneController>().skip = true;
				}
	}

}
