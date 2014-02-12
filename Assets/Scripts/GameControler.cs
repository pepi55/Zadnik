using UnityEngine;
using System.Collections;

public class GameControler : MonoBehaviour {
	/*--- PUBLICS ---*/
	//transform
	public GameObject hex;
	
	//int
	public int gridHeight = 16;
	public int gridLength = 16;
	
	//float
	public float radius = 0.64f;
	
	//bool
	public bool innerCircleRad = false;
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

		//float
		//rad = 0.64f;

		//bool
		innerCircleRad = false;
			
		//class
		grid = GetComponent<HexGrid>();
		/*--- END INIT ---*/

		grid.DrawGrid(hex);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
