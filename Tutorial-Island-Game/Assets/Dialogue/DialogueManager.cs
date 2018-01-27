using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// manager that contains all dialogues in the game
public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;
	// Use this for initialization
	void Start () {
		sentences = new Queue<string> (); 
	}

	public void StartDialogue(Dialogue dialogue) {

		animator.SetBool ("IsOpen", true);

		nameText.text = dialogue.DialogueName;

		sentences.Clear ();
		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence() {
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		dialogueText.text = sentence;
	}

	void EndDialogue() {
		animator.SetBool ("IsOpen", false);
		Debug.Log ("End of conversation");
	}
}
