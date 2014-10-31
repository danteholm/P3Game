using UnityEngine;
using System.Collections;

public class puzzleScript : MonoBehaviour {

	// Bool used to determine when a puzzle is active, or complete
	public bool keypadPuzzle = false;
	public bool puzzleComplete = false;

	// Textures for puzzles
	public Texture2D puzzleBackground;

	// Sizes for the keypad buttons
	private float buttonWidth = 75;
	private float buttonHeight = 75;

	// Positioning of the keypad buttons
	private float rowWidth = Screen.width/2.25f;
	private float rowHeight = Screen.height/2.25f;

	// Private variable for the player object
	GameObject player;
	GameObject mainCamera;

	// Bools for the password
	private bool numberOne = false;
	private bool numberTwo = false;
	private bool numberThree = false;

	void Start () {

		// Defines the player object for the created variable at the top of the script
		player = GameObject.FindWithTag ("Player");
		mainCamera = GameObject.Find ("Main Camera");
	}

	void Update () {

		// If the puzzle has been completed
		if (numberOne == true && numberTwo == true && numberThree == true) {

			// Toogle bool on to play sound effect
			player.GetComponent<soundEffects>().bookcaseMoving = true;

			/*// Toggles movement system back on
			player.GetComponent<MouseLook>().cutSceneOn = true;
			mainCamera.GetComponent<MouseLook>().cutSceneOn = true;
			
			// Deactivates puzzle
			mainCamera.GetComponent<puzzleScript>().keypadPuzzle = false;
			mainCamera.GetComponent<userInterface>().inventoryOn = true;*/

			// Puzzle mode toggle
			puzzleMode();

			// Toggles the puzzle to be complete
			puzzleComplete = true;

			// Call puzzle reset
			resetNumbers();
		}
	}

	// Update is called once per frame
	void OnGUI () {

		if (keypadPuzzle == true) {

			//GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), puzzleBackground);

			// Displays the first input number
			if (numberOne) {
				GUI.Button(new Rect(rowWidth-buttonWidth-5, rowHeight-buttonHeight-buttonHeight-40, buttonWidth, buttonHeight), "3");
			}

			// Displays the second input number
			if (numberTwo) {
				GUI.Button(new Rect(rowWidth, rowHeight-buttonHeight-buttonHeight-40, buttonWidth, buttonHeight), "9");
			}

			// Displays the second input number
			if (numberThree) {
				GUI.Button(new Rect(rowWidth+buttonWidth+5, rowHeight-buttonHeight-buttonHeight-40, buttonWidth, buttonHeight), "4");
			}

			// ---- FIRST ROW ----

			if (GUI.Button(new Rect(rowWidth-buttonWidth-5, rowHeight-buttonHeight-5, buttonWidth, buttonHeight), "1")) {

				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().errorSound = true;

				// Call puzzle reset
				resetNumbers();
			}

			if (GUI.Button(new Rect(rowWidth, rowHeight-buttonHeight-5, buttonWidth, buttonHeight), "2")) {

				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().errorSound = true;

				// Call puzzle reset
				resetNumbers();
			}

			if (GUI.Button(new Rect(rowWidth+buttonWidth+5, rowHeight-buttonHeight-5, buttonWidth, buttonHeight), "3")) {

				// Checks if correct number has been pressed
				if (numberOne == false) {

					// Play sound effect when clicking button
					player.GetComponent<soundEffects>().keypadSound = true;

					// Toggles the value on
					numberOne = true;
				
				} else {

					// Play sound effect when clicking button
					player.GetComponent<soundEffects>().errorSound = true;

					// Call puzzle reset
					resetNumbers();
				}
			}

			// ---- SECOND ROW ----

			if (GUI.Button(new Rect(rowWidth-buttonWidth-5, rowHeight, buttonWidth, buttonHeight), "4")) {

				// Checks if correct number has been pressed
				if (numberOne == true && numberTwo == true && numberThree == false) {
					
					// Play sound effect when clicking button
					player.GetComponent<soundEffects>().successSound = true;
					
					// Toggles the value on
					numberThree = true;
					
				} else {
					
					// Play sound effect when clicking button
					player.GetComponent<soundEffects>().errorSound = true;
					
					// Call puzzle reset
					resetNumbers();
				}
			}

			if (GUI.Button(new Rect(rowWidth, rowHeight, buttonWidth, buttonHeight), "5")) {

				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().errorSound = true;

				// Call puzzle reset
				resetNumbers();
			}

			if (GUI.Button(new Rect(rowWidth+buttonWidth+5, rowHeight, buttonWidth, buttonHeight), "6")) {

				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().errorSound = true;

				// Call puzzle reset
				resetNumbers();
			}

			// ---- THIRD ROW ----

			if (GUI.Button(new Rect(rowWidth-buttonWidth-5, rowHeight+buttonHeight+5, buttonWidth, buttonHeight), "7")) {

				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().errorSound = true;

				// Call puzzle reset
				resetNumbers();
			}

			if (GUI.Button(new Rect(rowWidth, rowHeight+buttonHeight+5, buttonWidth, buttonHeight), "8")) {

				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().errorSound = true;

				// Call puzzle reset
				resetNumbers();
			}

			if (GUI.Button(new Rect(rowWidth+buttonWidth+5, rowHeight+buttonHeight+5, buttonWidth, buttonHeight), "9")) {

				// Checks if correct number has been pressed
				if (numberOne == true && numberTwo == false) {
					
					// Play sound effect when clicking button
					player.GetComponent<soundEffects>().keypadSound = true;
					
					// Toggles the value on
					numberTwo = true;
					
				} else {
					
					// Play sound effect when clicking button
					player.GetComponent<soundEffects>().errorSound = true;
					
					// Call puzzle reset
					resetNumbers();
				}
			}

			// ---- END ----

			// Cancel button to end the puzzle
			if (GUI.Button(new Rect(rowWidth-buttonWidth-5, rowHeight+2*(buttonHeight)+10, 3*(buttonWidth)+10, buttonHeight), "Cancel")) {

				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				/*
				player.GetComponent<MouseLook>().cutSceneOn = true;
				mainCamera.GetComponent<MouseLook>().cutSceneOn = true;
				

				mainCamera.GetComponent<puzzleScript>().keypadPuzzle = false;
				mainCamera.GetComponent<userInterface>().inventoryOn = true;*/

				// Puzzle mode toggle
				puzzleMode();

				// Call puzzle reset
				resetNumbers();
			}

		}
	}

	// Toggles mode on/off
	void puzzleMode () {

		// Toggles movement system back on
		player.GetComponent<MouseLook>().cutSceneOn = !player.GetComponent<MouseLook>().cutSceneOn;
		mainCamera.GetComponent<MouseLook>().cutSceneOn = !mainCamera.GetComponent<MouseLook>().cutSceneOn;

		// Deactivates puzzle
		mainCamera.GetComponent<puzzleScript>().keypadPuzzle = !mainCamera.GetComponent<puzzleScript>().keypadPuzzle;
		mainCamera.GetComponent<userInterface>().inventoryOn = !mainCamera.GetComponent<userInterface>().inventoryOn;
	}

	// Reset the puzzle
	void resetNumbers () {
		numberOne = false;
		numberTwo = false;
		numberThree = false;
	}
}
