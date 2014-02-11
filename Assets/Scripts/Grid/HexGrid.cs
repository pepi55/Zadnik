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

	//list
	private List<List<Vector3>> r = new List<List<Vector3>>();
	private List<Vector3> q = new List<Vector3>();

	//class
	private class HexTile {
		public GameObject tile;
		public Vector2 position;
	}
	/*--- END PRIVATES ---*/

	// Use this for initialization
	void Start () {
		DrawGrid();

		Debug.Log(r[0][9]);
	}

	private void DrawGrid () {
		float unitLength = (innerCircleRad) ? (rad / (Mathf.Sqrt(3) / 2)) : rad;
		
		offsetX = unitLength * Mathf.Sqrt(3);
		offsetY = unitLength * 1.5f;
		
		for (int x = 0; x < gridLength; x++) {
			for (int y = 0; y < gridHeight; y++) {
				HexTile hexCell = new HexTile();
				Vector3 column;
				
				hexCell.position = HexOffset(x, y);
				hexCell.tile = (GameObject)Instantiate(hex, hexCell.position, Quaternion.identity);
				hexCell.tile.transform.parent = transform;
				hexCell.tile.name = GlobalValues.cellName;
				hexCell.tile.tag = GlobalValues.cellTag;

				column = AxisToCube(hexCell.position);
				q.Add(column);
			}

			r.Add(q);
		}
	}

	private Vector2 HexOffset (int x, int y) {
		Vector2 pos = new Vector2();

		float xp = y * offsetX;

		if (x % 2 != 0) {
			xp += offsetX / 2;
		}

		float yp = x * offsetY;

		pos.x = xp;
		pos.y = yp;

		return pos;
	}

	private Vector2 CubeToAxis (Vector3 cube) {
		float q, r;

		q = cube.x;
		r = cube.z;

		return new Vector2 (q, r);
	}

	private Vector3 AxisToCube (Vector2 axis) {
		float x, y, z;

		x = axis.x;
		z = axis.y;
		y = -x - z;

		return new Vector3(x, y, z);
	}
}