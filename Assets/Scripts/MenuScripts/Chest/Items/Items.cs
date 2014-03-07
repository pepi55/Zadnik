using UnityEngine;
using System.Collections;
using System;

public class Items : IComparable<Items> {

	private string name, Descr;
	private float Power;
	public Items(string newName, string newDescr, int newPower){
		name = NewName;
		Descr = newDescr;
		Power = newPower;

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
