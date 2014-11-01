﻿using UnityEngine;
using System.Collections;

public class userInterface : MonoBehaviour {

	// Bool used to determine when to draw the texture on the screen
	//private bool DrawGUI = false;
	//public bool inventoryOpen;
	public bool inventoryOn;

	// Variables used to store the images for the UI
	public Texture2D uiBar;
	public Texture2D uiInteract;
	public Texture2D uiLockedDoor;
	public Texture2D uiGotItem;
	public Texture2D uiCloseNote;

	// Notes
	public Texture2D uiPaperNote;

	// Item icons
	public Texture2D uiBedroomKey;
	public Texture2D uiHallKey;
	public Texture2D uiKitchenKey;
	public Texture2D uiBathroomKey;
	public Texture2D uiSecretKey;

	// Item triggers
	public bool showKey;
	public bool showFirstClue;

	// Private variable for the camera
	GameObject mainCamera;
	GameObject player;

	void Start () {
		inventoryOn = true;

		// Loads the camera through the variable defined above
		mainCamera = GameObject.Find ("Main Camera");
		player = GameObject.FindWithTag ("Player");
	}

	void OnGUI () {

		// Item bar at the bottom of the screen
		if (inventoryOn == true) {
			GUI.DrawTexture (new Rect (0, Screen.width/2-15, Screen.width, 100), uiBar);

			// <---- ITEMS ---->

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

			// <---- END ---->
		}

		// Checks, through the Raycast script, when the player is close to an object and is also looking at it
		// The message does not show up when the inventory is open
		if (mainCamera.GetComponent<Raycast>().imLookingAt == true) {

			// Draws the 2D texture for the message popup
			GUI.DrawTexture (new Rect (Screen.width/2-40, Screen.height/2f-10, 75, 75), uiInteract);
		}

		// Checks, through the Raycast script, when the player has picked up an object
		// The message does not show up when the inventory is open
		if (mainCamera.GetComponent<Raycast>().playerGotItem == true) {

			// Draws the 2D texture for the message popup
			GUI.DrawTexture (new Rect (Screen.width/3f-30, Screen.height/1.5f, 550, 96), uiGotItem);

			// Starts the HideUI function, which runs for a few seconds, to hide the UI element
			StartCoroutine("HideUI");
		}

		// Checks, through the Raycast script, when the player is trying to open a locked door
		// The message does not show up when the inventory is open
		if (mainCamera.GetComponent<Raycast>().doorIsLocked == true) {
			
			// Draws the 2D texture for the message popup
			GUI.DrawTexture (new Rect (Screen.width/2.5f, Screen.height/2f, 60, 92), uiLockedDoor);
			
			// Starts the HideUI function, which runs for a few seconds, to hide the UI element
			StartCoroutine("DoorLocked");
		}

		// Checks if player is reading the note
		if (player.GetComponent<items>().hasNote == true) {
			GUI.DrawTexture (new Rect (Screen.width/3f, 5, 502, 728), uiPaperNote);

			GUI.DrawTexture (new Rect (Screen.width/4.5f+15, Screen.height-105, 500, 100), uiCloseNote);
		}
	}

	// Timer function to hide the UI message
	IEnumerator HideUI () {

		// Yields after 1 seconds
		yield return new WaitForSeconds(1);

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