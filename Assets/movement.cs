using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public float Speed, RotationSpeed, StrenghtJump;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float MovSpeed = Time.deltaTime * Speed;
		float RotSpeed = Time.deltaTime * RotationSpeed;

		Rigidbody r = GetComponent<Rigidbody> ();

		if (r) {
			if (Input.GetKey (KeyCode.D)) {
				transform.Rotate (new Vector3 (0, RotSpeed, 0));
			}
			if (Input.GetKey (KeyCode.Q)) {
				transform.Rotate (new Vector3 (0, -RotSpeed, 0));
			}
			if (Input.GetKey (KeyCode.Z)) {
				r.AddForce (transform.forward * MovSpeed);
			}
			if (Input.GetKey (KeyCode.S)) {
				r.AddForce (-transform.forward * MovSpeed);
			}
		}
	}
}
