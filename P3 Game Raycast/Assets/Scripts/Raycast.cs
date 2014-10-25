using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	// Distance, and object interaction variables, for the Raycast
	public float distance;
	RaycastHit objectHit;

	// Bools used for UI related scenarios
	public bool imLookingAt;
	public bool playerGotItem;

	// Private variable for the player object
	GameObject player;

	void Start () {

		// Defines the player object for the created variable at the top of the script
		player = GameObject.FindWithTag ("Player");

		// There should probably be a line here to make the player object ignore the Raycast
	}

	void Update () {

		// Physical representation of the Raycast for testing purposes
		Debug.DrawRay (this.transform.position, this.transform.forward * distance, Color.magenta);

		// The raycast itself. Starts from the camera and runs out as defined by the distance variable
		// Furthermore, the Raycast ignores objects tagged as "Player" and as "Ground"
		if (Physics.Raycast (this.transform.position, this.transform.forward, out objectHit, distance) && objectHit.collider.gameObject.tag != "Player" && objectHit.collider.gameObject.tag != "Ground" && objectHit.collider.gameObject.tag != "Static") {

			imLookingAt = true;

			// Outputs a debug message to indicate what object you collided with
			Debug.Log ("Object: "+objectHit.collider.gameObject.name);

			// Runs if the player presses E while near an object
			if (Input.GetKeyDown (KeyCode.E)) {

				imLookingAt = false;

				// Outputs a message to indicate what item you picked up
				Debug.Log ("Received: "+objectHit.collider.gameObject.name);

				// Checks if the object you collide with is tagged as a "Keys"
				// This script can be modified to be used for any type of item so long as the respective scripts connected to it are modified as well
				// A tag should also be created for the other specific items that are made
				if (objectHit.collider.tag == "Keys") {

					playerGotItem = true;

					// Checks if the object you collide with is the key type labeled "normalKey"
					if (objectHit.collider.gameObject.GetComponent<keys>().whatTypeKey == keys.Keys.normalKey) {

						// Toggles the bool, from the item script, to true when item is picked up
						player.GetComponent<items>().hasNormalKey = true;

						// Toggles bool to true, which is used for sound effects
						GameObject.Find ("Player").GetComponent<soundEffects>().gotKey = true;

						// Destroys the object that you interacted with
						Destroy (objectHit.collider.gameObject);
					}
				}

				// Checks if the object you collide with is tagged as a "Doors"
				if (objectHit.collider.tag == "Doors") {
					
					// Checks if the object you collide with is the door type labeled "lockedDoor"
					// These are the doors that require keys to open, loaded from the inventory script
					if (objectHit.collider.gameObject.GetComponent<doors>().whatTypeDoor == doors.Doors.lockedDoor) {
						
						// Checks, through the items script, if the player has the required key to open this door
						if (player.GetComponent<items>().hasNormalKey == true) {

							// Removes the item from your inventory
							player.GetComponent<items>().hasNormalKey = false;

							// Toggles bool to true, which is used for sound effects
							GameObject.Find ("Player").GetComponent<soundEffects>().openDoor = true;

							// There should be a script here which changes the tag of the door to "unlockedDoor"

							// <---- ANIMATION GOES HERE ---->

							// For now, just destroy the door until the animation has been created and implemented
							Destroy (objectHit.collider.gameObject);

						// If required object isn't in your inventory
						} else {

							// <---- GUI MESSAGE GOES HERE ---->

							// For now, outputs a debug message until GUI elements have been created and implemented
							Debug.Log ("This door requires a key!");
						}
					}

					// Checks if the object you collide with is the door type labeled "normalDoor"
					// These are the doors that don't require a key to open
					if (objectHit.collider.gameObject.GetComponent<doors>().whatTypeDoor == doors.Doors.normalDoor) {

						// Toggles bool to true, which is used for sound effects
						GameObject.Find ("Player").GetComponent<soundEffects>().openDoor = true;

						// <---- ANIMATION GOES HERE ---->

						// For now, just destroy the door until the animation has been created and implemented
						Destroy (objectHit.collider.gameObject);
					}

					// Checks if the object you collide with is the door type labeled "unlockedDoor"
					// These are the doors that have been unlocked by a key
					if (objectHit.collider.gameObject.GetComponent<doors>().whatTypeDoor == doors.Doors.unlockedDoor) {

						// Toggles bool to true, which is used for sound effects
						GameObject.Find ("Player").GetComponent<soundEffects>().openDoor = true;

						// <---- ANIMATION GOES HERE ---->
						
						// For now, just destroy the door until the animation has been created and implemented
						Destroy (objectHit.collider.gameObject);
					}
				}

			}

		// If the player is not looking at the object, then it toggles the bool off
		} else {

			// Sets the bool to false so that the UI element is no longer drawn on the screen
			imLookingAt = false;
		}
	}
}