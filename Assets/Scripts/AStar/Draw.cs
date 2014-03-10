using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Draw {
	public static void DrawCube (Vector2 pos, Vector2 size, Color color) {
		Vector2 leftDown = new Vector2(-size.x / 2.0f, -size.y / 2.0f);
		Vector2 rightDown = new Vector2(size.x / 2.0f, -size.y / 2.0f);
		Vector2 rightUp = new Vector2(size.x / 2.0f, size.y / 2.0f);
		Vector2 leftUp = new Vector2(-size.x / 2.0f, size.y / 2.0f);

		Vector2[] cube2d = new Vector2[4];

		cube2d[0] = leftDown;
		cube2d[1] = rightDown;
		cube2d[2] = rightUp;
		cube2d[3] = leftUp;

		for (int i = 0; i < cube2d.Length; i++) {
			cube2d[i] += pos;
		}

		for (int i = 0; i < cube2d.Length; i++) {
			for (int j = 0; j < cube2d.Length; j++) {
				if (i != j) {
					Debug.DrawLine(cube2d[i], cube2d[j], color);
				}
			}
		}
	}
}