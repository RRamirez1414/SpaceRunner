using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
	public GameObject platformPrefab;
	public float spawnTime = 2f;
	private float currSpawnTime;
	// Use this for initialization
	void Start () {
		currSpawnTime = spawnTime;
	}
	
	// Update is called once per frame
	void Update () {
		currSpawnTime -= Time.deltaTime;
		// Ready to spawn a prefab?
		if (currSpawnTime < 0 && GameManager.instance.playerLiving) {
			Vector3 platformPos = new Vector3( 10f, Random.Range( -3f, 2f), 0f);
			Instantiate( platformPrefab, platformPos, Quaternion.identity);

			currSpawnTime = spawnTime;
		}
	}
}
