using UnityEngine;
using System.Collections;

public class menuNewGame : MonoBehaviour {

	// Hover over the object
	void OnMouseEnter () {
		GameObject.Find ("ngUnderline").renderer.enabled = true;
	}

	// Click the object
	void OnMouseDown () {
		Application.LoadLevel ("appartment");
	}

	// Check for a key press as well
	void Update () {
		if (Input.GetKeyDown (KeyCode.N)) {
			Application.LoadLevel ("appartment");
		}
	}

	// No longer hovering the object
	void OnMouseExit () {
		GameObject.Find ("ngUnderline").renderer.enabled = false;
	}
}