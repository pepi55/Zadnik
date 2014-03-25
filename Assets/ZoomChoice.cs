using UnityEngine;
using System.Collections;

public class ZoomChoice : MonoBehaviour {
	private float radius;
	public bool positive;
	private bool zoombrade = false;
	public int zoomAmount;
	void Awake(){
		zoomAmount = 2;
		if(positive){
			transform.position = new Vector2(-3, 3);
		}else{
			transform.position = new Vector2(-4, 3);
		}
	}
	// Use this for initialization
	void Start () {
		radius = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(zoomAmount == 1 && zoombrade == false){
			if(positive){
				transform.position = new Vector2(-1, 1);
			}else{
				transform.position = new Vector2(-2, 1);
			}

			zoombrade = true;
		} 
		if(zoomAmount == 2 && zoombrade == false){
			if(positive){
				transform.position = new Vector2(-3, 3);
			}else{
				transform.position = new Vector2(-4, 3);
			}

			zoombrade = true;
		}
		if(zoomAmount == 3 && zoombrade == false){
			if(positive){
				transform.position = new Vector2(-5, 5);
			}else{
				transform.position = new Vector2(-6, 5);
			}

			zoombrade = true;
		}
		//if(Input.touchCount == 1){
		if(Input.GetMouseButton(0)){
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
			dist = Mathf.Sqrt(dist);
			
			if(dist < radius){
				if(positive){
					GlobalValues.zoomUp = true;
					zoombrade = false;
				}
				if(!positive){
					GlobalValues.zoomDown = true;
					zoombrade = false;
				}
			}
		}
	}
}
