using UnityEngine;
using System.Collections;

public class userInterface : MonoBehaviour {

	/*
	 ***************************************************** 
	 * THIS SCRIPT HANDLES GENERAL GUI ELEMENTS THAT ARE *
	 * DISPLAY TO THE PLAYER WHILE PLAYING THE GAME!!    *
	 *****************************************************
	 */

	// Bool used to determine when to display the inventory bar
	public bool inventoryOn;
	// Variables used to store the images for the UI
	public Texture2D uiBar;
	public Texture2D uiInteract;
	public Texture2D uiLockedDoor;
	public Texture2D uiGotItem;
	public Texture2D uiPromptClose;
	// Item icons
	public Texture2D uiBedroomKey, uiHallKey, uiKitchenKey, uiBathroomKey, uiSecretKey, uiWireCutter;
	// Notes
	public Texture2D uiPaperNote, uiNote1;
	// Newspapers
	public Texture2D uiNewspaper1, uiNewspaper2, uiNewspaper3;
	// Hints
	public Texture2D uiHint1, uiHint2, uiHint3, uiSelfie;
	// Private variable for the player and camera object
	GameObject mainCamera;
	GameObject player;

	void Start () {
		inventoryOn = true;

		// Loads the camera through the variable defined above
		mainCamera = GameObject.Find ("Main Camera");
		player = GameObject.Find ("Player");
	}

	void OnGUI () {

		/* ----------
			ITEM BAR
		   ---------- */

		if (inventoryOn == true) {
			//GUI.DrawTexture (new Rect (0, Screen.width/2-15, Screen.width, 100), uiBar);

			/* ------------
				ITEM ICONS
			   ------------ */

			// Checks if player has the item
			if (player.GetComponent<items>().hasBedroomKey == true) {
				GUI.DrawTexture (new Rect (Screen.width/60, Screen.height/1.13f, 90, 73), uiBedroomKey);
			}

			// Checks if player has the item
			if (player.GetComponent<items>().hasHallKey == true) {
				GUI.DrawTexture (new Rect (Screen.width/10, Screen.height/1.13f, 60, 73), uiHallKey);
			}

			// Checks if player has the item
			if (player.GetComponent<items>().hasKitchenKey == true) {
				GUI.DrawTexture (new Rect (Screen.width/6, Screen.height/1.13f, 60, 73), uiKitchenKey);
			}

			// Checks if player has the item
			if (player.GetComponent<items>().hasLivingRoomKey == true) {
				GUI.DrawTexture (new Rect (Screen.width/4.25f, Screen.height/1.13f, 60, 73), uiBathroomKey);
			}

			// Checks if player has the item
			if (player.GetComponent<items>().hasSecretKey == true) {
				GUI.DrawTexture (new Rect (Screen.width/3.25f, Screen.height/1.13f, 60, 73), uiSecretKey);
			}

			// Checks if player has the item
			if (player.GetComponent<items>().hasWireCutter == true) {
				GUI.DrawTexture (new Rect (Screen.width/1f-105, Screen.height/1.13f+8, 90, 66), uiWireCutter);
			}

			/* -----------
				END ICONS
			   ----------- */
		}

		/* ---------
			END BAR
	       --------- */

		// Checks, through the Raycast script, when the player is close to an object and is also looking at it
		// The message does not show up when the inventory is open
		if (mainCamera.GetComponent<Raycast>().imLookingAt == true) {

			// Draws the 2D texture for the message popup
			GUI.DrawTexture (new Rect (Screen.width/2, Screen.height/2f, 50, 50), uiInteract);
		}

		// Checks, through the Raycast script, when the player has picked up an object
		// The message does not show up when the inventory is open
		/*if (mainCamera.GetComponent<Raycast>().playerGotItem == true) {

			// Draws the 2D texture for the message popup
			GUI.DrawTexture (new Rect (Screen.width/2.5f-50, Screen.height/1.5f, 275, 48), uiGotItem);

			// Starts the HideUI function, which runs for a few seconds, to hide the UI element
			StartCoroutine("HideUI");
		}*/

		// Checks, through the Raycast script, when the player is trying to open a locked door
		// The message does not show up when the inventory is open
		if (mainCamera.GetComponent<Raycast>().doorIsLocked == true) {
			
			// Draws the 2D texture for the message popup
			GUI.DrawTexture (new Rect (Screen.width/2.5f, Screen.height/2f, 65, 87), uiLockedDoor);
			
			// Starts the HideUI function, which runs for a few seconds, to hide the UI element
			StartCoroutine("DoorLocked");
		}

		/* ---------------
			BUTTON PROMPT
		   --------------- */

		if (mainCamera.GetComponent<Raycast>().uiPrompt == true) {
			GUI.DrawTexture (new Rect (Screen.width/1.4f, Screen.height-100, 160, 50), uiPromptClose);
		}

		/* ------------------
			READABLE OBJECTS
		   ------------------ */

		// Checks if player is reading the note on the first door
		if (player.GetComponent<items>().hasNote == true) {
			GUI.DrawTexture (new Rect (Screen.width/3f, 5, 502, 728), uiPaperNote);
		}

		// Checks if player is reading the note attached to the hall key
		if (player.GetComponent<items>().hasFirstNote == true) {
			GUI.DrawTexture (new Rect (Screen.width/3f, 5, 502, 728), uiNote1);
		}

		// Checks if player is reading the note attached to the hall key
		if (player.GetComponent<items>().hasSelfie == true) {
			GUI.DrawTexture (new Rect (Screen.width/4f-35, Screen.height/6f, 825, 475), uiSelfie);
		}

		// Checks if player is reading the first newspaper
		if (player.GetComponent<items>().readFirstNewspaper == true) {
			GUI.DrawTexture (new Rect (Screen.width/4f, 5, 774, 600), uiNewspaper1);
		}

		// Checks if player is reading the second newspaper
		if (player.GetComponent<items>().readSecondNewspaper == true) {
			GUI.DrawTexture (new Rect (Screen.width/4f, 5, 770, 597), uiNewspaper2);
		}

		// Checks if player is reading the third newspaper
		if (player.GetComponent<items>().readThirdNewspaper == true) {
			GUI.DrawTexture (new Rect (Screen.width/4f, 5, 766, 594), uiNewspaper3);
		}

		// Checks if player is reading the first hint
		if (player.GetComponent<items>().readHint1 == true) {
			GUI.DrawTexture (new Rect (Screen.width/3f, Screen.height/2.5f, 512, 128), uiHint1);
		}

		// Checks if player is reading the second hint
		if (player.GetComponent<items>().readHint2 == true) {
			GUI.DrawTexture (new Rect (Screen.width/3f, Screen.height/2.5f, 512, 128), uiHint2);
		}

		// Checks if player is reading the third hint
		if (player.GetComponent<items>().readHint3 == true) {
			GUI.DrawTexture (new Rect (Screen.width/3f, Screen.height/2.5f, 512, 128), uiHint3);
		}

		/* --------------
			END READABLE
		   -------------- */
	}

	// Timer function to hide the UI message
	IEnumerator HideUI () {

		// Yields after 2 seconds
		yield return new WaitForSeconds(2);

		// Sets the bool back to false when the timer is up
		mainCamera.GetComponent<Raycast>().playerGotItem = false;
	}

	// Timer function to hide the lock icon
	IEnumerator DoorLocked () {
		
		// Yields after 0.5 seconds
		yield return new WaitForSeconds(0.5f);
		
		// Sets the bool back to false when the timer is up
		mainCamera.GetComponent<Raycast>().doorIsLocked = false;
	}
}