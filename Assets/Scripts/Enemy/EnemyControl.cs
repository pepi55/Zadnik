using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyControl : MonoBehaviour {
	/*--- PUBLICS ---*/
	//list
	public static List<PathNode> E_sources;
	/*--- END PUBLICS ---*/
	
	/*--- PRIVATES ---*/
	//list
	private List<PathNode> E_solvedPath = new List<PathNode>();
	
	//int
	private int E_startIndex;
	private int E_endIndex;
	private int E_lastStartIndex;
	private int E_lastEndIndex;
	private int E_place;
	
	//gameobject
	private GameObject E_start;
	private GameObject E_end;
	
	//bool
	private bool E_pathDone;
	private bool E_reset;
	/*--- END PRIVATES ---*/
	
	void Start () {
		E_sources = HexGrid.sources;
		E_start = this.gameObject;
	}
	
	void OnEnable () {
		GameControler.OnClick += GetEnemyPath;
	}
	
	void OnDisable () {
		GameControler.OnClick -= GetEnemyPath;
	}
	
	private IEnumerator Move () {
		/*for (int i = 0; i < E_solvedPath.Count; i++) {
			if (E_solvedPath[i] != null) {
				transform.position = E_solvedPath[i].transform.position;
				
				yield return new WaitForSeconds(0.5f);
			} else {
				return false;
			}
		}*/
		yield return new WaitForSeconds(0.5f);

		transform.position = E_solvedPath[1].transform.position;
		GetEnemyPath();
	}
	
	private void GetEnemyPath () {
		E_end = GlobalValues.player;
		
		while (!E_pathDone) {
			if (E_reset) {
				E_solvedPath.Clear();
				E_reset = false;
			}
			
			if (E_start == null) {
				Debug.LogWarning("No start point!");
				
				E_pathDone = true;
			}
			
			if (E_end == null) {
				Debug.LogWarning("No end point!");
				
				E_pathDone = true;
			}
			
			E_startIndex = Closest(E_sources, E_start.transform.position);
			E_endIndex = Closest(E_sources, E_end.transform.position);
			
			if (E_startIndex != E_lastStartIndex || E_endIndex != E_lastEndIndex) {
				E_reset = true;
				
				E_lastStartIndex = E_startIndex;
				E_lastEndIndex = E_endIndex;
				
				continue;
			}
			
			if (!E_pathDone) {
				E_solvedPath = AStar.CalculatePath(E_sources[E_lastStartIndex], E_sources[E_lastEndIndex]);
				//pathDone = true;
			}
			
			if (E_solvedPath == null || E_solvedPath.Count < 1) {
				Debug.LogWarning("Invalid path!");
				E_reset = true;
				
				break;
			}
			
			for (int i = 0; i < E_solvedPath.Count - 1; i++) {
				if (AStar.InvalidNode(E_solvedPath[i]) || AStar.InvalidNode(E_solvedPath[i + 1])) {
					E_reset = true;
					
					continue;
				}
				
				Debug.DrawLine(E_solvedPath[i].Position, E_solvedPath[i + 1].Position, Color.cyan * new Color(1.0f, 1.0f, 1.0f, 1.0f));
			}
			
			if (E_reset) {
				continue;
			}
			
			if (E_solvedPath != null) {
				if (GlobalValues.playerMove) {
					StopCoroutine("Move");
					StartCoroutine("Move");
				} else if (!GlobalValues.playerMove) {
					StopCoroutine("Move");
				}

				E_pathDone = true;
			}
		}
		
		E_pathDone = false;
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