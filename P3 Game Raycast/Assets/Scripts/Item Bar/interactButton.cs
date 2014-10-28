using UnityEngine;
using System.Collections;

public class interactButton : MonoBehaviour {

	void Update () {
		
		// Shows the item while inventoryOn is enabled, and the player has received the item
		if (GameObject.Find ("Main Camera").GetComponent<Raycast>().imLookingAt == true) {
			gameObject.SetActive (true);
		} else {
			gameObject.SetActive (false);
		}
	}
}
