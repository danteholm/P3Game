using UnityEngine;
using System.Collections;

public class keys : MonoBehaviour {

	// Enum used to define the various types of keys available
	// There might not even be a need for three types, they're just there for now
	public enum Keys {brokenKey, rustyKey, normalKey}

	// The public variable, in which you can define what type of key the object that this script is attached to is
	public Keys whatTypeKey;
}