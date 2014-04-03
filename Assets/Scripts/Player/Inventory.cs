using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
//	AllItems itemObject = new AllItems();

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

	public static Dictionary<int,Texture2D> inventoryNameDictionary = new Dictionary<int, Texture2D>(){
		{0,AllItems.emptyIcon},
		{1,AllItems.emptyIcon},
		{2,AllItems.emptyIcon},
		{3,AllItems.emptyIcon},
		{4,AllItems.emptyIcon},
		{5,AllItems.emptyIcon},
		{6,AllItems.emptyIcon},
		{7,AllItems.emptyIcon},
		{8,AllItems.emptyIcon},
	};
	public static Dictionary<int,Texture2D> usingNameDictionary = new Dictionary<int, Texture2D>(){
		{0,AllItems.emptyIcon},
		{1,AllItems.emptyIcon},
		{2,AllItems.emptyIcon},
	};
	
	void Start(){
		gameObject.AddComponent<AllItems>();
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
		Debug.Log(inventoryNameDictionary[0]);
		GUI.skin.label.fontSize = 20;
		GUILayout.BeginArea(new Rect(SwPos,ShPos,SwPos * 6,ShPos * 5));
		GUILayout.Box("   Items  ",GUIStyle.none);
		GUILayout.BeginHorizontal();

		if(GUILayout.Button(inventoryNameDictionary[0],GUIStyle.none, GUILayout.Width(SwPos * 2))){
			for(int q = 1;q < 3;q++){
				usingNameDictionary[q] = inventoryNameDictionary[0];
				inventoryNameDictionary[0] = null;
			}
		}
		GUILayout.Button(inventoryNameDictionary[1],GUIStyle.none, GUILayout.Width(SwPos * 2));
		GUILayout.Button(inventoryNameDictionary[2],GUIStyle.none, GUILayout.Width(SwPos * 2));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(inventoryNameDictionary[3],GUIStyle.none, GUILayout.Width(SwPos * 2));
		GUILayout.Button(inventoryNameDictionary[4],GUIStyle.none, GUILayout.Width(SwPos * 2));
		GUILayout.Button(inventoryNameDictionary[5],GUIStyle.none, GUILayout.Width(SwPos * 2));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(inventoryNameDictionary[6],GUIStyle.none, GUILayout.Width(SwPos * 2));
		GUILayout.Button(inventoryNameDictionary[7],GUIStyle.none, GUILayout.Width(SwPos * 2));
		GUILayout.Button(inventoryNameDictionary[8],GUIStyle.none, GUILayout.Width(SwPos * 2));
		GUILayout.EndHorizontal();

		if(usingNameDictionary[0] != null){
			GlobalValues.Power = 2;
		}

		GUILayout.EndArea();


		GUILayout.BeginArea(new Rect(SwPos,ShPos * 5,SwPos * 6,ShPos * 5));

		GUILayout.BeginHorizontal();
		GUILayout.Box("   Uitrusting  ",GUIStyle.none);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(usingNameDictionary[0],GUIStyle.none, 	GUILayout.Height(SwPos * 2));
		GUILayout.Button(usingNameDictionary[1],GUIStyle.none, GUILayout.Height(SwPos * 2));
		GUILayout.Button(usingNameDictionary[2],GUIStyle.none, GUILayout.Height(SwPos * 2));
		GUILayout.EndHorizontal();

		GUILayout.EndArea();

	}
	
}
