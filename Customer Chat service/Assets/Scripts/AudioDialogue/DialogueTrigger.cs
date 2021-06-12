using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			//This Line Triggers Dialogue
			FindObjectOfType<Dialogue2>().StartDialog(dialogue);
		}
	}
}
