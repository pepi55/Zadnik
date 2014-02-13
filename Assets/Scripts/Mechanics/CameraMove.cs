using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	private int CameraPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 2){
			Vector2 touch = new Vector2();
			Vector2 touchBegin = new Vector2();
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				touchBegin = Input.GetTouch(0).position;

			}
			if(Input.GetTouch(0).phase == TouchPhase.Moved){
				touch = Input.GetTouch(0).position;
				if(touchBegin.x < touch.x){
					transform.Translate(1,0,0);
				}else{
					transform.Translate(-1,0,0);
				}

			}
		}
	}
}
