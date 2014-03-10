using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	//int
	public static int i;

	private int x, y;

	void OnMouseDown () {
		if (Input.touches.Length == 1) {
			if (GlobalValues.active) {
				RaycastHit2D selectHexRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
				
				if (selectHexRay.collider != null) {
					Debug.Log("huehuehuehuehuehuehuehuehuehuehuehuehuehuehuehuehue");
				}
				
				//Movement.OnMove();
			}
		}
	}

	public void MoveChar () {
		if (HexGrid.solvedPath.Count != 0) return;

		for (i = 0; i < HexGrid.solvedPath.Count; i++) {
			StartCoroutine(OnMove());
		}
	}

	public IEnumerator OnMove () {
		while (true) {
			if (HexGrid.solvedPath.Count == 0) yield return null;

			transform.position = HexGrid.solvedPath[i].Position;

			yield return new WaitForSeconds(1);
		}
	}
}