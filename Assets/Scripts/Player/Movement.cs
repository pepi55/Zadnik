using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	//float
	private float timer = 0;

	//bool
	private bool reset;
	private bool pathDone;
	private bool walking;

	//list
	public List<PathNode> solvedPath = new List<PathNode>();

	//pathnode
	private PathNode hex;

	//ray
	private RaycastHit2D selectHexRay;

	void FixedUpdate () {
		if (!walking && Input.GetMouseButtonDown(0) == true) {
			selectHexRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (selectHexRay.collider.tag == GlobalValues.cellTag) {
				HexGrid.end = selectHexRay.transform.gameObject;

				StartCoroutine(MoveChar());
			}
		}
		
		//MoveChar();
		/*if (Input.touchCount == 1) {
			if (GlobalValues.active) {
				RaycastHit2D selectHexRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
				
				if (selectHexRay.collider != null) {
					Debug.Log("huehuehuehuehuehuehuehuehuehuehuehuehuehuehuehuehue");
				}
				
				if (selectHexRay.collider.tag == GlobalValues.cellTag) {
					HexGrid.end = selectHexRay.transform.gameObject;
					MoveChar();
				}
			}
		}*/
	}

	private IEnumerator MoveChar () {
		int i = 0;
		walking = true;

		while (true) {
			i++;

			if (HexGrid.solvedPath.Count == 2) {
				walking = false;
				break;
			}

			yield return new WaitForSeconds(0.5f);
			transform.position = HexGrid.solvedPath[1].Position;
		}
	}
}