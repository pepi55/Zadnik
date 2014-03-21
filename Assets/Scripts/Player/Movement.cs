using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	//float
	//private float timer = 0;
	//private float timer = 0;

	//bool
	/*private bool reset;
	private bool pathDone;*/
	//private bool walking;
	//private bool click = false;

	//list
	//public List<PathNode> solvedPath = new List<PathNode>();

	//pathnode
	//private PathNode hex;

	//class
	//private EnemyMove enemy;

	//ray
	private RaycastHit2D selectHexRay;

	void Start () {
		//GlobalValues.playerPos = transform.position;
		GlobalValues.player = /*this.*/gameObject;
	}

	void Update () {
		if (/*!walking && */Input.GetMouseButtonDown(0) == true) {
			selectHexRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (selectHexRay.collider != null) {
				StopCoroutine("MoveChar");
				if (/* && */selectHexRay.collider.tag == GlobalValues.cellTag) {
					HexGrid.end = selectHexRay.transform.gameObject;

					StartCoroutine("MoveChar");
				}/* else if (!walking) {
					HexGrid.end = null;
				}*/
			}
		}
		
		//MoveChar();
		/*if (Input.touchCount == 1) {
			if (GlobalValues.active) {
				RaycastHit2D selectHexRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
				
				if (selectHexRay.collider != null) {
					Debug.Log("huehuehuehuehuehuehuehuehuehuehuehuehuehuehuehuehue");

					if (Input.GetMouseButtonDown(0)) Debug.Log("0");
					if (Input.GetMouseButtonDown(1)) Debug.Log("1");
					if (Input.GetMouseButtonDown(3)) Debug.Log("2");
				}
				
				if (selectHexRay.collider.tag == GlobalValues.cellTag) {
					HexGrid.end = selectHexRay.transform.gameObject;
					MoveChar();
				}
			}
		}*/
	}

	private IEnumerator MoveChar () {
		//int i = 0;
		//walking = true;
		EnemyMove enemyMovement;

		while (true) {
			//i++;
			yield return new WaitForSeconds(0.1f);
			Debug.Log(HexGrid.solvedPath.Count);
			HexGrid.solvedPath[0].tag = GlobalValues.cellTag;
			transform.position = HexGrid.solvedPath[1].Position;
			HexGrid.solvedPath[1].tag = GlobalValues.playerTag;

			if (HexGrid.solvedPath.Count == 2) {
				//walking = false;
				//GlobalValues.player = this.gameObject;

				break;
			}

			for (int i = 0; i < GlobalValues.enemies.Count; i++) {
				yield return new WaitForSeconds(0.1f);

				enemyMovement = GlobalValues.enemies[i].GetComponent<EnemyMove>();
				enemyMovement.solvedPath[0].tag = GlobalValues.cellTag;
				GlobalValues.enemies[i].transform.position = enemyMovement.solvedPath[1].Position;
				enemyMovement.solvedPath[1].tag = GlobalValues.enemyTag;
			}
			//GlobalValues.player = transform.position;
			//GlobalValues.move = true;
		}
	}
}