using UnityEngine;
using System.Collections;

public class doors : MonoBehaviour {

	// Enum used to define the various types of doors available
	// There might not even be a need for three types, they're just there for now
	public enum Doors {lockedDoor, unlockedDoor, normalDoor}

	// The public variable, in which you can define what type of door the object that this script is attached to is
	public Doors whatTypeDoor;
}