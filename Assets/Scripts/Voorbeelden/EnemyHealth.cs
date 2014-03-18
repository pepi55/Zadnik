using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public float health = 100f;

	private ScoreScript scoreScript;

	void Awake()
	{
		scoreScript = GameObject.FindGameObjectWithTag("ScoreUI").GetComponent<ScoreScript>();
	}

	void TakeDamage(float dmg)
	{
		health -= dmg;

		if (health <= 0)
		{
			Dead();
		}
	}

	void Dead()
	{
		scoreScript.IncreaseScore(10);
		Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Projectile")
		{
			TakeDamage(other.transform.GetComponent<BoogerController>().damage);
			Destroy(other.gameObject);
		}
	}
}
