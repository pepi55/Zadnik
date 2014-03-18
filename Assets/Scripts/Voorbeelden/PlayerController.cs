using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float movementSpeed;
	public float rotationSpeed;
	
	public Transform booger;
	public Transform noseTip;

	public float fireRate = 1.0f;

	private float nextFireTime;

	void Update()
	{
		// fetch input
		float y = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		// update transform
		this.transform.Translate(new Vector3(0f, 0f, z) * movementSpeed * Time.deltaTime);
		this.transform.Rotate(new Vector3(0f, y, 0f) * rotationSpeed * Time.deltaTime);

		if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime)
		{
			ShootBooger();
		}
	}

	void FixedUpdate()
	{
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}

	void ShootBooger()
	{
		nextFireTime = Time.time + fireRate;

		Instantiate(booger, noseTip.position, noseTip.rotation);
	}
}
