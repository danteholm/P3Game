using UnityEngine;
using System.Collections;

public class misc : MonoBehaviour {
	
	// Enum used to define the various types of misc items available
	// There might not even be a need for three types, they're just there for now
	public enum Misc {paperNote, firstClue, secondClue}
	
	// The public variable, in which you can define what type of misc item the object that this script is attached to is
	public Misc whatTypeItem;
}