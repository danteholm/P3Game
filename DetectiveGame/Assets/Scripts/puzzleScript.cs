using UnityEngine;
using System.Collections;

public class puzzleScript : MonoBehaviour {

	// Bool used to determine when a puzzle is active, or complete
	public bool keypadPuzzle = false;
	public bool puzzleComplete = false;

	// Graphics for puzzles
	public Texture2D puzzleBackground;
	public Texture2D uiKeypad;

	// Font for input field
	public Font Digital;

	// Sizes for the keypad buttons
	private float buttonWidth = 85;
	private float buttonHeight = 75;

	// Positioning of the keypad buttons
	private float rowWidth = Screen.width/2.25f;
	private float rowHeight = Screen.height/2.25f;

	// Private variable for the player object
	GameObject player;
	GameObject mainCamera;

	// Integers for the password input
	private int inputOne;
	private int inputTwo;
	private int inputThree;

	// Bools to determine when the numbers have been set
	private bool inputOneSet = false;
	private bool inputTwoSet = false;
	private bool inputThreeSet = false;

	// Integers for the correct numbers
	private int firstNumber = 3;
	private int secondNumber = 9;
	private int thirdNumber = 4;

	void Start () {

		// Defines the player object for the created variable at the top of the script
		player = GameObject.FindWithTag ("Player");
		mainCamera = GameObject.Find ("Main Camera");
	}

