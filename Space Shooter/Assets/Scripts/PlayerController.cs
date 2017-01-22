using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tilt{
	public float horizontal, verticalUp, verticalDown;
}

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Tilt tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireDelta;
	private float nextFire = 0.0F;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireDelta;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVetical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVetical);
		rb.velocity = movement * speed; 

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
			
		rb.rotation = Quaternion.Euler (
			rb.velocity.z * (rb.velocity.z > 0 ? tilt.verticalUp : tilt.verticalDown),
			0.0f,
			rb.velocity.x * -tilt.horizontal);
	}
}
