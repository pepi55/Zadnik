using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	private int CameraPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount >= 1){
			Debug.Log("hoi");
			Vector2 touch1;
			touch1 = Input.GetTouch(1).position;
			if(touch1.x > 0){
				Debug.Log("hoi");
				transform.Translate(1 * Time.deltaTime ,0,0);
			}
		}
	}
}
