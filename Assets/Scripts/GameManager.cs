using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	static public GameManager instance = null;

	public GameObject MainMenuButton;
	public GameObject RetryButton;
	public bool playerLiving = true;

	void Awake(){
		//Check if instance already exists
		if (instance == null)
			
			//if not, set instance to this
			instance = this;
		
		//If instance already exists and it's not this:
		else if (instance != this)
			
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    
		
		//Sets this to not be destroyed when reloading scene
		//DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PopMenu(){
		MainMenuButton.SetActive(true); 
		RetryButton.SetActive(true); 
	}
}
