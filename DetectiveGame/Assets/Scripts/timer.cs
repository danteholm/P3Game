using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

	// Variables used to determine when the timer is active, and when to display it to the player
	public bool timerOn = false;
	public bool displayTimer;
	// Defines how long the timer is for
	public float timeLeft;
	// Graphics for puzzles
	public Texture2D uiTimer;
	// Font for text output
	public Font Digital;

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

		if (displayTimer) {

			/* -----------
				TIMER GUI
			   ----------- */

			GUI.DrawTexture (new Rect (Screen.width/2.5f, Screen.height/3f, 300, 300), uiTimer);

			GUIStyle guiStyle = new GUIStyle();
			guiStyle.normal.textColor = new Color (1f, 1f, 1f);
			guiStyle.fontSize = 50;
			guiStyle.font = Digital;

			// Variables for calculating proper time formatting used for the UI
			int minutes = Mathf.FloorToInt(timeLeft / 60F);
			int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
			
			// Loads the integers and then formats them properly
			string displayTime = string.Format("{0:0}:{1:00}", minutes, seconds);

			// Text output for the timer
			GUI.Label(new Rect(Screen.width/2f-35, Screen.height/2f-5 , 250, 100), displayTime, guiStyle);

			/* -----
				END
			   ----- */
		}
	}
}
