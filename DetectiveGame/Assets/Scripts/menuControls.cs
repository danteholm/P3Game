using UnityEngine;
using System.Collections;

public class menuControls : MonoBehaviour {

	// Hover over the object
	void OnMouseEnter () {
		GameObject.Find ("cUnderline").renderer.enabled = true;
	}

	// Click the object
	void OnMouseDown () {
		Application.LoadLevel ("controls");
	}

	// Check for a key press as well
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			Application.LoadLevel ("controls");
		}
	}

	// No longer hovering the object
	void OnMouseExit () {
		GameObject.Find ("cUnderline").renderer.enabled = false;
	}
}