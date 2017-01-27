using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	public float startWait;

	public GameObject hazard;
	public int hazardCount;

	public Vector3 spawnTransform;
	public float spawnWait;

	public GUIText scoreText;

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore();
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves () {
		while (true) {
			yield return new WaitForSeconds(startWait);
			for (int i = 0; i < hazardCount; i++) {
				Instantiate (
					hazard,
					new Vector3 (Random.Range (-spawnTransform.x, spawnTransform.x), spawnTransform.y, spawnTransform.z), 
					Quaternion.identity
				);
				yield return new WaitForSeconds (spawnWait);
			}
		}
	}

	public void AddScore(int score){
		this.score += score;
		UpdateScore ();
	}

	public void UpdateScore(){
		scoreText.text = "Score: " + this.score;
	}
}
