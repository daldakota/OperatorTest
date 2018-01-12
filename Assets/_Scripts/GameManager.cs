using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	/* creates singleton pattern:
	public = anyone can see it
	static = anyone can access it */
	public static GameManager instance = null;

	[Header("Game Objects")]
	// Line Manager
	public GameObject LineManagerObj;
	private LineManager LineManager;
	// Keypad
	public GameObject KeypadObject;
	private Keypad Keypad;
	// Scrambler
	public GameObject ScramblerObj;
	private Scrambler Scrambler;
	// Request Monitor
	public Text RequestMonitorText;
	
	[Header("Story Events")]
	public StoryEvent[] StoryEvents;
	private int EventIndex = 0;

	[Header("Current Prompt")]
	public StoryEvent current = null;
	public int DesiredLine;
	public int AccessCode = 0;
	public bool scrambleRequired = false;
	public int KindOfScramble = 0;
	
	[Header("State Variables")]
	public bool beingPrompted;
	public bool correctLine;
	public bool correctCode;
	public bool isScrambled = false;

	void Awake(){
		/* Singleton Shit */
		if (instance == null){instance = this;}
		else if (instance != this){Destroy(gameObject);}
		DontDestroyOnLoad(gameObject);

		/* Actual Shit */
		Keypad = KeypadObject.GetComponent<Keypad>();
		LineManager = LineManagerObj.GetComponent<LineManager>();
		Scrambler = ScramblerObj.GetComponent<Scrambler>();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.S)){
			ReadStoryPrompt();
		}
	}

	void ResetCurrents(){

	}

	void ReadStoryPrompt(){
		// Keep track of current story event
		current = StoryEvents[EventIndex];
		// Access Code
		AccessCode = current.AccessCode;
		Keypad.NewCode(AccessCode);
		// Display Access Code
		// Later put this in a co-routine so that it delays
		RequestMonitorText.text = "REQUEST: \n" + AccessCode;
		// Desired Line
		DesiredLine = current.DesiredLine;
		// Does this prompt say it should be scrambled?
		scrambleRequired = current.scrambleRequired;
		// if (scrambleRequired == true){}
		// Play Prompt Audio, 5 is the int being used for Prompt audio
		LineManager.SwitchAudioSource(5);
		LineManager.promptAudioSource.clip = current.PromptAudio;
		LineManager.promptAudioSource.Play();
	}

	public void PlayEvent(){
		if (correctLine == true && correctCode == true){
			beingPrompted = false;
			LineManager.promptAudioSource.Stop();
			// Read in the other data, switch to correct audio source
			DesiredLine = DesiredLine - 1;
			LineManager.SwitchAudioSource(DesiredLine);
			
			LineManager.LineMonitorText[DesiredLine] = current.MonitorText;
			LineManager.LineAudioSources[DesiredLine].clip = current.EventAudio;
			LineManager.LineAudioSources[DesiredLine].Play();
			EventIndex++;
		}
	}
	
	// Currently disables cursor, might prove handy later
	public void DisablePlayerController(bool status){
		if (status == true){
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			// controller.enabled = false;
		}
		if (status == false){
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			// controller.enabled = true;
		}
	}
}
