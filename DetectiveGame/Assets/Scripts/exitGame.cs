using UnityEngine;
using System.Collections;

public class exitGame : MonoBehaviour {
	
	void Start () {
		
		// Prevents object from being destroyed when loading a level
		DontDestroyOnLoad(gameObject);
	}

	void Update () {

		/*if (Input.GetKey (KeyCode.Escape)) {
			
			// Quits game
			Application.Quit();
		}*/
	}
}
