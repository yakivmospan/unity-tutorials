using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}

		if (gameController == null) {
			Debug.Log ("Game Controller is not set.");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag != "Boundary") {
			Destroy(other.gameObject);
			Destroy(gameObject);
			gameController.AddScore (scoreValue);

			if (other.tag == "Player") {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
			}
			Instantiate (explosion, transform.position, transform.rotation);
		}
	}
}
