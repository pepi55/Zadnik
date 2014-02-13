using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	private Vector2 touch;
	private Vector2 touchBegin;
	private int CameraPos;
	private float distX;
	private float distY;
	public 	float intensity = 8;
	// Use this for initialization
	void Start () {
		intensity = intensity + 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.touchCount == 2){
			//---------------------- De begin van de aanraking op het scherm----------------------------//
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				touchBegin = Input.GetTouch(0).position;

			}
			//---------------------Als de touch een halve seconde stilstaat-----------------------------//
			if(Input.GetTouch(0).phase == TouchPhase.Stationary){
				touchBegin = Input.GetTouch(0).position;

			}
			//----------------------- Wanneer de beweging gebeurt ---------------------------//
			if(Input.GetTouch(0).phase == TouchPhase.Moved){
				touch = Input.GetTouch(0).position;
				distX = touchBegin.x - touch.x ;
				distY = touchBegin.y - touch.y ;

				if(distX > 100){
					transform.Translate(distX / intensity,0,0);
				}else if(distX < 100){
					transform.Translate(distX / intensity,0,0);
				}

				if(distY > 100){
					transform.Translate(0,distY / intensity,0);
				}else if(distY < 100){
					transform.Translate(0,distY / intensity,0);
				}
			}
		}
	}
}
