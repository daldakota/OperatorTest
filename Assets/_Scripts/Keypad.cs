using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour {

	/* Private */
	private int[] correct_code;
	private int[] entered_code;
	private int currentdigit;
	public Text keypadText;

	void Start(){
	}

	public void NewCode(int newCode){
		entered_code = new int[4];
		correct_code = digitArr(newCode);
		keypadText.text = "Enter Code";
	}
	// For inputting code for keypad
	public void CodeEntry(int digit){
		if (currentdigit == 0){keypadText.text = "";}
		if (currentdigit < 4){
			entered_code[currentdigit] = digit;
			currentdigit++;
			keypadText.text = keypadText.text + digit;

			if (currentdigit == 4){
				bool same = compArr(entered_code, correct_code);
				
				if (same == true){
					keypadText.text = "ACCEPTED";
					GameManager.instance.correctCode = true;
					GameManager.instance.PlayEvent();
				}
				else {Debug.Log("You fucked up!");}
				
				entered_code = new int[4];
				currentdigit = 0;
			}
		}
	}

	// https://answers.unity.com/questions/380548/compare-arrays-1.html
	// For comparing two arrays
	private bool compArr <T,S> (T[] arrayA, S[] arrayB) {
		if(arrayA.Length != arrayB.Length) return false;
		for(int i = 0; i < arrayA.Length; i++) {
			if(!arrayA[i].Equals(arrayB[i])) return false;
		}
		return true;
	}

	// https://stackoverflow.com/questions/4580261/integer-to-integer-array-c-sharp
	// For taking the desired code and creating an array that can be compared every time the player punches in a number!
	private int[] digitArr(int n){
		if (n == 0) return new int[1] { 0 };

		var digits = new List<int>();

		for (; n != 0; n /= 10)
			digits.Add(n % 10);

		var arr = digits.ToArray();
		System.Array.Reverse(arr);
		return arr;
	}
}