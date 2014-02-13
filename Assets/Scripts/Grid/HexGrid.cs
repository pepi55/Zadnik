using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexGrid : MonoBehaviour {
	//class
	private class HexTile {
		public GameObject tile;
		public Vector2 position;
	}
	
	public void DrawGrid (GameObject hex, int gridHeight = 16, int gridLength = 16, float rad = 0.64f, bool innerCircleRad = false) {
		float offsetX, offsetY;
		float unitLength = (innerCircleRad) ? (rad / (Mathf.Sqrt(3) / 2)) : rad;
		
		offsetX = unitLength * Mathf.Sqrt(3);
		offsetY = unitLength * 1.5f;
		
		for (int x = 0; x < gridLength; x++) {
			List<Vector3> q = new List<Vector3>();
			List<GameObject> hexagon = new List<GameObject>();
			for (int y = 0; y < gridHeight; y++) {
				HexTile hexCell = new HexTile();
				Vector3 column;
				
				hexCell.position = HexOffset(x, y, offsetX, offsetY);
				hexCell.tile = (GameObject)Instantiate(hex, hexCell.position, Quaternion.identity);
				hexCell.tile.transform.parent = transform;
				hexCell.tile.name = GlobalValues.cellName;
				hexCell.tile.tag = GlobalValues.cellTag;

				hexagon.Add(hexCell.tile);
				column = AxisToCube(hexCell.position);
				q.Add(column);
			}

			GlobalValues.hexCells.Add(hexagon);
			GlobalValues.row.Add(q);
		}
	}

	private Vector2 HexOffset (int x, int y, float offsetX, float offsetY) {
		float xp = y * offsetX;

		if (x % 2 != 0) {
			xp += offsetX / 2;
		}

		float yp = x * offsetY;

		return new Vector2(xp, yp);
	}

	public float GetDistance (Vector3 a, Vector3 b) {
		return (Mathf.Abs(a.x - b.x) + Mathf.Abs(a.z - b.z) + Mathf.Abs(a.x + a.z - b.x - b.z) / 2);
	}

	public Vector2 HexToPixel (Vector2 hexLocation, float rad) {
		float x, y;

		x = rad * Mathf.Sqrt(3) * (hexLocation.x + hexLocation.y / 2);
		y = rad * 3 / 2 * hexLocation.y;

		return new Vector2(x, y);
	}

	public Vector2 CubeToAxis (Vector3 cube) {
		float q, r;

		q = cube.x;
		r = cube.z;

		return new Vector2(q, r);
	}

	public Vector3 AxisToCube (Vector2 axis) {
		float x, y, z;

		x = axis.x;
		z = axis.y;
		y = -x - z;

		return new Vector3(x, y, z);
	}

	public Vector3 RoundToHex (Vector3 cube) {
		int roundedX, roundedY, roundedZ, diffX, diffY, diffZ;

		roundedX = (int)Mathf.Round(cube.x);
		roundedY = (int)Mathf.Round(cube.y);
		roundedZ = (int)Mathf.Round(cube.z);

		diffX = (int)Mathf.Abs(roundedX - cube.x);
		diffY = (int)Mathf.Abs(roundedY - cube.y);
		diffZ = (int)Mathf.Abs(roundedZ - cube.z);

		if (diffX > diffY && diffX > diffZ) {
			roundedX = -roundedY - roundedZ;
		} else if (diffY > diffZ) {
			roundedY = -roundedX - roundedZ;
		} else {
			roundedZ = -roundedX - roundedY;
		}

		return new Vector3(roundedX, roundedY, roundedZ);
	}
}