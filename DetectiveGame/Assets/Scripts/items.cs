using UnityEngine;
using System.Collections;

public class items : MonoBehaviour {

	// Rudimentary item system, used to toggle items in the inventory, for now

	// Key variables
	public bool hasKitchenKey, hasLivingRoomKey, hasHallKey, hasSecretKey, hasBedroomKey;
	// Misc. item variables
	public bool hasNote, hasFirstNote, hasSecondNote, hasThirdNote, hasClue1;
	// Newspapers
	public bool readFirstNewspaper, readSecondNewspaper, readThirdNewspaper;
	// Hints
	public bool readHint1, readHint2, readHint3;
}