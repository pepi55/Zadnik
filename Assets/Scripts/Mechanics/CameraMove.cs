using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	private Vector2 touch;
	private Vector2 touchBegin;
	private Vector2 mousePos;
	private int CameraPos;
	private float distX;
	private float distY;
	public 	float intensity = 8;

	private Vector2 pos;
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		intensity = intensity  + 1;

		pos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.touchCount == 2){
			Vector2 touch = new Vector2();
			Vector2 touchBegin = new Vector2();

			//---------------------- De begin van de aanraking op het scherm----------------------------//
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				mousePos = Input.GetTouch(0).position;
			}

			//---------------------Als de touch een halve seconde stilstaat-----------------------------//
			if(Input.GetTouch(0).phase == TouchPhase.Stationary){
				mousePos = Input.GetTouch(0).position;
			}

			//----------------------- Wanneer de beweging gebeurt ---------------------------//
			if(Input.GetTouch(0).phase == TouchPhase.Moved){
				touchBegin = mousePos;
				touch = Input.GetTouch(0).position;
				distX = touchBegin.x - touch.x ;
				distY = touchBegin.y - touch.y ;

				if(distX > 10){
					//Debug.Log("Left");
					transform.Translate(distX / intensity,0,0);
				}else if(distX < -10){
					//Debug.Log("Right" + distX +"TouchX"+ touchBegin.x +"TouchX2"+ touch.x);
					transform.Translate(distX / intensity,0,0);
				}
				/*--- Y pos ---*/
				if (transform.position.y > 8.74f) {
					pos.y = -9.5f;

					transform.position = pos;
				}

				if (transform.position.y < -9.5f) {
					pos.y = 8.74f;

					transform.position = pos;
				}
				/*--- X pos ---*/
				if (transform.position.x > 12.12174f) {
					pos.x = -9.5f;

					transform.position = pos;
				}

				if (transform.position.x < -9.5f) {
					pos.x = 12.12174f;

					transform.position = pos;
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
