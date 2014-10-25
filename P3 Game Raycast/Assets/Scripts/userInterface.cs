﻿using UnityEngine;
using System.Collections;

public class userInterface : MonoBehaviour {

	// Bool used to determine when to draw the texture on the screen
	//private bool DrawGUI = false;
	private bool inventoryOpen;

	// Variables used to store the images for the UI
	public Texture2D uiInteract;
	public Texture2D uiGotItem;
	public Texture2D uiInventory;

	void OnGUI () {

		// Runs if the player presses 'I', when the inventory is closed
		if (Input.GetKeyDown (KeyCode.I) && inventoryOpen == false) {

			// Toggles the inventory on after timer has finished
			StartCoroutine("InventoryOn");
		}

		// Runs if the player presses 'I', when the inventory is open
		if (inventoryOpen == true) {

			// Draws the 2D texture for the inventory screen
			GUI.DrawTexture (new Rect (Screen.width/3-150, 0, 1024, 1024), uiInventory);

			// Toggles the inventory off
			if (Input.GetKeyDown (KeyCode.I) && inventoryOpen == true) {

				// Toggles bool off after timer has finished
				StartCoroutine("InventoryOff");
			}
		}

		// Checks, through the Raycast script, when the player is close to an object and is also looking at it
		if (GameObject.Find ("Main Camera").GetComponent<Raycast>().imLookingAt == true) {

			// Draws the 2D texture for the message popup
			GUI.DrawTexture (new Rect (Screen.width/3+50, Screen.height/2+50, 512, 64), uiInteract);
		}

		// Checks, through the Raycast script, when the player has picked up an object
		if (GameObject.Find ("Main Camera").GetComponent<Raycast>().playerGotItem == true) {

			// Draws the 2D texture for the message popup
			GUI.DrawTexture (new Rect (Screen.width/3+50, Screen.height/2+50, 512, 64), uiGotItem);

			// Starts the HideUI function, which runs for a few seconds, to hide the UI element
			StartCoroutine("HideUI");
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