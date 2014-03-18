using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public Rect invertoryRect = new Rect(Screen.width / 10,Screen.height / 10,Screen.width / 10 * 8,400);
	private bool inventoryWindowShow = false;
	public Texture2D Test = AllItems.arrowIcon;
	private float ShPos = Screen.height / 10;
	private float SwPos = Screen.width / 10;

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

	public GameObject Place;
//	Allitems itemObject = new Allitems();
	// Use this for initialization
	void Start () {

	}
	
	void OnGUI(){
		if(GUI.Button(new Rect(SwPos,ShPos / 10,100,50),Place ,"Inventory")){
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

		GUILayout.BeginArea(new Rect(SwPos,ShPos,SwPos * 6,ShPos * 6));

		GUILayout.BeginHorizontal();
		if(GUILayout.Button(inventoryNameDictionary[0], GUILayout.Height(10))){
			inventoryNameDictionary[9] = inventoryNameDictionary[0];
			inventoryNameDictionary[0] = "";
		}
		GUILayout.Button(inventoryNameDictionary[1], GUILayout.Width(20));
		GUILayout.Button(inventoryNameDictionary[2], GUILayout.Height(10));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(inventoryNameDictionary[3], GUILayout.Height(50));
		GUILayout.Button(inventoryNameDictionary[4], GUILayout.Height(50));
		GUILayout.Button(inventoryNameDictionary[5], GUILayout.Height(50));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(inventoryNameDictionary[6], GUILayout.Height(50));
		GUILayout.Button(inventoryNameDictionary[7], GUILayout.Height(50));
		GUILayout.Button(inventoryNameDictionary[8], GUILayout.Height(50));
		GUILayout.EndHorizontal();
	
		GUILayout.BeginHorizontal();
		GUILayout.Box("   Uitrusting  ",GUIStyle.none);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Button(inventoryNameDictionary[9], GUILayout.Height(100));
		GUILayout.Button(inventoryNameDictionary[10], GUILayout.Height(100));
		GUILayout.Button(inventoryNameDictionary[11], GUILayout.Height(100));
		GUILayout.EndHorizontal();

	}
	
}
