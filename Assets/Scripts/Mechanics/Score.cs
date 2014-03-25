using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private Rect WindowRect;
	public int ScorePoints;
	void Start(){
		WindowRect = new Rect(5, Screen.height - 50, 300, 100);
	}
	void OnGUI(){
		GUI.color = Color.white;
		GUI.skin.label.fontSize = 30;
		GUI.Label(WindowRect,"Score " + GlobalValues.bug  + "   Level = " + GlobalValues.level);
	}

}
