using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private float speed = 2f;
	private Rigidbody rb;

	public float moveSpeed = 0.4f;

	//для плавного движения шара
	//private Vector3 lastPosFollower;
	private float lastPosFollowerX;

	//private Vector3 lastPosObject;
	private float lastPosObjectX;


	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();

		//lastPosFollower = gameObject.transform.position;
		//lastPosObject = gameObject.transform.position;

		lastPosFollowerX = lastPosObjectX = gameObject.transform.position.x;

		rb.AddForce(new Vector3(0, 24f, 0), ForceMode.Impulse);//начальный прыжок
	}
	

	void FixedUpdate () {
		rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed); //постоянное движение шара по оси z
		if (Input.GetMouseButton(0))
		{
			Vector3 pos = Input.mousePosition;
			pos.z = transform.position.z - Camera.main.transform.position.z;
			//float dist = transform.position.z - Camera.main.transform.position.z;

			//pos.z = dist;
			pos = Camera.main.ScreenToWorldPoint(pos);
			//pos.y = lastPosObject.y = lastPosFollower.y = transform.position.y;
			//pos.z = lastPosObject.z = lastPosFollower.z = transform.position.z;
			//lastPosFollower.z = lastPosObject.z = pos.z;
			//transform.position = SmoothApproach(lastPosFollower, lastPosObject, pos, moveSpeed);

			//float newX = SmoothApproachX(lastPosFollower.x, lastPosObject.x, pos.x, moveSpeed);
			float newX = SmoothApproachX(lastPosFollowerX, lastPosObjectX, pos.x, moveSpeed);
			transform.position = new Vector3(newX, transform.position.y, transform.position.z);
			lastPosFollowerX = gameObject.transform.position.x;
			lastPosObjectX = pos.x;
			//lastPosFollower = gameObject.transform.position;
			//lastPosObject = pos;
			//transform.position = Vector3.Lerp(transform.position, pos, moveSpeed);
		}

	}

	//
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Platform")
		{
			rb.AddForce(new Vector3(0, 24f, 0), ForceMode.Impulse);//прыжок при ударе о платформу
		}
	}


	//заимствованная функция плавного движения
	//Vector3 SmoothApproach(Vector3 pastPosition, Vector3 pastTargetPosition, Vector3 targetPosition, float speed)
	//{
	//	float t = Time.deltaTime * speed;
	//	Vector3 v = (targetPosition - pastTargetPosition) / t;
	//	Vector3 f = pastPosition - pastTargetPosition + v;
	//	return targetPosition - v + f * Mathf.Exp(-t);
	//}
	

		//упрощение (облегчение?) под задачи проекта
	float SmoothApproachX(float pastPositionX, float pastTargetPositionX, float targetPositionX, float speed)
	{
		float t = Time.deltaTime * speed;
		float v = (targetPositionX - pastTargetPositionX) / t;
		float f = pastPositionX - pastTargetPositionX + v;
		return targetPositionX - v + f * Mathf.Exp(-t);
	}




}
