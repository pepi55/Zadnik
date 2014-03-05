using UnityEngine;
using System.Collections;

public class ChestMenu : MonoBehaviour {

	private float radius;
	public Texture2D Item, Empty;
	public bool PopBool = false;
	public bool doWindow0 = true;
	private Rect PopMenu = new Rect(Screen.width - 200 ,0,200,100);
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
		GUI.Button(new Rect(0,30, 50,50), Item,GUIStyle.none);
		GUI.Button(new Rect(50,30, 50,50), Empty,GUIStyle.none);
		GUI.Button(new Rect(50,30, 50,50), Empty,GUIStyle.none);
		if(GUI.Button(new Rect(10, 80, 100, 20), "Leave")){
			Destroy(gameObject);
			PopBool = false;
		}
		if(GUI.Button(new Rect(200 - 20, 0, 20, 20), "X",GUIStyle.none)){
			Destroy(gameObject);
			PopBool = false;
		}
	}
	void OnGUI() {
		//doWindow0 = GUI.Toggle(new Rect(10, 10, 100, 20), doWindow0, "Window 0");
		if (PopBool)
			GUI.Window(0, PopMenu, DoWindow0, "Chest",GUIStyle.none);
		
	}
}
