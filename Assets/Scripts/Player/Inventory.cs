using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public Rect invertoryRect = new Rect(Screen.width / 4,Screen.height / 2,400,400);
	private bool inventoryWindowShow = false;

	public static Dictionary<int,string> inventoryNameDictionary = new Dictionary<int, string>(){
		{0,string.Empty},
		{1,string.Empty},
		{2,string.Empty},
		{3,string.Empty},
		{4,string.Empty},
		{5,string.Empty},
		{6,string.Empty},
		{7,string.Empty},
		{8,string.Empty},
	};
	public Texture2D Test = AllItems.arrowIcon;
	public Texture2D Place;
//	Allitems itemObject = new Allitems();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width - 100,Screen.height - 50,100,50),Place ,"Inventory")){
			if(!inventoryWindowShow){
				inventoryWindowShow = true;
			}else{
				inventoryWindowShow = false;
			}
		}

		if(inventoryWindowShow){
			invertoryRect = GUI.Window(0,invertoryRect,InventoryWindowFunc,"Inventory");
		}
	}
	void InventoryWindowFunc(int id){
	
	/*	//Display
		inventoryNameDictionary[0] = swordItem.name;
		inventoryNameDictionary[1] = BowItem.name;
		inventoryNameDictionary[2] = HealthItem.name;*/

		GUILayout.BeginArea(new Rect(10,50,400,400));

		GUILayout.BeginHorizontal();
		if(GUILayout.Button(inventoryNameDictionary[0], GUILayout.Height(50))){
			inventoryNameDictionary[6] = inventoryNameDictionary[0];
			inventoryNameDictionary[0] = "";
		}
		GUILayout.Button(inventoryNameDictionary[1], GUILayout.Height(50));
		GUILayout.Button(inventoryNameDictionary[2], GUILayout.Height(50));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(inventoryNameDictionary[3], GUILayout.Height(50));
		GUILayout.Button(inventoryNameDictionary[4], GUILayout.Height(50));
		GUILayout.Button(inventoryNameDictionary[5], GUILayout.Height(50));
		GUILayout.EndHorizontal();
	
		GUILayout.BeginHorizontal();
		GUILayout.Box("   Uitrusting  ",GUIStyle.none);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(inventoryNameDictionary[6], GUILayout.Height(100));
		GUILayout.Button(inventoryNameDictionary[7], GUILayout.Height(100));
		GUILayout.Button(inventoryNameDictionary[8], GUILayout.Height(100));
		GUILayout.EndHorizontal();

	}
	
}
