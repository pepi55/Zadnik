using UnityEngine;
using System.Collections;

public class Chestmenu2 : MonoBehaviour {
	//	private List<Texture2D> ItemRandom = new List <Texture2D>();
	
	public Texture2D Item1, Item2, Item3,Item4, Item5, Item6;
	public Texture2D ItemRandom1,ItemRandom2,ItemRandom3;
	
	private float radius; 
	private float Luck;
	private float RandomNumber;
	
	public bool PopBool = false;
	public bool doWindow0 = true;
	private bool ChestReady = false;
	
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
				Debug.Log("WOOT");
				PopBool = true;
			}
		}
	}
	void DoWindow0(int windowID ) {
		if(GUI.Button(new Rect(0,30, 50,50),ItemRandom1,GUIStyle.none)){
			Debug.Log("FUCK ME");
		}
		GUI.Button(new Rect(50,30, 50,50), ItemRandom2,GUIStyle.none);
		GUI.Button(new Rect(100,30, 50,50), ItemRandom3,GUIStyle.none);
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
		if(ChestReady){
			if (PopBool){
				GUI.Window(0, PopMenu, DoWindow0, "Chest",GUIStyle.none);
			}
		}
		
	}
}