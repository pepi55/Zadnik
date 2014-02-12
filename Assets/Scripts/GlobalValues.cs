using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GlobalValues{
	//strings
	public static string cellName = "hexGridCell";
	public static string cellTag = "gridCell";

	public static string gameControllerTag = "GameController";

	//floats
	public static float SFXvol = 1f;
	public static float MAINvol = 1f;

	public static float radius = 0.64f;

	//ints
	public static int KillCount;
	public static int ExpCount;
	public static int GoldCount;

	public static int gridH;
	public static int gridW;

	//lists
	public static List<List<GameObject>> hexCells = new List<List<GameObject>>();
	public static List<List<Vector3>> row = new List<List<Vector3>>();
}