	// Submit function for the keypad
	void Submit () {

		// Runs a check on the numbers input
		if (inputOne == firstNumber && inputTwo == secondNumber && inputThree == thirdNumber) {

			// Toogle bool on to play sound effect
			player.GetComponent<soundEffects>().successSound = true;
			player.GetComponent<soundEffects>().bookcaseMoving = true;

			// Puzzle mode toggle
			puzzleMode();

			// Toggles the puzzle to be complete
			puzzleComplete = true;

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


		if (keypadPuzzle == true) {

			//GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), puzzleBackground);
			GUI.DrawTexture (new Rect (Screen.width/3f-15, Screen.height/6.5f, 500, 500), uiKeypad);

			GUI.Button(new Rect(rowWidth-buttonWidth-5, rowHeight-buttonHeight-buttonHeight-40, 3*(buttonWidth)+10, buttonHeight), "", inputStyle);

			// Displays the first input number
			if (inputOneSet) {
				GUI.Label(new Rect(rowWidth-50, rowHeight-2*(buttonHeight)-15, buttonWidth, buttonHeight), inputOne.ToString(), inputStyle);
			}

			// Displays the second input number
			if (inputTwoSet) {
				GUI.Label(new Rect(rowWidth, rowHeight-2*(buttonHeight)-15, buttonWidth, buttonHeight), inputTwo.ToString(), inputStyle);
			}

			// Displays the third input number
			if (inputThreeSet) {
				GUI.Label(new Rect(rowWidth+50, rowHeight-2*(buttonHeight)-15, buttonWidth, buttonHeight), inputThree.ToString(), inputStyle);
			}

			// ---- FIRST ROW ----

			// '1' button
			if (GUI.Button(new Rect(rowWidth-buttonWidth+25, rowHeight-buttonHeight-15, buttonWidth, buttonHeight), "", GUIStyle.none)) {

				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				// Checks what # of input it is
				if (inputOneSet == false) {
					
					inputOne = 1;
					inputOneSet = true;
					
				} else if (inputOneSet == true && inputTwoSet == false) {

					inputTwo = 1;
					inputTwoSet = true;
					
				} else if (inputTwoSet == true && inputThreeSet == false) {

					inputThree = 1;
					inputThreeSet = true;
					
				}
			}

			// '2' button
			if (GUI.Button(new Rect(rowWidth+35, rowHeight-buttonHeight-15, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				// Checks what # of input it is
				if (inputOneSet == false) {
					
					inputOne = 2;
					inputOneSet = true;
					
				} else if (inputOneSet == true && inputTwoSet == false) {
					
					inputTwo = 2;
					inputTwoSet = true;
					
				} else if (inputTwoSet == true && inputThreeSet == false) {
					
					inputThree = 2;
					inputThreeSet = true;
					
				}
			}

			// '3' button
			if (GUI.Button(new Rect(rowWidth+buttonWidth+45, rowHeight-buttonHeight-15, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				// Checks what # of input it is
				if (inputOneSet == false) {
					
					inputOne = 3;
					inputOneSet = true;
					
				} else if (inputOneSet == true && inputTwoSet == false) {
					
					inputTwo = 3;
					inputTwoSet = true;
					
				} else if (inputTwoSet == true && inputThreeSet == false) {
					
					inputThree = 3;
					inputThreeSet = true;
					
				} 
			}

			// ---- SECOND ROW ----

			// '4' button
			if (GUI.Button(new Rect(rowWidth-buttonWidth+25, rowHeight-5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				// Checks what # of input it is
				if (inputOneSet == false) {
					
					inputOne = 4;
					inputOneSet = true;
					
				} else if (inputOneSet == true && inputTwoSet == false) {
					
					inputTwo = 4;
					inputTwoSet = true;
					
				} else if (inputTwoSet == true && inputThreeSet == false) {
					
					inputThree = 4;
					inputThreeSet = true;
	
				}
			}

			// '5' button
			if (GUI.Button(new Rect(rowWidth+35, rowHeight-5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;
				
				// Checks what # of input it is
				if (inputOneSet == false) {
					
					inputOne = 5;
					inputOneSet = true;
					
				} else if (inputOneSet == true && inputTwoSet == false) {
					
					inputTwo = 5;
					inputTwoSet = true;
					
				} else if (inputTwoSet == true && inputThreeSet == false) {
					
					inputThree = 5;
					inputThreeSet = true;
					
				}
			}

			// '6' button
			if (GUI.Button(new Rect(rowWidth+buttonWidth+45, rowHeight-5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				// Checks what # of input it is
				if (inputOneSet == false) {
					
					inputOne = 6;
					inputOneSet = true;
					
				} else if (inputOneSet == true && inputTwoSet == false) {
					
					inputTwo = 6;
					inputTwoSet = true;
					
				} else if (inputTwoSet == true && inputThreeSet == false) {
					
					inputThree = 6;
					inputThreeSet = true;
					
				}
			}

			// ---- THIRD ROW ----

			// '7' button
			if (GUI.Button(new Rect(rowWidth-buttonWidth+25, rowHeight+buttonHeight+5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				// Checks what # of input it is
				if (inputOneSet == false) {
					
					inputOne = 7;
					inputOneSet = true;
					
				} else if (inputOneSet == true && inputTwoSet == false) {
					
					inputTwo = 7;
					inputTwoSet = true;
					
				} else if (inputTwoSet == true && inputThreeSet == false) {
					
					inputThree = 7;
					inputThreeSet = true;
					
				}
			}

			// '8' button
			if (GUI.Button(new Rect(rowWidth+35, rowHeight+buttonHeight+5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				// Checks what # of input it is
				if (inputOneSet == false) {
					
					inputOne = 8;
					inputOneSet = true;
					
				} else if (inputOneSet == true && inputTwoSet == false) {
					
					inputTwo = 8;
					inputTwoSet = true;
					
				} else if (inputTwoSet == true && inputThreeSet == false) {
					
					inputThree = 8;
					inputThreeSet = true;
					
				}
			}

			// '9' button
			if (GUI.Button(new Rect(rowWidth+buttonWidth+45, rowHeight+buttonHeight+5, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				// Checks what # of input it is
				if (inputOneSet == false) {
					
					inputOne = 9;
					inputOneSet = true;
					
				} else if (inputOneSet == true && inputTwoSet == false) {
					
					inputTwo = 9;
					inputTwoSet = true;
					
				} else if (inputTwoSet == true && inputThreeSet == false) {
					
					inputThree = 9;
					inputThreeSet = true;
					
				}
			}

			// ---- FOURTH ROW ----

			// 'X' button to end the puzzle
			if (GUI.Button(new Rect(rowWidth-buttonWidth+25, rowHeight+2*(buttonHeight)+15, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;
				
				// Puzzle mode toggle
				puzzleMode();
				
				// Call puzzle reset
				resetNumbers();
			}

			// '0' button
			if (GUI.Button(new Rect(rowWidth+35, rowHeight+2*(buttonHeight)+15, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				// Checks what # of input it is
				if (inputOneSet == false) {
					
					inputOne = 0;
					inputOneSet = true;
					
				} else if (inputOneSet == true && inputTwoSet == false) {
					
					inputTwo = 0;
					inputTwoSet = true;
					
				} else if (inputTwoSet == true && inputThreeSet == false) {
					
					inputThree = 0;
					inputThreeSet = true;
					
				}
			}

			// 'OK' button, to submit the input code
			if (GUI.Button(new Rect(rowWidth+buttonWidth+45, rowHeight+2*(buttonHeight)+15, buttonWidth, buttonHeight), "", GUIStyle.none)) {
				
				// Play sound effect when clicking button
				player.GetComponent<soundEffects>().keypadSound = true;

				Submit();
			}

			// ---- END ----
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
		inputOne = 0;
		inputTwo = 0;
		inputThree = 0;

		inputOneSet = false;
		inputTwoSet = false;
		inputThreeSet = false;
	}

	// Timer function to hide the UI message
	IEnumerator bookcaseSound () {
		
		// Yields after 0.5 seconds
		yield return new WaitForSeconds(1);
		
		// Toggle bool for sound effect
		player.GetComponent<soundEffects>().bookcaseMoving = true;
	}
}
