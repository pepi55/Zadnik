using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GlobalValues {
	//strings
	public static string screenPos;

	public static string cellName = "hexGridCell";
	public static string cellTag = "gridCell";
	public static string cellPath = "Grid/HexTile";
	
	public static string dummyTag = "dummy";
	public static string dummyName = "dummy";
	public static string dummyPath = "Enemies/Dummy";

	public static string chestTag = "chest";
	public static string chestName = "chest";
	public static string chestPath = "Objects/Chest";

	public static string gameControllerTag = "GameController";
	public static string playerTag = "Player";

	public static string bug = "";

	//floats
	public static float SFXvol = 1f;
	public static float MAINvol = 1f;

	public static float radius = 0.64f;

	//ints
	public static int KillCount;
	public static int ExpCount;
	public static int GoldCount;
	public static int level;

	public static int gridH;
	public static int gridW;
	
	//bools
	public static bool Death = false;
	public static bool active = false;

	//vectors
	public static Vector2 playerPos = new Vector2();
}
