using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
	/*--- PUBLICS ---*/
	//list
	public static List<PathNode> solvedPath = new List<PathNode>();
	/*--- END PUBLICS ---*/

	/*--- PRIVATES ---*/
	//int
	private int startIndex;
	private int endIndex;
	private int lastStartIndex;
	private int lastEndIndex;
	private int place;

	private int HitPoints = 10;

	//gameobject
	private GameObject start;
	private GameObject end;

	//bool
	private bool pathDone;
	private bool reset;

	//list
	private List<PathNode> sources;
	private List<PathNode> fov;
	/*--- END PRIVATES ---*/

	void Start () {
		sources = HexGrid.sources;
		start = this.gameObject;

		GlobalValues.player = this.gameObject;
	}

	void OnEnable () {
		GameControler.PlayerClick += GetPath;
		EnemyControl.HitPlayer += HitPlayer;
	}
	
	void OnDisable () {
		GameControler.PlayerClick -= GetPath;
		EnemyControl.HitPlayer -= HitPlayer;
	}

	private IEnumerator Move () {
		foreach (PathNode hex in sources) {
			hex.gameObject.SetActive(false);
		}

		fov = PathNode.FieldOfView(start, 5);

		foreach (PathNode hex in sources) {
			hex.gameObject.SetActive(true);
		}

		GlobalValues.playerMove = true;

		for (int i = 1; i < solvedPath.Count; i++) {
			if (solvedPath[i] != null) {
				/*if (solvedPath[i - 1] != null) {
					solvedPath[i].tag = GlobalValues.cellTag;
				}*/
				transform.position = solvedPath[i].transform.position;
				solvedPath[i].tag = GlobalValues.playerTag;

				yield return new WaitForSeconds(0.5f);

				solvedPath[i].tag = GlobalValues.cellTag;
			} else {
				return false;
			}
		}

		GlobalValues.playerMove = false;
	}

	private void HitPlayer () {
		if (HitPoints != 0) {
			HitPoints--;

			if(HitPoints == 0){
				Application.LoadLevel("PeterTest");
			}
		}
	}

	private void GetPath () {
		end = GlobalValues.targetTile;

		while (!pathDone) {
			if (reset) {
				solvedPath.Clear();
				reset = false;
			}

			if (start == null) {
				Debug.LogWarning("No start point!");

				pathDone = true;
			}

			if (end == null) {
				Debug.LogWarning("No end point!");

				pathDone = true;
			}

			startIndex = Closest(sources, start.transform.position);
			endIndex = Closest(sources, end.transform.position);

			if (startIndex != lastStartIndex || endIndex != lastEndIndex) {
				reset = true;

				lastStartIndex = startIndex;
				lastEndIndex = endIndex;

				continue;
			}

			if (!pathDone) {
				solvedPath = AStar.CalculatePath(sources[lastStartIndex], sources[lastEndIndex]);
				//pathDone = true;
			}

			if (solvedPath == null || solvedPath.Count < 1) {
				Debug.LogWarning("Invalid path!");
				reset = true;

				break;
			}

			for (int i = 0; i < solvedPath.Count - 1; i++) {
				if (AStar.InvalidNode(solvedPath[i]) || AStar.InvalidNode(solvedPath[i + 1])) {
					reset = true;

					continue;
				}

				Debug.DrawLine(solvedPath[i].Position, solvedPath[i + 1].Position, Color.cyan * new Color(1.0f, 1.0f, 1.0f, 1.0f));
			}

			if (reset) {
				continue;
			}

			if (solvedPath != null) {
				StopCoroutine("Move");
				StartCoroutine("Move");

				pathDone = true;
			}
		}

		pathDone = false;
	}

	private static int Closest (List<PathNode> inNodes, Vector2 toPoint) {
		int closestIndex = 0;
		float minDistance = float.MaxValue;
		
		for (int i = 0; i < inNodes.Count; i++) {
			if (AStar.InvalidNode(inNodes[i])) continue;
			
			float thisDistance = Vector2.Distance(toPoint, inNodes[i].Position);
			
			if (thisDistance > minDistance) continue;
			
			minDistance = thisDistance;
			closestIndex = i;
		}
		
		return closestIndex;
	}
}