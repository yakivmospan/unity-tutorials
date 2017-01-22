using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazardAsteroid;
	public Vector3 spawnTransform;

	// Use this for initialization
	void Start () {
		SpawnWaves ();
	}
	
	void SpawnWaves () {
		Instantiate (
			hazardAsteroid,
			new Vector3(Random.Range(-spawnTransform.x, spawnTransform.x), spawnTransform.y, spawnTransform.z), 
			Quaternion.identity
		);
	}
}
