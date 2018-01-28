using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// manager that contains all dialogues in the game
public class DialogueManager : MonoBehaviour {

 public Text dialogueText;

 public Animator animator;

 private string[] sentences;
 private int index = -1;

 // Use this for initialization
 void Start () {
  sentences = new string[] {};
 }

 public void StartDialogue(Dialogue dialogue) {

  animator.SetBool ("IsOpen", true);
  sentences = new string[dialogue.sentences.Length];
  dialogue.sentences.CopyTo (sentences, 0);
  DisplayNextSentence ();
 }

 public void DisplayNextSentence() {
  index += 1;
  if (index == sentences.Length) {
   index = sentences.Length -1;
  }

  string sentence = sentences[index];
  dialogueText.text = sentence;
 }

 public void DisplayPreviousSentence() {
  index -= 1;
  if (index == -1) {
   index = 0;
   return;
  }
  string sentence = sentences[index];
  dialogueText.text = sentence;
 }

 void EndDialogue() {
  animator.SetBool ("IsOpen", false);
 }
}
