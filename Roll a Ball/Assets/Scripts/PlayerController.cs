using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;

	public GameObject pickUps;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		winText.gameObject.SetActive (false);
		UpdateTextCount ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVetical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVetical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			UpdateTextCount ();
		}
	}

	void UpdateTextCount(){
		countText.text = "Count: " + count.ToString ();
		if (count == pickUps.transform.childCount) {
			winText.gameObject. SetActive (true);
		}
	}
}
