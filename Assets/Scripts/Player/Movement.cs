using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//hexgrid
<<<<<<< HEAD
	private HexGrid grid;
=======
	private HexGrid grid = null;
>>>>>>> master

	//int
	private int x;
	private int y;

	void Start () {
<<<<<<< HEAD
		grid.DrawGrid();

		x = 2; //(int)transform.position.x;
		y = 4; //(int)transform.position.y;

		transform.position = GlobalValues.hexCells[2][2].transform.position;
=======
		GameObject gameController = GameObject.FindGameObjectWithTag(GlobalValues.gameControllerTag);
		grid = gameController.GetComponent<HexGrid>();
>>>>>>> master
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.W)) {
			y = 1;
			x += 1;

			Vector3 rounded = grid.RoundToHex(GlobalValues.row[x][y]);
			Vector2 coordinates = grid.CubeToAxis(rounded);
			Vector2 newPos = grid.HexToPixel(coordinates, GlobalValues.radius);

			transform.position = newPos;

			Debug.Log("vector: " + GlobalValues.row[x][y]);
			Debug.Log("position: " + transform.position);
			Debug.Log("x: " + x);
			Debug.Log("y: " + y);
		}
	}
}