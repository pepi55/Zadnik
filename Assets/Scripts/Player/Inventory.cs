using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public Rect invertoryRect = new Rect(Screen.width / 10,Screen.height / 10,Screen.width / 10 * 8,400);

	private bool inventoryWindowShow = false;

	public Texture2D Test = AllItems.arrowIcon;

	private float ShPos = Screen.height / 10;
	private float SwPos = Screen.width / 10;	
	private float radius;

	private Animator animator;


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

//	Allitems itemObject = new Allitems();
	// Use this for initialization
	void Start(){
		animator = GetComponent<Animator>();
		animator.GetBool("Open");
		radius = transform.localScale.x;
		
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
			invertoryRect = GUI.Window(0,invertoryRect,InventoryWindowFunc,"Inventory");

		}else{
			animator.SetBool("Open" , false);

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
