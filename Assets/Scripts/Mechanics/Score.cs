﻿using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private Rect WindowRect;
	public int ScorePoints;
	void Start(){
		WindowRect = new Rect(0, Screen.height - 100, Screen.height / 2, Screen.width / 10);
	}
	void OnGUI(){
		GUI.skin.label.fontSize = 20;
		if(GlobalValues.DummyKill != 0){
			GUI.Label(WindowRect,"You have to kill " + GlobalValues.DummyKill  + " Dummies "/* + GlobalValues.level*/);
		}else{
			GUI.Label(WindowRect,"Good job warrior find your way to the stairway to continue the quest");

		}
	}

}
