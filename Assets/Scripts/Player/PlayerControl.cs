using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
	/*--- PUBLICS ---*/
	//list
	public static List<PathNode> sources;
	/*--- END PUBLICS ---*/

	/*--- PRIVATES ---*/
	//list
	private List<PathNode> solvedPath = new List<PathNode>();
	/*--- END PRIVATES ---*/

	void Awake () {
		sources = HexGrid.sources;
	}

	void OnEnable () {
		//GameControler.OnClick +=
	}

	void OnDisable () {
		//GameControler.OnClick -=
	}
}