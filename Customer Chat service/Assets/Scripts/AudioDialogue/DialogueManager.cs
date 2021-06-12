using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Queue<string> Sentences;

	//My Codes
	public Queue<AudioClip> AudioClips;
	public FPSController PlayerControllerScript;
	public Animator talker;
	///

	public Text nameText;
	public Text dialogueText;

	public AudioSource audioSource;

	public Animator animator;

	public bool haveTalkerModel;

	// Use this for initialization
	void Start () {
		
		Sentences=new Queue<string>();

		//My Code
		AudioClips = new Queue<AudioClip>();

	}
	
	public void StartDialogue(Dialogue dialogue){

		//As We are talking to player
		//Disable Player Movements..
		PlayerControllerScript.enabled = false;

		//if we have a talker Model then start his talking animation
		if(haveTalkerModel){
			talker.SetBool("Talk",true);
		}
		//

		animator.SetBool("IsOpen",true);
		//nameText.text=dialogue.name;
		//Debug.Log("Starting Conversation with:"+dialogue.name);
		Sentences.Clear();
		AudioClips.Clear();

		foreach(string sentence in dialogue.sentences){
			Sentences.Enqueue(sentence);
		}
		foreach(AudioClip audioClip in dialogue.audioClips){
			AudioClips.Enqueue(audioClip);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence(){

		if(Sentences.Count==0){
			EndDialogue();
			return;
		}
		string sentence=Sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
		//Play Audio Clip Here
		AudioClip audioclip = AudioClips.Dequeue();
		audioSource.Stop();
		audioSource.clip = audioclip;
		audioSource.Play();
	}

	IEnumerator TypeSentence(string sentence){
		dialogueText.text="";
		foreach(char letter in sentence.ToCharArray()){
			dialogueText.text+=letter;
			yield return null;
		}
	}
	
	void EndDialogue(){
		Debug.Log("End Of Conversation");
		animator.SetBool("IsOpen",false);

		//Enable Player Control so that he can move again..! 
		//As we completed talking
		PlayerControllerScript.enabled = true;

		//if we have a talker Model then stop his talking animation
		if(haveTalkerModel){
			talker.SetBool("Talk",false);
		}
	}
}
