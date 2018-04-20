using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField]
	private Transform target;
	[SerializeField]
	public Vector3 offset;

	private void LateUpdate()
	{

		Vector3 newPos = target.position + offset;
		newPos = new Vector3(offset.x, offset.y, newPos.z);
		transform.position = newPos;

	}
}
