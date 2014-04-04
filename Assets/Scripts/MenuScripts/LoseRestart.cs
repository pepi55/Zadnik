using UnityEngine;
using System.Collections;

public class LoseRestart : MonoBehaviour {

	void OnMouseDown () {
		Application.LoadLevel("StartMenu");
	}
}
