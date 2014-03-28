using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChestTest : MonoBehaviour {
//	AllItems itemObject = new AllItems();

	public Texture2D background, Item1, Item2, Item3, Empty;
	
	private float radius; 
	private float Luck;
	private float RandomNumber;
	private float SwPos = Screen.height / 10;
	private float ShPos = Screen.width / 10;
	
	private Animator animator;

	private bool clickable = true;
	private bool PopBool = false;
	private bool Obtain1 = false ,Obtain2 = false, Obtain3 = false;
	//private bool doWindow0 = true;
	private bool chestReady = false;
	
	private Rect PopMenu = new Rect(Screen.height - Screen.height / 10 * 3,0 ,Screen.height / 10 * 3,Screen.width / 10 * 3);

	public static Dictionary<int,Texture2D> lootDictionary = new Dictionary<int, Texture2D>(){
		{0,AllItems.emptyIcon},
		{1,AllItems.emptyIcon},
		{2,AllItems.emptyIcon},

	};


	void Awake(){
		animator = GetComponent<Animator>();
		radius = transform.localScale.x;
		lootDictionary[0] = AllItems.swordIcon1;
		lootDictionary[1] = AllItems.wandIcon;
	}
	
	void Update(){
		if(clickable){
			if(Input.GetMouseButtonDown(0)){
				Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
				dist = Mathf.Sqrt(dist);	

				if(dist < radius){
					animator.SetBool("Open", true);
					clickable = false;
					PopBool = true;
				}
			}


			/*if(Input.GetMouseButtonDown(0)){
				Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
				float ply = Mathf.Pow(MousePos.x - GlobalValues.player.transform.position.x, 2) + Mathf.Pow(MousePos.y - GlobalValues.player.transform.position.y, 2);
				
				ply = Mathf.Sqrt(ply);
				dist = Mathf.Sqrt(dist);
				
				if(dist < radius && ply < (radius + 1.0f)){
					animator.SetBool("Open", true);
					clickable = false;
					PopBool = true;
				}
		
			}*/
		}
		/*if(Input.GetMouseButtonUp(0)){
			clickable = true;
		}
		//	Destroy(gameObject);*/
	}

	void DoWindow0(int windowID ) {
		if(chestReady == false){
			lootDictionary[0] = AllItems.swordIcon1;
			lootDictionary[1] = AllItems.wandIcon;
			chestReady = true;
			Debug.Log(lootDictionary[0]);
		}

		if (GUI.Button(new Rect(0,30, SwPos,ShPos),	Item1,GUIStyle.none)){
			if(!Obtain1){	
				for(int i = 0; 0 < 9;i++){
					if(Inventory.inventoryNameDictionary[i] == null){
						Inventory.inventoryNameDictionary[i] = AllItems.swordIcon1;
						Item1 = null;
						Obtain1 = true;
						Debug.Log("Working " + i);
						break;
					}
				}
			}else{
				Debug.Log("This slot is empty");
				
			}
		}
		if (GUI.Button(new Rect(SwPos,30, SwPos,ShPos),Item2,GUIStyle.none)){
			if(!Obtain2){
				Obtain2 = true;
			}else{
				Debug.Log("This slot is empty");
				
			}
		}
		if (GUI.Button(new Rect(SwPos * 2,30, SwPos,ShPos), Item3,GUIStyle.none)){
			if(!Obtain3){
				for(int j = 0; 0 < 9;j++){
					if(Inventory.inventoryNameDictionary[j] == null){
						Inventory.inventoryNameDictionary[j] =  AllItems.swordIcon2;
						Item3 = null;
						Obtain3 = true;
						Debug.Log("Working " + j);
						break;
					}
				}
			}else{
				Debug.Log("This slot is empty");
				
			}
		}
		GUI.skin.button.fontSize = 30;
		if(GUI.Button(new Rect(0, ShPos * 2, SwPos * 2, ShPos), "Leave")){
			animator.SetBool("Open", false);
			PopBool = false;
			clickable = false;
			
		}
		if(GUI.Button(new Rect(200 - 20, 0, 20, 20), "X",GUIStyle.none)){
			animator.SetBool("Open", false);
			PopBool = false;
			clickable = false;
			
		}
	}

	void OnGUI() {
		if (PopBool){
			GUI.Window(0, PopMenu, DoWindow0, "Chest",GUIStyle.none);
			if (background != null)
				GUI.DrawTexture(PopMenu,background);
			
		}
		
	}

	void OnBecameVisible(){
		enabled = true;
	}
	void OnBecameInvisible(){
		enabled = false;
	}
}
