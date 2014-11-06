using UnityEngine;
using System.Collections;

public class menuControls : MonoBehaviour {
	
	// Bool to determine when to render the hover effect
	public GUIStyle menuButton;
	
	// Draw button
	void OnGUI () {
		if (GUI.Button(new Rect(Screen.width/2f-100, Screen.height/4f-25, 375, 75), "", menuButton)) {
			Application.LoadLevel ("controls");
		}
	}

	// Check for a key press as well
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			Application.LoadLevel ("controls");
		}
	}
}