using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	// Distance, and object interaction variables, for the Raycast
	public float distance;
	RaycastHit objectHit;

	// Bools used for UI related scenarios
	public bool imLookingAt;
	public bool playerGotItem;
	public bool doorIsLocked;

	// Private variable for the player object
	GameObject player;
	GameObject mainCamera;

	// Bools to control the doors
	bool bedroomDoorClosed = true;
	bool kitchenDoor1Closed = true;
	bool kitchenDoor2Closed = true;
	bool bathroomDoorClosed = true;
	bool livingRoomDoorClosed = true;
	bool officeDoorClosed = true;

	void Start () {

		// Defines the player object for the created variable at the top of the script
		player = GameObject.FindWithTag ("Player");
		mainCamera = GameObject.Find ("Main Camera");
	}

	void Update () {

		// Physical representation of the Raycast for testing purposes
		Debug.DrawRay (this.transform.position, this.transform.forward * distance, Color.magenta);

		// The raycast itself. Starts from the camera and runs out as defined by the distance variable
		// Furthermore, the Raycast ignores objects tagged as "Player" and as "Ground"
		if (Physics.Raycast (this.transform.position, this.transform.forward, out objectHit, distance) && objectHit.collider.gameObject.tag != "Player" && objectHit.collider.gameObject.tag != "Untagged") {

			// Only runs if the inventory is activated
			if (mainCamera.GetComponent<userInterface>().inventoryOn == true) {

				// Toggles the interact button when near interactive objects
				imLookingAt = true;

				// Outputs a debug message to indicate what object you collided with
				Debug.Log ("Object: "+objectHit.collider.gameObject.name);

				// Runs if the player presses E while near an object
				if (Input.GetKeyDown (KeyCode.E)) {

					imLookingAt = false;

					// Outputs a message to indicate what item you picked up
					//Debug.Log ("Received: "+objectHit.collider.gameObject.name);

					// Checks if the object you collide with is tagged as "Keys", "Items" or "Paper"
					// This script can be modified to be used for any type of item so long as the respective scripts connected to it are modified as well
					// A tag should also be created for the other specific items that are made
					if (objectHit.collider.tag == "Keys" || objectHit.collider.tag == "Item" || objectHit.collider.tag == "Paper") {

						playerGotItem = true;

						// Checks if the object you collide with is the key type labeled "bedroomKey"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.bedroomKey) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasBedroomKey = true;
							player.GetComponent<items>().hasNote = true;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().gotKey = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
						}
						
						// Checks if the object you collide with is the key type labeled "KitchenKey"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.kitchenKey) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasKitchenKey = true;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().gotKey = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
						}
						
						// Checks if the object you collide with is the key type labeled "SecretKey"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.secretKey) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasSecretKey = true;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().gotKey = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
							
						}
						
						// Checks if the object you collide with is the key type labeled "HallKey"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.hallKey) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasHallKey = true;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().gotKey = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
						}
						
						// Checks if the object you collide with is the key type labeled "livingRoomKey"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.livingRoomKey) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasLivingRoomKey = true;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().gotKey = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
						}
						
						// Checks if the object you collide with is the item type labeled "paperNote"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeItem == objectManager.Misc.paperNote) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasNote = true;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().gotPaper = true;
						}
						
						// Checks if the object you collide with is the item type labeled "firstClue"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeItem == objectManager.Misc.firstClue) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasClue1 = true;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().gotPaper = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
						}
					}

					// Checks if the object you collide with is tagged as a "Doors"
					if (objectHit.collider.tag == "Doors") {

						// Checks if the object you collide with is the door type labeled "bedroomDoor"
						// This door requires a key to open, loaded from the inventory script
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.bedroomDoor) {
							
							// Checks, through the items script, if the player has the required key to open this door
							if (player.GetComponent<items>().hasBedroomKey == true) {

								// Runs if the door is closed
								if (bedroomDoorClosed) {

									// Toggles bool to true, which is used for sound effects
									player.GetComponent<soundEffects>().openDoor = true;
									player.GetComponent<soundEffects>().activeTik = true;
									
									// Plays the animation to open door
									GameObject.Find("bedroomDoor").animation.Play("open");
									
									// Starts the timer
									mainCamera.GetComponent<timer>().timerOn = true;

									// Toggles bool
									bedroomDoorClosed = !bedroomDoorClosed;
								}
								
							// If required object isn't in your inventory
							} else {
								
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
								
								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().doorIsLocked = true;
								
								// For now, outputs a debug message until GUI elements have been created and implemented
								Debug.Log ("This door requires a key!");
							}
						}
						
						// Checks if the object you collide with is the door type labeled "kitchenDoor1"
						// This door requires a key to open, loaded from the inventory script
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.kitchenDoor1) {

							// Checks, through the items script, if the player has the required key to open this door
							if (player.GetComponent<items>().hasHallKey == true) {

								// Runs if the door is closed
								if (kitchenDoor1Closed) {

									// Toggles bool to true, which is used for sound effects
									player.GetComponent<soundEffects>().openDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("kitchenDoor1").animation.Play("open");

									// Toggles bool
									kitchenDoor1Closed = !kitchenDoor1Closed;

								// If the door is not closed
								} else {
									
									// Toggles bool to true, which is used for sound effects
									player.GetComponent<soundEffects>().closeDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("kitchenDoor1").animation.Play("close");
									
									// Toggles bool
									kitchenDoor1Closed = !kitchenDoor1Closed;
								}
									
							// If required object isn't in your inventory
							} else {
									
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
									
								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().doorIsLocked = true;
									
								// For now, outputs a debug message until GUI elements have been created and implemented
								Debug.Log ("This door requires a key!");
							}
						}

						// Checks if the object you collide with is the door type labeled "kitchenDoor2"
						// This door requires a key to open, loaded from the inventory script
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.kitchenDoor2) {
							
							// Checks, through the items script, if the player has the required key to open this door
							if (player.GetComponent<items>().hasKitchenKey == true) {

								// Runs if the door is closed
								if (kitchenDoor2Closed) {
								
									// Toggles bool to true, which is used for sound effects
									player.GetComponent<soundEffects>().openDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("kitchenDoor2").animation.Play("open");

									// Toggles bool
									kitchenDoor2Closed = !kitchenDoor2Closed;
								
								// If the door is not closed
								} else {
									
									// Toggles bool to true, which is used for sound effects
									player.GetComponent<soundEffects>().closeDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("kitchenDoor2").animation.Play("close");
									
									// Toggles bool
									kitchenDoor2Closed = !kitchenDoor2Closed;
								}
								
							// If required object isn't in your inventory
							} else {
								
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
								
								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().doorIsLocked = true;
								
								// For now, outputs a debug message until GUI elements have been created and implemented
								Debug.Log ("This door requires a key!");
							}
						}

						// Checks if the object you collide with is the door type labeled "bathroomDoor"
						// This door requires a key to open, loaded from the inventory script
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.bathroomDoor) {
							
							// Checks, through the items script, if the player has the required key to open this door
							if (player.GetComponent<items>().hasLivingRoomKey == true) {

								// Runs if the door is closed
								if (bathroomDoorClosed) {
								
									// Toggles bool to true, which is used for sound effects
									player.GetComponent<soundEffects>().openDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("bathroomDoor").animation.Play("open");

									// Toggles bool
									bathroomDoorClosed = !bathroomDoorClosed;
								
								// If the door is not closed
								} else {
									
									// Toggles bool to true, which is used for sound effects
									player.GetComponent<soundEffects>().closeDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("bathroomDoor").animation.Play("close");
									
									// Toggles bool
									bathroomDoorClosed = !bathroomDoorClosed;
								}
								
							// If required object isn't in your inventory
							} else {
								
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
								
								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().doorIsLocked = true;
								
								// For now, outputs a debug message until GUI elements have been created and implemented
								Debug.Log ("This door requires a key!");
							}
						}

						// Checks if the object you collide with is the door type labeled "livingRoomDoor"
						// This door requires a key to open, loaded from the inventory script
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.livingRoomDoor) {
							
							// Checks, through the items script, if the player has the required key to open this door
							if (player.GetComponent<items>().hasKitchenKey == true) {

								// Runs if the door is closed
								if (livingRoomDoorClosed) {

									// Toggles bool to true, which is used for sound effects
									player.GetComponent<soundEffects>().openDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("livingroomDoor").animation.Play("open");

									// Toggles bool
									livingRoomDoorClosed = !livingRoomDoorClosed;
								
								// If the door is not closed
								} else {

									// Toggles bool to true, which is used for sound effects
									player.GetComponent<soundEffects>().closeDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("livingroomDoor").animation.Play("close");
									
									// Toggles bool
									livingRoomDoorClosed = !livingRoomDoorClosed;
								}
								
							// If required object isn't in your inventory
							} else {
								
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
								
								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().doorIsLocked = true;
								
								// For now, outputs a debug message until GUI elements have been created and implemented
								Debug.Log ("This door requires a key!");
							}
						}

						// Checks if the object you collide with is the door type labeled "officeDoor"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.officeDoor) {

							// Runs if the door is closed
							if (officeDoorClosed) {

								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().openDoor = true;
								
								// Plays the animation to open door
								GameObject.Find("officeDoor").animation.Play("open");

								// Toggles bool
								officeDoorClosed = !officeDoorClosed;
							
							// If the door is not closed
							} else {

								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().closeDoor = true;
								
								// Plays the animation to open door
								GameObject.Find("officeDoor").animation.Play("close");
								
								// Toggles bool
								officeDoorClosed = !officeDoorClosed;
							}
						}

						// Checks if the object you collide with is the door type labeled "frontDoor"
						// This door requires a key to open, loaded from the inventory script
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.frontDoor) {
							
							// Checks, through the items script, if the player has the required key to open this door
							if (player.GetComponent<items>().hasSecretKey == true) {
								
								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().openDoor = true;
								
								//load win Animation
								Application.LoadLevel ("win");
								
							// If required object isn't in your inventory
							} else {
								
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
								
								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().doorIsLocked = true;
								
								// For now, outputs a debug message until GUI elements have been created and implemented
								Debug.Log ("This door requires a key!");
							}
						}
					}

					// Checks if the object you collide with is tagged as a "Puzzle"
					if (objectHit.collider.tag == "Puzzle") {

						// Checks if the object you collide with is the door type labeled "keyPad"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatPuzzle == objectManager.Puzzle.keyPad) {

							// If the puzzle has not been solved
							if (mainCamera.GetComponent<puzzleScript>().puzzleComplete == false) {

								// Toggles off movement system so you can do puzzles
								player.GetComponent<MouseLook>().cutSceneOn = false;
								mainCamera.GetComponent<MouseLook>().cutSceneOn = false;

								// Activates puzzle
								mainCamera.GetComponent<puzzleScript>().keypadPuzzle = true;
								mainCamera.GetComponent<userInterface>().inventoryOn = false;
							
							// If the puzzle has been solved
							} else if (mainCamera.GetComponent<puzzleScript>().puzzleComplete == true) {

								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().errorSound = true;
							}
						}
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