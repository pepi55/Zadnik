using UnityEngine;
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

	void OnMouseDown () {
		if (Input.touches.Length == 1) {
			if (GlobalValues.active) {
				RaycastHit2D selectHexRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);

				if (selectHexRay.collider != null) {
					Debug.Log("huehuehuehuehuehuehuehuehuehuehuehuehuehuehuehuehue");
				}

				//Movement.OnMove();
			}
		}
	}
}
