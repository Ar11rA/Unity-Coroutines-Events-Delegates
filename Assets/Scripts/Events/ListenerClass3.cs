using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerClass3 : MonoBehaviour  {

	void OnEnable() {
		BallController.deathEvent += this.onPlayerDeath;
	}

	void OnDisable() {
		BallController.deathEvent -= this.onPlayerDeath;
	}

	public void onPlayerDeath() {
		Debug.Log("Listener 3 response");
		BallController.deathEvent -= this.onPlayerDeath;
	}
}
