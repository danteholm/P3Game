using UnityEngine;
using System.Collections;

public class puzzleScript : MonoBehaviour {

	// Bool used to determine when a puzzle is active, or complete
	public bool keypadPuzzle = false;
	public bool puzzleComplete = false;
	// Graphics for puzzles
	//public Texture2D puzzleBackground;
	public Texture2D uiKeypad;
	// Font for input field
	public Font Digital;
	// Sizes for the keypad buttons
	private float buttonWidth = 85;
	private float buttonHeight = 75;
	// Positioning of the keypad buttons
	private float rowWidth = Screen.width/2.25f;
	private float rowHeight = Screen.height/2.25f;
	// Variables used to handle the player input, and the correct keycode
	private string inputOutput = null;
	private int inputNumber;
	private int whatInputAmI;
	public string keyCode;
	// Private variable for the player object
	GameObject player;
	GameObject mainCamera;

	void Start () {

		// Defines the player object for the created variable at the top of the script
		player = GameObject.FindWithTag ("Player");
		mainCamera = GameObject.Find ("Main Camera");
	}

	// Submit function for the keypad
	void Submit () {

		// Runs a check on the numbers input
		if (inputOutput == keyCode) {

			// Toogle bool on to play sound effect
			player.GetComponent<soundEffects>().successSound = true;
			player.GetComponent<soundEffects>().bookcaseMoving = true;
			
			// Puzzle mode toggle
			puzzleMode();
			
			// Toggles the puzzle to be complete
			puzzleComplete = true;

			// Play animation on bookshelf
			GameObject.Find ("bookshelfOffice").animation.Play("bookcase");
			
			// Call puzzle reset
			resetNumbers();

		// If the numbers are not correct
		} else {

			// Toogle bool on to play sound effect
			player.GetComponent<soundEffects>().errorSound = true;

			// Call puzzle reset
			resetNumbers();
		}
	}

