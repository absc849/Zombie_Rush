using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	private Rigidbody rb;
	private bool jump = false;
	[SerializeField]
	private float jumpForce = 100f;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		// use fixed update if using rigid body
		if (Input.GetMouseButtonDown (0)) {

	// 0 left click
			// 1 right click or mac double click
			anim.Play("Jump");
			rb.useGravity = true;
			jump = true;

		}
	}

	void FixedUpdate() {
		if (jump == true) {
			jump = false;
			rb.velocity = new Vector2(0,0); // good for double jumps 
			rb.AddForce(new Vector2(0,jumpForce), ForceMode.Impulse);
				// vector 2 because we dont care about the z value with jump just the y
		}

	}


}
