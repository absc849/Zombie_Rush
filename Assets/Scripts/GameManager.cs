using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour {

	//singletons ensure that only one instance of the class is created and also provides a global point of access to the object.
	//static so there can only be one
	public static GameManager instance;

	//we are just going to set this as inactive, all GameObjects have active or inactive values
	[SerializeField]
	private GameObject mainMenu;
	[SerializeField]
	private GameObject gameOverScreen;
	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;
	public Text scoreTxt;
	private float score = 0;
	//private float currentScore = 0;
	
	public float Score{
		get {return score;}
	}



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
		StartCoroutine (WaitForGameOver());

	}

	public void PlayerStartedGame() {
		playerActive = true;
	}

	public void EnterGame() {
		mainMenu.SetActive (false);
		gameStarted = true;
	}

	public void RestartGame() {
		playerActive = false;
		gameOver = false;
		gameStarted = false;
		gameOverScreen.SetActive (false);
		SceneManager.LoadScene ("Game");

	}

	public void EndGame() {
		gameOverScreen.SetActive (true);
		scoreTxt.text = "Score: " + score;
	}


	public void AddScore (){
		score += 20;
		//scoreTxt.text = "Score: " + score;
	}

	IEnumerator WaitForGameOver(){
		yield return new WaitForSeconds (3.0f);
			
		EndGame ();

	}

}
