using UnityEngine;
using System.Collections;

public class ScreenRotation : MonoBehaviour {

	private Quaternion screenRotation;
	public float speed = 5;
	// Use this for initialization
	void Start () {
		screenRotation = transform.rotation;
		//Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		float newSpeed = speed * Time.deltaTime;

		screenRotation.x = Input.acceleration.x;
		screenRotation.y = Input.acceleration.y;

		Debug.Log(screenRotation.x);
		transform.rotation = screenRotation;

	}
}
