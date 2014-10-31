using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

	// Defines how long the timer is for
	public float timeLeft;
	public bool timerOn = false;

	// Update is called once per frame
	void Update () {

		if (timerOn) {
			// Timer script. Runs until the timer is below 0.
			timeLeft -= Time.deltaTime;
			if(timeLeft < 1) {
					
				// Loads the game over scene
				Application.LoadLevel("lose");
			}
		}
	}

	// GUI function to show the timer in minutes and seconds
	// The timer is rendered as 0:00
	void OnGUI () {

		if (timerOn) {
			GUIStyle guiStyle = new GUIStyle();
			guiStyle.normal.textColor = new Color (1.5f, 2f, 0f);
			guiStyle.fontSize = 60;

			// Variables for calculating proper time formatting used for the UI
			int minutes = Mathf.FloorToInt(timeLeft / 60F);
			int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
			
			// Loads the integers and then formats them properly
			string displayTime = string.Format("{0:0}:{1:00}", minutes, seconds);

			// UI element for the timer
			GUI.Label(new Rect(10,5,250,100), displayTime, guiStyle);
		}
	}
}
