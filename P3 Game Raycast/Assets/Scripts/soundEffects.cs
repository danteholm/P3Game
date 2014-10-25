using UnityEngine;
using System.Collections;

public class soundEffects : MonoBehaviour {

	// Variables for sound effects
	public AudioClip doorOpen;
	public AudioClip doorClose;
	public AudioClip paper;
	public AudioClip key;

	// Bools used to determine when to play sound effects
	public bool openDoor;
	public bool closeDoor;
	public bool gotKey;

	void Update () {

		// Checks for bool status, if true, in order to play sound effect
		if (openDoor == true) {

			// Plays the specified sound effect
			audio.PlayOneShot (doorOpen);

			// Resets the bool back to false
			openDoor = false;
		}

		// Checks for bool status, if true, in order to play sound effect
		if (openDoor == true) {
			
			// Plays the specified sound effect
			audio.PlayOneShot (doorClose);
			
			// Resets the bool back to false
			closeDoor = false;
		}

		// Checks for bool status, if true, in order to play sound effect
		if (gotKey == true) {

			// Plays the specified sound effect
			audio.PlayOneShot (key);
			
			// Resets the bool back to false
			gotKey = false;
		}
	}
}
