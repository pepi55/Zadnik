using UnityEngine;
using System.Collections;

public class Onvision : MonoBehaviour {
 	
	void Update () {
		Debug.Log("ben bezig");
	}
	void OnBecameVisible(){
		Debug.Log("Zichtbaar");
		enabled = true;
	}
	void OnBecameInvisible(){
		Debug.Log("Ontzichtbaar");
		enabled = false;
	}
}
