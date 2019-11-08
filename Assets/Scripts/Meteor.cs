using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	public float moveSpeed = 5f; 
	public float rotateSpeed = 2f;
	public float force = 10f;
	public float torqueForce = .2f; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		GetComponent<Rigidbody2D>().AddForce (Vector2.left * force);
		GetComponent<Rigidbody2D>().AddTorque (.2f);
		//transform.position -= transform.right * moveSpeed * Time.deltaTime; 
		//GetComponent<Rigidbody2D>().AddForce (Vector2.down * 10f); 
		Destroy (gameObject, 4f);
		 
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "floor"){
			Destroy (gameObject); 
		}
	}
}
