using UnityEngine;
using System.Collections;

public class GameControler : MonoBehaviour {
	/*--- PUBLICS ---*/
	//transform
	public GameObject hex;
	
	//int
	public int gridHeight;
	public int gridLength;
	/*--- END PUBLICS ---*/
	
	/*--- PRIVATES ---*/
	//float
	private float offsetX, offsetY;
	
	//class
	private HexGrid grid = null;
	/*--- END PRIVATES ---*/

	// Use this for initialization
	void Start () {
		/*--- INIT ---*/
		//int
		gridHeight = 16;
		gridLength = 16;

		//class
		grid = GetComponent<HexGrid>();
		/*--- END INIT ---*/

		grid.DrawGrid(hex, gridHeight, gridLength);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
