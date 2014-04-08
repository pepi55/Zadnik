using UnityEngine;

using System.Collections;

public class Fader : MonoBehaviour {
	public float fadeSpeed = 0.1f;

	public bool sceneStart = true;

	void Awake(){
		guiTexture.pixelInset = new Rect(0,0,Screen.width,Screen.height);
	}

	void Update(){
		if(sceneStart){
			StartScene();

		}else{
			ClickToContinue();
		}

	}
	void FadeToClear(){
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);

	}

	void FadeToBlack(){
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);

	}
	void ClickToContinue(){
		if(Input.GetMouseButtonDown(0) && !sceneStart){
			EndScene();
			Debug.Log("FUCK YEAH");
		}
	}
	void StartScene(){
		FadeToClear();
		if(guiTexture.color.a <= 0.05f){
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			sceneStart = false;
		}
	}
	
	
	public void EndScene(){
		guiTexture.enabled = true;
		FadeToBlack();
		if(guiTexture.color.a >= 1.10f)
			Screen.orientation = ScreenOrientation.Portrait;
			Application.LoadLevel("StartMenu");

	}
}
