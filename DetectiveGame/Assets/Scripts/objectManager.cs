using UnityEngine;
using System.Collections;

public class objectManager : MonoBehaviour {

	// Use this script to create new types. Not the previous ones

	// Enums are used to define the various types of objects available
	public enum Doors {none, frontDoor, bedroomDoor, bathroomDoor, kitchenDoor1, kitchenDoor2, officeDoor, livingRoomDoor}
	public enum Keys {none, bedroomKey, kitchenKey, secretKey, hallKey, livingRoomKey}
	public enum Items {none, paperNote, firstClue, secondClue}
	public enum InteractiveObject {none, bomb, newspaper1, newspaper2, newspaper3, globusRotate, globusOpen, stove, bedroomTable1, bedroomTable2, hallwayDresser, bedroomChest, livingRoomChest}
	public enum Hints {none, hint1, hint2, hint3}
	public enum Puzzle {none, keyPad}

	// The public variable, in which you can define what type of the specified object that it is
	public Doors whatTypeDoor;
	public Keys whatTypeKey;
	public Items whatTypeItem;
	public InteractiveObject whatObjectAmI;
	public Hints whatHintIsThis;
	public Puzzle whatPuzzle;

}
