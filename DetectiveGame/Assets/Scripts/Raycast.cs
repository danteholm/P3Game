using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	/*
	 ************************************************* 
	 * THIS SCRIPT HANDLES /ALL/ RAYCASTING AND USER *
	 * INTERACTION WITH OBJECTS IN THE GAME!!        *
	 *************************************************
	 */

	// Distance, and object interaction variables, for the Raycast
	public float distance;
	RaycastHit objectHit;
	// Bools used for UI related scenarios
	public bool imLookingAt;
	public bool playerGotItem;
	public bool doorIsLocked;
	public bool uiPrompt;
	// Private variable for the objects used for interaction
	GameObject player;
	GameObject mainCamera;
	GameObject bomb;
	GameObject keyPad;
	GameObject sounds;
	GameObject voices;
	// Bools to open and close objects
	bool bedroomDoorClosed = true;
	bool kitchenDoor1Closed = true;
	bool kitchenDoor2Closed = true;
	bool bathroomDoorClosed = true;
	bool livingRoomDoorClosed = true;
	bool officeDoorClosed = true;
	bool globusClosed = true;
	bool stoveClosed = true;
	bool bedroomTable1Closed = true;
	bool bedroomTable2Closed = true;
	bool bedroomChestClosed = true;
	bool hallwayDresserClosed = true;
	bool livingRoomChestClosed = true;
	// Bools for voice overs
	bool selfiePlayed;
	bool stovePlayed;

	void Start () {

		// Defines the player object for the created variable at the top of the script
		player = GameObject.Find ("Player");
		mainCamera = GameObject.Find ("Main Camera");
		bomb = GameObject.Find ("Old-timer bomb prefab");
		keyPad = GameObject.Find ("KeyPad");
		sounds = GameObject.Find ("SFX");
		voices = GameObject.Find ("VO");
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
				//Debug.Log ("Object: "+objectHit.collider.gameObject.name);

				// Runs if the player presses E while near an object
				if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.Mouse0)) {

					imLookingAt = false;

					// Outputs a message to indicate what item you picked up
					//Debug.Log ("Received: "+objectHit.collider.gameObject.name);

					// Checks if the object you collide with is tagged as "Keys", or "Notes"
					// This script can be modified to be used for any type of item so long as the respective scripts connected to it are modified as well
					// A tag should also be created for the other specific items that are made
					if (objectHit.collider.tag == "Keys" || objectHit.collider.tag == "Notes") {

						playerGotItem = true;

						// Checks if the object you collide with is the key type labeled "bedroomKey"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.bedroomKey) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasBedroomKey = true;
							player.GetComponent<items>().hasNote = true;

							// Shuts off all systems
							lockdown();

							// Prompt
							Prompt();
							
							// Toggles bool to true, which is used for sound effects
							sounds.GetComponent<soundEffects>().gotKey = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
						}
						
						// Checks if the object you collide with is the key type labeled "KitchenKey"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.kitchenKey) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasKitchenKey = true;
							
							// Toggles bool to true, which is used for sound effects
							sounds.GetComponent<soundEffects>().gotKey = true;

							// Camera switch turned on
							player.GetComponent<cameraSwitch>().switchCamAngle = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
						}
						
						// Checks if the object you collide with is the key type labeled "SecretKey"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.secretKey) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasSecretKey = true;
							
							// Toggles bool to true, which is used for sound effects
							sounds.GetComponent<soundEffects>().gotKey = true;

							// Toggle voice over
							voices.GetComponent<voiceOvers>().lastKey = true;

							// Camera switch turned on
							player.GetComponent<cameraSwitch>().switchCamAngle = true;

							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
							
						}
						
						// Checks if the object you collide with is the key type labeled "HallKey"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.hallKey) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasHallKey = true;
							player.GetComponent<items>().hasFirstNote = true;
							
							// Shuts off all systems
							lockdown();

							// Prompt
							Prompt();

							// Toggles bool to true, which is used for sound effects
							sounds.GetComponent<soundEffects>().gotKey = true;

							// Toggle voice over
							voices.GetComponent<voiceOvers>().secondKey = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
						}
						
						// Checks if the object you collide with is the key type labeled "livingRoomKey"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.livingRoomKey) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasLivingRoomKey = true;
							
							// Toggles bool to true, which is used for sound effects
							sounds.GetComponent<soundEffects>().gotKey = true;

							// Camera switch turned on
							player.GetComponent<cameraSwitch>().switchCamAngle = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
						}
						
						// Checks if the object you collide with is the item type labeled "paperNote"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeItem == objectManager.Items.paperNote) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasNote = true;
							
							// Toggles bool to true, which is used for sound effects
							sounds.GetComponent<soundEffects>().gotPaper = true;
						}
						
						// Checks if the object you collide with is the item type labeled "firstClue"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeItem == objectManager.Items.firstClue) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasClue1 = true;
							
							// Toggles bool to true, which is used for sound effects
							sounds.GetComponent<soundEffects>().gotPaper = true;
							
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
									sounds.GetComponent<soundEffects>().openDoor = true;
									sounds.GetComponent<soundEffects>().activeTik = true;
									
									// Plays the animation to open door
									GameObject.Find("bedroomDoor").animation.Play("open");
									
									// Starts the timer
									bomb.GetComponent<timer>().timerOn = true;

									// Toggles bool
									bedroomDoorClosed = !bedroomDoorClosed;

									// Camera switch turned on
									player.GetComponent<cameraSwitch>().switchCamAngle = true;
								}
								
							// If required object isn't in your inventory
							} else {
								
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().doorIsLocked = true;
								
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
									sounds.GetComponent<soundEffects>().openDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("kitchenDoor1").animation.Play("open");

									// Toggles bool
									kitchenDoor1Closed = !kitchenDoor1Closed;

									// Camera switch turned on
									player.GetComponent<cameraSwitch>().switchCamAngle = true;

								// If the door is not closed
								} else {
									
									// Toggles bool to true, which is used for sound effects
									sounds.GetComponent<soundEffects>().closeDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("kitchenDoor1").animation.Play("close");
									
									// Toggles bool
									kitchenDoor1Closed = !kitchenDoor1Closed;

									// Camera switch turned on
									player.GetComponent<cameraSwitch>().switchCamAngle = true;
								}
									
							// If required object isn't in your inventory
							} else {
									
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
									
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().doorIsLocked = true;
									
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
									sounds.GetComponent<soundEffects>().openDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("kitchenDoor2").animation.Play("open");

									// Toggles bool
									kitchenDoor2Closed = !kitchenDoor2Closed;

									// Camera switch turned on
									player.GetComponent<cameraSwitch>().switchCamAngle = true;
								
								// If the door is not closed
								} else {
									
									// Toggles bool to true, which is used for sound effects
									sounds.GetComponent<soundEffects>().closeDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("kitchenDoor2").animation.Play("close");
									
									// Toggles bool
									kitchenDoor2Closed = !kitchenDoor2Closed;

									// Camera switch turned on
									player.GetComponent<cameraSwitch>().switchCamAngle = true;
								}
								
							// If required object isn't in your inventory
							} else {
								
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().doorIsLocked = true;
								
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
									sounds.GetComponent<soundEffects>().openDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("bathroomDoor").animation.Play("open");

									// Toggles bool
									bathroomDoorClosed = !bathroomDoorClosed;

									// Camera switch turned on
									player.GetComponent<cameraSwitch>().switchCamAngle = true;
								
								// If the door is not closed
								} else {
									
									// Toggles bool to true, which is used for sound effects
									sounds.GetComponent<soundEffects>().closeDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("bathroomDoor").animation.Play("close");
									
									// Toggles bool
									bathroomDoorClosed = !bathroomDoorClosed;

									// Camera switch turned on
									player.GetComponent<cameraSwitch>().switchCamAngle = true;
								}
								
							// If required object isn't in your inventory
							} else {
								
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().doorIsLocked = true;
								
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
									sounds.GetComponent<soundEffects>().openDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("livingroomDoor").animation.Play("open");

									// Toggles bool
									livingRoomDoorClosed = !livingRoomDoorClosed;

									// Camera switch turned on
									player.GetComponent<cameraSwitch>().switchCamAngle = true;
								
								// If the door is not closed
								} else {

									// Toggles bool to true, which is used for sound effects
									sounds.GetComponent<soundEffects>().closeDoor = true;
									
									// Plays the animation to open door
									GameObject.Find("livingroomDoor").animation.Play("close");
									
									// Toggles bool
									livingRoomDoorClosed = !livingRoomDoorClosed;

									// Camera switch turned on
									player.GetComponent<cameraSwitch>().switchCamAngle = true;
								}
								
							// If required object isn't in your inventory
							} else {
								
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().doorIsLocked = true;
								
								// For now, outputs a debug message until GUI elements have been created and implemented
								Debug.Log ("This door requires a key!");
							}
						}

						// Checks if the object you collide with is the door type labeled "officeDoor"
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.officeDoor) {

							// Runs if the door is closed
							if (officeDoorClosed) {

								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().openDoor = true;
								
								// Plays the animation to open door
								GameObject.Find("officeDoor").animation.Play("open");

								// Toggles bool
								officeDoorClosed = !officeDoorClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
							
							// If the door is not closed
							} else {

								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().closeDoor = true;
								
								// Plays the animation to open door
								GameObject.Find("officeDoor").animation.Play("close");
								
								// Toggles bool
								officeDoorClosed = !officeDoorClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
							}
						}

						// Checks if the object you collide with is the door type labeled "frontDoor"
						// This door requires a key to open, loaded from the inventory script
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.frontDoor) {
							
							// Checks, through the items script, if the player has the required key to open this door
							if (player.GetComponent<items>().hasSecretKey == true) {

								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().openDoor = true;

								// If the bomb has been disarmed when opening the front door
								if (bomb.GetComponent<timer>().isWireCut == true) {

									Application.LoadLevel ("win-disarm");
								
								// If it has not been disarmed
								} else {

									Application.LoadLevel ("win");
								}
								
							// If required object isn't in your inventory
							} else {
								
								// Toggles bool to true, which is used to display message that the door is locked
								doorIsLocked = true;
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().doorIsLocked = true;
								
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
							if (keyPad.GetComponent<puzzleScript>().puzzleComplete == false) {

								// Toggles off system so you can do puzzles
								lockdown();

								// Activates puzzle
								keyPad.GetComponent<puzzleScript>().keypadPuzzle = true;
							
							// If the puzzle has been solved
							} else if (keyPad.GetComponent<puzzleScript>().puzzleComplete == true) {

								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().errorSound = true;
							}
						}
					}

					// Checks if the object you collide with is tagged as a "Misc"
					// This should generally be used for all of the interactable items in the world that are not inventory items, or puzzles
					if (objectHit.collider.tag == "Misc") {

						// Checks if the object you collide with is the bomb
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.bomb) {

							// Show the timer on the screen
							bomb.GetComponent<timer>().displayTimer = true;
							
							// Shuts off all systems
							lockdown();
							
							// Prompt
							Prompt();
						}

						// Checks if the object you collide with is the killer selfie
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.killerSelfie) {
							
							// Show the newspaper on the screen
							player.GetComponent<items>().hasSelfie = true;
							
							// Shuts off all systems
							lockdown();
							
							// Prompt
							Prompt();

							// Only play selfie voice over once
							if (selfiePlayed == false) {
								voices.GetComponent<voiceOvers>().killerSelfie = true;

								selfiePlayed = true;
							}
						}

						// Checks if the object you collide with is the first newspaper
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.newspaper1) {
							
							// Show the newspaper on the screen
							player.GetComponent<items>().readFirstNewspaper = true;
							
							// Shuts off all systems
							lockdown();
							
							// Prompt
							Prompt();
						}

						// Checks if the object you collide with is the second newspaper
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.newspaper2) {
							
							// Show the newspaper on the screen
							player.GetComponent<items>().readSecondNewspaper = true;
							
							// Shuts off all systems
							lockdown();
							
							// Prompt
							Prompt();
						}

						// Checks if the object you collide with is the third newspaper
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.newspaper3) {
							
							// Show the newspaper on the screen
							player.GetComponent<items>().readThirdNewspaper = true;
							
							// Shuts off all systems
							lockdown();
							
							// Prompt
							Prompt();
						}

						// Checks if the object you collide with is the first hint
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatHintIsThis == objectManager.Hints.hint1) {
							
							// Show the hint on the screen
							player.GetComponent<items>().readHint1 = true;
							
							// Shuts off all systems
							lockdown();
							
							// Prompt
							Prompt();
						}

						// Checks if the object you collide with is the second hint
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatHintIsThis == objectManager.Hints.hint2) {
							
							// Show the hint on the screen
							player.GetComponent<items>().readHint2 = true;
							
							// Shuts off all systems
							lockdown();
							
							// Prompt
							Prompt();
						}

						// Checks if the object you collide with is the third hint
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatHintIsThis == objectManager.Hints.hint3) {
							
							// Show the hint on the screen
							player.GetComponent<items>().readHint3 = true;
							
							// Shuts off all systems
							lockdown();
							
							// Prompt
							Prompt();
						}

						// Globus sphere, for rotation
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.globusRotate) {

							// Toggles bool to true, which is used for sound effects
							//sounds.GetComponent<soundEffects>().openDoor = true;

							// Plays the animation to open door
							GameObject.Find("globe").animation.Play("rotation");

							// Camera switch turned on
							player.GetComponent<cameraSwitch>().switchCamAngle = true;
						}

						// Globus latch, to open and close it
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.globusOpen) {

							// Runs if the globus is closed
							if (globusClosed) {

								// Toggles bool to true, which is used for sound effects
								//sounds.GetComponent<soundEffects>().openDoor = true;
								
								// Plays the animation to open door
								GameObject.Find("globe").animation.Play("open");

								globusClosed = !globusClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
							
							// If the globus is not closed
							} else {

								// Toggles bool to true, which is used for sound effects
								//sounds.GetComponent<soundEffects>().openDoor = true;

								// Plays the animation to open door
								GameObject.Find("globe").animation.Play("close");

								globusClosed = !globusClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
							}
						}

						// Bedside table 1, to open and close it
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.bedroomTable1) {

							// Runs if closed
							if (bedroomTable1Closed) {

								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().openCupboard = true;
								
								// Plays the animation to open door
								GameObject.Find("bedsideTable1").animation.Play("open");
								
								bedroomTable1Closed = !bedroomTable1Closed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
								
							// If not closed
							} else {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().closeCupboard = true;
								
								// Plays the animation to open door
								GameObject.Find("bedsideTable1").animation.Play("close");
								
								bedroomTable1Closed = !bedroomTable1Closed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
							}
						}

						// Bedside table 2, to open and close it
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.bedroomTable2) {
							
							// Runs if closed
							if (bedroomTable2Closed) {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().openCupboard = true;
								
								// Plays the animation to open door
								GameObject.Find("bedsideTable2").animation.Play("open");
								
								bedroomTable2Closed = !bedroomTable2Closed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
								
							// If not closed
							} else {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().closeCupboard = true;
								
								// Plays the animation to open door
								GameObject.Find("bedsideTable2").animation.Play("close");
								
								bedroomTable2Closed = !bedroomTable2Closed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
							}
						}

						// Bedroom chest, to open and close it
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.bedroomChest) {
							
							// Runs if closed
							if (bedroomChestClosed) {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().openChest = true;
								
								// Plays the animation to open door
								GameObject.Find("chest1").animation.Play("open");
								
								bedroomChestClosed = !bedroomChestClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
								
							// If not closed
							} else {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().closeChest = true;
								
								// Plays the animation to open door
								GameObject.Find("chest1").animation.Play("close");
								
								bedroomChestClosed = !bedroomChestClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
							}
						}

						// Hallway dresser, to open and close it
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.hallwayDresser) {
							
							// Runs if closed
							if (hallwayDresserClosed) {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().openCupboard = true;
								
								// Plays the animation to open door
								GameObject.Find("sideboard1").animation.Play("open");
								
								hallwayDresserClosed = !hallwayDresserClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
								
							// If not closed
							} else {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().closeCupboard = true;
								
								// Plays the animation to open door
								GameObject.Find("sideboard1").animation.Play("close");
								
								hallwayDresserClosed = !hallwayDresserClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
							}
						}

						// Kitchen stove, to open and close it
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.stove) {
							
							// Runs if closed
							if (stoveClosed) {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().openStove = true;

								// If voice over hasn't been heard before
								if (stovePlayed == false) {

									// Toggle voice over
									voices.GetComponent<voiceOvers>().stove = true;

									// Toggles true so the voice over won't be played again
									stovePlayed = true;
								}

								// Plays the animation to open door
								GameObject.Find("stove2").animation.Play("opened");
								
								stoveClosed = !stoveClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
								
							// If not closed
							} else {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().closeStove = true;
								
								// Plays the animation to open door
								GameObject.Find("stove2").animation.Play("closed");
								
								stoveClosed = !stoveClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
							}
						}

						// Living room chest, to open and close it
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatObjectAmI == objectManager.InteractiveObject.livingRoomChest) {
							
							// Runs if closed
							if (livingRoomChestClosed) {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().openChest = true;
								
								// Plays the animation to open door
								GameObject.Find("chest2").animation.Play("open");
								
								livingRoomChestClosed = !livingRoomChestClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
								
							// If not closed
							} else {
								
								// Toggles bool to true, which is used for sound effects
								sounds.GetComponent<soundEffects>().closeChest = true;
							
								// Plays the animation to open door
								GameObject.Find("chest2").animation.Play("close");
								
								livingRoomChestClosed = !livingRoomChestClosed;

								// Camera switch turned on
								player.GetComponent<cameraSwitch>().switchCamAngle = true;
							}
						}

						// Checks if the object you collide with is the wirecutter
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeItem == objectManager.Items.wireCutter) {
							
							// Toggles the bool, from the item script, to true when item is picked up
							player.GetComponent<items>().hasWireCutter = true;
							
							// Toggles bool to true, which is used for sound effects
							sounds.GetComponent<soundEffects>().gotKey = true;

							// Camera switch turned on
							player.GetComponent<cameraSwitch>().switchCamAngle = true;
							
							// Destroys the object that you interacted with
							Destroy (objectHit.collider.gameObject);
						}
					}
				}
			}
		
		// If the player is not looking at the object, then it toggles the bool off
		} else {
					
			// Sets the bool to false so that the UI element is no longer drawn on the screen
			imLookingAt = false;
		}
	
		// Checks if the prompt button is active
		if (uiPrompt == true) {

			// When Esc is pressed
			if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse1)) {
			
				// If player looking at the timer
				if (bomb.GetComponent<timer>().displayTimer == true) {

					// Turns the systems back on
					lockdown();
					
					// Turns prompt off
					Prompt();
					
					// Toggles note off again
					bomb.GetComponent<timer>().displayTimer = false;
				}

				// If player is reading the starting note
				if (player.GetComponent<items>().hasNote == true) {

					// Toggles bool to true, which is used for sound effects
					sounds.GetComponent<soundEffects>().gotPaper = true;

					// Turns the systems back on
					lockdown();

					// Turns prompt off
					Prompt();
						
					// Toggles note off again
					player.GetComponent<items>().hasNote = false;
				}

				// If player is reading the first note w/ key
				if (player.GetComponent<items>().hasFirstNote == true) {
						
					// Toggles bool to true, which is used for sound effects
					sounds.GetComponent<soundEffects>().gotPaper = true;
						
					// Turns the systems back on
					lockdown();

					// Turns prompt off
					Prompt();
						
					// Toggles note off again
					player.GetComponent<items>().hasFirstNote = false;
				}

				// If player is looking at the killer selfie
				if (player.GetComponent<items>().hasSelfie == true) {
					
					// Toggles bool to true, which is used for sound effects
					sounds.GetComponent<soundEffects>().gotPaper = true;
					
					// Turns the systems back on
					lockdown();
					
					// Turns prompt off
					Prompt();
					
					// Toggles note off again
					player.GetComponent<items>().hasSelfie = false;
				}

				// If player is reading the first newspaper
				if (player.GetComponent<items>().readFirstNewspaper == true) {
					
					// Toggles bool to true, which is used for sound effects
					sounds.GetComponent<soundEffects>().gotPaper = true;
					
					// Turns the systems back on
					lockdown();
					
					// Turns prompt off
					Prompt();
					
					// Toggles note off again
					player.GetComponent<items>().readFirstNewspaper = false;
				}

				// If player is reading the second newspaper
				if (player.GetComponent<items>().readSecondNewspaper == true) {
					
					// Toggles bool to true, which is used for sound effects
					sounds.GetComponent<soundEffects>().gotPaper = true;
					
					// Turns the systems back on
					lockdown();
					
					// Turns prompt off
					Prompt();
					
					// Toggles note off again
					player.GetComponent<items>().readSecondNewspaper = false;
				}

				// If player is reading the third newspaper
				if (player.GetComponent<items>().readThirdNewspaper == true) {
					
					// Toggles bool to true, which is used for sound effects
					sounds.GetComponent<soundEffects>().gotPaper = true;
					
					// Turns the systems back on
					lockdown();
					
					// Turns prompt off
					Prompt();
					
					// Toggles note off again
					player.GetComponent<items>().readThirdNewspaper = false;
				}

				// If player is reading the first hint
				if (player.GetComponent<items>().readHint1 == true) {
					
					// Toggles bool to true, which is used for sound effects
					sounds.GetComponent<soundEffects>().gotPaper = true;
					
					// Turns the systems back on
					lockdown();
					
					// Turns prompt off
					Prompt();
					
					// Toggles note off again
					player.GetComponent<items>().readHint1 = false;
				}

				// If player is reading the second hint
				if (player.GetComponent<items>().readHint2 == true) {
					
					// Toggles bool to true, which is used for sound effects
					sounds.GetComponent<soundEffects>().gotPaper = true;
					
					// Turns the systems back on
					lockdown();
					
					// Turns prompt off
					Prompt();
					
					// Toggles note off again
					player.GetComponent<items>().readHint2 = false;
				}

				// If player is reading the third hint
				if (player.GetComponent<items>().readHint3 == true) {
					
					// Toggles bool to true, which is used for sound effects
					sounds.GetComponent<soundEffects>().gotPaper = true;
					
					// Turns the systems back on
					lockdown();
					
					// Turns prompt off
					Prompt();
					
					// Toggles note off again
					player.GetComponent<items>().readHint3 = false;
				}
			}
		}
	}

	void lockdown () {
		
		// Toggles movement and inventory system on/off
		player.GetComponent<MouseLook>().cutSceneOn = !player.GetComponent<MouseLook>().cutSceneOn;
		mainCamera.GetComponent<MouseLook>().cutSceneOn = !mainCamera.GetComponent<MouseLook>().cutSceneOn;

		mainCamera.GetComponent<userInterface>().inventoryOn = !mainCamera.GetComponent<userInterface>().inventoryOn;
	}

	void Prompt () {

		uiPrompt = !uiPrompt;
	}
}