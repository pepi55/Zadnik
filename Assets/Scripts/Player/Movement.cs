using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	//list
	public static List<PathNode> sources;

	//gameobject
	public GameObject start;
	public GameObject end;

	//bool
	private bool pathDone;
	public static bool reset;

	//ray
	private RaycastHit2D selectHexRay;

	void Awake () {
		sources = HexGrid.sources;
	}

	private void GetPath () {

	}
}