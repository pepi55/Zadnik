using UnityEngine;
using System.Collections;

public class ChestMenu : MonoBehaviour {

	private float radius;
	public bool PopBool = false;
	public bool doWindow0 = true;
	private Rect PopMenu = new Rect(0,0,Screen.width,Screen.height);
	// Use this for initialization
	void Start(){
		radius = transform.localScale.x;
	}
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
			dist = Mathf.Sqrt(dist);
			if(dist < radius){
				PopBool = true;
			}
		}
	}
	void DoWindow0(int windowID) {
		if(GUI.Button(new Rect(10, 30, 80, 20), "Leave")){
			//Destroy.
			PopBool = false;
		}
	}
	void OnGUI() {
		//doWindow0 = GUI.Toggle(new Rect(10, 10, 100, 20), doWindow0, "Window 0");
		if (PopBool)
			GUI.Window(0, new Rect(110, 10, 200, 60), DoWindow0, "Inside of Chest");
		
	}
}
