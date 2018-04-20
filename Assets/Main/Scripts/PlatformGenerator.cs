using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	[SerializeField]
	private float spawnTime = 3f;
	[SerializeField]
	private List<GameObject> platforms = new List<GameObject>();

	const float constPosModifierZ = 5.9f;//примерное расстояние, которое пролетает шар по оси z за один прыжок 


	void Start ()
	{
		//создание первичных платформ (за исколючением стартовой)
		for (int i = 1; i < 5; i++)
		{
			CreateNewPlatform(constPosModifierZ*i);
		}
	}
	
	//создание новой платфомы (публичная функция)
	public void CreatePlatform(float zPos)
	{
		StartCoroutine(NewPlatform((zPos + 4 * constPosModifierZ)));
	}

	//создание новой платформы (внутренняя функция)
	private void CreateNewPlatform(float zPos)
	{
		int rand = Random.Range(1, 15);
		float randPosX = Random.Range(-3, 3);
		if (rand < 13)
		{
			Instantiate(platforms[0], new Vector3(randPosX, 0, zPos), new Quaternion(0, 0, 0, 0));
		}
		else
		{
			Instantiate(platforms[1], new Vector3(randPosX, 0, zPos), new Quaternion(0, 0, 0, 0));
		}
	}


	//для создания платформы с задержкой
	IEnumerator NewPlatform(float zPos)
	{
		yield return new WaitForSeconds(spawnTime);
		CreateNewPlatform(zPos);


	}

}
