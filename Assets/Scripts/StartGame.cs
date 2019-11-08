using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 

	}

	public void StartTheGame(){
		Application.LoadLevel("SpaceRunner");
	}

	public void StartMenu() {
		Application.LoadLevel("SpaceRunnerMenu");
	}
}
