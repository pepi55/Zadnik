using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	/*--- PUBLICS ---*/
	//int
	public int hexSize = 64;
	/*--- END PUBLICS ---*/

	/*--- PRIVATES ---*/
	//int
	private int hexHeight;

	//float
	private float hexWidth;

	private float verticalSpacing;
	private float horizontalSpacing;
	/*--- END PRIVATES ---*/
	
	void Start () {
		hexHeight = hexSize * 2;
		hexWidth = Mathf.Sqrt(3) / 2 * hexHeight;

		verticalSpacing = 3 / 4 * hexHeight;
		horizontalSpacing = hexWidth;
	}

	void Update () {
	
	}

	void DrawGrid (int size) {

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
		float x = cube.x + (cube.z + (cube.z >> 1)) / 2;
		float y = cube.z;

		return new Vector2 (x, y);
	}

	private Vector3 EvenRToCube (Vector2 EvenR) {
		float x = EvenR.x - (EvenR.y + (EvenR.y >> 1)) / 2;
		float z = EvenR.y;
		float y = -x - z;

		return new Vector3 ();
	}
}