using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuerTime;
	public Vector2 maneuerWait;

	public Tilt tilt;
	public Boundary boundary;

	private float currentSpeed;
	private float targetManeuer;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		currentSpeed = rb.velocity.z;
		StartCoroutine (Evade ());
	}

	IEnumerator Evade(){
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));

		while (true) {
			targetManeuer = Random.Range (1, dodge) * -Mathf.Sign(transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuerTime.x, maneuerTime.y));
			targetManeuer = 0;
			yield return new WaitForSeconds (Random.Range (maneuerWait.x, maneuerWait.y));
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		float newTargetManeuer = Mathf.MoveTowards(rb.velocity.x, targetManeuer, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newTargetManeuer, 0.0f, currentSpeed);

		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));

		rb.rotation = Quaternion.Euler (
			rb.velocity.z * (rb.velocity.z > 0 ? tilt.verticalUp : tilt.verticalDown),
			0.0f,
			rb.velocity.x * -tilt.horizontal);	
	}

}
