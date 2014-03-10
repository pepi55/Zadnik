using UnityEngine;
using System.Collections;

public class DummyAnimation : MonoBehaviour {
	public AudioClip dummyHit;
	public AudioClip dummyDeath;
	private float radius;
	private Animator animator;
	private int HitAnim = 0;
	private int HitPoints = 5;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		radius = transform.localScale.x;

	}
	
	// Update is called once per frame
	void Update () {
		animator.SetInteger("Lives",HitPoints);
		if(HitPoints == 1){	
			//AudioSource.PlayClipAtPoint(dummyDeath, transform.position, 1);
			animator.SetBool("Alive",false);
		}
		if(HitAnim != 0){
			HitAnim -= 1;
			animator.SetInteger("Hit",HitAnim);
		}
		if(Input.GetMouseButtonDown(0) && HitPoints != 0){
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
			dist = Mathf.Sqrt(dist);
			if(dist < radius){
				AudioSource.PlayClipAtPoint(dummyHit, transform.position, 1);
				HitPoints -= 1;
				HitAnim = 20;
				animator.SetInteger("Hit",HitAnim);
				if(HitPoints == 0){
					AudioSource.PlayClipAtPoint(dummyDeath, transform.position, 1);
				}
			}
		}
	}
}
