using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour {
	private bool jump = false;
	private float yStart = 0.0f;
	private float yEnd = 0.0f;
	private float diffrence ;
	private bool Began = false;
	private bool Moved = false;

	void Update () {
		//----leest af hoeveel vingers er op het scherm zitten zovaak gaat het hierdoorheen
		for (var i = 0; i < Input.touchCount; ++i) {
			//Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
			//RaycastHit hit;
			if (Input.GetTouch(i).phase == TouchPhase.Began){
				yStart = Input.GetTouch(0).position.y;
				Began = true;
			}  
			
			if (Input.GetTouch(i).phase == TouchPhase.Moved){
				Moved = true;
				yEnd = Input.GetTouch(0).position.y;
				diffrence = yEnd - yStart;
				Debug.Log(diffrence);	
				if ((yStart < yEnd && diffrence > 50  )) {
					Debug.Log("yEnd");
					jump = true;
				}
			}
			if (Input.GetTouch(i).phase == TouchPhase.Ended) {
				yStart = 0.0f;
				
				yEnd = 0.0f;
				
				yEnd = Input.GetTouch(0).position.y;
				diffrence = yEnd - yStart;
				if (Began == true && Moved == false ) {
					Moved = false;
					Began = false;

				}
				
				if (Began  && Moved && jump) {
					rigidbody.AddForce(Vector3.up * 4000 * Time.deltaTime );
					jump = false;  
					
				}
			}
			
		}  
	}
}
