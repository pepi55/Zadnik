using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
public class PathNode : MonoBehaviour, IPathNode<PathNode> {
	public List<PathNode> connections;
	public static int index;

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

	}

	void Awake () {
		if (connections == null) {
			connections = new List<PathNode>();
		}
	}

	void Update () {
		//Draw.DrawCube(transform.position, Vector2.one);

		if (connections == null) {
			return;
		} else {
			for (int i = 0; i < connections.Count; i++) {
				if (connections[i] == null) {
					continue;
				} else {
					Debug.DrawLine(transform.position, connections[i], Color.cyan);
				}
			}
		}
	}
}
*/