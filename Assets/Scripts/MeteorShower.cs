using UnityEngine;
using System.Collections;

public class MeteorShower : MonoBehaviour {

	public GameObject meteorPrefab; 
	public float randnumber = 800; 
	public float maxRand = 2000; 
	public float showerTime = 3f; 
	private float currShowerTime; 
	// Use this for initialization
	void Start () {
		currShowerTime = showerTime;
	}
	
	// Update is called once per frame
	void Update () {
		currShowerTime -= Time.deltaTime;
		if (currShowerTime < 0 ) {
			float rand = Random.Range (0, 200);
			if (rand == 2) {
				Vector3 meteorPos = new Vector3 ( Random.Range ( 3f, 15f) , Random.Range (5f, 1.5f) , 0f);
				Instantiate(meteorPrefab, meteorPos, Quaternion.identity);
			} 
		}
	}
}
