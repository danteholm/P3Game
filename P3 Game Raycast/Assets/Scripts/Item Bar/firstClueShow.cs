using UnityEngine;
using System.Collections;

public class firstClueShow : MonoBehaviour {

	void Start () {
	}

	void OnGUI () {

		// Shows the item while inventoryOn is enabled, and the player has received the item
		if (GameObject.Find ("Main Camera").GetComponent<userInterface>().showFirstClue == true) {
			gameObject.SetActive (true);
		}
	}
}
