using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public float followSpeed;
	public Transform player;

	private Vector3 offset;

	void Start()
	{
		offset = transform.position - player.position;
	}

	void LateUpdate()
	{
		transform.position = player.position + offset;
	}
}
