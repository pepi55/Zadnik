using UnityEngine;
using System.Collections;

public class ZoomChoice : MonoBehaviour {
	private float radius;
	public bool positive;
	void Awake(){
		if(positive){
			transform.position = new Vector2(Screen.width / 10 * 8, Screen.height / 10 * 8);
		}
	}
	// Use this for initialization
	void Start () {
		radius = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.touchCount == 1){
		if(Input.GetMouseButton(0)){
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
			dist = Mathf.Sqrt(dist);
			
			if(dist < radius){
				Debug.Log(GlobalValues.zoomUp);
				if(positive){
					GlobalValues.zoomUp = true;
				}
				if(!positive){
					GlobalValues.zoomDown = true;
				}
			}
		}
	}
}
