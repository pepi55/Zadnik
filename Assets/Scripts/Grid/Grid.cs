using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	/*--- PUBLICS ---*/
	//int
	public int hexSize = 64;

	//gameobject
	public GameObject hexagonicalCell;
	/*--- END PUBLICS ---*/

	/*--- PRIVATES ---*/
	//int
	private int hexHeight;

	//float
	private float hexWidth;

	private float verticalSpacing;
	private float horizontalSpacing;

	//class
	private class HexTile {
		public GameObject hexCell;
		public Vector2 position;
		public int value;
	}
	/*--- END PRIVATES ---*/
	
	void Start () {
		hexHeight = hexSize * 2;
		hexWidth = Mathf.Sqrt(3) / 2 * hexHeight;

		verticalSpacing = 3 / 4 * hexHeight;
		horizontalSpacing = hexWidth;

		DrawGrid (hexSize);
	}

	void Update () {
	
	}

	void DrawGrid (int size) {
		HexTile hexagon = new HexTile();
		Vector3 [] neighbours = new Vector3[] {
			new Vector3(+1f, -1f, 0f), new Vector3(+1f, 0f, -1f), new Vector3(0f, +1f, -1f),
			new Vector3(-1f, +1f, 0f), new Vector3(-1f, 0f, +1f), new Vector3(0f, -1f, +1f)
		};
		Vector2 [] neighbours2d = new Vector2[] {
			new Vector2(+1f, 0f), new Vector2(+1f, -1f), new Vector2(0f, -1f),
			new Vector2(-1f, 0f), new Vector2(-1f, +1f), new Vector2(0f, +1f)
		};

		for (int i = 0; i < neighbours2d.Length; i++) {
			hexagon.position = neighbours2d [i];
			hexagon.hexCell = (GameObject)Instantiate(hexagonicalCell, hexagon.position, Quaternion.identity);
			hexagon.hexCell.name = GlobalValues.cellName;
			hexagon.hexCell.tag = GlobalValues.cellTag;
		}
	}

	private Vector2 CubeToAxis (Vector3 cube) {
		float x = cube.x;
		float y = cube.z;

		return new Vector2 (x, y);
	}

	private Vector3 AxisToCube (Vector2 axis) {
		float x = axis.x;
		float z = axis.y;
		float y = -x - z;

		return new Vector3 (x, y, z);
	}

	private Vector2 CubeToEvenR (Vector3 cube) {
		float x = cube.x + (cube.z + ((int)cube.z & 1)) / 2;
		float y = cube.z;

		return new Vector2 (x, y);
	}

	private Vector3 EvenRToCube (Vector2 EvenR) {
		float x = EvenR.x - (EvenR.y + ((int)EvenR.y & 1)) / 2;
		float z = EvenR.y;
		float y = -x - z;

		return new Vector3 (x, y, z);
	}
}