using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private int score;
	private int coinCount;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text coinsText;
	[SerializeField]
	private GameObject gasStreamPrefab;

	[SerializeField]
	private GameObject gameOverPanel;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject mainCam;
	[SerializeField]
	private GameObject platformGen;



	private string scr = "Score: ";
	private string cn = "Coins: ";
	//повышение очков
	public void ScoreUp()
	{
		score++;
		scoreText.text = scr + score;//обновление счета очков
		if (score % 3 == 0)
		{
			ParticleExp();
		}
	}
	//увеличение количества монет
	public void CoinUp()
	{
		coinCount++;
		coinsText.text = cn + coinCount;//обновление количества монет
		

	}
	//получение текущего счёта
	public int GetScore()
	{
		return score;
	}
	//получение текущего количества монет
	public int GetCoinCount()
	{
		return coinCount;
	}
	//функция обнуления очков
	private void Refresh()
	{
		score = 0;
		scoreText.text = scr + score;
	}
	//активания префаба частиц
	private void ParticleExp()
	{
		//Vector3 randLoc = new Vector3(0, 0, 13);
		Vector3 randLoc = new Vector3(Random.Range(-3, 3), Random.Range(-10, 0), Random.Range(10, 10));
		Instantiate(gasStreamPrefab, randLoc, new Quaternion(0, 0, 0, 0));
	}

	//вывод панели конца игры и включение "паузы"
	public void GameOver()
	{
		gameOverPanel.active = true;
		player.GetComponent<PlayerController>().enabled = false;
		mainCam.GetComponent<CameraFollow>().enabled = false;
		platformGen.SetActive(false);
	}



}
