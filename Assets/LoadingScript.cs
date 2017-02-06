using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScript : MonoBehaviour {

	public static LoadingScript instance;

	void Awake(){
		if (instance == null) {
			instance = this;
			// this = the current instance 
		} else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad (gameObject);

	}
}
