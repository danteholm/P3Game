using UnityEngine;
using System.Collections;

public class menuNewGame : MonoBehaviour {

	// GUIStyle that, via the Unity inspector, defines the style for the menu buttons
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