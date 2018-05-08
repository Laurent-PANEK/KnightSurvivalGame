using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {

	public float speed = 3.0f;
	public float rotationSpeed = 150.0f;
	public int damage = 20;
	void Update () {

		float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		RaycastHit hit;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate (0, 0, translation);
		transform.Rotate (0, rotation, 0);
		if (Input.GetKeyDown ("space")) {
			if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit)) {
				if (hit.distance <= 2) {
					GameObject.Find ("Dragonblade").GetComponent<Animation> ().Play ("Attack");
					hit.transform.SendMessage ("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}