using UnityEngine;
using System.Collections;

public class NewInventory 
{
	Item[] items = new Item[5];

	Weapon sword = new Weapon();

	void AddItem(Item item)
	{
		// heb ik plek?

		// waar dan?

		// stop item in inventory
	}

	void EquipItem()
	{

	}

	void OnGUI()
	{
/*		for (int i=0; i < items.GetLength; i++)
		{
			//GUILayout.Button(items[i].icon, // blablabla
		}*/
	}

}

public class Item
{
	public int id;
	public string description;
	public Texture2D icon;
}

public class Weapon : Item
{
	public float damage;
}

public class Armor : Item
{
	public float defenseRate;
}