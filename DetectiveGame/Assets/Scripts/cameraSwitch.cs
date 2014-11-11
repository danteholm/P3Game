using UnityEngine;
using System.Collections;

public class cameraSwitch : MonoBehaviour {

	// Variables to define which objects are the cameras, for the game, in the inspector
	public GameObject Camera1;
	public GameObject Camera2;
	// Used to toggle when to switch the camera angle and disable movement
	public bool switchCamAngle;
	private bool lockdown;
	private bool movementOff;
	// Private variable for the objects used for interaction
	GameObject player;
	GameObject mainCamera;

	public void Start () {

		// Defines the player object for the created variable at the top of the script
		player = GameObject.Find ("Player");
		mainCamera = GameObject.Find ("Main Camera");

		// Defines which camera is active at the beginning
		Camera1.camera.active = true;
		Camera2.camera.active = false;
	}

	void Update () {

		// When the camera switch is on it will enable the other camera, then turn it back off via another function
		if (switchCamAngle == true) {
			Camera2.camera.active = true;
			Camera1.camera.active = false;

			// Disables movement
			if (movementOff == false) {
				player.GetComponent<MouseLook>().cutSceneOn = false;
				movementOff = true;
			}

			// Return camera to normal when timer is up
			StartCoroutine("camSwitch");
		// When the camera switch is not on, the default camera will be used
		} else if (switchCamAngle == false) {
			Camera1.camera.active = true;
			Camera2.camera.active = false;

			// Enables movement
			if (movementOff == true) {
				player.GetComponent<MouseLook>().cutSceneOn = true;
				movementOff = false;
			}
		}
	}

	// Timer function to determine when to switch the camera back to default
	IEnumerator camSwitch () {

		// Yields when time is up
		yield return new WaitForSeconds(0.7f);

		// Switch back to the default camera angle
		switchCamAngle = false;
	}
}