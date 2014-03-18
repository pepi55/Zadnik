using UnityEngine;
using System.Collections;

public class ProfileTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Profile.StartProfile("Start");
	}
	
	// Update is called once per frame
	void Update () {
		Profile.StartProfile("Update");
		float y = 10;
		float x = y * y;
		Profile.EndProfile("Update");
	}

	void OnApplicationExit(){
		Profile.EndProfile("Start");
		Profile.PrintResults();

	}
}
