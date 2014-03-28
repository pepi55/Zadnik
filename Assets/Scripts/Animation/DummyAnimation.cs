using UnityEngine;
using System.Collections;

public class DummyAnimation : MonoBehaviour {
	public AudioClip dummyHit;
	public AudioClip dummyDeath;
	private float radius;
	private Animator animator;
	private int HitAnim = 0;
	private int HitPoints = 5;

<<<<<<< HEAD
	void OnEnable () {
		GameControler.EnemyAction += HitDummy;
	}

	void OnDisable () {
		GameControler.EnemyAction -= HitDummy;
	}
	
=======

>>>>>>> FETCH_HEAD
	void Start () {
		animator = GetComponent<Animator>();
		radius = 0.5f; //transform.localScale.x;
	}

	void Update () {
		animator.SetInteger("Lives",HitPoints);

		if(HitPoints == 0){	
			animator.SetBool("Alive",false);
		}

		if(HitAnim != 0){
			HitAnim -= 1;
			animator.SetInteger("Hit",HitAnim);
		}

		/*if(Input.GetMouseButtonDown(0) && HitPoints != 0){
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
			float ply = Mathf.Pow(MousePos.x - GlobalValues.player.transform.position.x, 2) + Mathf.Pow(MousePos.y - GlobalValues.player.transform.position.y, 2);

			ply = Mathf.Sqrt(ply);
			dist = Mathf.Sqrt(dist);

			if(dist < radius && ply < (radius + 1.0f)){
				AudioSource.PlayClipAtPoint(dummyHit, transform.position, 1);
				HitPoints -= GlobalValues.Power + 1;
				HitAnim = 20;
				animator.SetInteger("Hit",HitAnim);

				if(HitPoints == 0){
					AudioSource.PlayClipAtPoint(dummyDeath, transform.position, 1);
				}
			}
		}*/
	}

	private void HitDummy () {
		if (HitPoints != 0) {
			Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(mousePos.x - transform.position.x,2) + Mathf.Pow(mousePos.y - transform.position.y,2);
			float ply = Mathf.Pow(mousePos.x - GlobalValues.player.transform.position.x, 2) + Mathf.Pow(mousePos.y - GlobalValues.player.transform.position.y, 2);

			ply = Mathf.Sqrt(ply);
			dist = Mathf.Sqrt(dist);

			if(dist < radius && ply < (radius + 1.0f)){
				AudioSource.PlayClipAtPoint(dummyHit, transform.position, 1);
				HitPoints -= GlobalValues.Power + 1;
				HitAnim = 20;
				animator.SetInteger("Hit",HitAnim);
				
				if(HitPoints == 0){
					GlobalValues.DummyKill -= 1;
					Debug.Log(GlobalValues.DummyKill);
					AudioSource.PlayClipAtPoint(dummyDeath, transform.position, 1);
				}
			}
		}
	}

	//-----pas wanneer de dummy visible is word zijn code uitgevoerd----//
	void OnBecameVisible(){
		enabled = true;
	}
	void OnBecameInvisible(){
		enabled = false;
	}
}
