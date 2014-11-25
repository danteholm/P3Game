using UnityEngine;
using System.Collections;

public class voiceOvers : MonoBehaviour {

	// Define the audio source itself
	public AudioSource _voiceOver;
	// Variables for the voice overs
	public AudioClip awakenVoice;
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
	public AudioClip bombWasDisarmedVoice;
	// Variables used to toggle /when/ to play the voice overs
	public bool awaken;
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
	public bool bombWasDisarmed;

	void Update () {

		if (awaken == false) {

			_voiceOver.clip = awakenVoice;
			_voiceOver.Play();
			awaken = true;
		}

		if (halfTime) {

			_voiceOver.clip = halfTimeVoice;
			_voiceOver.Play();
			halfTime = false;
		}

		if (oneMinuteLeft) {
			
			_voiceOver.clip = oneMinuteLeftVoice;
			_voiceOver.Play();
			oneMinuteLeft = false;
		}

		if (secondKey) {
			
			_voiceOver.clip = secondKeyVoice;
			_voiceOver.Play();
			secondKey = false;
		}

		if (lastKey) {
			
			_voiceOver.clip = lastKeyVoice;
			_voiceOver.Play();
			lastKey = false;
		}

		if (stove) {
			
			_voiceOver.clip = stoveVoice;
			_voiceOver.Play();
			stove = false;
		}

		if (paintings) {

			_voiceOver.clip = paintingsVoice;
			_voiceOver.Play();
			paintings = false;
		}

		if (secretRoom) {

			_voiceOver.clip = secretRoomVoice;
			_voiceOver.Play();
			secretRoom = false;
		}

		if (killerSelfie) {
			
			_voiceOver.clip = killerSelfieVoice;
			_voiceOver.Play();
			killerSelfie = false;
		}

		if (moralChoice) {
			
			_voiceOver.clip = moralChoiceVoice;
			_voiceOver.Play();
			moralChoice = false;
		}

		if (bombWasDisarmed) {
			
			_voiceOver.clip = bombWasDisarmedVoice;
			_voiceOver.Play();
			bombWasDisarmed = false;
		}
	}
}
