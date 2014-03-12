using UnityEngine;
using System.Collections;

public class Chestmenu2 : MonoBehaviour {
	//	private List<Texture2D> ItemRandom = new List <Texture2D>();
	
	public Texture2D Item1, Item2, Item3;
	
	private float radius; 
	private float Luck;
	private float RandomNumber;
	
	public bool PopBool = false;
	private bool Obtain1, Obtain2, Obtain3;
	public bool doWindow0 = true;
	
	private Rect PopMenu = new Rect(Screen.width - 200 ,0,200,100);
	
	void Start(){

		radius = transform.localScale.x;
	}
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
			dist = Mathf.Sqrt(dist);
			if(dist < radius){
				Debug.Log(Obtain1);
				PopBool = true;
			}
		}
	}
	void DoWindow0(int windowID ) {
		if (GUI.Button(new Rect(0,30, 50,50),	Item1,GUIStyle.none)){
			if(!Obtain1){

			}
			Debug.Log("This slot is empty");
		}
		if (GUI.Button(new Rect(50,30, 50,50), 	Item2,GUIStyle.none)){
			if(!Obtain2){
				
			}
			Debug.Log("This slot is empty");
		}
		if (GUI.Button(new Rect(100,30, 50,50), Item3,GUIStyle.none)){
			if(!Obtain3){
				Debug.Log("OBTAINED SWORD");
				Item3 = Item1;
			}
		}
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
		if (PopBool){
			GUI.Window(0, PopMenu, DoWindow0, "Chest",GUIStyle.none);
		}
		
	}
}