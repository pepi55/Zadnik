using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChestMenu : MonoBehaviour {
	
	public 	List<Texture2D> Items = new List<Texture2D>();
//	private List<Texture2D> ItemRandom = new List <Texture2D>();

	public Texture2D Item1, Item2, Item3,Item4, Item5, Item6;
	public Texture2D ItemRandom1,ItemRandom2,ItemRandom3;

	private float radius; 
	private float Luck;
	private float RandomNumber;

	public bool PopBool = false;
	public bool doWindow0 = true;
	private bool ChestReady = false;

	private Rect PopMenu = new Rect(Screen.width - 200 ,0,200,100);

	void Start(){
		Luck = Mathf.Round(Random.Range(1,2));
		//Voeg de Items toe aan de RandomGenerator
		Items.Add(Item1);
		Items.Add(Item2);
		Items.Add(Item3);
		if(Luck == 2){
			Items.Add(Item4);
			Items.Add(Item5);
			Items.Add(Item6);
		}

		//Check 100x of het mogelijk is om binnen de nummers te blijven
		/*for(int i = 0; i < 100; i++){
			Debug.Log(Random.Range(0, Items.Count + 1));
		}*/

		//Kies een random getal tussen 0 en de grootte van de array en verander hem in de randomItem
		int index1 = Random.Range(0, Items.Count + 1);
		Texture2D ItemRandom1 = Items[index1];

		int index2 = Random.Range(0, Items.Count + 1);
		Texture2D ItemRandom2 = Items[index2];

		int index3 = Random.Range(0, Items.Count + 1);
		Texture2D ItemRandom3 = Items[index3];

		Debug.Log(Items.Count);
		Debug.Log(ItemRandom1 +" "+ ItemRandom2 +" "+ ItemRandom3);
		//Debug.Log("1e = " + index1 + " 2e = "  + index2 + " 3e = " + index3);

		/*
		RandomNumber = Mathf.Round(Random.Range(1,2));
		Debug.Log(RandomNumber);
		if(RandomNumber == 1){
			ItemRandom1 = Item1;
			Debug.Log("1");
		}else if(RandomNumber == 2){
			ItemRandom1 = Item2;
			Debug.Log("2");
		}

		//ItemRandom = Item + 1; //Mathf.Round(Random.Range(1,2));
		*/
		radius = transform.localScale.x;
		ChestReady = true;
	}
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
			dist = Mathf.Sqrt(dist);
			if(dist < radius){
				GlobalValues.bug = "Chest Clicked";
				PopBool = true;
			}
		}
	}
	void DoWindow0(int windowID ) {
		if(GUI.Button(new Rect(0,30, 50,50),ItemRandom1,GUIStyle.none)){
			Debug.Log("FUCK ME");
		}
		GUI.Button(new Rect(50,30, 50,50), ItemRandom2,GUIStyle.none);
		GUI.Button(new Rect(100,30, 50,50), ItemRandom3,GUIStyle.none);
		if(GUI.Button(new Rect(10, 80, 100, 20), "Leave")){
			Destroy(gameObject);
			PopBool = false;
		}
		if(GUI.Button(new Rect(200 - 20, 0, 20, 20), "X",GUIStyle.none)){
			Destroy(gameObject);
			PopBool = false;
		}
	}
	void OnGUI() {
		//doWindow0 = GUI.Toggle(new Rect(10, 10, 100, 20), doWindow0, "Window 0");
		if(ChestReady){
			if (PopBool){
				GUI.Window(0, PopMenu, DoWindow0, "Chest",GUIStyle.none);
			}
		}

	}
}
