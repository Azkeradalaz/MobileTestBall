using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	private GameObject manager;
	[SerializeField]
	private AudioClip tapSound;
	private GameObject platformGenerator;
	private bool gotHit;//переменная для исключения возможности двойного срабатывания


	private void Start()
	{
		manager = GameObject.Find("GameManager");
		platformGenerator = GameObject.Find("PlatformGenerator");
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (!gotHit)//проверка на случай двойного срабатывания
		{
			if (collision.gameObject.tag == "Player")//если объект - игрок
			{
				gotHit = true;//
				transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), 0.3f);
				manager.GetComponent<ScoreManager>().ScoreUp();
				platformGenerator.GetComponent<PlatformGenerator>().CreatePlatform(collision.transform.position.z);
				AudioSource.PlayClipAtPoint(tapSound, transform.position);
				Destroy(gameObject, 1.5f);// уничтожение объекта

			}
		}
	}
}
