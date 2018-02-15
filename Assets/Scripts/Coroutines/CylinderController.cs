using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour {

	IEnumerator currentMoveCoroutine;

	public Transform[] path;

	void Start () {
		string[] messages = { "Say", "hello", "to", "coroutines" }; 
		Debug.Log ("Starting Log");
		StartCoroutine (PrintMessages (messages, 1f)); 
		//DisplayMessages(messages, 1f);
		Debug.Log ("Ending Log");
		StartCoroutine (FollowPath ());
	}

	// With coroutines
	IEnumerator PrintMessages(string[] messages, float delay) {
		foreach (string message in messages) {
			Debug.Log (message);
			yield return new WaitForSeconds (delay);
		}
	}

	// Without coroutines
	void DisplayMessages(string[] messages, float delay) {
		foreach (string message in messages) {
			Debug.Log (message);
		}
	}

	IEnumerator Move(Vector3 destination, float speed) {
		while (transform.position != destination) {
			transform.position = Vector3.MoveTowards (transform.position, destination, speed * Time.deltaTime);
			yield return null;
		}
	}

	IEnumerator FollowPath() {
		foreach (Transform waypoint in path) {
			yield return StartCoroutine (Move (waypoint.position, 8));
		}
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (currentMoveCoroutine != null) {
				StopCoroutine (currentMoveCoroutine);
			}
			currentMoveCoroutine = Move (Random.onUnitSphere * 5, 8);
			StartCoroutine (currentMoveCoroutine);
		}
	}
		
}
