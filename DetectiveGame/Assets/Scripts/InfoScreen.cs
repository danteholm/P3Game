using UnityEngine;
using System.Collections;

public class InfoScreen : MonoBehaviour {
	
	void Update () {

		Screen.lockCursor = true;

		// Loads the game level when Enter, or Return has been pressed
		if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) {

			Application.LoadLevel (1);
		}
	}
}