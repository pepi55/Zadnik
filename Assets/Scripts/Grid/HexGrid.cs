using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexGrid : MonoBehaviour {
	/*--- PUBLICS ---*/
	//transform
	public GameObject hex;

	//int
	public int gridHeight = 16;
	public int gridLength = 16;

	//float
	public float rad = 0.55f;

	//bool
	public bool innerCircleRad = true;
	/*--- END PUBLICS ---*/

	/*--- PRIVATES ---*/
	//float
	private float offsetX, offsetY;

	//array
	//>>> total amount of tiles <<<//

	//class
	private class HexTile {
		public GameObject tile;
		public Vector2 position;
	}
	/*--- END PRIVATES ---*/

	// Use this for initialization
	void Start () {
		float unitLength = (innerCircleRad) ? (rad / (Mathf.Sqrt (3) / 2)) : rad;

		offsetX = unitLength * Mathf.Sqrt (3);
		offsetY = unitLength * 1.5f;

		for (int x = 0; x < gridLength; x++) {
			for (int y = 0; y < gridHeight; y++) {
				/*
				Vector2 hexPos = HexOffset(x, y);
				Instantiate(hex, hexPos, Quaternion.identity);
				hex.name = "hex"; // " + x + y;
				*/

				HexTile hexCell = new HexTile();

				hexCell.position = HexOffset(x, y);
				hexCell.tile = (GameObject)Instantiate(hex, hexCell.position, Quaternion.identity);
				hexCell.tile.name = GlobalValues.cellName;
				hexCell.tile.tag = GlobalValues.cellTag;
			}
		}
	}

	Vector2 HexOffset (int x, int y) {
		Vector2 pos = Vector2.zero;

		if (y % 2 == 0) {
			pos.x = x * offsetX;
			pos.y = y * offsetY;
		} else {
			pos.x = (x + 0.5f) * offsetX;
			pos.y = y * offsetY;
		}

		return pos;
	}
}