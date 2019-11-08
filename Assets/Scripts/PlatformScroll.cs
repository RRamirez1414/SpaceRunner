using UnityEngine;
using System.Collections;

public class PlatformScroll : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		if (GameManager.instance.playerLiving) {
			transform.position -= transform.right * speed * Time.deltaTime;
			//float amtToMove = speed * Time.deltaTime;
			//transform.Translate (Vector3.down * amtToMove, Space.World);
			
			if (transform.position.x < -15.7f) 
			{
				Destroy(gameObject);
			}
		}
	}
}
