﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health = 100.0f;

	private GUIText healthText;

	void Awake()
	{
		healthText = GameObject.FindGameObjectWithTag("PlayerHealthUI").GetComponent<GUIText>();
		healthText.text = "Health: " + health;
	}

	public void TakeDamage(float dmg)
	{
		health -= dmg;

		healthText.text = "Health: " + health;

		if (health <= 0)
		{
			Dead();
		}
	}

	void Dead()
	{
		Debug.Log("Ik ben dood...!");
	}
}
