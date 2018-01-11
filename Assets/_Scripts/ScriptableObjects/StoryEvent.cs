using UnityEngine;
using System.Collections;

[System.Serializable]
public class StoryEvent : ScriptableObject
{
	public string EventName = "New Event";
	public int eventID = 0;
	[Header("Prompt Information")]
	public AudioClip PromptAudio = null;
	public int DesiredLine = 0;
	public int AccessCode = 0;
	public bool scrambleRequired = false;
	public int KindOfScramble = 0;
	[Header("Call Information")]
	public AudioClip EventAudio = null;
	public bool isInterrupted = false;
	public float interruptTime = 0.0f;
	public string MonitorText = null;
	
}