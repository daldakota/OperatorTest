using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	/* creates singleton pattern:
	public = anyone can see it
	static = anyone can access it */
	public static GameManager instance = null;
	
	private UI_Manager UI_Manager;

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
		UI_Manager = GetComponent<UI_Manager>();
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
		current = null;
		DesiredLine = 0;
		AccessCode = 0;
		scrambleRequired = false;
		KindOfScramble = 0;
	}

	void ResetState(){
		beingPrompted = false;
		correctLine = false;
		correctCode = false;
		isScrambled = false;
	}

	void ReadStoryPrompt(){
		// Keep track of current story event
		current = StoryEvents[EventIndex];
		
		// Access Code
		AccessCode = current.AccessCode;
		Keypad.NewCode(AccessCode);
		
		// Display Access Code
		// TODO: put this in a co-routine so that it delays
		UI_Manager.MonitorPrompt(AccessCode);
		
		// Desired Line
		DesiredLine = current.DesiredLine;
		
		// Does this prompt say it should be scrambled?
		scrambleRequired = current.scrambleRequired;
		if (scrambleRequired == true){
			Scrambler.ScrambleLine = current.DesiredLine;
			Scrambler.ScrambleType = current.KindOfScramble;
		}
		
		// Play Prompt Audio, 5 is the int being used for Prompt audio
		LineManager.SwitchAudioSource(5);
		LineManager.promptAudioSource.clip = current.PromptAudio;
		LineManager.promptAudioSource.Play();
	}

	private bool CheckCorrect(){
		if (
			correctLine == true
			&&
			correctCode == true
			&&
			isScrambled == current.scrambleRequired
		) {return true;}
		else {return false;}
	}

	public void PlayEvent(){
		if (CheckCorrect() == true){
			LineManager.promptAudioSource.Stop();
			// Read in the other data, switch to correct audio source
			DesiredLine = DesiredLine - 1;
			LineManager.SwitchAudioSource(DesiredLine);
			LineManager.LineMonitorText[DesiredLine] = current.MonitorText;
			LineManager.LineAudioSources[DesiredLine].clip = current.EventAudio;
			LineManager.LineAudioSources[DesiredLine].Play();
			EventIndex++;
			ResetCurrents();
			ResetState();
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
