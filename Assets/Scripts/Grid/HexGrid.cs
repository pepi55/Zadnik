using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexGrid : MonoBehaviour {
	public static List<PathNode> sources;

	public GameObject start;
	public static GameObject end;

	public static List<PathNode> solvedPath = new List<PathNode>();

	public Color nodeColor = new Color(0.05f, 0.3f, 0.05f, 0.1f);
	public Color connectionColor = Color.blue; //new Color(1.0f, 0.2f, 0.05f, 1.5f);
	public Color pathColor = Color.magenta; //new Color(0.5f, 0.03f, 0.3f, 1.0f);

	//int
	private int startIndex;
	private int endIndex;
	private int lastStartIndex;
	private int lastEndIndex;
	private int place;

	//bool
	private bool pathDone;
	public static bool reset;
	public bool gridCreated;

	void Awake () {
		if (gridCreated) return;

		sources = PathNode.CreateGrid(Vector2.zero, Vector2.one * 1.0f, new int[] {20, 20}, 1.0f);
		/*place = (int)Random.Range(1, sources.Count);
		SpawnDummy(place);*/

		/*for (int i = 0; i < sources.Count; i++) {
			if (sources[i] == null) {
				SpawnDummy(i);
				break;
			}
		}*/

		gridCreated = true;
	}

	public void PulsePoint (int index) {
		if (AStar.InvalidNode(sources[index])) return;

		Draw.DrawCube(sources[index].Position, Vector2.one * 1.0f, connectionColor);
	}

	public void DrawConnections (int startPoint, int endPoint, Color inColor) {
		Debug.DrawLine(sources[startPoint].Position, sources[endPoint].Position, inColor);
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

	void Update () {
		if (reset) {
			pathDone = false;
			solvedPath.Clear();
			reset = false;
		}

		if (start == null) {
			Debug.LogWarning("No start point");
			//enabled = false;

			return;
		} else if (end == null) {
			//Debug.LogWarning("No end point");
			//enabled = false;

			return;
		}

		startIndex = Closest(sources, start.transform.position);
		endIndex = Closest(sources, end.transform.position);

		if (startIndex != lastStartIndex || endIndex != lastEndIndex) {
			reset = true;

			lastStartIndex = startIndex;
			lastEndIndex = endIndex;

			return;
		}

		for (int i = 0; i < sources.Count; i++) {
			if (AStar.InvalidNode(sources[i])) continue;
			sources[i].nodeColor = nodeColor;
		}

		PulsePoint(lastStartIndex);
		PulsePoint(lastEndIndex);

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

			return;
		}

		for (int i = 0; i < solvedPath.Count - 1; i++) {
			if (AStar.InvalidNode(solvedPath[i]) || AStar.InvalidNode(solvedPath[i + 1])) {
				reset = true;
				return;
			}

			Debug.DrawLine(solvedPath[i].Position, solvedPath[i + 1].Position, Color.cyan * new Color(1.0f, 1.0f, 1.0f, 1.0f));
		}
	}
}