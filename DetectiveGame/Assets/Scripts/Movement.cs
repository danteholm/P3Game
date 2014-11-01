using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	//GameObject player;
	RaycastHit hit;
	bool move = false;
	Vector3 newpos;
	//it's a good idea to have the speed as a public global variable so you can edit it in the graphical editor
	public float speed = 5f;
	public float Height = 15;
	
	void Start () {
		//player = GameObject.Find("Player"); //makes sure that the changes happen to the player
		hit = new RaycastHit();
	}
	
	void Update () {
		
		//if i press the left mousebutton a ray is shot from the camera to where my mouse is
		if (Input.GetMouseButton(0)) {
			//if (hit.transform.gameObject.tag == "Ground"){
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			//if it hits something ...
				if (Physics.Raycast(ray, out hit, 1000.0f)) {
				//it stores the new Vecter3 in newpos
				//also this gets deleted every frame if you don't define it as a global variable
					newpos = new Vector3(hit.point.x, Height, hit.point.z);
				//and it moves the player to the new position
				
				//If this is here it is only executed when you press the mouse button and the raycast hits, you want to set the target here and then execute the lerp or movetowards elsewere
				//player.transform.position = Vector3.MoveTowards(transform.position, newpos, Time.deltaTime*5);
				//instead we say
					move = true;
				//}
				//player.transform.position = newpos;
			}
		}
		if (move){
			transform.position = Vector3.MoveTowards(transform.position, newpos, Time.deltaTime*speed);
			if (Vector3.Distance(transform.position, newpos) < 0.1f){
				move = false;
			}
		}
		
		//lets me see the raycasting
		Ray testray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (testray.origin, testray.direction* 1000, Color.cyan);
		
	}
}

