using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

	private Animator anim;
	private Rigidbody rb;
	private bool jump = false;
	[SerializeField]
	private float jumpForce = 100f;
	[SerializeField] 
	private AudioClip sfxJump;
	[SerializeField]
	private AudioClip sfxDeath;
	private AudioSource audioSource;
	private float score = 0;
	private float currentScore = 0;

	public float Score{
		get {return score;}
	}

	// awake is good for assertions and components that need to be initialized before start
	void Awake() {
		Assert.IsNotNull (sfxJump);
		Assert.IsNotNull (sfxDeath);
	}

	
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		// use fixed update if using rigid body
		score = currentScore;
		if (!GameManager.instance.GameOver && GameManager.instance.GameStarted) {
			if (Input.GetMouseButtonDown (0)) {

				GameManager.instance.PlayerStartedGame();
				// 0 left click
				// 1 right click or mac double click
				anim.Play ("Jump");
				audioSource.PlayOneShot (sfxJump);
				rb.useGravity = true;
				jump = true;

			}
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

	void OnCollisionEnter(Collision collision) // this can be left empty you dont always need to collect information about the collison
	{
		if (collision.gameObject.tag.Equals ("Obstacle")) {
			rb.AddForce (new Vector2 (-50, 20), ForceMode.Impulse);
			rb.detectCollisions = false;
			audioSource.PlayOneShot (sfxDeath);
			GameManager.instance.PlayerCollided ();

		}//next part doesnt work 
		else if (collision.gameObject.tag.Equals ("Coin")) {
			currentScore = score + 20;
			print (currentScore);

		}
	}

}
