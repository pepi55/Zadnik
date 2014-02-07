using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexGridArray : MonoBehaviour {
	/*--- PUBLICS ---*/
	//transform
	public Transform hex;

	//int
	public int gridHeight = 16;
	public int gridLength = 16;

	//float
	public float rad = 0.5f;

	//bool
	public bool innerCircleRad = true;
	/*--- END PUBLICS ---*/

	/*--- PRIVATES ---*/
	//float
	private float offsetX, offsetY;

	//list
	private List<List<Transform>> grid = new List<List<Transform>>();
	/*--- END PRIVATES ---*/

	// Use this for initialization
	void Start () {
		float unitLength = (innerCircleRad) ? (rad / (Mathf.Sqrt (3) / 2)) : rad;

		offsetX = unitLength * Mathf.Sqrt (3);
		offsetY = unitLength * 1.5f;

		for (int x = 0; x < gridLength; x++) {
			for (int y = 0; y < gridHeight; y++) {
				Vector2 hexPos = HexOffset(x, y);
				Instantiate(hex, hexPos, Quaternion.identity);
				hex.name = "hex " + x + y;
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
