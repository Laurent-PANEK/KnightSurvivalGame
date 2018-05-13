using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 200;

	void Update () {
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
	void ApplyDamage (int damage) {
		health -= damage;
	}
}