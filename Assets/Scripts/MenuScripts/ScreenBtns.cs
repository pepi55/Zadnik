using UnityEngine;
using System.Collections;

public class ScreenBtns : MonoBehaviour {

	public GUISkin guiSkin;
	public Texture2D background, LOGO, startBtn, howtoBtn, statBtn, controllsBtn;
	public Texture2D optionBtn, creditBtn, quitbtn, volumeBox, brightBox, backBtn;
	public Texture2D controlBtn,tutBtn;
	public string LvlName = "" , TutName = "";
	public string[] AboutTextLines = new string[0];
	
	
	private string clicked = "", MessageDisplayOnAbout = "This game is made by Team Zadnik \n ";
	private Rect WindowRect = new Rect(Screen.width / 2, Screen.height / 10, Screen.width / 4, Screen.height);
	private Rect HugeRect = new Rect(0, 0, Screen.width, Screen.height);
	private float volume = 1.0f;
	
	private void Start()
	{
		for (int x = 0; x < AboutTextLines.Length;x++ ){
			MessageDisplayOnAbout += AboutTextLines[x] + " \n ";

		}
		MessageDisplayOnAbout += "Use two fingers to return to main";
	}
	
	private void OnGUI()
	{
		if (background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
		if (LOGO != null && clicked != "credits")
			GUI.DrawTexture(WindowRect, LOGO);
		
		GUI.skin = guiSkin;
		if (clicked == ""){
			WindowRect = GUI.Window(0, HugeRect, menuFunc, "Main Menu" ,GUIStyle.none);

		}
		else if(clicked == "howToPlay"){
			WindowRect = GUI.Window(1, HugeRect, HowToFunc, "howToPlay" ,GUIStyle.none);

		}
		else if(clicked == "stat"){
			WindowRect = GUI.Window(2, WindowRect, StatFunc, "Your Stats" ,GUIStyle.none);

		}
		else if (clicked == "options"){
			WindowRect = GUI.Window(3, WindowRect, optionsFunc, "Options" ,GUIStyle.none);

		}
		else if (clicked == "credits"){
			GUI.Box(new Rect (0,0,Screen.width,Screen.height), MessageDisplayOnAbout);

		}
	}


	//-------De option field------//
	private void optionsFunc(int id)
	{
		GUILayout.Box(volumeBox,GUIStyle.none);
		volume = GUILayout.HorizontalSlider(volume ,0.0f,1.0f);
		AudioListener.volume = volume;

		if (GUILayout.Button(brightBox,GUIStyle.none)){
			Debug.Log("Brightness");
			
		}

		if (GUILayout.Button(controlBtn,GUIStyle.none)){
			Debug.Log("Controlls");
				
		}


		if (GUILayout.Button(backBtn,GUIStyle.none)){
			clicked = "";

		}
	}

	//------How to play Scherm-------//
	private void HowToFunc(int id){
		GUILayout.Box(startBtn);

		if(GUILayout.Button(tutBtn,GUIStyle.none)){
			Application.LoadLevel("");
		}
		if (GUILayout.Button(backBtn,GUIStyle.none)){
			clicked = "";

		}
	}

	//-------Stat Scherm--------//
	private void StatFunc(int id){
		string killPoints 	= GlobalValues.KillCount.ToString();
		string expPoints 	= GlobalValues.ExpCount.ToString();
		string goldPoints 	= GlobalValues.ExpCount.ToString();
		string widthPoints 	= Screen.width.ToString();
		string heightPoints 	= Screen.height.ToString();


		GUILayout.Box("KillCount = " 	+ killPoints);
		GUILayout.Box("Exp earned = " 	+ expPoints);
		GUILayout.Box("Gold earned = " 	+ goldPoints);
		GUILayout.Box("Screenwidth = " 	+ widthPoints);
		GUILayout.Box("screenheight = " + heightPoints);

		if (GUILayout.Button(backBtn,GUIStyle.none)){
			clicked = "";

		}
	}

	//------Main Menu Scherm-------//
	private void menuFunc(int id)
	{
		//buttons 
		if (GUILayout.Button(startBtn,GUIStyle.none)){
			Application.LoadLevel(LvlName);

		}
		if (GUILayout.Button(howtoBtn,GUIStyle.none)){
			clicked = "howToPlay";
			
		}
		if (GUILayout.Button(statBtn,GUIStyle.none)){
			clicked = "stat";

		}

		if (GUILayout.Button(optionBtn,GUIStyle.none)){
			clicked = "options";

		}
		if (GUILayout.Button(creditBtn,GUIStyle.none)){
			clicked = "credits";

		}
		if (GUILayout.Button(quitbtn,GUIStyle.none)){
			Application.Quit();

		}
	}
	
	private void Update()
	{
		if (clicked == "credits" && Input.touchCount == 2)
			clicked = "";
	}
}
