using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private Rect WindowRect;
	public int ScorePoints;
	void Start(){
		WindowRect = new Rect(5, Screen.height - 20, 100, 20);
	}
	void OnGUI(){
		GUI.color = Color.white;
		GUI.Label(WindowRect,"Score " + GlobalValues.bug  + "   Level = " + GlobalValues.level);
	}

}
