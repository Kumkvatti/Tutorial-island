using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// single dialogue object
[System.Serializable]
public class Dialogue {

	[TextArea(1, 7)]
	public string[] sentences;
}
