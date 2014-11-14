using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

public class CharacterControls : MonoBehaviour {
	
	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;

	private bool grounded = false;
	private Animation anim;
	protected Animator animator;
	public float DirectionDampTime = .25f;
		
	void Awake () {
		rigidbody.freezeRotation = true;
		rigidbody.useGravity = false;
	}

	
	void Start () 
	{
		animator = GetComponent<Animator>();

	}
	void FixedUpdate () {

		if (GameObject.FindWithTag ("Player").GetComponent<MouseLook>().cutSceneOn == true) {
			if (grounded) {

				// Calculate how fast we should be moving
				Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				targetVelocity = transform.TransformDirection(targetVelocity);
				targetVelocity *= speed;
			
			
				// Apply a force that attempts to reach our target velocity
				Vector3 velocity = rigidbody.velocity;
				Vector3 velocityChange = (targetVelocity - velocity);
				velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
				velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
				velocityChange.y = 0;
				rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
			}
			
			// We apply gravity manually for more tuning control
			rigidbody.AddForce(new Vector3 (0, -gravity * rigidbody.mass, 0));
			
			grounded = false;

		//	if (Input.GetAxis ("Horizontal") > 0.1f || Input.GetAxis ("Vertical") > 0.1f) {
		//		GameObject.Find("Player").animation.CrossFade ("walking_1");

		//	} else if (Input.GetAxis ("Horizontal") < 0.1f || Input.GetAxis ("Vertical") < 0.1f) {
		//		GameObject.Find("Player").animation.CrossFade ("31_08");
		//	}
			if(animator)
			{
				//get the current state
				AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
				
				//if we're in "Run" mode, respond to input for jump, and set the Jump parameter accordingly. 
				if(stateInfo.nameHash == Animator.StringToHash("Base Layer.RunBT"))
				{
					if(Input.GetButton("Fire1")) 
						animator.SetBool("Jump", true );
				}
				else
				{
					animator.SetBool("Jump", false);				
				}
				
				float h = Input.GetAxis("Horizontal");
				float v = Input.GetAxis("Vertical");
				
				//set event parameters based on user input
				animator.SetFloat("Speed", h*h+v*v);
				animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
			}		


		}
	}
	
	
	void OnCollisionStay () {
		grounded = true;    
	}
	

}