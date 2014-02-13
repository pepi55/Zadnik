using UnityEngine;
using System.Collections;

public class HexCell : MonoBehaviour {
	private Movement player = null;

	void Start () {
		GameObject character = GameObject.FindGameObjectWithTag(GlobalValues.playerTag);
		player = character.GetComponent<Movement>();
	}

	void OnMouseDown () {
		player.MoveTo(transform.position);
	}
}
