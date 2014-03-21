using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	//list
	public static List<PathNode> sources;
	public static List<PathNode> solvedPath = new List<PathNode>();

	//gameobject
	private GameObject start;
	private GameObject end;

	//int
	private int startIndex;
	private int endIndex;
	private int lastStartIndex;
	private int lastEndIndex;
	private int place;

	//bool
	private bool pathDone;
	public static bool reset;

	//ray
	private RaycastHit2D selectHexRay;

	//color
	public Color nodeColor = new Color(0.05f, 0.3f, 0.05f, 0.1f);

	void Start () {
		sources = HexGrid.sources;
		start = this.gameObject;
		GlobalValues.player = this.gameObject;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) == true) {
			selectHexRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (selectHexRay.collider != null) {
				StopCoroutine("Move");

				if (selectHexRay.collider.tag == GlobalValues.cellTag) {
					end = selectHexRay.transform.gameObject;

					GetPath();
					Debug.Log(solvedPath.Count);
					//StartCoroutine("Move");
				}
			}
		}
	}

	private IEnumerator Move () {
		for (int i = 0; i < solvedPath.Count - 1; i++) {
			transform.position = solvedPath[i].Position;
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void GetPath () {
		while (true) {
			if (reset) {
				pathDone = false;
				solvedPath.Clear();
				reset = false;
			}
			
			if (start == null) {
				Debug.LogWarning("No start point");
				//enabled = false;
				
				break; //return;
			} else if (end == null) {
				Debug.LogWarning("No end point");
				//enabled = false;
				
				break; //return;
			}
			
			startIndex = Closest(sources, start.transform.position);
			endIndex = Closest(sources, end.transform.position);
			
			if (startIndex != lastStartIndex || endIndex != lastEndIndex) {
				reset = true;
				
				lastStartIndex = startIndex;
				lastEndIndex = endIndex;
				
				break; //return;
			}
			
			for (int i = 0; i < sources.Count; i++) {
				if (AStar.InvalidNode(sources[i])) continue;
				sources[i].nodeColor = nodeColor;
			}
			
			//PulsePoint(lastStartIndex);
			//PulsePoint(lastEndIndex);
			
			if (!pathDone) {
				/*for (int i = 0; i < 6; i++) {
				solvedPath = AStar.CalculatePath(sources[lastStartIndex], sources[lastEndIndex]);
			}*/
				solvedPath = AStar.CalculatePath(sources[lastStartIndex], sources[lastEndIndex]);
				/*for (int i = 0; i < solvedPath.Count; i++) {
				Debug.Log(solvedPath[i]);
			}*/
				pathDone = true;
			}
			
			if (solvedPath == null || solvedPath.Count < 1) {
				Debug.LogWarning("Invalid Path");
				reset = true;
				enabled = false;
				
				break; //return;
			}
			
			for (int i = 0; i < solvedPath.Count - 1; i++) {
				if (AStar.InvalidNode(solvedPath[i]) || AStar.InvalidNode(solvedPath[i + 1])) {
					reset = true;
					break; //return;
				}
				
				Debug.DrawLine(solvedPath[i].Position, solvedPath[i + 1].Position, Color.cyan * new Color(1.0f, 1.0f, 1.0f, 1.0f));
			}
		}
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