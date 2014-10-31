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
		if (Physics.Raycast (this.transform.position, this.transform.forward, out objectHit, distance) && objectHit.collider.gameObject.tag != "Player" && objectHit.collider.gameObject.tag != "Untagged") {

			imLookingAt = true;

			// Outputs a debug message to indicate what object you collided with
			Debug.Log ("Object: "+objectHit.collider.gameObject.name);

			// Runs if the player presses E while near an object
			if (Input.GetKeyDown (KeyCode.E) /*&& GameObject.Find ("Main Camera").GetComponent<userInterface>().inventoryOpen == false*/) {

				imLookingAt = false;

				// Outputs a message to indicate what item you picked up
				//Debug.Log ("Received: "+objectHit.collider.gameObject.name);

				// Checks if the object you collide with is tagged as "Keys", "Items" or "Paper"
				// This script can be modified to be used for any type of item so long as the respective scripts connected to it are modified as well
				// A tag should also be created for the other specific items that are made
				if (objectHit.collider.tag == "Keys" || objectHit.collider.tag == "Item" || objectHit.collider.tag == "Paper") {

					playerGotItem = true;


				}
					// Checks if the object you collide with is the key type labeled "normalKey"
					if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.bedroomKey) {

						// Toggles the bool, from the item script, to true when item is picked up
						player.GetComponent<items>().hasBedroomKey = true;

						// Toggles bool to true, which is used for sound effects
						player.GetComponent<soundEffects>().gotKey = true;

						// Destroys the object that you interacted with
						Destroy (objectHit.collider.gameObject);
					}


				// Checks if the object you collide with is the key type labeled "normalKey"
				if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.KitchenKey) {
					
					// Toggles the bool, from the item script, to true when item is picked up
					player.GetComponent<items>().hasKitchenKey = true;
					
					// Toggles bool to true, which is used for sound effects
					player.GetComponent<soundEffects>().gotKey = true;
					
					// Destroys the object that you interacted with
					Destroy (objectHit.collider.gameObject);
				}

				
				// Checks if the object you collide with is the key type labeled "normalKey"
				if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.SecretKey) {
					
					// Toggles the bool, from the item script, to true when item is picked up
					player.GetComponent<items>().hasSecretKey = true;
					
					// Toggles bool to true, which is used for sound effects
					player.GetComponent<soundEffects>().gotKey = true;
					
					// Destroys the object that you interacted with
					Destroy (objectHit.collider.gameObject);
					
				}
				
				
				// Checks if the object you collide with is the key type labeled "normalKey"
					if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeKey == objectManager.Keys.HallKey) {
						
						// Toggles the bool, from the item script, to true when item is picked up
						player.GetComponent<items>().hasHallKey = true;
						
						// Toggles bool to true, which is used for sound effects
						player.GetComponent<soundEffects>().gotKey = true;
						
						// Destroys the object that you interacted with
						Destroy (objectHit.collider.gameObject);
					}

			
					// Checks if the object you collide with is the key type labeled "normalKey"
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
						
						// Destroys the object that you interacted with
						//Destroy (objectHit.collider.gameObject);
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






			/*

			// Checks if the object you collide with is the door type labeled "livingroomDoor"
			if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.bedroomDoor) {

						// Toggles bool to true, which is used for sound effects
						player.GetComponent<soundEffects>().openDoor = true;

						// Plays the animation to open door
						GameObject.Find("livingroomDoor").animation.Play("open");
						//transform.parent.animation.Play("open");
						//GameObject.Find ("door").transform.parent.animation.Play("open");

						// For now, just destroy the door until the animation has been created and implemented
						//Destroy (objectHit.collider.gameObject);
					}
			
			// Checks if the object you collide with is the door type labeled "bathroomDoor"
				if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.bathroomDoor) {

						// Toggles bool to true, which is used for sound effects
						player.GetComponent<soundEffects>().openDoor = true;

						// Plays the animation to open door
						GameObject.Find("bathroomDoor").animation.Play("open");
						
						// For now, just destroy the door until the animation has been created and implemented
						//Destroy (objectHit.collider.gameObject);
					}
			
			// Checks if the object you collide with is the door type labeled "kitchenDoor1"
				if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.kitchenDoor1) {
						
						// Toggles bool to true, which is used for sound effects
						player.GetComponent<soundEffects>().openDoor = true;
						
						// Plays the animation to open door
						GameObject.Find("kitchenDoor1").animation.Play("open");
						
						// For now, just destroy the door until the animation has been created and implemented
						//Destroy (objectHit.collider.gameObject);
					}

					// Checks if the object you collide with is the door type labeled "kitchenDoor2"
					if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.kitchenDoor2) {
						
						// Toggles bool to true, which is used for sound effects
						player.GetComponent<soundEffects>().openDoor = true;
						
						// Plays the animation to open door
						GameObject.Find("kitchenDoor2").animation.Play("open");
						
						// For now, just destroy the door until the animation has been created and implemented
						//Destroy (objectHit.collider.gameObject);
					}*/
			






				// Checks if the object you collide with is tagged as a "Doors"
				if (objectHit.collider.tag == "Doors") {
					
					// Checks if the object you collide with is the door type labeled "bedroomDoor"
					// This door requires a key to open, loaded from the inventory script
					if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.bedroomDoor) {
						
						// Checks, through the items script, if the player has the required key to open this door
						if (player.GetComponent<items>().hasBedroomKey == true) {

							// Removes the item from your inventory
							//player.GetComponent<items>().hasNormalKey = false;

							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().openDoor = true;
							player.GetComponent<soundEffects>().activeTik = true;

							// There should be a script here which changes the tag of the door to "unlockedDoor"
						
							// Plays the animation to open door
							GameObject.Find("bedroomDoor").animation.Play("open");

							GameObject.Find("Main Camera").GetComponent<timer>().timerOn = true;
							// For now, just destroy the door until the animation has been created and implemented
							//Destroy (objectHit.collider.gameObject);

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

					// Checks if the object you collide with is tagged as a "Doors"
					if (objectHit.collider.tag == "Doors") {
						
						// Checks if the object you collide with is the door type labeled "bedroomDoor"
						// This door requires a key to open, loaded from the inventory script
						if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.kitchenDoor1) {
							
							// Checks, through the items script, if the player has the required key to open this door
							if (player.GetComponent<items>().hasHallKey == true) {
								
								// Removes the item from your inventory
								//player.GetComponent<items>().hasNormalKey = false;
								
								// Toggles bool to true, which is used for sound effects
								player.GetComponent<soundEffects>().openDoor = true;
						
								
								// There should be a script here which changes the tag of the door to "unlockedDoor"
								
								// Plays the animation to open door
								GameObject.Find("KitchenDoor1").animation.Play("open");
								
					
								// For now, just destroy the door until the animation has been created and implemented
								//Destroy (objectHit.collider.gameObject);
								
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


					if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.kitchenDoor2) {
						
						// Checks, through the items script, if the player has the required key to open this door
						if (player.GetComponent<items>().hasKitchenKey == true) {
							
							// Removes the item from your inventory
							//player.GetComponent<items>().hasNormalKey = false;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().openDoor = true;
							
							// There should be a script here which changes the tag of the door to "unlockedDoor"
							
							// Plays the animation to open door
							GameObject.Find("KitchenDoor2").animation.Play("open");
							
							// For now, just destroy the door until the animation has been created and implemented
							//Destroy (objectHit.collider.gameObject);
							
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
				
					if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.bathroomDoor) {
						
						// Checks, through the items script, if the player has the required key to open this door
						if (player.GetComponent<items>().hasLivingRoomKey == true) {
							
							// Removes the item from your inventory
							//player.GetComponent<items>().hasNormalKey = false;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().openDoor = true;
							
							// There should be a script here which changes the tag of the door to "unlockedDoor"
							
							// Plays the animation to open door
							GameObject.Find("BathroomDoor").animation.Play("open");
							
							// For now, just destroy the door until the animation has been created and implemented
							//Destroy (objectHit.collider.gameObject);
							
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


					if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.LivingRoomDoor) {
						
						// Checks, through the items script, if the player has the required key to open this door
						if (player.GetComponent<items>().hasKitchenKey == true) {
							
							// Removes the item from your inventory
							//player.GetComponent<items>().hasNormalKey = false;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().openDoor = true;
							
							// There should be a script here which changes the tag of the door to "unlockedDoor"
							
							// Plays the animation to open door
							GameObject.Find("LivingRoomDoor").animation.Play("open");
							
							// For now, just destroy the door until the animation has been created and implemented
							//Destroy (objectHit.collider.gameObject);
							
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

					
					if (objectHit.collider.gameObject.GetComponent<objectManager>().whatTypeDoor == objectManager.Doors.frontDoor) {
						
						// Checks, through the items script, if the player has the required key to open this door
						if (player.GetComponent<items>().hasSecretKey == true) {
							
							// Removes the item from your inventory
							//player.GetComponent<items>().hasNormalKey = false;
							
							// Toggles bool to true, which is used for sound effects
							player.GetComponent<soundEffects>().openDoor = true;
							
						//load win Animation. 
							
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
			}

		// If the player is not looking at the object, then it toggles the bool off
		} else {

			// Sets the bool to false so that the UI element is no longer drawn on the screen
			imLookingAt = false;
		}
		
	}
}