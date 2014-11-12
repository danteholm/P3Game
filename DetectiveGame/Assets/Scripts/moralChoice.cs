using UnityEngine;
using System.Collections;

public class moralChoice : MonoBehaviour {

	// Executes when the player character enters the trigger area
	void OnTriggerEnter (Collider other) {

		if (GameObject.Find ("Player").GetComponent<items>().hasSecretKey == true) {
			GameObject.Find ("VO").GetComponent<voiceOvers>().moralChoice = true;
			Destroy (gameObject);
		}
	}
}
