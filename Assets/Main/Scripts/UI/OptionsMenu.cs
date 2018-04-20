using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {

	[SerializeField]
	private List<GameObject> settings = new List<GameObject>(); //спискок для дальшейшего удобства

	private void Start()
	{
		SetMuteSoundToggle();




	}

	//включает-выключает звуки в игре, сохраняет настройку в PlayerPrefs
	public void MuteSound(bool mute)
	{
		if (mute)
		{
			AudioListener.pause = true;
			PlayerPrefs.SetInt("MuteSound", 1);
		}
		else
		{
			AudioListener.pause = false;
			PlayerPrefs.SetInt("MuteSound", 0);
		}
	}

	//загрузка настройки выключения звука из PlayerPrefs
	private void SetMuteSoundToggle()
	{
		int tmp = PlayerPrefs.GetInt("MuteSound");
		if (tmp == 0)
		{
			settings[0].gameObject.GetComponent<UnityEngine.UI.Toggle>().isOn = false;
		}
		else if (tmp == 1)
		{
			settings[0].gameObject.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
		}

	}



}
