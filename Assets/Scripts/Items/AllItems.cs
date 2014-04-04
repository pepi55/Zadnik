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
	public Texture2D eSwordIcon7;
	public Texture2D eSwordIcon8;
	public Texture2D eSwordIcon9;
	public Texture2D eSwordIcon10;
 	public Texture2D eSwordIcon11;
	public Texture2D eSwordIcon12;
	public Texture2D eSwordIcon13;
	public Texture2D eSwordIcon14;
	public Texture2D eSwordIcon15;
	public Texture2D eSwordIcon16;
	public Texture2D eSwordIcon17;
	public Texture2D eSwordIcon18;
	public Texture2D eSwordIcon19;
	public Texture2D eSwordIcon20;
	public Texture2D eSwordIcon21;
	public Texture2D eSwordIcon22;
	public Texture2D eSwordIcon23;
	public Texture2D eSwordIcon24;
	public Texture2D eSwordIcon25;
	public Texture2D eSwordIcon26;
	public Texture2D eSwordIcon27;
	public Texture2D eSwordIcon28;
	public Texture2D eSwordIcon29;
	public Texture2D eSwordIcon30;
	public Texture2D eSwordIcon31;
	public Texture2D eSwordIcon32;
	public Texture2D eSwordIcon33;
	public Texture2D eSwordIcon34;
	public Texture2D eSwordIcon35;
	public Texture2D eSwordIcon36;
	public Texture2D eSwordIcon37;
	public Texture2D eSwordIcon38;
	public Texture2D eSwordIcon39;
	public Texture2D eSwordIcon40;
	public Texture2D eSwordIcon41;
	public Texture2D eSwordIcon42;
	public Texture2D eSwordIcon43;
	public Texture2D eSwordIcon44;
	public Texture2D eSwordIcon45;
	public Texture2D eSwordIcon46;
	public Texture2D eSwordIcon47;
	public Texture2D eSwordIcon48;
	public Texture2D eSwordIcon49;
	public Texture2D eSwordIcon50;
	public Texture2D eSwordIcon51;
	public Texture2D eSwordIcon52;
	public Texture2D eSwordIcon53;
	public Texture2D eSwordIcon54;
	public Texture2D eSwordIcon55;
	public Texture2D eSwordIcon56;
	public Texture2D eSwordIcon57;
	public Texture2D eSwordIcon58;
	public Texture2D eSwordIcon59;
	public Texture2D eSwordIcon60;
	public Texture2D eSwordIcon61;
	public Texture2D eSwordIcon62;
	public Texture2D eSwordIcon63;
	public Texture2D eSwordIcon64;
	public Texture2D eSwordIcon65;
	public Texture2D eSwordIcon66;

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
	static public Texture2D swordIcon7;
	static public Texture2D swordIcon8;
	static public Texture2D swordIcon9;
	static public Texture2D swordIcon10;
	static public Texture2D swordIcon11;
	static public Texture2D swordIcon12;
	static public Texture2D swordIcon13;
	static public Texture2D swordIcon14;
	static public Texture2D swordIcon15;
	static public Texture2D swordIcon16;
	static public Texture2D swordIcon17;
	static public Texture2D swordIcon18;
	static public Texture2D swordIcon19;
	static public Texture2D swordIcon20;
	static public Texture2D swordIcon21;
	static public Texture2D swordIcon22;
	static public Texture2D swordIcon23;
	static public Texture2D swordIcon24;
	static public Texture2D swordIcon25;
	static public Texture2D swordIcon26;
	static public Texture2D swordIcon27;
	static public Texture2D swordIcon28;
	static public Texture2D swordIcon29;
	static public Texture2D swordIcon30;
	static public Texture2D swordIcon31;
	static public Texture2D swordIcon32;
	static public Texture2D swordIcon33;
	static public Texture2D swordIcon34;
	static public Texture2D swordIcon35;
	static public Texture2D swordIcon36;
	static public Texture2D swordIcon37;
	static public Texture2D swordIcon38;
	static public Texture2D swordIcon39;
	static public Texture2D swordIcon40;
	static public Texture2D swordIcon41;
	static public Texture2D swordIcon42;
	static public Texture2D swordIcon43;
	static public Texture2D swordIcon44;
	static public Texture2D swordIcon45;
	static public Texture2D swordIcon46;
	static public Texture2D swordIcon47;
	static public Texture2D swordIcon48;
	static public Texture2D swordIcon49;
	static public Texture2D swordIcon50;
	static public Texture2D swordIcon51;
	static public Texture2D swordIcon52;
	static public Texture2D swordIcon53;
	static public Texture2D swordIcon54;
	static public Texture2D swordIcon55;
	static public Texture2D swordIcon56;
	static public Texture2D swordIcon57;
	static public Texture2D swordIcon58;
	static public Texture2D swordIcon59;
	static public Texture2D swordIcon60;
	static public Texture2D swordIcon61;
	static public Texture2D swordIcon62;
	static public Texture2D swordIcon63;
	static public Texture2D swordIcon64;
	static public Texture2D swordIcon65;
	static public Texture2D swordIcon66;
	static public Texture2D wandIcon;

	static public List<ItemCreate> Item = new List<ItemCreate>{
		new	ItemCreate(1,"Regular Swords",	swordIcon1,"This sword is pretty basic"),
		new ItemCreate(1,"Casual Sword  ",	swordIcon2,"Talkin about casual...."),
		new ItemCreate(2,"Basic Sword",		swordIcon3,"Mere basic"),
		new ItemCreate(3,"Swords",			swordIcon4,"what did you expect?"),
		new ItemCreate(4,"Regular Swords",swordIcon1,"This sword is pretty basic"),
		new ItemCreate(5,"Regular Swords",swordIcon1,"This sword is pretty basic"),
		new ItemCreate(6,"Regular Swords",swordIcon1,"This sword is pretty basic"),
		new ItemCreate(7,"Regular Swords",swordIcon1,"This sword is pretty basic"),
		new ItemCreate(8,"Regular Swords",swordIcon1,"This sword is pretty basic"),
		new ItemCreate(9,"Regular Swords",swordIcon1,"This sword is pretty basic"),
		new ItemCreate(10,"Regular Swords",swordIcon1,"This sword is pretty basic"),
		new ItemCreate(11,"Regular Swords",swordIcon1,"This sword is pretty basic"),
		new ItemCreate(12,"Regular Swords",swordIcon1,"This sword is pretty basic"),
		new ItemCreate(13,"Regular Swords",swordIcon1,"This sword is pretty basic"),
		new ItemCreate(14,"Regular Swords",swordIcon1,"This sword is pretty basic"),

	};
	

	public ItemCreate arrowItem 	= 	new ItemCreate(0,"Arrows",arrowIcon,"Shooting THAT SHIT");
	public ItemCreate wandItem 		= 	new ItemCreate(0,"Wand",wandIcon,"Magic....");


	// Use this for initialization
	void Awake() {
		swordIcon1 = eSwordIcon1;
		arrowIcon = eArrowIcon;
		wandIcon  = eWandIcon;
		emptyIcon = eEmptyIcon;

	}

	public class ItemCreate
	{
		public int 			id;
		public string 		naam;
		public string 		descr;
		public Texture2D 	icon;

		public ItemCreate(int Id,string Name,Texture2D Ico, string des)
		{
			id = Id;
			naam = Name;
			icon = Ico;
			descr = des;	
			
		}
	}
}
