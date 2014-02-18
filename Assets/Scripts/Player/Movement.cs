using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//int
	int x, y;

	void Start () {

	}

	/*void FixedUpdate () {
		if (Input.GetMouseButtonDown(0)) {
			x += 1;
			y = 1;

			Vector2 coordinates = grid.CubeToAxis(GlobalValues.row[x][y]);
			Vector2 newPos = grid.HexToPixel(coordinates, GlobalValues.radius);

			transform.position = newPos;

			Debug.Log(GlobalValues.row[x][y]);
		}
	}*/

	void OnMouseDown () {

	}

	public void MoveTo (Vector3 position) {
		transform.position = position;
	}
}