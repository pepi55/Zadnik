using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControler : MonoBehaviour {
	/*--- PUBLICS ---*/
	//bool
	//public static bool reset;

	//list
	public static List<PathNode> sources;

	//gameobject
	public GameObject start;
	public GameObject end;
	
	//int
	public int gridHeight;
	public int gridLength;

	//delegate
	public delegate void FindPath();

	//event
	public static event FindPath OnClick;
	/*--- END PUBLICS ---*/
	
	/*--- PRIVATES ---*/
	//bool
	private bool pathDone;

	//ray
	private RaycastHit2D selectHexRay;

	//int
	private int startIndex;
	private int endIndex;
	/*--- END PRIVATES ---*/
	
	void Awake () {
		gridHeight = 16; GlobalValues.gridH = gridHeight;
		gridLength = 16; GlobalValues.gridW = gridLength;

		sources = HexGrid.sources;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) == true) {
			selectHexRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if (selectHexRay.collider != null) {
				if (selectHexRay.collider.tag == GlobalValues.cellTag) {
					if (OnClick != null) {
						OnClick();
					}
				}
			}
		}
	}
}