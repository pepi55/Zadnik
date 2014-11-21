using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ChestTest : MonoBehaviour {
//	Item itemObject = new Item();

	public Texture2D background, Empty;
	private Texture2D  Item1, Item2, Item3;
	
	private float radius; 
	private float Luck;
	private float RandomNumber;
	private float SwPos = Screen.height / 10;
	private float ShPos = Screen.width / 10;
	
	private Animator animator;
	private AllItems itemComponent;

	private bool clickable = true;
	private bool PopBool = false;
	private bool Obtain1 = false ,Obtain2 = false, Obtain3 = false;
	//private bool doWindow0 = true;
	private bool chestReady = false;
	
	private Rect PopMenu = new Rect(Screen.height - Screen.height / 10 * 3,0 ,Screen.height / 10 * 3,Screen.width / 10 * 3);

	public static Dictionary<int,AllItems.ItemCreate> lootDictionary = new Dictionary<int, AllItems.ItemCreate>(){
		{0,AllItems.Item[1]},
		{1,AllItems.Item[0]},
		{2,AllItems.Item[0]},

	};

	void Awake(){
		itemComponent = GetComponent<AllItems>();
		animator = GetComponent<Animator>();
		radius = transform.localScale.x;
		Item1 = lootDictionary[0].icon;
		Item2 = lootDictionary[1].icon;
		Item3 = lootDictionary[2].icon;
		/*lootDictionary[0] = AllItems.swordIcon1;
		lootDictionary[1] = AllItems.wandIcon;*/
	}

	private void OpenChest () {
		if(clickable){
			if(Input.GetMouseButtonDown(0)){
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				float dist = Mathf.Pow(mousePos.x - transform.position.x,2) + Mathf.Pow(mousePos.y - transform.position.y,2);
				float ply = Mathf.Pow(mousePos.x - GlobalValues.player.transform.position.x, 2) + Mathf.Pow(mousePos.y - GlobalValues.player.transform.position.y, 2);

				dist = Mathf.Sqrt(dist);
				ply = Mathf.Sqrt(ply);
				
				if(dist < radius && ply < (radius + 1.0f)){
					animator.SetBool("Open", true);
					clickable = false;
					PopBool = true;
				}
			}
		}
	}
	
	void Update(){
		if(clickable){
			/*if(Input.GetMouseButtonDown(0)){
				Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
				dist = Mathf.Sqrt(dist);	

				if(dist < radius){
					animator.SetBool("Open", true);
					clickable = false;
					PopBool = true;
					GlobalValues.invOpen = true;
				}
			}*/
			if(Input.GetMouseButtonDown(0)){
				Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
				float dist = Mathf.Pow(mousePos.x - transform.position.x,2) + Mathf.Pow(mousePos.y - transform.position.y,2);
				float ply = Mathf.Pow(mousePos.x - GlobalValues.player.transform.position.x, 2) + Mathf.Pow(mousePos.y - GlobalValues.player.transform.position.y, 2);
				
				ply = Mathf.Sqrt(ply);
				dist = Mathf.Sqrt(dist);
				
				if(dist < radius && ply < (radius + 1.0f)){
					animator.SetBool("Open", true);
					clickable = false;
					PopBool = true;
					GlobalValues.invOpen = true;
				}
		
			}
		}
		if(Input.GetMouseButtonUp(0)){
			clickable = true;
		}
		//	Destroy(gameObject);*
	}

	void DoWindow0(int windowID ) {
		if(chestReady == false){
			/*lootDictionary[0] = AllItems.swordIcon1;
			lootDictionary[1] = AllItems.wandIcon;*/
			chestReady = true;
		}

		if (GUI.Button(new Rect(0,30, SwPos,ShPos),	Item1,GUIStyle.none)){
			if(!Obtain1){
				Item1 = AllItems.Item[0].icon;
				for(int i = 0; 0 < 9;i++){
					if(Inventory.inventoryNameDictionary[i] == AllItems.Item[0]){
						Inventory.inventoryNameDictionary[i] = lootDictionary[0];
						Obtain1 = true;
						break;
					}
					Item1 = AllItems.Item[0].icon;
				}
			}else{
				Debug.Log("This slot is empty number1");
				
			}
		}
		if (GUI.Button(new Rect(SwPos,30, SwPos,ShPos),Item2,GUIStyle.none)){
			if(!Obtain2){
				Obtain2 = true;
			}else{
				Debug.Log("This slot is empty number2");
				
			}
		}
		if (GUI.Button(new Rect(SwPos * 2,30, SwPos,ShPos), Item3,GUIStyle.none)){
			if(!Obtain3){
				for(int j = 0; 0 < 9;j++){
					if(Inventory.inventoryNameDictionary[j] == AllItems.Item[0]){
						Inventory.inventoryNameDictionary[j] =  lootDictionary[2];
						Obtain3 = true;
						break;
					}
				}
			}else{
				Debug.Log("This slot is empty number3");
				
			}
		}
		GUI.skin.button.fontSize = 30;
		if(GUI.Button(new Rect(0, ShPos * 2, SwPos * 2, ShPos), "Leave")){
			animator.SetBool("Open", false);
			PopBool = false;
			clickable = false;
			GlobalValues.invOpen = false;
			
		}
		if(GUI.Button(new Rect(200 - 20, 0, 20, 20), "X",GUIStyle.none)){
			animator.SetBool("Open", false);
			PopBool = false;
			clickable = false;
			GlobalValues.invOpen = false;
			
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
