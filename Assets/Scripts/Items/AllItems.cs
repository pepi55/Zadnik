using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AllItems : MonoBehaviour {
	private float randomChoice;

	public Texture2D eSwordIcon1;
	public Texture2D eSwordIcon2;
	public Texture2D eSwordIcon3;
	public Texture2D eSwordIcon4;
	public Texture2D eSwordIcon5;
	public Texture2D eSwordIcon6;
	public Texture2D eSwordIcon7;
	public Texture2D eSwordIcon8;
	public Texture2D eSwordIcon9;
	public Texture2D eSwordIcon10;
 	public Texture2D eSwordIcon11;
	public Texture2D eSwordIcon12;
	public Texture2D eSwordIcon13;
	public Texture2D eSwordIcon14;

	public Texture2D eArrowIcon;
	public Texture2D eWandIcon;
	public Texture2D eEmptyIcon;

	static public Texture2D emptyIcon;

	static public Texture2D arrowIcon;

	//----swords----//
	static public Texture2D swordIcon1;
	static public Texture2D swordIcon2;
	static public Texture2D swordIcon3;
	static public Texture2D swordIcon4;
	static public Texture2D swordIcon5;
	static public Texture2D swordIcon6;
	static public Texture2D swordIcon7;
	static public Texture2D swordIcon8;
	static public Texture2D swordIcon9;
	static public Texture2D swordIcon10;
	static public Texture2D swordIcon11;
	static public Texture2D swordIcon12;
	static public Texture2D swordIcon13;
	static public Texture2D swordIcon14;
	static public Texture2D swordIcon15;
	static public Texture2D wandIcon;

	static public List<ItemCreate> Item = new List<ItemCreate>{
		new	ItemCreate(0,"Empty",	emptyIcon,"You've chosen nothing"),
		new ItemCreate(1,"Casual Sword  ",	swordIcon1,"Talkin about casual...."),
		new ItemCreate(2,"Basic Sword",		swordIcon3,"Mere basic"),
		new ItemCreate(3,"Swords",			swordIcon4,"what did you expect?"),
		new ItemCreate(4,"Toothpick",		swordIcon5,"It cuts through meat...between my teeth"),
		new ItemCreate(5,"Enhanced sword",	swordIcon6,"Classy anf usefull"),
		new ItemCreate(6,"Special sword",	swordIcon7,"In some way everybody is special..."),
		/*new ItemCreate(7,"Regular Swords",swordIcon8,"This sword is pretty basic"),
		new ItemCreate(8,"Regular Swords",swordIcon9,"This sword is pretty basic"),
		new ItemCreate(9,"Regular Swords",swordIcon10,"This sword is pretty basic"),
		new ItemCreate(10,"Regular Swords",swordIcon11,"This sword is pretty basic"),
		new ItemCreate(11,"Regular Swords",swordIcon12,"This sword is pretty basic"),
		new ItemCreate(12,"Regular Swords",swordIcon13,"This sword is pretty basic"),
		new ItemCreate(13,"Regular Swords",swordIcon14,"This sword is pretty basic"),
		new ItemCreate(14,"Regular Swords",swordIcon15,"This sword is pretty basic"),*/
		new ItemCreate(15,"Arrows",			arrowIcon,"Shooting THAT SHIT"),
		new ItemCreate(16,"Wand",			wandIcon,"Magic...."),

	};
	

										


	// Use this for initialization
	void Awake() {
		swordIcon1 = eSwordIcon1;
		swordIcon2 = eSwordIcon2;
		swordIcon3 = eSwordIcon3;
		swordIcon4 = eSwordIcon4;
		swordIcon5 = eSwordIcon5;
		swordIcon6 = eSwordIcon6;
		arrowIcon = eArrowIcon;
		wandIcon  = eWandIcon;
		emptyIcon = eEmptyIcon;
		Item[1].icon = swordIcon1;
		Item[2].icon = swordIcon2;
		Item[3].icon = swordIcon3;
		Item[4].icon = swordIcon4;
		Debug.Log(Item[1].icon);

	}

	public class ItemCreate
	{
		public int 			id;
		public string 		naam;
		public string 		descr;
		public Texture2D 	icon;

		private AllItems itemComponent;
		public ItemCreate(int Id,string Name,Texture2D Ico, string des)
		{

			id = Id;
			naam = Name;
			icon = Ico;
			descr = des;	
			
		}
	}
}
