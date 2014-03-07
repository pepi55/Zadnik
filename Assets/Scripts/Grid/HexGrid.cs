using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexGrid : MonoBehaviour {
	public void DrawGrid (int gridHeight = 16, int gridLength = 16) {
		/*float offsetX, offsetY;
		float unitLength = (innerCircleRad) ? (rad / (Mathf.Sqrt(3) / 2)) : rad;
		
		offsetX = unitLength * Mathf.Sqrt(3);
		offsetY = unitLength * 1.5f;*/
		
		for (int x = 0; x < gridLength; x++) {
			List<HexTile> column = new List<HexTile>();
			//List<GameObject> hexagon = new List<GameObject>();
			for (int y = 0; y < gridHeight; y++) {
				HexTile hexCell = new HexTile();
				Vector2 pos = HexOffset(x, y);

				hexCell.hexagon = (GameObject)Instantiate(Resources.Load(GlobalValues.cellPath), pos, Quaternion.identity);
				hexCell.hexagon.transform.parent = transform;
				hexCell.hexagon.name = GlobalValues.cellName;
				hexCell.hexagon.tag = GlobalValues.cellTag;
			}

<<<<<<< HEAD
			GlobalValues.row.Add(column);
		}
	}
=======
	public Color nodeColor = new Color(0.05f, 0.3f, 0.05f, 0.1f);
	public Color connectionColor = Color.blue; //new Color(1.0f, 0.2f, 0.05f, 1.5f);
	public Color pathColor = Color.magenta; //new Color(0.5f, 0.03f, 0.3f, 1.0f);
>>>>>>> master

	private Vector2 HexOffset (int x, int y) {
		/*float xp = y * offsetX;

		if (x % 2 != 0) {
			xp += offsetX / 2;
		}

		float yp = x * offsetY;*/
		float xPos, yPos;

		xPos = y + (GlobalValues.radius * x);
		yPos = x * (Mathf.Sqrt((Mathf.Pow(GlobalValues.radius * 2, 2)) - (Mathf.Sqrt(GlobalValues.radius))));

<<<<<<< HEAD
		return new Vector2(xPos, yPos);
=======
		sources = PathNode.CreateGrid(Vector2.zero, Vector2.one * 1.0f, new int[] {20, 20}/*, 0.0f*/);
		gridCreated = true;
>>>>>>> master
	}

	public float GetDistance (Vector3 a, Vector3 b) {
		return (Mathf.Abs(a.x - b.x) + Mathf.Abs(a.z - b.z) + Mathf.Abs(a.x + a.z - b.x - b.z) / 2);
	}

	public Vector2 HexToPixel (Vector2 hexLocation, float rad) {
		float x, y;

		x = hexLocation.x + (hexLocation.y / 2); //rad * Mathf.Sqrt(3) * (hexLocation.x + hexLocation.y / 2);
		y = hexLocation.y * Mathf.Sqrt(rad); //rad * 3 / 2 * hexLocation.y;

		return new Vector2(x, y);
	}

	public Vector2 PixelToHex (Vector2 location, float rad) {
		float x, y;

		x = (1 / 3 * Mathf.Sqrt(3) * location.x - 1 / 3 * location.y) / rad;
		y = 2 / 3 * location.y / rad;

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

<<<<<<< HEAD
		return new Vector3(roundedX, roundedY, roundedZ);
=======
		for (int i = 0; i < solvedPath.Count - 1; i++) {
			if (AStar.InvalidNode(solvedPath[i]) || AStar.InvalidNode(solvedPath[i + 1])) {
				reset = true;
				return;
			}

			Debug.DrawLine(solvedPath[i].Position, solvedPath[i + 1].Position, Color.cyan * new Color(1.0f, 1.0f, 1.0f, 1.0f));
		}
>>>>>>> master
	}
}