using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : UIPopup
{
	[Header("Button")]
	[SerializeField] private Button _optionButton;

	[Header("OptionPopup")]
	[SerializeField] private GameObject _option;

	protected override void Start()
	{
		base.Start();
		Init(GameManager.Instance.QuitGame, GameManager.Instance.ResumeGame);
		_optionButton.onClick.AddListener(() => { _option.SetActive(true); });
	}


}
