using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

	/*
	 ***************************************************** 
	 * THIS SCRIPT HANDLES THE TIMER FUNCTIONALITY, AND  *
	 * THE PUZZLE, FOR THE BOMB OBJECT IN THE GAME!!     *
	 *****************************************************
	 */

	// Variables used to determine when the timer is active, and when to display it to the player
	public bool timerOn = false;
	public bool displayTimer;
	// Defines how long the timer is for
	public float timeLeft;
	// Graphics for puzzles
	public Texture2D uiTimer;
	public Texture2D uiWireText;
	// Bool to check whether the puzzle has been completed or not
	public bool isWireCut;
	// Font for text output
	public Font Digital;
	// GUIStyle that, via the Unity inspector, defines the style for the wires
	public GUIStyle wire;
	// Height, and width, of the wire buttons
	private float buttonWidth = 305;
	private float buttonHeight = 35;
	// Variables for the voice overs
	private bool halfTimePlayed;
	private bool oneMinutePlayed;
	// Private variable for the player and camera object
	GameObject player;
	GameObject sounds;
	GameObject voices;

	void Start () {
		
		// Defines the player object for the created variable at the top of the script
		player = GameObject.Find ("Player");
		sounds = GameObject.Find ("SFX");
		voices = GameObject.Find ("VO");
	}

	// Update is called once per frame
	void Update () {

		// Make sure the sound effect keeps looping
		audio.loop = true;

		if (timerOn) {

			// Runs so long as the correct wire has not been cut
			if (isWireCut == false) {

				// Timer script. Runs until the timer is below 0.
				timeLeft -= Time.deltaTime;

				// If half the time is left
				if (timeLeft < 301 && halfTimePlayed == false) {

					// Toggle voice over
					voices.GetComponent<voiceOvers>().halfTime = true;
					halfTimePlayed = true;
				}

				// If one minute is left
				if (timeLeft < 61 && oneMinutePlayed == false) {

					// Toggle voice over
					voices.GetComponent<voiceOvers>().oneMinuteLeft = true;
					oneMinutePlayed = true;
				}

				// If time runs out
				if (timeLeft < 1) {
						
					// Loads the game over scene
					Application.LoadLevel("lose");
				}
			} else {
				audio.Stop ();
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

			// The image for the timer
			//GUI.DrawTexture (new Rect (Screen.width/2.5f, Screen.height/3f, 300, 300), uiTimer);
			GUI.DrawTexture (new Rect (Screen.width/3.5f, Screen.height/4f, 798, 375), uiTimer);

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
			GUI.Label(new Rect(Screen.width/2.5f-50, Screen.height/2f-32, 250, 100), displayTime, guiStyle);

			/* -----
				END
			   ----- */

			// Renders if the player has the wirecutters in their inventory
			if (player.GetComponent<items>().hasWireCutter == true && isWireCut == false) {

				/* ----------
					WIRE GUI
				   ---------- */

				// When the player cuts the red wire
				if (GUI.Button(new Rect(Screen.width/2f+25, Screen.height/1.5f-60, buttonWidth, buttonHeight), "CUT THE RED WIRE", wire)) {

					// Toggle puzzle off since the correct wire was cut
					isWireCut = true;

				}

				// When the player cuts the green wire
				if (GUI.Button(new Rect(Screen.width/2f+25, Screen.height/1.5f-20, buttonWidth, buttonHeight), "CUT THE GREEN WIRE", wire)) {
					
					// Explosive sound
					Explosion();

					// End game
					Application.LoadLevel("lose");
				}

				// When the player cuts the blue wire
				if (GUI.Button(new Rect(Screen.width/2f+25, Screen.height/1.5f+20, buttonWidth, buttonHeight), "CUT THE BLUE WIRE", wire)) {

					// Explosive sound
					Explosion();

					// End game
					Application.LoadLevel("lose");
				}

				// When the player cuts the yellow wire
				if (GUI.Button(new Rect(Screen.width/2f+25, Screen.height/1.5f+60, buttonWidth, buttonHeight), "CUT THE YELLOW WIRE", wire)) {

					// Explosive sound
					Explosion();

					// End game
					Application.LoadLevel("lose");
				}

				// When the player cuts the purple wire
				if (GUI.Button(new Rect(Screen.width/2f+25, Screen.height/1.5f+100, buttonWidth, buttonHeight), "CUT THE PURPLE WIRE", wire)) {

					// Explosive sound
					Explosion();

					// End game
					Application.LoadLevel("lose");
				}


				/* -----
					END
				   ----- */

			}
		}
	}

	void Explosion () {
		
		sounds.GetComponent<soundEffects>().explosionSound = true;
	}
}
