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
			if (x < GlobalValues.gridH - 1) {
				x += 1;
			}

			transform.position = GetPosition(GlobalValues.row[x][y]);

			Debug.Log("vector: " + GlobalValues.row[x][y]);
			Debug.Log("position: " + transform.position);
			Debug.Log("x: " + x);
			Debug.Log("y: " + y);
		}

		if (Input.GetKeyDown(KeyCode.S)) {
			if (x >= 1 && x <= GlobalValues.gridH) {
				x -= 1;
			}

			transform.position = GetPosition(GlobalValues.row[x][y]);

			Debug.Log("vector: " + GlobalValues.row[x][y]);
			Debug.Log("position: " + transform.position);
			Debug.Log("x: " + x);
			Debug.Log("y: " + y);
		}

		if (Input.GetKeyDown(KeyCode.A)) {
			if (y < GlobalValues.gridW - 1) {
				y += 1;
			}

			transform.position = GetPosition(GlobalValues.row[x][y]);

			Debug.Log("vector: " + GlobalValues.row[x][y]);
			Debug.Log("position: " + transform.position);
			Debug.Log("x: " + x);
			Debug.Log("y: " + y);
		}

		if (Input.GetKeyDown(KeyCode.D)) {
			if (y >= 1 && y <= GlobalValues.gridW) {
				y -= 1;
			}

			transform.position = GetPosition(GlobalValues.row[x][y]);
			
			Debug.Log("vector: " + GlobalValues.row[x][y]);
			Debug.Log("position: " + transform.position);
			Debug.Log("x: " + x);
			Debug.Log("y: " + y);
		}
	}

	private Vector3 GetPosition (Vector3 coordinates) {
		Vector3 rounded = grid.RoundToHex(coordinates);
		Vector2 pos = grid.CubeToAxis(rounded);
		Vector2 newPos = grid.HexToPixel(pos, GlobalValues.radius);

		return newPos;
	}
}