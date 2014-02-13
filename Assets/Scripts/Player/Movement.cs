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

	void FixedUpdate () {
		if (Input.GetMouseButtonDown(0)) {

		}
	}

	public void MoveTo (Vector3 position) {
		transform.position = position;
	}

	private Vector3 GetPosition (Vector3 coordinates) {
		Vector3 rounded = grid.RoundToHex(coordinates);
		Vector2 pos = grid.CubeToAxis(rounded);
		Vector2 newPos = grid.HexToPixel(pos, GlobalValues.radius);

		return newPos;
	}
}