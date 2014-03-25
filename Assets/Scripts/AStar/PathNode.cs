using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathNode : MonoBehaviour, IPathNode<PathNode> {
	public List<PathNode> connections;
	public Color nodeColor = Color.green;
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

	public static List<PathNode> CreateGrid (Vector2 center, Vector2 spacing, int[] dim, float randomSpace) {
		GameObject gridObject = new GameObject("grid");
		GameObject enemies = new GameObject("enemies");

		int xCount = dim[0];
		int yCount = dim[1];

		float radius = 0.64f;

		float xWidth = spacing.x * xCount;
		float yWidth = spacing.y * yCount;
		float xStart = center.x - (xWidth / 2.0f) + (spacing.x / 2.0f);
		float yStart = center.y - (yWidth / 2.0f) + (spacing.y / 2.0f);

		float offsetX = radius * Mathf.Sqrt(3);
		float offsetY = radius * 1.5f;

		List<PathNode> result = new List<PathNode>();

		//Random.seed = 1337;
		float reset = randomSpace;

		for (int x = 0; x < xCount; x++) {
			float xPos = (x * offsetX/*spacing.x*/) + xStart;

			for (int y = 0; y < yCount; y++) {
				/*if (randomSpace < 1.0f) {
					if (Random.value <= randomSpace) {
						result.Add(null);
						
						continue;
					}
				}*/

				float yPos = (y * offsetY/*spacing.y*/) + yStart;
				float offset = (y % 2.0f == 0.0f) ? spacing.x * 0.56f : 0.0f;
				Vector2 newPos = new Vector2(xPos + offset, yPos);
				PathNode newNode = Spawn(newPos); //generateHexAt(i - floor(j/2), j);
				
				newNode.transform.parent = gridObject.transform;

				randomSpace = reset;

				if (randomSpace <= 1.0f) {
					randomSpace -= Random.value;

					if (randomSpace > 0.15 && randomSpace < 0.16) { /*Random.value > 0.15 && Random.value < 0.1*/
						GameObject enemy;

						enemy = (GameObject)Instantiate(Resources.Load(GlobalValues.enemyPath), newPos, Quaternion.identity);
						enemy.tag = GlobalValues.enemyTag;
						enemy.name = GlobalValues.enemyName;
						enemy.transform.parent = enemies.transform;

						//newNode.tag = GlobalValues.enemyTag;
						newNode.enabled = false;

						GlobalValues.enemies.Add(enemy);
					} else if (randomSpace > 0.05f && randomSpace < 0.15f) { /*Random.value > 0.05f && Random.value < 0.15f*/
						/*GameObject wall;

						wall = (GameObject)Instantiate(Resources.Load(GlobalValues.wallPath), newPos, Quaternion.identity);
						wall.tag = GlobalValues.wallTag;
						wall.name = GlobalValues.wallName;*/
						//newNode.tag = GlobalValues.wallTag;

						result.Add(null);
						continue;
					} else if (randomSpace > 0.001f && randomSpace < 0.05f) { /*Random.value > 0.001f && Random.value < 0.05f*/
						GameObject dummy;
						
						dummy = (GameObject)Instantiate(Resources.Load(GlobalValues.dummyPath), newPos, Quaternion.identity);
						dummy.tag = GlobalValues.dummyTag;
						dummy.name = GlobalValues.dummyName;
						dummy.transform.parent = enemies.transform;

						//newNode.tag = GlobalValues.dummyTag;
						//newNode.active = false;
						newNode.enabled = false;
						
						/*result.Add(null);
						continue;*/
					} else if (randomSpace < 0.001f) { /*Random.value < 0.001f*/
						GameObject chest;

						chest = (GameObject)Instantiate(Resources.Load(GlobalValues.chestPath), newPos, Quaternion.identity);
						chest.tag = GlobalValues.chestTag;
						chest.name = GlobalValues.chestName;

						//newNode.tag = GlobalValues.chestTag;
						//newNode.active = false;
						newNode.enabled = false;
						
						/*result.Add(null);
						continue;*/
					}
				}

				result.Add(newNode);
			}
		}

		for (int x = 0; x < xCount; x++) {
			for (int y = 0; y < yCount; y++) {
				int thisIndex = (x * yCount) + y;
				List<int> connectedIndicies = new List<int>();
				PathNode thisNode = result[thisIndex];

				if (AStar.InvalidNode(thisNode)/* || HexGrid.solvedPath[1].gameObject.tag != GlobalValues.cellTag*/) {
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

					if (AStar.InvalidNode(thisConnection) || thisConnection.gameObject.tag != GlobalValues.cellTag) {
						continue;
					}

					thisNode.Connections.Add(thisConnection);
				}
			}
		}

		return result;
	}
}