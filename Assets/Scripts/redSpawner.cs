using UnityEngine;
using System.Collections;

public class redSpawner : MonoBehaviour {

	public float spawnInterval = 2f;
	private float currSpawnTime = 0f;
	
	public GameObject redPrefab;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// If we've reached our next spawn time, spawn an enemy!
		if (Time.time >= currSpawnTime){ 
			float rand = Random.Range (0 ,1000); 
			if ( rand > 900 ){
				Instantiate(redPrefab, transform.position, Quaternion.identity);
				currSpawnTime = Time.time + spawnInterval;
			}
		}
	}
}
