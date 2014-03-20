﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	AllItems itemObject = new AllItems();

	private float ShPos = Screen.height / 10;
	private float SwPos = Screen.width / 10;
	//public string "Occupy0", "Occupy1","Occupy2","Occupy3","Occupy4","Occupy5";
	//public string "Occupy6", "Occupy7","Occupy8","Occupy9","Occupy10","Occupy11";
	public string inside1,inside2,inside3,inside4,inside5,inside6,inside7,inside8;
	private float radius;

	public Rect invertoryRect = new Rect(Screen.width / 10,Screen.height / 10,Screen.width / 10 * 8,400);

	private bool inventoryWindowShow = false;

	public Texture2D background;

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
		{9,AllItems.emptyIcon},
		{10,AllItems.emptyIcon},
		{11,AllItems.emptyIcon},

	};

	void Start(){
		animator = GetComponent<Animator>();
		animator.GetBool("Open");
		radius = transform.localScale.x;

		for(int i = 0;i < 12 ; i++){
			if(inventoryNameDictionary[i] == null){
				inventoryNameDictionary[i] = AllItems.emptyIcon;

			}
		}
	

		
	}
	void Update () {
		//transform.position = new Vector2(SwPos * 8, ShPos * 8);
		if(Input.GetMouseButtonDown(0)){
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
			dist = Mathf.Sqrt(dist);
			
			if(dist < radius){
				if(!inventoryWindowShow){
					inventoryWindowShow = true;

				}else{
					inventoryWindowShow = false;

				}
			}
		}
		
	}
	
	void OnGUI(){
		if(inventoryWindowShow){
			animator.SetBool("Open" , true);
			invertoryRect = GUI.Window(0,invertoryRect,InventoryWindowFunc,"", GUIStyle.none);
			if (background != null){
				GUI.DrawTexture(invertoryRect,background);
			}
			
		}else{
			animator.SetBool("Open" , false);

		}

	}


	void InventoryWindowFunc(int id){

		//Display
		inventoryNameDictionary[1] = AllItems.emptyIcon;
		inventoryNameDictionary[2] = AllItems.emptyIcon;


		GUILayout.BeginArea(new Rect(0,0,SwPos * 6,ShPos * 6));
		GUILayout.Box("   Items  ",GUIStyle.none);
		GUILayout.BeginHorizontal();
		if(GUILayout.Button(inventoryNameDictionary[0],GUIStyle.none, GUILayout.Height(ShPos))){
			inventoryNameDictionary[9] = inventoryNameDictionary[0];
			inventoryNameDictionary[0] = AllItems.emptyIcon;
		}
		GUILayout.Button(inventoryNameDictionary[1],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.Button(inventoryNameDictionary[2],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(inventoryNameDictionary[3],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.Button(inventoryNameDictionary[4],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.Button(inventoryNameDictionary[5],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(inventoryNameDictionary[6],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.Button(inventoryNameDictionary[7],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.Button(inventoryNameDictionary[8],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.EndHorizontal();
	
		GUILayout.BeginHorizontal();
		GUILayout.Box("   Uitrusting  ",GUIStyle.none);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(inventoryNameDictionary[9],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.Button(inventoryNameDictionary[10],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.Button(inventoryNameDictionary[11],GUIStyle.none, GUILayout.Height(ShPos));
		GUILayout.EndHorizontal();

		GUILayout.EndArea();
	}
	
}
