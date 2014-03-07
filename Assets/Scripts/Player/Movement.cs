using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//int
	int x, y;

	void Start () {

	}

	/*void FixedUpdate () {
		if (GlobalValues.active) {

		}
	}*/

	public static void OnMove () {

	}

	public void MoveTo (Vector3 position) {
		transform.position = position;
	}
}