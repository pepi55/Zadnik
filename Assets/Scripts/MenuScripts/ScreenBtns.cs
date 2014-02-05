﻿using UnityEngine;
using System.Collections;

public class ScreenBtns : MonoBehaviour {

	public GUISkin guiSkin;
	public Texture2D background, LOGO,startBtn;
	public string LvlName = "";
	public string[] AboutTextLines = new string[0];
	
	
	private string clicked = "", MessageDisplayOnAbout = "This game is made by Team Zadnik \n ";
	private Rect WindowRect = new Rect((Screen.width / 2) - 100, 0, 200, 200);
	private float volume = 1.0f;
	
	private void Start()
	{
		for (int x = 0; x < AboutTextLines.Length;x++ )
		{
			MessageDisplayOnAbout += AboutTextLines[x] + " \n ";
		}
		MessageDisplayOnAbout += "Use two fingers to return to main";
	}
	
	private void OnGUI()
	{
		if (background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
		if (LOGO != null && clicked != "about")
			GUI.DrawTexture(WindowRect, LOGO);
		
		GUI.skin = guiSkin;
		if (clicked == "")
		{
			WindowRect = GUI.Window(0, WindowRect, menuFunc, "Main Menu");
		}
		else if(clicked == "howToPlay"){
			WindowRect = GUI.Window(1, WindowRect, menuFunc, "howToPlay");
		}
		else if (clicked == "options")
		{
			WindowRect = GUI.Window(1, WindowRect, optionsFunc, "Options");
		}
		else if (clicked == "about")
		{
			GUI.Box(new Rect (0,0,Screen.width,Screen.height), MessageDisplayOnAbout);
		}else if (clicked == "resolution")
		{
			GUILayout.BeginVertical();
			for (int x = 0; x < Screen.resolutions.Length;x++ )
			{
				if (GUILayout.Button(Screen.resolutions[x].width + "X" + Screen.resolutions[x].height))
				{
					Screen.SetResolution(Screen.resolutions[x].width,Screen.resolutions[x].height,true);
				}
			}
			GUILayout.EndVertical();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Back"))
			{
				clicked = "options";
			}
			GUILayout.EndHorizontal();
		}
	}
	
	private void optionsFunc(int id)
	{
		if (GUILayout.Button("Resolution"))
		{
			clicked = "resolution";
		}
		GUILayout.Box("Volume");
		volume = GUILayout.HorizontalSlider(volume ,0.0f,1.0f);
		AudioListener.volume = volume;
		if (GUILayout.Button("Back"))
		{
			clicked = "";
		}
	}
	
	private void menuFunc(int id)
	{
		//buttons 
		if (GUILayout.Button(startBtn))
		{
			Application.LoadLevel(LvlName);
		}
		if (GUILayout.Button("How to play"))
		{
			clicked = "howToPlay";
		}
		if (GUILayout.Button("Options"))
		{
			clicked = "options";
		}
		if (GUILayout.Button("About"))
		{
			clicked = "about";
		}
		if (GUILayout.Button("Quit Game"))
		{
			Application.Quit();
		}
	}
	
	private void Update()
	{
		if (clicked == "about" && Input.touchCount == 2)
			clicked = "";
	}
}
