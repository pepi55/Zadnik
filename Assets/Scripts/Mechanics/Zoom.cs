using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour 
{
/*	Vector2 touch0, touch1;
	float distanceOld;
	private float distance;
	// Use this for initialization
	void Start () {
		camera.farClipPlane = 10.0F;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount >= 2){

			touch0 = Input.GetTouch(0).position;
			touch1 = Input.GetTouch(1).position;
			
			distance =  Vector2.Distance(touch0, touch1);
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				distanceOld = Vector2.Distance(touch0, touch1);
			}
			if(distance < distanceOld){
				camera.farClipPlane = distance;
			//	Debug.Log(distance);
			}
		}
	}
*/
	static bool zoomUp;
	static bool zoomDown;

	void Update()
	{
		if(GlobalValues.zoomUp){
			ZoomCamera(-1);
			GlobalValues.zoomUp = false;
		}
		if(GlobalValues.zoomDown){
			ZoomCamera(1);
			GlobalValues.zoomDown = false;
		}
	}

	private void ZoomCamera(float zoomFactor)
	{
		camera.orthographicSize = Mathf.Clamp(camera.orthographicSize += zoomFactor, 1, 5);
	}
}
