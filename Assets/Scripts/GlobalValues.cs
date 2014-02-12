using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GlobalValues{
	//strings
	public static string cellName = "hexGridCell";
	public static string cellTag = "gridCell";

	//floats
	public static float SFXvol = 1;
	public static float MAINvol = 1;

	//ints
	public static int KillCount;
	public static int ExpCount;
	public static int GoldCount;

	//lists
	public static List<List<GameObject>> hexCells = new List<List<GameObject>>();
	public static List<List<Vector3>> r = new List<List<Vector3>>();
}
