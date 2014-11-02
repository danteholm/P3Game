using UnityEngine;
using System.Collections;

public class InfoScreen : MonoBehaviour {
	
	void Update () {

		Screen.lockCursor = true;

		// Loads the game level when Enter, or Return has been pressed
		if (Input.anyKey) {

			Application.LoadLevel (1);
		}
	}
}