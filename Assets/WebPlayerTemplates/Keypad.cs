using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour {
	
	// Objects
	public GameObject targetdoor;
	public GameObject KeypadPanel;

	// Variables
	public int[] code;
	private int[] entered_code;
	private int currentdigit;
	private Text keypadText;

	void Start(){
		entered_code = new int[4];
	}
	// For clicking the keypad
	void OnMouseUpAsButton(){
		/* Simple Unlock 
		Debug.Log("I've been clicked");
		door.locked = !door.locked;
		Debug.Log(door.locked); */
		if (door.locked == true){
			GameManager.instance.DisablePlayerController(true);
			KeypadPanel.SetActive(true);
			keypadText = KeypadPanel.GetComponentInChildren<Text>();
		}
	}
	public void ExitKeypad(){
		GameManager.instance.DisablePlayerController(false);
		KeypadPanel.SetActive(false);
	}
	// For inputting code for keypad
	public void CodeEntry(int digit){
		Debug.Log(digit);
		if (currentdigit < 4){
			entered_code[currentdigit] = digit;
			currentdigit++;
			keypadText.text = keypadText.text + digit;

			if (currentdigit == 4){
				bool same = compArr(entered_code, code);
				
				if (same == true){
					door.locked = !door.locked;
					Debug.Log("Door locked: " + door.locked);
				}
				else {Debug.Log("You fucked up!");}
				
				GameManager.instance.DisablePlayerController(false);
				KeypadPanel.SetActive(false);
				entered_code = new int[4];
				currentdigit = 0;
			}
		}
	}
	// https://answers.unity.com/questions/380548/compare-arrays-1.html
	private bool compArr <T,S> (T[] arrayA, S[] arrayB) {
		if(arrayA.Length != arrayB.Length) return false;
		for(int i = 0; i < arrayA.Length; i++) {
			if(!arrayA[i].Equals(arrayB[i])) return false;
		}
		return true;
	}
}