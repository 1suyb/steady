using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuOpenButton : MonoBehaviour
{
	[SerializeField] private GameObject _pauseMenu;

	private void Start()
	{
		this.GetComponent<Button>().onClick.AddListener(PauseGame);
	}
	public void PauseGame()
	{
		_pauseMenu.SetActive(true);
		GameManager.Instance.PauseGame();
	}
}
