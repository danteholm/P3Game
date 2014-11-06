using UnityEngine;
using System.Collections;

public class menuQuit : MonoBehaviour {

	// Hover over the object
	void OnMouseEnter () {
		GameObject.Find ("qUnderline").renderer.enabled = true;
	}

	// Click the object
	void OnMouseDown () {
		Application.Quit ();
	}

	// Check for a key press as well
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit ();
		}
	}

	// No longer hovering the object
	void OnMouseExit () {
		GameObject.Find ("qUnderline").renderer.enabled = false;
	}
}