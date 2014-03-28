using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private Rect WindowRect;
	public int ScorePoints;
	void Start(){
		WindowRect = new Rect(0, Screen.width / 10 * 9, Screen.height / 10, Screen.width / 10);
	}
	void OnGUI(){
		GUI.skin.label.fontSize = 10;
		GUI.Label(WindowRect,"Score " + GlobalValues.bug  + "   Level = " + GlobalValues.level);
	}

}
