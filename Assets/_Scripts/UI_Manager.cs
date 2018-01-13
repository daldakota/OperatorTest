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


	[Header("UI Object References")]
	// Request Monitor
	public GameObject RequestMonitorObj;
	private Text RequestMonitorText;
	// Codebook UI
	public GameObject CodebookPanel;

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
}
