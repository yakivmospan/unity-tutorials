using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public float startWait;

	public GameObject[] hazards;
	public int hazardCount;

	public Vector3 spawnTransform;
	public float spawnWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		restartText.text = "";
		gameOverText.text = "";

		UpdateScore();
		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		if (restart && Input.GetKey(KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	
	IEnumerator SpawnWaves () {
		while (true) {
			yield return new WaitForSeconds(startWait);
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards [Random.Range(0, hazards.Length)];
				Instantiate (
					hazard,
					new Vector3 (Random.Range (-spawnTransform.x, spawnTransform.x), spawnTransform.y, spawnTransform.z), 
					Quaternion.identity
				);
				yield return new WaitForSeconds (spawnWait);
			}

			if (gameOver) {
				restart = true;
				restartText.text = "Press 'R' key to Restart";
				break;
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

	public void GameOver(){
		gameOver = true;
		gameOverText.text = "Game Over";
	}
}
