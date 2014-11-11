using UnityEngine;
using System.Collections;

public class objectManager : MonoBehaviour {

	/*
	 ************************************************* 
	 * THIS SCRIPT HANDLES ALL THE BEHIND THE SCENES *
	 * FUNCTIONALITY OF OBJECTS IN THE GAME THAT ARE *
	 * USED FOR ANY AND ALL USER INTERACTION!!       *
	 *************************************************
	 */

	// Enums are used to define the various types of objects available
	public enum Doors {none, frontDoor, bedroomDoor, bathroomDoor, kitchenDoor1, kitchenDoor2, officeDoor, livingRoomDoor}
	public enum Keys {none, bedroomKey, kitchenKey, secretKey, hallKey, livingRoomKey}
	public enum Items {none, paperNote, firstClue, secondClue, wireCutter}
	public enum InteractiveObject {none, bomb, killerSelfie, newspaper1, newspaper2, newspaper3, globusRotate, globusOpen, stove, bedroomTable1, bedroomTable2, hallwayDresser, bedroomChest, livingRoomChest}
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
