using UnityEngine;
using System.Collections;

public class codeOnWall : MonoBehaviour {
	
	// Executes when the player character enters the trigger area
	void OnTriggerEnter (Collider other) {
		
		GameObject.Find ("VO").GetComponent<voiceOvers>().paintings = true;
		Destroy (gameObject);
	}
}
