using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//hexgrid
	private HexGrid grid;

	//int
	private int x;
	private int y;

	// Use this for initialization
	void Start () {
		grid.DrawGrid();

		x = 2; //(int)transform.position.x;
		y = 4; //(int)transform.position.y;

		transform.position = GlobalValues.hexCells[2][2].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W)) {
			transform.position = GlobalValues.hexCells[x][y].transform.position;
			x += 1;
			y += 1;

			Debug.Log("vector: " + GlobalValues.r[x][y]);
			Debug.Log("position: " + transform.position);
			Debug.Log("x: " + x);
			Debug.Log("y: " + y);
		}
	}
}