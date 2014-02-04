using UnityEngine;
using System.Collections;

public class HexGrid : MonoBehaviour {
	/*--- PRIVATES ---*/
	private GameObject hexGridCell;
	/*--- END PRIVATES ---*/

	/*--- PUBLICS ---*/
	//ints
	public int gridLength = 16;
	public int gridHeight = 16;

	//floats
	public float gridOffsetX = 0.5f;
	public float gridOffsetY = 0.5f;
	/*-- END PUBLICS ---*/
	
	// Use this for initialization
	void Start () {
		for (int x = 0; x < gridLength; x++) {
			gridOffsetX += x;
			for (int y = 0; y < gridHeight; y++) {
				hexGridCell = Instantiate(Resources.Load<GameObject>("Grid/HexTile"), new Vector2(x + gridOffsetX, y), Quaternion.identity) as GameObject;
				hexGridCell.name = GlobalValues.cellName + x + y;
			}
		}
	}
}