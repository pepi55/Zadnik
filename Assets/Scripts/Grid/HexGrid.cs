using UnityEngine;
using System.Collections;

public class HexGrid : MonoBehaviour {
	/*--- PRIVATES ---*/
	//floats
	private float hexHeight;
	private float hexWidth;
	/*--- END PRIVATES ---*/

	/*--- PUBLICS ---*/
	//ints
	public int gridLength = 16;
	public int gridHeight = 16;

	//gameobjects
	public GameObject hexGridCell;
	/*-- END PUBLICS ---*/

	void Start () {
		setSizes();
		createGrid();
	}

	void setSizes () {
		hexWidth = hexGridCell.renderer.bounds.size.x;
		hexHeight = hexGridCell.renderer.bounds.size.y;
	}

	void createGrid () {
		GameObject hexGrid = new GameObject ("HexGrid");

		for (int y = 0; y < gridHeight; y++) {
			for (int x = 0; x < gridLength; x++) {
				GameObject hexCell = (GameObject)Instantiate(Resources.Load("Grid/HexTile"));
				Vector2 gridPos = new Vector2(x, y);

				hexCell.transform.position = getWorldPos(gridPos);
				hexCell.transform.parent = hexGrid.transform;
			}
		}
	}

	Vector2 getInitPos () {
		Vector2 initPos;

		initPos = new Vector2 (-hexWidth * gridLength / 2f + hexWidth / 2, gridHeight / 2f * hexHeight - hexHeight / 2);

		return initPos;
	}

	Vector2 getWorldPos (Vector2 gridPos) {
		Vector2 initPos = getInitPos();
		float offset = 0;
		float x, y;

		if (gridPos.y % 2 != 0) {
			offset = hexWidth / 2;
		}

		x = initPos.x + offset + gridPos.x * hexWidth;
		y = initPos.y - gridPos.y * hexHeight * 0.75f;

		return new Vector2(x, y);
	}
}