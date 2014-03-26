using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControler : MonoBehaviour {
	/*--- PUBLICS ---*/
	//list
	public static List<PathNode> sources;

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
		sources = HexGrid.sources;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) == true) {
			selectHexRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (selectHexRay.collider != null) {
				if (selectHexRay.collider.tag == GlobalValues.cellTag) {
					GlobalValues.targetTile = selectHexRay.transform.gameObject;

					if (OnClick != null) {
						OnClick();
					}
				}
			}
		}
	}
}