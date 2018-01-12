using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineManager : MonoBehaviour {

	/* References */
	[Header("Prompt Audio Source")]
	public AudioSource promptAudioSource;
	[Header("Line Object References")]
	public int currentAudioSource;
	public AudioSource[] LineAudioSources;
	public Button[] LineButtons;

	/* Variables */
	[Header("Line Variable Arrays")]
	public bool[] LineInUse = new bool[4];
	public string[] LineMonitorText = new string[4];

	void Update(){
		for(int i = 0; i < LineAudioSources.Length; i++){
			ColorBlock cb = LineButtons[i].colors;
			if(!LineAudioSources[i].isPlaying){
				cb.normalColor = Color.red;
			}
			else{cb.normalColor = Color.green;}
			LineButtons[i].colors = cb;
		}
	}
	
	public void LineSelect(int LineIn){
		// Adapt input for the array cos arrays are dumb
		LineIn = LineIn -1;
		
		if (GameManager.instance.beingPrompted == true && LineIn != GameManager.instance.DesiredLine){
			// Play a denied sound
			Debug.Log("NO");
		}
		if(LineInUse[LineIn] == false && (LineIn + 1) == GameManager.instance.DesiredLine){
			LineInUse[LineIn] = true;
			GameManager.instance.correctLine = true;
			SwitchAudioSource(LineIn);
			GameManager.instance.PlayEvent();
		}
		else {
			SwitchAudioSource(LineIn);
		}
	}
	public void SwitchAudioSource(int desiredAudioSource){
		if (currentAudioSource == 5){
			promptAudioSource.volume = 0;
			currentAudioSource = desiredAudioSource;
		}
		if (desiredAudioSource == 5){
			for(int i = 0; i < LineAudioSources.Length; i++){
				LineAudioSources[i].volume = 0;
				promptAudioSource.volume = 1;
				currentAudioSource = 5;
			}
		}
		else {
			// Also switch what text is on the monitor
			// GameManager.instance.RequestMonitorText.text = LineMonitorText[desiredAudioSource];
			LineAudioSources[currentAudioSource].volume = 0;
			LineAudioSources[desiredAudioSource].volume = 1;
		}
		currentAudioSource = desiredAudioSource;
	}
}
