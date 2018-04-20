using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
	[SerializeField]
	private AudioClip collectSound; //звук подбора монеты
	[SerializeField]
	private float rotationSpeed = 50f; //скорость кручения монеты, для удобства настраиваемая в инспекторе

	private GameObject manager; //менеджер счета

	private void Start()
	{
		manager = GameObject.Find("GameManager");
	}
	void Update () {
		//кручение вокруг оси
		gameObject.transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed);
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")//если коллизия с игроком
		{
			manager.GetComponent<ScoreManager>().CoinUp();//добавить монету в счёт
			StartCoroutine(CoinPicked());//запустить корутину подбора монеты
		}
	}
	//подбор монеты
	private IEnumerator CoinPicked()
	{
		AudioSource.PlayClipAtPoint(collectSound, transform.position);//проигрывание аудио подбора монеты
		//выключение визуальной и физической части объекта
		gameObject.GetComponent<SphereCollider>().enabled = false;//выключение коллайдера
		gameObject.GetComponent<MeshRenderer>().enabled = false;//выключение меша 
		
		yield return new WaitForSeconds(collectSound.length);//ожидание окончание клипа
		Destroy(gameObject);//уничтожение объекта

	}
}
