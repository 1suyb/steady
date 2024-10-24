using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindFirstObjectByType<GameManager>();
				if(_instance == null)
				{
					_instance = new GameObject("GameManager").AddComponent<GameManager>();
				}

				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	public void PauseGame()
	{
		Time.timeScale = 0.0f;
	}
	public void ResumeGame()
	{
		Time.timeScale = 1.0f;
	}
}
