using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private GameObject[] Cubes;
	delegate float GetParameter(GameObject cube);
	// Use this for initialization
	void Start () {
		Cubes =  GameObject.FindGameObjectsWithTag("cube");

		Debug.Log(GetCubeMaxParamter (Cubes, cube => cube.transform.position.y ));
		Debug.Log(GetCubeMaxParamter (Cubes, cube => cube.transform.position.z));
		Debug.Log(GetCubeMaxParamter (Cubes, cube => cube.transform.position.x ));
		/*
		Debug.Log(GetCubeMaxParamter (Cubes, GetHeight));
		Debug.Log(GetCubeMaxParamter (Cubes, GetBreadth));
		Debug.Log(GetCubeMaxParamter (Cubes, GetLength));
		*/
		/*
		Debug.Log(GetCubeMaxHeight (Cubes));
		Debug.Log(GetCubeMaxBreadth (Cubes));
		Debug.Log(GetCubeMaxLength (Cubes));
		*/
	}

	int GetCubeMaxParamter(GameObject[] Cubes, GetParameter getParamter) {
		float maxHeight = 0.0f;
		int cubeNumber = 0;
		for (int i = 0; i < Cubes.Length; i++) {
			float currentParameter = getParamter (Cubes [i]);
			if (currentParameter > maxHeight) {
				maxHeight = currentParameter;
				cubeNumber = i + 1;
			}
		}
		return cubeNumber;
	}



	/* Delgate Method
	float GetHeight(GameObject cube) {
		return cube.transform.position.y;
	}

	float GetBreadth(GameObject cube) {
		return cube.transform.position.z;
	}

	float GetLength(GameObject cube) {
		return cube.transform.position.x;
	}
	*/


	/* Basic Method 
	int GetCubeMaxHeight(GameObject[] Cubes) {
		float maxHeight = 0.0f;
		int cubeNumber = 0;
		for (int i = 0; i < Cubes.Length; i++) {
			if (Cubes [i].transform.position.y > maxHeight) {
				maxHeight = Cubes [i].transform.position.y;
				cubeNumber = i + 1;
			}
		}
		return cubeNumber;
	}
		
	int GetCubeMaxLength(GameObject[] Cubes) {
		float maxLength = 0.0f;
		int cubeNumber = 0;
		for (int i = 0; i < Cubes.Length; i++) {
			if (Cubes [i].transform.position.x > maxLength) {
				maxLength = Cubes [i].transform.position.x;
				cubeNumber = i + 1;
			}
		}
		return cubeNumber;
	}

	int GetCubeMaxBreadth(GameObject[] Cubes) {
		float maxBreadth = 0.0f;
		int cubeNumber = 0;
		for (int i = 0; i < Cubes.Length; i++) {
			if (Cubes [i].transform.position.z > maxBreadth) {
				maxBreadth = Cubes [i].transform.position.z;
				cubeNumber = i + 1;
			}
		}
		return cubeNumber;
	}
	*/
}
