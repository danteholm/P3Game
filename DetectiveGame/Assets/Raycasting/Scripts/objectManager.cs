using UnityEngine;
using System.Collections;

public class objectManager : MonoBehaviour {

	// Use this script to create new types. Not the previous ones

	// Enums are used to define the various types of objects available
	public enum Doors {frontDoor, bedroomDoor, bathroomDoor, kitchenDoor1, kitchenDoor2, officeDoor, livingroomDoor, none}
	public enum Keys {bedroomKey, Key2, Key3, Key4, Key5, Key6, none}
	public enum Misc {paperNote, firstClue, secondClue, none}

	// The public variable, in which you can define what type of the specified object that it is
	public Doors whatTypeDoor;
	public Keys whatTypeKey;
	public Misc whatTypeItem;
}
