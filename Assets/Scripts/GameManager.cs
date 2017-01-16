using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//singletons ensure that only one instance of the class is created and also provides a global point of access to the object.
	//static so there can only be one
	public static GameManager instance;

	private bool playerActive = false;
	private bool gameOver = false;

	public bool PlayerActive{
		get {return playerActive;}
	}

	public bool GameOver{
		get {return gameOver;}
	}


	void Awake(){
		if (instance == null) {
			instance = this;
			// this = the current instance 
		} else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayerCollided() {
		gameOver = true;

	}

	public void PlayerStartedGame() {
		playerActive = true;
	}
}
