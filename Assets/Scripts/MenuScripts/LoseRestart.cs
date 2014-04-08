using UnityEngine;
using System.Collections;

public class LoseRestart : MonoBehaviour {

	void OnMouseDown () {
		Screen.orientation = ScreenOrientation.Portrait;
		Application.LoadLevel("StartMenu");
	}
}
