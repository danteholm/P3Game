using UnityEngine;
using System.Collections;

public class secretRoom : MonoBehaviour {

	// Executes when the player character enters the trigger area
	void OnTriggerEnter (Collider other) {

		GameObject.Find ("VO").GetComponent<voiceOvers>().secretRoom = true;
		Destroy (gameObject);
	}
}
