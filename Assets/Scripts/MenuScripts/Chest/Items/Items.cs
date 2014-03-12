using UnityEngine;
using System.Collections;
using System;

public class Items : IComparable<Items> {

	private string name, descr;
	private int power;
	public Items(string newName, string newDescr, int newPower){
		name = newName;
		descr = newDescr;
		power = newPower;
		Debug.Log(name);
		Debug.Log(descr);

	}
	public int CompareTo(Items other)
	{
		if(other == null)
		{
			return 1;
		}
		
		//Return the difference in power.
		return power - other.power;
	}

}
