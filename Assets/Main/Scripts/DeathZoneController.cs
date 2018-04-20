using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneController : MonoBehaviour {
	[SerializeField]
	private GameObject toFollow;
	[SerializeField]
	private GameObject manager;


	void FixedUpdate () {
		//следование зоны смерти за игроком
		transform.position = new Vector3(toFollow.transform.position.x, 0f, toFollow.transform.position.z);

	}

	//отправка сообщения о конце игры
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			manager.GetComponent<ScoreManager>().GameOver();
		}
	}
}
