using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyControl : MonoBehaviour {
	public Animator animator;
	public AudioClip playerHit1,playerHit2,playerHit3,playerDeath;
	/*--- PUBLICS ---*/
	//list
	public static List<PathNode> E_solvedPath = new List<PathNode>();

	//delegate
	public delegate void Player();

	//event
	public static event Player HitPlayer;
	/*--- END PUBLICS ---*/
	
	/*--- PRIVATES ---*/
	//int
	private int E_startIndex;
	private int E_endIndex;
	private int E_lastStartIndex;
	private int E_lastEndIndex;
	private int E_place;
	private int playerPain;

	private int HitPoints = 5;

	//float
	private float radius = 0.5f;

	//gameobject
	private GameObject E_start;
	private GameObject E_end;
	
	//bool
	private bool E_pathDone;
	private bool E_reset;

	//list
	private List<PathNode> E_sources;
	/*--- END PRIVATES ---*/
	
	void Start () {
		animator = GetComponent<Animator>();
		E_sources = HexGrid.sources;
		E_start = this.gameObject;
	}
	
	void OnEnable () {
		GameControler.EnemyAction += GetEnemyPath;
		GameControler.HitEnemy += HitEnemy;
	}
	
	void OnDisable () {
		GameControler.EnemyAction -= GetEnemyPath;
		GameControler.HitEnemy -= HitEnemy;
	}
	
	private IEnumerator Move () {
		/*--- MOVEMENT ---*/
		float dist = Mathf.Pow(transform.position.x - GlobalValues.player.transform.position.x, 2) + Mathf.Pow(transform.position.y - GlobalValues.player.transform.position.y, 2);
		Mathf.Sqrt(dist);

		if (/*!GlobalValues.playerMove || */dist < radius + 1) {
			if (HitPlayer != null) {
				HitPlayer();
			}
			return false;
		} else if (GlobalValues.playerMove) {
			transform.position = E_solvedPath[1].transform.position;
			/*if (E_solvedPath[1].tag == GlobalValues.cellTag) {
				transform.position = E_solvedPath[1].transform.position;
				E_solvedPath[1].tag = GlobalValues.enemyTag;
			}*/
			
			yield return new WaitForSeconds(0.5f);

			GetEnemyPath();
		}
	}

	private void HitEnemy () {
		/*--- PLAYER HITS ---*/
		if (HitPoints != 0) {
			Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(mousePos.x - transform.position.x,2) + Mathf.Pow(mousePos.y - transform.position.y,2);
			float ply = Mathf.Pow(mousePos.x - GlobalValues.player.transform.position.x, 2) + Mathf.Pow(mousePos.y - GlobalValues.player.transform.position.y, 2);
			
			ply = Mathf.Sqrt(ply);
			dist = Mathf.Sqrt(dist);
			
			if(dist < radius && ply < (radius + 1.0f)){
				HitPoints -= GlobalValues.Power + 1;
				playerPain = Random.Range(1,10);
				Debug.Log(playerPain);
				switch(playerPain){
				case 1:
					AudioSource.PlayClipAtPoint(playerHit1, transform.position, 1);
					break;
				case 2:
					AudioSource.PlayClipAtPoint(playerHit2, transform.position, 1);
					break;
					
				default:
					AudioSource.PlayClipAtPoint(playerHit3, transform.position, 1);
					break;
					
				}
				if(HitPoints == 0){
					AudioSource.PlayClipAtPoint(playerDeath, transform.position, 1);
					Destroy(gameObject);
				}
			}
		}
	}
	
	private void GetEnemyPath () {
		E_end = GlobalValues.player;
		
		while (!E_pathDone) {
			if (E_reset) {
				E_solvedPath.Clear();
				E_reset = false;
			}
			
			if (E_start == null) {
				Debug.LogWarning("No start point!");
				
				E_pathDone = true;
			}
			
			if (E_end == null) {
				Debug.LogWarning("No end point!");
				
				E_pathDone = true;
			}
			
			E_startIndex = Closest(E_sources, E_start.transform.position);
			E_endIndex = Closest(E_sources, E_end.transform.position);
			
			if (E_startIndex != E_lastStartIndex || E_endIndex != E_lastEndIndex) {
				E_reset = true;
				
				E_lastStartIndex = E_startIndex;
				E_lastEndIndex = E_endIndex;
				
				continue;
			}
			
			if (!E_pathDone) {
				E_solvedPath = AStar.CalculatePath(E_sources[E_lastStartIndex], E_sources[E_lastEndIndex]);
				//pathDone = true;
			}
			
			if (E_solvedPath == null || E_solvedPath.Count < 1) {
				Debug.LogWarning("Invalid path!");
				E_reset = true;
				
				break;
			}
			
			for (int i = 0; i < E_solvedPath.Count - 1; i++) {
				if (AStar.InvalidNode(E_solvedPath[i]) || AStar.InvalidNode(E_solvedPath[i + 1])) {
					E_reset = true;
					
					continue;
				}
				
				Debug.DrawLine(E_solvedPath[i].Position, E_solvedPath[i + 1].Position, Color.cyan * new Color(1.0f, 1.0f, 1.0f, 1.0f));
			}
			
			if (E_reset) {
				continue;
			}
			
			if (E_solvedPath != null) {
				StopCoroutine("Move");
				StartCoroutine("Move");

				E_pathDone = true;
			}
		}

		E_pathDone = false;
	}
	
	private static int Closest (List<PathNode> inNodes, Vector2 toPoint) {
		int closestIndex = 0;
		float minDistance = float.MaxValue;
		
		for (int i = 0; i < inNodes.Count; i++) {
			if (AStar.InvalidNode(inNodes[i])) continue;
			
			float thisDistance = Vector2.Distance(toPoint, inNodes[i].Position);
			
			if (thisDistance > minDistance) continue;
			
			minDistance = thisDistance;
			closestIndex = i;
		}
		
		return closestIndex;
	}
}