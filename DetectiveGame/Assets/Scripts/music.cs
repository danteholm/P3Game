using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {

	// BGM music
	public AudioSource _BGM;
	public AudioClip _startMusic;
	public AudioClip _tenseMusic;

	void Start () {

		// Set music to the start music, and play it
		_BGM.clip = _startMusic;
		_BGM.Play();
	}


	void Update () {

		// Just a second before two minutes are left
		if (GameObject.Find ("Old-timer bomb prefab").GetComponent<timer>().timeLeft < 121) {

			// If the music playing is BGM1
			if (_BGM.clip == _startMusic) {

				// Change to BGM2, and play it
				_BGM.clip = _tenseMusic;
				_BGM.Play();
			}
		}
	}
}
