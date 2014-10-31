using UnityEngine;
using System.Collections;

public class objectManager : MonoBehaviour {

	// Use this script to create new types. Not the previous ones

	// Enums are used to define the various types of objects available
	public enum Doors {frontDoor, bedroomDoor, bathroomDoor, kitchenDoor1, kitchenDoor2, officeDoor,LivingRoomDoor, none}
	public enum Keys {bedroomKey, KitchenKey, SecretKey, HallKey,livingRoomKey, none}
	public enum Misc {paperNote, firstClue, secondClue, keyPad, none}

	// The public variable, in which you can define what type of the specified object that it is
	public Doors whatTypeDoor;
	public Keys whatTypeKey;
	public Misc whatTypeItem;
}
