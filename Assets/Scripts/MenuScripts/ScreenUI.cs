using UnityEngine;
using System.Collections;

public class ScreenUI : MonoBehaviour {
	
	public Texture2D background, LOGO, ActionMenuBtn, howtoBtn, statBtn, controllsBtn;
	public Texture2D optionBtn, creditBtn, quitbtn, volumeBox, brightBox, backBtn;
	public Texture2D controlBtn,tutBtn;

	public GUISkin guiSkin;
	public string LvlName = "" , TutName = "";
	public string[] AboutTextLines = new string[0];
	
	
	private string clicked = "", MessageDisplayOnAbout = "This game is made by Team Zadnik \n ";
	private Rect WindowRect = new Rect(0, Screen.height - 20, Screen.width, Screen.height);
	private Rect HugeRect = new Rect(0, 0, Screen.width, Screen.height);
	private float volume = 1.0f;
	
	private void Start()
	{
		//---------------------de credits worden hierin gestopt zodat het al klaar staat---------------------//
		for (int x = 0; x < AboutTextLines.Length;x++ ){
			MessageDisplayOnAbout += AboutTextLines[x] + " \n ";

		}
		MessageDisplayOnAbout += "Use two fingers to return to main";
	}

	//---------------------de function om bij een click een andere te kiezen------------------------------------------//
	private void OnGUI()
	{
		if (background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
		if (LOGO != null && clicked != "credits")
			GUI.DrawTexture(WindowRect, LOGO);
		
		GUI.skin = guiSkin;
		if (clicked == ""){
			WindowRect = GUI.Window(0, WindowRect, menuFunc, "Main Menu" ,GUIStyle.none);

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


	//-----------------------De option field----------------------//
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

	//------------------------------------------------How to play Scherm----------------------------//
	private void HowToFunc(int id){

		if(GUILayout.Button(tutBtn,GUIStyle.none)){
			Application.LoadLevel("");
		}
		if (GUILayout.Button(backBtn,GUIStyle.none)){
			clicked = "";

		}
	}

	//-------------------------------------------------Stat Scherm--------//
	private void StatFunc(int id){
		string killPoints 		= GlobalValues.KillCount.ToString();
		string expPoints 		= GlobalValues.ExpCount.ToString();
		string goldPoints 		= GlobalValues.ExpCount.ToString();
		string widthPoints 		= Screen.width.ToString();
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

	//------------------------------------------------Main Menu Scherm----------------------------//
	private void menuFunc(int id)
	{
		if (GUILayout.Button(ActionMenuBtn,GUIStyle.none)){
			Application.LoadLevel(LvlName);

		}
	}
	//----------------------------------------overige functies die buiten de menu gebeuren-----------------------//
	private void Update()
	{
		if (clicked == "credits" && Input.touchCount == 2)
			clicked = "";
	}
}
