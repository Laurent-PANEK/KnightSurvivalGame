using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMethod : MonoBehaviour {
	public Animation anim;
	public void Start () {
		anim = GetComponent<Animation> ();
	}

	public void Update () {
		if (Input.GetKeyDown ("e")) {
			anim.Play ("animation");
		}
	}
}