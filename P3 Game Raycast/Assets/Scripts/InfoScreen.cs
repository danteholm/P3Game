using UnityEngine;
using System.Collections;

public class InfoScreen : MonoBehaviour {
	
	void Update () {

		// Loads the game level when Enter, or Return has been pressed
		if (Input.GetKey (KeyCode.Return) || Input.GetKey (KeyCode.KeypadEnter)) {

			Application.LoadLevel ("level1");
		}
	}
}