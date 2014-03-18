using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChestTest : MonoBehaviour {
	public Texture2D Item1, Item2, Item3;
	
	private float radius; 
	private float Luck;
	private float RandomNumber;
	
	private Animator animator;
	
	public bool PopBool = false;
	private bool Obtain1, Obtain2, Obtain3;
	public bool doWindow0 = true;
	
	private Rect PopMenu = new Rect(Screen.width - 200 ,0,200,100);
	public static Dictionary<int,string> lootDictionary = new Dictionary<int, string>(){
		{0,string.Empty},
		{1,string.Empty},
		{2,string.Empty},
	};
	AllItems itemObject = new AllItems();
	void Start(){
		lootDictionary[0] = itemObject.swordItem1.name;
		animator = GetComponent<Animator>();
		radius = transform.localScale.x;
		
	}
	
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
			dist = Mathf.Sqrt(dist);
			
			if(dist < radius){
				animator.SetBool("Open", true);

				PopBool = true;
			}
		}
		//	Destroy(gameObject);
	}

	void DoWindow0(int windowID ) {
		if (GUI.Button(new Rect(0,30, 50,50),	Item1,GUIStyle.none)){
			if(!Obtain1){
				Obtain1 = true;
				
			}else{
				Debug.Log("This slot is empty");
				
			}
		}
		if (GUI.Button(new Rect(50,30, 50,50), 	Item2,GUIStyle.none)){
			if(!Obtain2){
				Obtain2 = true;
				
			}else{
				Debug.Log("This slot is empty");
				
			}
		}
		if (GUI.Button(new Rect(100,30, 50,50), Item3,GUIStyle.none)){
			if(!Obtain3){
				Inventory.inventoryNameDictionary[0] = lootDictionary[0];
				Item3 = Item1;
				Obtain3 = true;
				
			}else{
				Debug.Log("This slot is empty");
				
			}
		}
		if(GUI.Button(new Rect(10, 80, 100, 20), "Leave")){
			animator.SetBool("Open", false);
			PopBool = false;
			
		}
		if(GUI.Button(new Rect(200 - 20, 0, 20, 20), "X",GUIStyle.none)){
			animator.SetBool("Open", false);
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
