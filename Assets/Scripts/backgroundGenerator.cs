using UnityEngine;
using System.Collections;

public class backgroundGenerator : MonoBehaviour {


	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		// If the player is still living, keep movin'
		if (GameManager.instance.playerLiving) {
			transform.position -= transform.right * speed * Time.deltaTime;
			float amtToMove = speed * Time.deltaTime;
			//transform.Translate (Vector3.down * amtToMove, Space.World);
			
			if (transform.position.x < -14.5f) 
			{
				
				transform.position = new Vector3(15.5f, transform.position.y, transform.position.z); 
			}
		}


	}
}
