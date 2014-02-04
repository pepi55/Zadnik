using UnityEngine;
using System.Collections;

public class Inscreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Touch
		transform.Translate(Vector3(1,0,0) * Time.deltaTime);
	}
}
