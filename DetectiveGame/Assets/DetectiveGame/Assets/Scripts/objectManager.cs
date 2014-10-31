using UnityEngine;
using System.Collections;

public class objectManager : MonoBehaviour {

	// Use this script to create new types. Not the previous ones

	// Enums are used to define the various types of objects available
	public enum Doors {none, frontDoor, bedroomDoor, bathroomDoor, kitchenDoor1, kitchenDoor2, officeDoor, livingRoomDoor}
	public enum Keys {none, bedroomKey, kitchenKey, secretKey, hallKey, livingRoomKey}
	public enum Misc {none, paperNote, firstClue, secondClue, keyPad}
	public enum Puzzle {none, keyPad}

	// The public variable, in which you can define what type of the specified object that it is
	public Doors whatTypeDoor;
	public Keys whatTypeKey;
	public Misc whatTypeItem;
	public Puzzle whatPuzzle;
}
