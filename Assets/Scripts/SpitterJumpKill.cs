using UnityEngine;
using System.Collections;

public class SpitterJumpKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D( Collider2D other ){
		if (other.gameObject.tag == "Player") {
			SendMessageUpwards("Squash");
			gameObject.GetComponent<Collider2D>().enabled = false;
		}
	}
}
