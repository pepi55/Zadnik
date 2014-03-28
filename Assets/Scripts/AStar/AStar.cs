using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AStar {

	//Check valid nodes
	public static bool InvalidNode<T>(T inNode) where T : IPathNode<T> {
		if (inNode == null || inNode.Invalid) {
			return true;
		} else {
			return false;
		}
	}

	//Check distance
	private static float Distance<T>(T start, T goal) where T : IPathNode<T> {
		if (InvalidNode(start) || InvalidNode(goal)) {
			return float.MaxValue;
		} else {
			return Vector2.Distance(start.Position, goal.Position);
		}
	}

	//Calculate estimate cost
	private static float CostEstimate<T>(T start, T goal) where T : IPathNode<T> {
		return Distance(start, goal);
	}

	//Calculate "cheapest" path
	private static T LowestScore<T>(List<T> openset, Dictionary<T, float> scores) where T : IPathNode<T> {
		int index = 0;
		float lowestScore = float.MaxValue;

		for (int i = 0; i < openset.Count; i++) {
			if (scores[openset[i]] > lowestScore) {
				continue;
			}

			index = i;
			lowestScore = scores[openset[i]];
		}

		return openset[index];
	}

	//Path == found ? reconstruct : find it;
	private static void ReconstructPath<T>(Dictionary<T, T> from, T currentNode, ref List<T> result) where T : IPathNode<T> {
		if (from.ContainsKey(currentNode)) {
			ReconstructPath(from, from[currentNode], ref result);
			result.Add(currentNode);
			return;
		} else {
			result.Add(currentNode);
		}
	}

	//A* in action
	public static List<T> CalculatePath<T>(T start, T goal) where T : IPathNode<T> {
		List<T> closedset = new List<T>();
		List<T> openset = new List<T>();

		Dictionary<T, T> from = new Dictionary<T, T>();

		Dictionary<T, float> score = new Dictionary<T, float>();
		Dictionary<T, float> estimateCost = new Dictionary<T, float>();
		Dictionary<T, float> totalCost = new Dictionary<T, float>();

	//Redo: //Found inapropriate tags in solvedpath; redo calculation without these
		openset.Add(start);
		score[start] = 0.0f;
		estimateCost[start] = CostEstimate(start, goal);
		totalCost[start] = estimateCost[start];

		while (openset.Count != 0) {
			T x = LowestScore(openset, totalCost);

			if (x.Equals(goal)) {
				List<T> result = new List<T>();
				ReconstructPath(from, x, ref result);

				/*for (int j = 0; j < EnemyControl.E_solvedPath.Count; j++) {
					for (int i = 0; i < PlayerControl.solvedPath.Count; i++) {
						if (EnemyControl.E_solvedPath[j].tag != GlobalValues.cellTag || PlayerControl.solvedPath[i].tag != GlobalValues.cellTag) {;
							goto Redo; //solve path again with apropriate tags; alternative: query stuff???
						}
					}
				}*/

				return result;
			}

			openset.Remove(x);
			closedset.Add(x);

			foreach (T y in x.Connections) {
				if (AStar.InvalidNode(y) || closedset.Contains(y)) {
					continue;
				}

				if (y.Tag == GlobalValues.cellTag) {

				}

				float currentScore = score[x] + Distance(x, y);
				bool cheaper = false;

				if (!openset.Contains(y)) {
					openset.Add(y);
					cheaper = true;
				} else if (currentScore < score[y]) {
					cheaper = true;
				}

				if (cheaper) {
					from[y] = x;
					score[y] = currentScore;
					estimateCost[y] = CostEstimate(y, goal);
					totalCost[y] = score[y] + estimateCost[y];
				}
			}
		}

		return null;
	}
}