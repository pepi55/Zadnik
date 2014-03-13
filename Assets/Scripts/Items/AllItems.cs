using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllItems : MonoBehaviour {
	public Texture2D eSwordIcon;
	public Texture2D eArrowIcon;
	public Texture2D eWandIcon;
	public Texture2D eEmptyIcon;

	static public Texture2D emptyIcon;
	static public Texture2D swordIcon;
	static public Texture2D arrowIcon;
	static public Texture2D wandIcon;
	
	public ItemCreate swordItem = 	new ItemCreate(0,"Swords",swordIcon,"CUTTING THAT SHIT");
	public ItemCreate arrowItem = 	new ItemCreate(0,"Arrows",arrowIcon,"Shooting THAT SHIT");
	public ItemCreate wandItem 	= 	new ItemCreate(0,"Wand",wandIcon,"Magic....");


	// Use this for initialization
	void Start () {
		swordIcon = eSwordIcon;
		arrowIcon = eArrowIcon;
		wandIcon  = eWandIcon;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public class ItemCreate : MonoBehaviour{
		public int 			id;
		public string 		name;
		public string 		descr;
		public Texture2D 	icon;
		public ItemCreate(int Id,string Name,Texture2D Ico, string des){
			id = Id;
			name = Name;
			icon = Ico;
			descr = des;
			
			
		}
	}
}
