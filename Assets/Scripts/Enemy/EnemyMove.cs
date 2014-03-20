using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMove : MonoBehaviour {
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
	
	// Update is called once per frame
	void Update () {
		if (GlobalValues.move) {

		}
	}
}
