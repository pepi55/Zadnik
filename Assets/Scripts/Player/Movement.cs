using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//hexgrid
	private HexGrid grid = null;

	//int
	private int x;
	private int y;

	void Start () {
		GameObject gameController = GameObject.FindGameObjectWithTag(GlobalValues.gameControllerTag);
		grid = gameController.GetComponent<HexGrid>();
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