	// Update is called once per frame
	void OnGUI () {

		GUIStyle inputStyle = new GUIStyle();
		inputStyle.fontSize = 60;
		inputStyle.normal.textColor = new Color (0.1f, 0.1f, 0.1f);
		inputStyle.font = Digital;

		// Only renders when the puzzle is active
		if (keypadPuzzle == true) {

			/* ------------
				KEYPAD GUI
			   ------------ */

			//GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), puzzleBackground);
			GUI.DrawTexture (new Rect (Screen.width/3f-15, Screen.height/6.5f, 500, 500), uiKeypad);

			/* ---------
			    DISPLAY
			   --------- */

			GUI.Label(new Rect(rowWidth-42, rowHeight-2*(buttonHeight)-15, buttonWidth, buttonHeight), inputOutput, inputStyle);

			/* -----------
			    FIRST ROW
			   ----------- */

			// '1' button
			if (GUI.Button(new Rect(rowWidth-buttonWidth+25, rowHeight-buttonHeight-15, buttonWidth, buttonHeight), "", GUIStyle.none)) {

				// Play sound effect when clicking button
				buttonSound();

				// Changes the int to match the button pressed
				whatInputAmI = 1;

				// Runs the script to insert the value into the input variable
				buttonPress();

			}

			// '2' button
			if (GUI.Button(new Rect(rowWidth+35, rowHeight-buttonHeight-15, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				buttonSound();

				// Changes the int to match the button pressed
				whatInputAmI = 2;

				// Runs the script to insert the value into the input variable
				buttonPress();
			}

			// '3' button
			if (GUI.Button(new Rect(rowWidth+buttonWidth+45, rowHeight-buttonHeight-15, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				buttonSound();

				// Changes the int to match the button pressed
				whatInputAmI = 3;

				// Runs the script to insert the value into the input variable
				buttonPress();
			}

			/* ------------
			    SECOND ROW
			   ------------ */

			// '4' button
			if (GUI.Button(new Rect(rowWidth-buttonWidth+25, rowHeight-5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				buttonSound();

				// Changes the int to match the button pressed
				whatInputAmI = 4;

				// Runs the script to insert the value into the input variable
				buttonPress();
			}

			// '5' button
			if (GUI.Button(new Rect(rowWidth+35, rowHeight-5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				buttonSound();

				// Changes the int to match the button pressed
				whatInputAmI = 5;

				// Runs the script to insert the value into the input variable
				buttonPress();
			}

			// '6' button
			if (GUI.Button(new Rect(rowWidth+buttonWidth+45, rowHeight-5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				buttonSound();

				// Changes the int to match the button pressed
				whatInputAmI = 6;

				// Runs the script to insert the value into the input variable
				buttonPress();
			}

			/* -----------
			    THIRD ROW
			   ----------- */

			// '7' button
			if (GUI.Button(new Rect(rowWidth-buttonWidth+25, rowHeight+buttonHeight+5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				buttonSound();

				// Changes the int to match the button pressed
				whatInputAmI = 7;

				// Runs the script to insert the value into the input variable
				buttonPress();
			}

			// '8' button
			if (GUI.Button(new Rect(rowWidth+35, rowHeight+buttonHeight+5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				buttonSound();

				// Changes the int to match the button pressed
				whatInputAmI = 8;

				// Runs the script to insert the value into the input variable
				buttonPress();
			}

			// '9' button
			if (GUI.Button(new Rect(rowWidth+buttonWidth+45, rowHeight+buttonHeight+5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				buttonSound();

				// Changes the int to match the button pressed
				whatInputAmI = 9;

				// Runs the script to insert the value into the input variable
				buttonPress();
			}

			/* ------------
			    FOURTH ROW
			   ------------ */

			// 'X' button to end the puzzle
			if (GUI.Button(new Rect(rowWidth-buttonWidth+25, rowHeight+2*(buttonHeight)+15, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				buttonSound();
				
				// Puzzle mode toggle
				puzzleMode();
				
				// Call puzzle reset
				resetNumbers();
			
			// If player presses the Escape key instead
			} else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown (KeyCode.Mouse1)) {
				// Puzzle mode toggle
				puzzleMode();
				
				// Call puzzle reset
				resetNumbers();
			}

			// '0' button
			if (GUI.Button(new Rect(rowWidth+35, rowHeight+2*(buttonHeight)+15, buttonWidth, buttonHeight), "", GUIStyle.none)) {

				// Play sound effect when clicking button
				buttonSound();

				// Changes the int to match the button pressed
				whatInputAmI = 0;

				// Runs the script to insert the value into the input variable
				buttonPress();
			}

			// 'OK' button, to submit the input code
			if (GUI.Button(new Rect(rowWidth+buttonWidth+45, rowHeight+2*(buttonHeight)+15, buttonWidth, buttonHeight), "", GUIStyle.none)) {

				buttonSound();

				Submit();
			}

			/* -----
			    END
			   ----- */
		}
	}

	// Toggle mode on/off function
	void puzzleMode () {

		// Toggles movement system back on
		player.GetComponent<MouseLook>().cutSceneOn = !player.GetComponent<MouseLook>().cutSceneOn;
		mainCamera.GetComponent<MouseLook>().cutSceneOn = !mainCamera.GetComponent<MouseLook>().cutSceneOn;

		// Toggles puzzle, and inventory
		mainCamera.GetComponent<puzzleScript>().keypadPuzzle = !mainCamera.GetComponent<puzzleScript>().keypadPuzzle;
		mainCamera.GetComponent<userInterface>().inventoryOn = !mainCamera.GetComponent<userInterface>().inventoryOn;
	}

	// Reset the puzzle
	void resetNumbers () {

		inputOutput = null;
		whatInputAmI = 0;
		inputNumber = 0;
	}

	// Play sound effect when clicking button
	void buttonSound () {

		player.GetComponent<soundEffects>().keypadSound = true;
	}

	// Button press script
	void buttonPress () {

		// Checks what # of input it is. The cap is at 7
		if (inputNumber < 7) {

			// Increase the value. This is used to cap the max amount of digits the code can be
			inputNumber ++;

			// Inserts the value of the button pressed to the string
			inputOutput += whatInputAmI;
		
		// If the player inputs another number when the capacity has reached 7
		} else {

			// Resets the value of the output string
			inputOutput = null;

			// Resets the output when it exceeds the 7 digit capacity
			inputNumber = 1;

			// Inserts the value of the button pressed to the string
			inputOutput += whatInputAmI;
		}
	}

	// Plays the sound effect for the bookcase moving after a short delay
	IEnumerator bookcaseSound () {

		yield return new WaitForSeconds(1);
		
		// Toggle bool for sound effect
		player.GetComponent<soundEffects>().bookcaseMoving = true;
	}
}
