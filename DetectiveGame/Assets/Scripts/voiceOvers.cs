using UnityEngine;
using System.Collections;

public class voiceOvers : MonoBehaviour {

	// Variables for the voice overs
	public AudioClip halfTimeVoice;
	public AudioClip oneMinuteLeftVoice;
	public AudioClip bombNotDisarmedVoice;
	public AudioClip bombDisarmedVoice;
	public AudioClip deathVoice;
	public AudioClip killerSelfieVoice;
	public AudioClip secondKeyVoice;
	public AudioClip lastKeyVoice;
	public AudioClip paintingsVoice;
	public AudioClip moralChoiceVoice;
	public AudioClip secretRoomVoice;
	public AudioClip stoveVoice;
	// Variables used to toggle /when/ to play the voice overs
	public bool halfTime;
	public bool oneMinuteLeft;
	public bool bombNotDisarmed;
	public bool bombDisarmed;
	public bool death;
	public bool killerSelfie;
	public bool secondKey;
	public bool lastKey;
	public bool paintings;
	public bool moralChoice;
	public bool secretRoom;
	public bool stove;

	void Update () {

		if (halfTime) {

			audio.PlayOneShot (halfTimeVoice);
			halfTime = false;
		}

		if (oneMinuteLeft) {
			
			audio.PlayOneShot (oneMinuteLeftVoice);
			oneMinuteLeft = false;
		}

		if (secondKey) {
			
			audio.PlayOneShot (secondKeyVoice);
			secondKey = false;
		}

		if (lastKey) {
			
			audio.PlayOneShot (lastKeyVoice);
			lastKey = false;
		}

		if (stove) {
			
			audio.PlayOneShot (stoveVoice);
			stove = false;
		}

		if (paintings) {

			audio.PlayOneShot (paintingsVoice);
			paintings = false;
		}

		if (secretRoom) {

			audio.PlayOneShot (secretRoomVoice);
			secretRoom = false;
		}

		if (killerSelfie) {
			
			audio.PlayOneShot (killerSelfieVoice);
			killerSelfie = false;
		}

		if (moralChoice) {
			
			audio.PlayOneShot (moralChoiceVoice);
			moralChoice = false;
		}
	}
}
