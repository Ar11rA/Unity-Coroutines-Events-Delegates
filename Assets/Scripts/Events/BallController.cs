using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using System;

public class BallController : MonoBehaviour {

	private Rigidbody rb;

	public float speed;

	public delegate void DeathDelegate();
	public static event DeathDelegate deathEvent;

	/*
	NOTE - The above two statements can be replaced by:
	public static event Action deathEvent
	*/
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Wall")) {
			die ();
		}
	}

	void die() {
		Debug.Log ("Collided with wall");
		deathEvent ();
		Destroy (gameObject);
	}
}
