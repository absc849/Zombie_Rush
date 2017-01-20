using UnityEngine;
using System.Collections;

public class Coin : MovingObject {

	[SerializeField]
	Vector3 topPos;
	
	[SerializeField]
	Vector3 bottPos;
	
	[SerializeField]
	float speed;


	//	[SerializeField]
	//	float rotateSpeed;
	

	
	// Use this for initialization
	void Start () {

		StartCoroutine (Move (bottPos));
	}
	

	protected override void Update()
	{
		if (GameManager.instance.PlayerActive) {
			//makes rocks fly off screen :(
			//transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
			
			base.Update ();
		}
	}


	IEnumerator Move(Vector3 target){
		//when you want to work with distance always use mathf.abs absolute value dont always do a - b if you have a 
		// negative number in a - b you will get incorrect information
		//mathf.abs(-10) is 10
		//local pos - where we currently are
		
		//.y because we only want the y pos
		while(Mathf.Abs((target-transform.localPosition).y) > 0.20f){
			//	print ((target-transform.localPosition).y);
			
			Vector3 direction = target.y == topPos.y ? Vector3.up : Vector3.down;
			// if target.y is equal to top position. y then do vector 3 up if not then do vector 3 down
			// ternary operations are better than if statements imo
			transform.localPosition += direction * Time.deltaTime * speed;
			
			// add this direction to the position
			
			
			
			
			yield return null;
			
			
		}
		
		yield return new WaitForSeconds (0.25f);
		
		Vector3 newTarget = target.y == topPos.y ? bottPos : topPos;
		
		StartCoroutine (Move (newTarget));
	}

	void OnTriggerEnter(Collider other) 
	{

		if (other.gameObject.name == "Player"){
			GameManager.instance.AddScore();
			print (GameManager.instance.Score);
		
			Destroy(gameObject);


			//audioSource.PlayOneShot(sfxDeath);
			//GameManager.instance.PlayerCollided();
		}

	}


}
