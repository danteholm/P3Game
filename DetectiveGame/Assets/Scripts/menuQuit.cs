﻿using UnityEngine;
using System.Collections;

public class menuQuit : MonoBehaviour {
	
	// GUIStyle that, via the Unity inspector, defines the style for the menu buttons
	public GUIStyle menuButton;
	
	// Draw button
	void OnGUI () {
		if (GUI.Button(new Rect(Screen.width/2f-38, Screen.height/4f+50, 250, 75), "", menuButton)) {
			Application.Quit ();
		}
	}

	// Check for a key press as well
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit ();
		}
	}
}