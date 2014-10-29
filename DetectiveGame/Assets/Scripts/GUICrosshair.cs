using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour {
	public Texture2D crosshairImage;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width/2,Screen.height/2,50,50),crosshairImage);
	}
}
