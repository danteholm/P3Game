using UnityEngine;
using System.Collections;

public class userInterface : MonoBehaviour {

	// Bool used to determine when to draw the texture on the screen
	//private bool DrawGUI = false;
	public bool inventoryOpen;
	public bool inventoryOn;

	// Variables used to store the images for the UI
	public Texture2D uiInteract;
	public Texture2D uiGotItem;
	public Texture2D uiInventory;
	public Texture2D uiNormalKey;
	public Texture2D uiFirstClue;
	public Texture2D uiPaperNote;
	public Texture2D uiBar;

	// Item triggers
	public bool showKey;
	public bool showFirstClue;

	void Start () {
		inventoryOn = true;
	}

	void OnGUI () {

		// Item bar at the bottom of the screen
		if (inventoryOn == true) {
			GUI.DrawTexture (new Rect (0, Screen.width/2-15, Screen.width, 100), uiBar);

			// <---- ITEMS ---->

			// Checks if player has the key
			if (GameObject.Find("Player").GetComponent<items>().hasNormalKey == true) {
				GUI.DrawTexture (new Rect (Screen.width/60, Screen.height/1.13f, 90, 73), uiNormalKey);
			}

			// Checks if player has the paper
			if (GameObject.Find ("Player").GetComponent<items>().hasClue1 == true) {
				GUI.DrawTexture (new Rect (Screen.width/10, Screen.height/1.125f, 90, 68), uiFirstClue);
			}

			// <---- END ---->
		}


		// Runs if the player presses 'I', when the inventory is closed
		/* if (Input.GetKeyDown (KeyCode.I) && inventoryOpen == false) {

			// Toggles the inventory on after timer has finished
			StartCoroutine("InventoryOn");
		}

		// Runs if the player presses 'I', when the inventory is open
		if (inventoryOpen == true) {

			// Draws the 2D texture for the inventory screen
			GUI.DrawTexture (new Rect (Screen.width/3-150, 0, 1024, 1024), uiInventory);

			// <---- ITEMS ---->

			// Checks if player has the key
			if (GameObject.Find ("Player").GetComponent<items>().hasNormalKey == true) {
				GUI.DrawTexture (new Rect (Screen.width/4+50, Screen.height/5, 100, 100), uiNormalKey);
			}

			// Checks if player has the paper
			if (GameObject.Find ("Player").GetComponent<items>().hasClue1 == true) {
				GUI.DrawTexture (new Rect (Screen.width/4+175, Screen.height/5, 100, 100), uiNormalKey);
			}

			// <---- END ---->

			// Toggles the inventory off
			if (Input.GetKeyDown (KeyCode.I) && inventoryOpen == true) {

				// Toggles bool off after timer has finished
				StartCoroutine("InventoryOff");
			}
		} */

		// Checks, through the Raycast script, when the player is close to an object and is also looking at it
		// The message does not show up when the inventory is open
		if (GameObject.Find ("Main Camera").GetComponent<Raycast>().imLookingAt == true && inventoryOpen == false) {

			// Draws the 2D texture for the message popup
			//GUI.DrawTexture (new Rect (Screen.width/3+50, Screen.height/2+50, 512, 64), uiInteract);
			GUI.DrawTexture (new Rect (Screen.width/2-45, Screen.height/1.5f, 75, 75), uiInteract);
		}

		// Checks, through the Raycast script, when the player has picked up an object
		// The message does not show up when the inventory is open
		if (GameObject.Find ("Main Camera").GetComponent<Raycast>().playerGotItem == true && inventoryOpen == false) {

			// Draws the 2D texture for the message popup
			GUI.DrawTexture (new Rect (Screen.width/3f-25, Screen.height/1.5f, 512, 64), uiGotItem);

			// Starts the HideUI function, which runs for a few seconds, to hide the UI element
			StartCoroutine("HideUI");
		}

		// Checks if player is reading the note
		if (GameObject.Find ("Player").GetComponent<items>().hasNote == true) {
			GUI.DrawTexture (new Rect (Screen.width/3, 25, 602, 828), uiPaperNote);
		}
	}

	// Timer function
	IEnumerator HideUI () {

		// Yields after 2 seconds
		yield return new WaitForSeconds(2);

		// Sets the "playerGotItem" bool back to false when the timer is up
		GameObject.Find ("Main Camera").GetComponent<Raycast>().playerGotItem = false;
	}

	// Timer function used for when opening inventory
	IEnumerator InventoryOn () {
		
		// Yields after 0.1 seconds
		yield return new WaitForSeconds(0.1f);
		
		// Sets the "inventoryOpen" bool to true when the timer is up
		inventoryOpen = true;
	}

	// Timer function used for when closing inventory
	IEnumerator InventoryOff () {
		
		// Yields after 0.1 seconds
		yield return new WaitForSeconds(0.1f);
		
		// Sets the "inventoryOpen" bool back to false when the timer is up
		inventoryOpen = false;
	}
}