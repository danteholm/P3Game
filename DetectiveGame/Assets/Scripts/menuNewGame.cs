using UnityEngine;
using System.Collections;

public class menuNewGame : MonoBehaviour {

	// Bool to determine when to render the hover effect
	public GUIStyle menuButton;

	// Draw button
	void OnGUI () {
		if (GUI.Button(new Rect(Screen.width/2f-68, Screen.height/4f-100, 300, 75), "", menuButton)) {
			Application.LoadLevel ("appartment");
		}
	}

	// Check for a key press as well
	void Update () {
		if (Input.GetKeyDown (KeyCode.N)) {
			Application.LoadLevel ("appartment");
		}
	}
}