using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	private AllItems itemComponent;

	private float SwPos = Screen.height / 10;
	private float ShPos = Screen.width / 10;
	private float radius;


	private Rect invertoryRect 		= new Rect(Screen.height / 10,Screen.width / 10,Screen.height / 10 * 8,Screen.width / 10 * 8);
	private Rect invertoryRectOne 	= new Rect(Screen.height / 10,Screen.width / 10,Screen.height / 10 * 6,Screen.width / 10 * 6);
	private Rect invertoryRectTwo 	= new Rect(Screen.height / 10 ,Screen.width / 10 * 6,Screen.height / 10 * 2,Screen.width / 10 * 2);

	private bool inventoryWindowShow = false;
	private bool clickable = true;

	public Texture2D background, backgroundSec;

	private Animator animator;

	public static Dictionary<int,AllItems.ItemCreate> inventoryNameDictionary = new Dictionary<int, AllItems.ItemCreate>(){
		{0,AllItems.Item[0]},
		{1,AllItems.Item[0]},
		{2,AllItems.Item[0]},
		{3,AllItems.Item[0]},
		{4,AllItems.Item[0]},
		{5,AllItems.Item[0]},
		{6,AllItems.Item[0]},
		{7,AllItems.Item[0]},
		{8,AllItems.Item[0]},
	};
	public static Dictionary<int,AllItems.ItemCreate> usingNameDictionary = new Dictionary<int,AllItems.ItemCreate>(){
		{0,AllItems.Item[0]},
		{1,AllItems.Item[0]},
		{2,AllItems.Item[0]},
	};
	
	void Start(){
		itemComponent = GetComponent<AllItems>();
		animator = GetComponent<Animator>();
		animator.GetBool("Open");
		radius = transform.localScale.x;

		for(int i = 0;i < 9 ; i++){
			if(inventoryNameDictionary[i] != null){
				inventoryNameDictionary[i] = null;

			}
		}
	

		
	}
	void Update () {
		//transform.position = new Vector2(SwPos * 8, ShPos * 8);
		if(clickable){
		//if(Input.touchCount == 1){
			if(Input.GetMouseButton(0)){
				Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
				dist = Mathf.Sqrt(dist);
				
				if(dist < radius){
					if(!inventoryWindowShow){
						GlobalValues.invOpen = true;
						inventoryWindowShow = true;
						clickable = false;

					}else{
						GlobalValues.invOpen = false;
						inventoryWindowShow = false;
						clickable = false;

					}
				}
			}
		}
		if(Input.GetMouseButtonUp(0)){
			clickable = true;
		}
		
	}
	
	void OnGUI(){
		if(inventoryWindowShow){
			animator.SetBool("Open" , true);
			invertoryRect = GUI.Window(0,invertoryRect,InventoryWindowFunc,"", GUIStyle.none);
			if (background != null){
				GUI.DrawTexture(invertoryRectOne,background);
				GUI.DrawTexture(invertoryRectTwo,backgroundSec);
			}
			
		}else{
			animator.SetBool("Open" , false);
		}

	}


	void InventoryWindowFunc(int id){
		GUI.skin.label.fontSize = 20;
		GUILayout.BeginArea(new Rect(SwPos,ShPos,SwPos * 6,ShPos * 5));
			GUILayout.Box("   Items  ",GUIStyle.none);
			GUILayout.BeginHorizontal();

			if(GUILayout.Button(inventoryNameDictionary[0].naam, GUILayout.Width(SwPos * 2))){
				for(int q = 1;q < 3;q++){
					usingNameDictionary[q] = inventoryNameDictionary[0];
					inventoryNameDictionary[0] = null;
				break;
				}
			}
			GUILayout.Button(inventoryNameDictionary[1].naam, GUILayout.Width(SwPos * 2));
			GUILayout.Button(inventoryNameDictionary[2].naam, GUILayout.Width(SwPos * 2));
		GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
				GUILayout.Button(inventoryNameDictionary[3].naam, GUILayout.Width(SwPos * 2));
				GUILayout.Button(inventoryNameDictionary[4].naam, GUILayout.Width(SwPos * 2));
				GUILayout.Button(inventoryNameDictionary[5].naam, GUILayout.Width(SwPos * 2));
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
				GUILayout.Button(inventoryNameDictionary[6].naam, GUILayout.Width(SwPos * 2));
				GUILayout.Button(inventoryNameDictionary[7].naam, GUILayout.Width(SwPos * 2));
				GUILayout.Button(inventoryNameDictionary[8].naam, GUILayout.Width(SwPos * 2));
			GUILayout.EndHorizontal();

			if(usingNameDictionary[0] != null){
				GlobalValues.Power = 2;
			}

		GUILayout.EndArea();


		GUILayout.BeginArea(new Rect(SwPos,ShPos * 5,SwPos * 6,ShPos * 5));

			GUILayout.BeginHorizontal();
			GUILayout.Box("   Uitrusting  ",GUIStyle.none);
			GUILayout.EndHorizontal();

<<<<<<< HEAD
		GUILayout.BeginHorizontal();
		GUILayout.Button(usingNameDictionary[0],GUIStyle.none, GUILayout.Height(SwPos * 2));
		GUILayout.Button(usingNameDictionary[1],GUIStyle.none, GUILayout.Height(SwPos * 2));
		GUILayout.Button(usingNameDictionary[2],GUIStyle.none, GUILayout.Height(SwPos * 2));
		GUILayout.EndHorizontal();
=======
			GUILayout.BeginHorizontal();
			GUILayout.Button(usingNameDictionary[0].naam, 	GUILayout.Height(SwPos * 2));
			GUILayout.Button(usingNameDictionary[1].naam, 	GUILayout.Height(SwPos * 2));
			//GUILayout.Button(usingNameDictionary[2].naam, 	GUILayout.Height(SwPos * 2));
			GUILayout.EndHorizontal();
>>>>>>> origin/master

		GUILayout.EndArea();

	}
	
}
