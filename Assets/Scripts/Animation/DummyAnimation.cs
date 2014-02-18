using UnityEngine;
using System.Collections;

public class DummyAnimation : MonoBehaviour {
	public bool Alive;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

		if(Alive){
			animator.SetBool("Alive",true);
		}else{
			animator.SetBool("Alive",false);
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
