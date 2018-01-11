using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
	public int currentAudioSource = 0;
	public int numberOfAudioSources;
	public AudioSource[] myAudioSources;
	public Button[] myButtons;

	void Awake(){
		myAudioSources = GetComponentsInChildren<AudioSource>();
		numberOfAudioSources = myAudioSources.Length;
		// Set all audio sources other than the first to mute
		for (int i = 1; i < myAudioSources.Length; i++){
			myAudioSources[i].volume = 0;
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Space)){
			ScrollAudioSource();
		}
		if (Input.GetKeyDown(KeyCode.P)){
			PauseSource();
		}
		for(int i = 0; i < myAudioSources.Length; i++){
			ColorBlock cb = myButtons[i].colors;
			if(!myAudioSources[i].isPlaying){
				cb.normalColor = Color.red;
			}
			else{cb.normalColor = Color.green;}
			myButtons[i].colors = cb;
		}
	}

	public void ScrollAudioSource(){
		myAudioSources[currentAudioSource].volume = 0;
		if(currentAudioSource == 3){
			currentAudioSource = 0;
		}
		else{currentAudioSource++;}
		myAudioSources[currentAudioSource].volume = 1;
	}

	public void SwitchAudioSource(int desiredAudioSource){
		myAudioSources[currentAudioSource].volume = 0;
		myAudioSources[desiredAudioSource].volume = 1;
		currentAudioSource = desiredAudioSource;
	}

	void PauseSource(){
		AudioSource current = myAudioSources[currentAudioSource];
		if(current.isPlaying){current.Pause();}
		else{current.UnPause();}	
	}
}
