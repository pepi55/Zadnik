using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour 
{
	public float speed;
	public float attackCooldown = 1.0f;
	public float attackDamage = 50.0f;

	public Transform player;

	private Transform target;
	private float nextAttackTime;
	private bool targetInSight;

	void Update()
	{
		if (target)
		{
			Vector3 raycastDirection = target.position - transform.position;
			Ray ray = new Ray(transform.position, raycastDirection);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform == target)
				{
					transform.LookAt(target);
					transform.Translate(Vector3.forward * speed * Time.deltaTime);					
					
					// calculate distance between enemy & target
					if (Vector3.Distance(this.transform.position, target.position) < 2)
					{
						// if attack is not on cooldown
						if (Time.time > nextAttackTime)	
						{
							Attack();
						}
					}
				}
			}
		}
	}

	void Attack()
	{
		// reset attack cooldown
		nextAttackTime = Time.time + attackCooldown;

		// damage the target
		target.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
	}


	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			target = null;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			target = other.transform;
		}
	}

	void FixedUpdate()
	{
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}
}
