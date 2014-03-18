using UnityEngine;
using System.Collections;

public class BoogerController : MonoBehaviour 
{
	public float speed;
	public float damage = 50;
	public float destroyTime;

	void Start()
	{
		Destroy(gameObject, destroyTime);
	}

	void Update()
	{
		this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
