using UnityEngine;
using System.Collections;

public class enemyControl : MonoBehaviour {

	public float moveSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position -= transform.right * moveSpeed * Time.deltaTime;
		Destroy (gameObject, 6f); 
	}

	void Squash(){
		gameObject.GetComponent<Animator>().SetBool("dead", true);
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		Destroy (gameObject, 5f);
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "meteor"){
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None; 
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * 500); 
			Destroy (gameObject , 5f); 
		}
	}
}
