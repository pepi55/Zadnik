using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	public string levelName;
	// Use this for initialization
	void Start () {
		if(levelName == null){
			Debug.Log("The Desination has no name");
		}
	}
	void OnMouseDown(){
		Application.LoadLevel(levelName);
	}
}
