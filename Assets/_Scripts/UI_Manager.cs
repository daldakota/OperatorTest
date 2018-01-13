using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {
	// This class will be for managing the UI elements

	/* creates singleton pattern:
	public = anyone can see it
	static = anyone can access it */
	public static UI_Manager instance = null;

	[Header("Monitor")]
	// Request Monitor
	public GameObject RequestMonitorObj;
	private Text RequestMonitorText;

	[Header("Codebook")]
	// Codebook UI
	public GameObject CodebookPanel;
	private int currentCodebookPage = 0;
	public GameObject[] CodebookPages;

	void Awake(){
		/* Singleton Shit */
		if (instance == null){instance = this;}
		else if (instance != this){Destroy(gameObject);}
		DontDestroyOnLoad(gameObject);

		/* Actual Shit */
		RequestMonitorText = RequestMonitorObj.GetComponentInChildren<Text>();
	}

	/* Monitor */
	public void MonitorPrompt(int AccessCode){
		RequestMonitorText.text = "REQUEST: \n" + AccessCode;
	}

	public void LineInUpdate(string String){

	}

	/* Codebook */
	public void ActivateCodebook(){
		CodebookPanel.SetActive(!CodebookPanel.activeInHierarchy);
	}

	public void CodebookPageFlip(int Direction){
		// 0 is left, 1 is right
		// checks to see if you are at the end of the pages
		if (currentCodebookPage == 0 && Direction == 0){Debug.Log("No.");}
		else if (currentCodebookPage == CodebookPages.Length -1 && Direction == 1){Debug.Log("No.");}
		else {
			CodebookPages[currentCodebookPage].SetActive(false);
			if (Direction == 0){currentCodebookPage -=1;}
			else if (Direction == 1){currentCodebookPage +=1;}
			CodebookPages[currentCodebookPage].SetActive(true);
		}
	}
}
