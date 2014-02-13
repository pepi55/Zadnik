using UnityEngine;
using System.Collections;

public class HexCell : MonoBehaviour {
	private Movement player = null;
	private HexGrid grid = null;

	void Start () {
		GameObject character = GameObject.FindGameObjectWithTag(GlobalValues.playerTag);
		player = character.GetComponent<Movement>();

		GameObject gameController = GameObject.FindGameObjectWithTag(GlobalValues.gameControllerTag);
		grid = gameController.GetComponent<HexGrid>();
	}

	void OnMouseDown () {
		/*Debug.Log(grid.GetDistance(player.transform.position, transform.position));
		Debug.Log(Mathf.Floor(grid.GetDistance(player.transform.position, transform.position)));
		player.MoveTo(transform.position);*/
	}

	public Vector3 GetPos () {
		Vector2 currentPosition = grid.CubeToAxis(transform.position);

		return grid.PixelToHex(currentPosition, GlobalValues.radius);
	}
}