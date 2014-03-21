using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChestTest : MonoBehaviour {
//	AllItems itemObject = new AllItems();
	public Texture2D background, Item1, Item2, Item3, Empty;
	
	private float radius; 
	private float Luck;
	private float RandomNumber;
	
	private Animator animator;
	
	public bool PopBool = false;
	private bool Obtain1 = false ,Obtain2 = false, Obtain3 = false;
	public bool doWindow0 = true;
	private bool chestReady = false;
	
	private Rect PopMenu = new Rect(Screen.width - 200 ,0,200,100);

	public static Dictionary<int,Texture2D> lootDictionary = new Dictionary<int, Texture2D>(){
		{0,AllItems.emptyIcon},
		{1,AllItems.emptyIcon},
		{2,AllItems.emptyIcon},

	};


	void Start(){
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
		if(chestReady == false){
			lootDictionary[0] = AllItems.swordIcon1;
			lootDictionary[1] = AllItems.wandIcon;
		}
		if (GUI.Button(new Rect(0,30, 50,50),	Item1,GUIStyle.none)){
			if(!Obtain1){
				Obtain1 = true;
				
			}else{
				Debug.Log("This slot is empty");
				
			}
		}
		if (GUI.Button(new Rect(50,30, 50,50),Item2,GUIStyle.none)){
			if(!Obtain2){
				for(int i = 0; 0 < 9;i++){
					if(Inventory.inventoryNameDictionary[i] == null){
						Inventory.inventoryNameDictionary[i] = AllItems.swordIcon1;
						Item2 = null;
						Obtain2 = true;
						break;
					}
				}
			}else{
				Debug.Log("This slot is empty");
				
			}
		}
		if (GUI.Button(new Rect(100,30, 50,50), Item3,GUIStyle.none)){
			if(!Obtain3){
				for(int j = 0; 0 < 9;j++){
					if(Inventory.inventoryNameDictionary[j] == null){
					Inventory.inventoryNameDictionary[j] = lootDictionary[0];
					Item3 = null;
					Obtain3 = true;
						break;
					}
				}
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
		if (PopBool){
			GUI.Window(0, PopMenu, DoWindow0, "Chest",GUIStyle.none);
			if (background != null)
				GUI.DrawTexture(PopMenu,background);
			
		}
		
	}
}
