﻿using UnityEngine;
using System.Collections;

public class GameControler : MonoBehaviour {
	/*--- PUBLICS ---*/
	//gameobject
	//public GameObject hex;
	
	//int
	public int gridHeight;
	public int gridLength;
	/*--- END PUBLICS ---*/
	
	/*--- PRIVATES ---*/
	//float
	
	//class
	//private HexGrid grid = null;
	/*--- END PRIVATES ---*/

	// Use this for initialization
	void Start () {
		/*--- INIT ---*/
		//int
		gridHeight = 16; GlobalValues.gridH = gridHeight;
		gridLength = 16; GlobalValues.gridW = gridLength;

		//class
		//grid = GetComponent<HexGrid>();
		/*--- END INIT ---*/

		//grid.DrawGrid(gridHeight, gridLength);
	}
}
