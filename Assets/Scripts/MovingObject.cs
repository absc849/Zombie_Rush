using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	[SerializeField]
	float objectSpeed = 1;

	[SerializeField]
	private float resetPos = 9.8f;

	[SerializeField]
	private float startPos = -88.3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		// protected virtual allows subclass to override update or just call it from the parent

		if (!GameManager.instance.GameOver) {
	
			transform.Translate (Vector3.right * (objectSpeed * Time.deltaTime));
			if (transform.localPosition.x >= resetPos) {
				Vector3 newPos = new Vector3 (startPos, transform.position.y, transform.position.z);
				transform.position = newPos;

			}
		}
	}
}
