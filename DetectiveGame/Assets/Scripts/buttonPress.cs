using UnityEngine;
using System.Collections;

public class buttonPress : MonoBehaviour {

	public bool restartGame;

	void Update () {

		Screen.lockCursor = false;
	}

	void OnGUI () {
		
		// Make the first button. If it is pressed, Application.Loadlevel (0) will be executed
		if(GUI.Button(new Rect(Screen.width/2-90,Screen.height/1.3f,180,70), "End Game")) {

			restartGame = true;
			Application.LoadLevel("main");
		}
	}
}