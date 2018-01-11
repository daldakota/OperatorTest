using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrambler : MonoBehaviour {

	/* Buttons */
	[Header("Scrambler Buttons")]
	public Button[] ScramblerButtons;
	private Button ScramblerPowerButton;
	private Button ScramblerLineButton;
	private Button ScramblerTypeButton;

	/* Variables */
	[Header("Scrambler Variables")]
	public bool ScramblerOn = false;
	public int CurrentLine = 1;
	public int CurrentType = 1;

	void Awake(){
		ScramblerPowerButton = ScramblerButtons[0];
		ScramblerLineButton = ScramblerButtons[1];
		ScramblerTypeButton = ScramblerButtons[2];
	}

	/* TEMPORARY, JUST TO KEEP IN MIND WHAT KIND OF SCRAMBLE IS ON */
	public Text ScramblerLineText;
	public Text ScramblerTypeText;
	void Update(){
		ScramblerLineText.text = CurrentLine.ToString();
		ScramblerTypeText.text = CurrentType.ToString();
	}

	/* UI Button Functions */
	public void ToggleScramblerPower(){
		ScramblerOn = !ScramblerOn;
		Debug.Log("Scrambler On: " + ScramblerOn);
	}

	public void ChangeScramblerLine(){
		if (CurrentLine == 3) {CurrentLine = 0;}
		else {CurrentLine++;}
	}

	public void ChangeScramblerType(){
		if (CurrentType == 3) {CurrentType = 0;}
		else {CurrentType++;}
	}
}
