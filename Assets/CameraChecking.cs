using UnityEngine;
using System.Collections;

public class CameraChecking : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GlobalValues.screenStance == true){
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}else{
			Screen.orientation = ScreenOrientation.Portrait;
		}
	}
}
