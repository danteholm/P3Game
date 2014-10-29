using UnityEngine;
using System.Collections;

public class barShow : MonoBehaviour {
	
	void Update () {

		// Shows the item bar while inventoryOn is enabled
		if (GameObject.Find ("Main Camera").GetComponent<userInterface>().inventoryOn == true) {
			gameObject.SetActive (true);
		} else {
			gameObject.SetActive (false);
		}
	}
}
