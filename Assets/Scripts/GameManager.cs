using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	//singletons ensure that only one instance of the class is created and also provides a global point of access to the object.
	//static so there can only be one
	public static GameManager instance;

	//we are just going to set this as inactive, all GameObjects have active or inactive values
	[SerializeField]
	private GameObject mainMenu;
	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;

	public bool PlayerActive{
		get {return playerActive;}
	}

	public bool GameOver{
		get {return gameOver;}
	}

	public bool GameStarted{
		get {return gameStarted;}
	}


	void Awake(){
		if (instance == null) {
			instance = this;
			// this = the current instance 
		} else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad (gameObject);

		Assert.IsNotNull (mainMenu);
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

	public void EnterGame() {
		mainMenu.SetActive (false);
		gameStarted = true;
	}
}
