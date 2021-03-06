﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GlobalValues {
	//strings
	public static string screenPos;

	public static string finishedLevel = "nextlevel";

	public static string cellName = "hexGridCell";
	public static string cellTag = "gridCell";
	public static string cellPath = "Grid/HexTile";

	public static string wallTag = "wall";
	public static string wallName = "wall";
	public static string wallPath = "Grid/Wall";
	
	public static string dummyTag = "dummy";
	public static string dummyName = "dummy";
	public static string dummyPath = "Enemies/Dummy";

	public static string chestTag = "chest";
	public static string chestName = "chest";
	public static string chestPath = "Objects/Chest";

	public static string enemyTag = "enemy";
	public static string enemyName = "enemy";
	public static string enemyPath = "Enemies/Enemy1";
	public static string enemyPath2 = "Enemies/Enemy2";

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
	public static int level = 1;
	public static int Power;
	public static int DummyKill = 5;

	public static int gridH = 20;
	public static int gridW = 20;

	public static int playerHP = 10;
	
	//bools
	public static bool Death = false;
	public static bool zoomUp = false;
	public static bool zoomDown = false;
	public static bool playerMove = false;
	public static bool invOpen = false;
	public static bool screenStance = true;

	//gameobjects
	public static GameObject player;
	public static GameObject targetTile;

	//lists
	public static List<GameObject> enemies = new List<GameObject>();
}