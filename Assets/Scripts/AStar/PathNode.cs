using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathNode : MonoBehaviour, IPathNode<PathNode> {
	public List<PathNode> connections;
	public Color nodeColor = Color.cyan;
	public static int index;
	
	void Awake () {
		if (connections == null) {
			connections = new List<PathNode>();
		}
	}
	
	void Update () {
		Draw.DrawCube(transform.position, Vector2.one, nodeColor);
		
		if (connections == null) {
			return;
		} else {
			for (int i = 0; i < connections.Count; i++) {
				if (connections[i] == null) {
					continue;
				} else {
					Debug.DrawLine(transform.position, connections[i].Position, nodeColor);
				}
			}
		}
	}

	public bool Invalid {
		get {
			return(this == null);
		}
	}

	public List<PathNode> Connections {
		get {
			return(connections);
		}
	}

	public Vector2 Position {
		get {
			return transform.position;
		}
	}

	public static PathNode Spawn (Vector2 inPosition) {
		GameObject tile = (GameObject)Instantiate(Resources.Load(GlobalValues.cellPath), inPosition, Quaternion.identity);
		PathNode newNode;

		tile.name = GlobalValues.cellName;
		tile.tag = GlobalValues.cellTag;
		newNode = tile.AddComponent<PathNode>();

		index++;

		return newNode;
	}

	public static List<PathNode> CreateGrid (Vector2 center, Vector2 spacing, int[] dim/*, float randomSpace*/) {
		GameObject gridObject = new GameObject("grid");

		int xCount = dim[0];
		int yCount = dim[1];

		float xWidth = spacing.x * xCount;
		float yWidth = spacing.y * yCount;
		float xStart = center.x - (xWidth / 2.0f) + (spacing.x / 2.0f);
		float yStart = center.y - (yWidth / 2.0f) + (spacing.y / 2.0f);

		List<PathNode> result = new List<PathNode>();

		//Random.seed = 1337;

		for (int x = 0; x < xCount; x++) {
			float xPos = (x * spacing.x) + xStart;

			for (int y = 0; y < yCount; y++) {
				/*if (randomSpace < 0.0f) {
					if (Random.value <= randomSpace) {
						result.Add(null);
						continue;
					}
				}*/

				float yPos = (y * spacing.y) + yStart;
				float offset = (y % 2.0f == 0.0f) ? spacing.x * 0.5f : 0.0f;
				Vector2 newPos = new Vector2(xPos + offset, yPos);

				PathNode newNode = Spawn(newPos); //generateHexAt(i - floor(j/2), j);

				result.Add(newNode);
				newNode.transform.parent = gridObject.transform;
			}
		}

		for (int x = 0; x < xCount; x++) {
			for (int y = 0; y < yCount; y++) {
				int thisIndex = (x * yCount) + y;
				List<int> connectedIndicies = new List<int>();
				PathNode thisNode = result[thisIndex];

				if (AStar.InvalidNode(thisNode)) {
					continue;
				}

				if (y % 2.0f == 0.0f) {
					if (x != 0) {
						connectedIndicies.Add(((x - 1) * yCount) + y);
					}
					
					if (x != xCount - 1) {
						connectedIndicies.Add(((x + 1) * yCount) + y);
					}

					if (y != 0) {
						connectedIndicies.Add((x * yCount) + (y - 1));
					}
					
					if (y != yCount - 1) {
						connectedIndicies.Add((x * yCount) + (y + 1));
					}

					/*if (x != 0 && y != 0) {
						connectedIndicies.Add(((x - 1) * yCount) + (y - 1));
					}*/
					
					if (x != xCount - 1 && y != yCount - 1) {
						connectedIndicies.Add(((x + 1) * yCount) + (y + 1));
					}
					
					/*if (x != 0 && y != yCount - 1) {
						connectedIndicies.Add(((x - 1) * yCount) + (y + 1));
					}*/
					
					if (x != xCount - 1 && y != 0) {
						connectedIndicies.Add(((x + 1) * yCount) + (y - 1));
					}
				} else {
					if (x != 0) {
						connectedIndicies.Add(((x - 1) * yCount) + y);
					}
					
					if (x != xCount - 1) {
						connectedIndicies.Add(((x + 1) * yCount) + y);
					}
					
					if (y != 0) {
						connectedIndicies.Add((x * yCount) + (y - 1));
					}
					
					if (y != yCount - 1) {
						connectedIndicies.Add((x * yCount) + (y + 1));
					}
					
					if (x != 0 && y != 0) {
						connectedIndicies.Add(((x - 1) * yCount) + (y - 1));
					}
					
					/*if (x != xCount - 1 && y != yCount - 1) {
						connectedIndicies.Add(((x + 1) * yCount) + (y + 1));
					}*/
					
					if (x != 0 && y != yCount - 1) {
						connectedIndicies.Add(((x - 1) * yCount) + (y + 1));
					}
					
					/*if (x != xCount - 1 && y != 0) {
						connectedIndicies.Add(((x + 1) * yCount) + (y - 1));
					}*/
				}

				for (int i = 0; i < connectedIndicies.Count; i++) {
					PathNode thisConnection = result[connectedIndicies[i]];

					if (AStar.InvalidNode(thisConnection)) {
						continue;
					}

					thisNode.Connections.Add(thisConnection);
				}
			}
		}

		return result;
	}
}