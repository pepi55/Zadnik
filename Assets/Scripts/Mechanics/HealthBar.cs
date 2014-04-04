using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	AudioClip deathSound;
	public float size;
	Vector2 scale;

	/*private float extra = 1;
	private float maxHealth = 14;
	private float curHealth;*/
	
	void Start () {
		//--hiermee word bepaald hoe groot de healthbar is en hoeveel erin zit--//
		/*grootte = transform.localScale.x;
		curHealth = maxHealth + extra;*/

		scale = transform.localScale;
	}

	void Update () {
		//----Zolang je niet dood bent moet je levens eraf halen tot je dood bent-----//
		/*if(GlobalValues.Death == false){
			Vector3 scale = transform.localScale;
			scale.x = curHealth;
			transform.localScale = scale;
			if(curHealth < 1){
				GlobalValues.Death = true;
			}
			if(Input.GetKeyDown(KeyCode.Space)){
				curHealth -= 1;
			}
		}*/

		if (GlobalValues.Death == false) {
			scale.x = GlobalValues.playerHP * size;
			transform.localScale = scale;
		}
	}
}
