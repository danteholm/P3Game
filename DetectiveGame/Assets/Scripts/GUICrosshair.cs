using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour {
	public Texture2D crosshairImage;

	// Renders the crosshair on the screen
	// It only shows up when cutscenes aren't being played
	// It doesn't show up if the interact button is currently on the screen

	void OnGUI() {

		if (GameObject.FindWithTag ("Player").GetComponent<MouseLook>().cutSceneOn == true) {

			if (GameObject.Find ("Main Camera").GetComponent<Raycast>().imLookingAt == false) {
				GUI.Label (new Rect (Screen.width/2, Screen.height/2, 50, 50), crosshairImage);
			}
		}
	}
}
