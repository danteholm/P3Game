using UnityEngine;
using System.Collections;

public class soundEffects : MonoBehaviour {

	// Variables for sound effects
	public AudioClip doorOpen;
	public AudioClip doorClose;
	public AudioClip lockedDoor;
	public AudioClip paper;
	public AudioClip key;
	public AudioClip tik;
	public AudioClip buttonPad;
	public AudioClip error;
	public AudioClip success;
	public AudioClip bookcase;

	// Bools used to determine when to play sound effects
	public bool openDoor;
	public bool closeDoor;
	public bool doorIsLocked;

	// Item related sounds
	public bool gotKey;
	public bool gotPaper;

	// Bomb sound
	public bool activeTik;

	// Keypad Puzzle sounds
	public bool keypadSound;
	public bool errorSound;
	public bool successSound;
	public bool bookcaseMoving;

	void Update () {

		// Checks for bool status, if true, in order to play sound effect
		if (openDoor == true) {

			// Plays the specified sound effect
			audio.PlayOneShot (doorOpen);

			// Resets the bool back to false
			openDoor = false;
		}

		// Checks for bool status, if true, in order to play sound effect
		if (closeDoor == true) {
			
			// Plays the specified sound effect
			audio.PlayOneShot (doorClose);
			
			// Resets the bool back to false
			closeDoor = false;
		}

		// Checks for bool status, if true, in order to play sound effect
		if (doorIsLocked == true) {
			
			// Plays the specified sound effect
			audio.PlayOneShot (lockedDoor);
			
			// Resets the bool back to false
			doorIsLocked = false;
		}

		// Checks for bool status, if true, in order to play sound effect
		if (gotKey == true) {

			// Plays the specified sound effect
			audio.PlayOneShot (key);
			
			// Resets the bool back to false
			gotKey = false;
		}

		if (gotPaper == true) {
			
			// Plays the specified sound effect
			audio.PlayOneShot (paper);
			
			// Resets the bool back to false
			gotPaper = false;
		}

		if (activeTik == true) {
			
			// Plays the specified sound effect
			audio.PlayOneShot(tik);

			// Make sure the sound effect keeps looping
			audio.loop = true;	

			// Resets the bool back to false
			activeTik = false;
		
		}
		
		// Checks for bool status, if true, in order to play sound effect
		if (keypadSound == true) {
			
			// Plays the specified sound effect
			audio.PlayOneShot (buttonPad);
			
			// Resets the bool back to false
			keypadSound = false;
		}
		
		// Checks for bool status, if true, in order to play sound effect
		if (errorSound == true) {
			
			// Plays the specified sound effect
			audio.PlayOneShot (error);
			
			// Resets the bool back to false
			errorSound = false;
		}
		
		// Checks for bool status, if true, in order to play sound effect
		if (successSound == true) {
			
			// Plays the specified sound effect
			audio.PlayOneShot (success);
			
			// Resets the bool back to false
			successSound = false;
		}
		
		// Checks for bool status, if true, in order to play sound effect
		if (bookcaseMoving == true) {
			
			// Plays the specified sound effect
			audio.PlayOneShot (bookcase);
			
			// Resets the bool back to false
			bookcaseMoving = false;
		}
	}
}