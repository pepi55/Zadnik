using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public float grootte;
	private float extra;
	private float maxHealth = 14;
	private float curHealth;


	// Use this for initialization
	void Start () {
		grootte = transform.localScale.x;
		curHealth = maxHealth + extra;
	}
	
	// Update is called once per frame
	void Update () {
		if(GlobalValues.Death == false){
			Vector3 scale = transform.localScale;
			scale.x = curHealth;
			transform.localScale = scale;
			if(curHealth < 1){
				GlobalValues.Death = true;
			}
			if(Input.GetKeyDown(KeyCode.Space)){
				curHealth -= 1;
			}
		}
	}
}
