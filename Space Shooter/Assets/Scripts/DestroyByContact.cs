using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explision;
	public GameObject playerExplision;

	void OnTriggerEnter(Collider other) {
		if (other.tag != "Boundary") {
			Destroy(other.gameObject);
			Destroy(gameObject);

			if (other.tag == "Player") {
				Instantiate (playerExplision, other.transform.position, other.transform.rotation);
			}
			Instantiate (explision, transform.position, transform.rotation);
		}
	}
}
