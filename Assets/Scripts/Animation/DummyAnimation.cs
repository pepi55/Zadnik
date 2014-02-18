using UnityEngine;
using System.Collections;

public class DummyAnimation : MonoBehaviour {
	private float radius;
	public bool Alive;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		radius = transform.localScale.x;

	}
	
	// Update is called once per frame
	void Update () {

		if(Alive){
			animator.SetBool("Alive",true);
		}else{
			animator.SetBool("Alive",false);
		}
		if(Input.GetMouseButtonDown(0)){
			Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float dist = Mathf.Pow(MousePos.x - transform.position.x,2) + Mathf.Pow(MousePos.y - transform.position.y,2);
			dist = Mathf.Sqrt(dist);
			if(dist > radius){
				Debug.Log("hitting the dummy");
				animator.SetTrigger("Hit");
			}
		}
	
		if(Input.GetKey(KeyCode.Space)){
			if(Alive){
				Alive = false;
			}else{
				Alive = true;
			}
		}
	}
}
