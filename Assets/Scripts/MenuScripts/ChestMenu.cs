using UnityEngine;
using System.Collections;

public class ChestMenu : MonoBehaviour {

	private float radius;
	public bool PopBool = false;
	public bool doWindow0 = true;
	private Rect PopMenu = new Rect(Screen.width - 120 ,0,120,100);
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
			Destroy(gameObject);
			PopBool = false;
		}
	}
	void OnGUI() {
		//doWindow0 = GUI.Toggle(new Rect(10, 10, 100, 20), doWindow0, "Window 0");
		if (PopBool)
			GUI.Window(0, PopMenu, DoWindow0, "Chest");
		
	}
}
