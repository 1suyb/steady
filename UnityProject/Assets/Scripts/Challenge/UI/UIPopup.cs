using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private Button _acceptButton;
	[SerializeField] private Button _cancelButton;
	[SerializeField] private Button _background;

	private Action _acceptEvent;
	private Action _rejectEvent;

	protected virtual void Start()
	{
		Bind();
	}
 
	public void Init(string text, Action acceptEvent, Action rejectEvent)
	{
		_text.text =text;
		Init(acceptEvent, rejectEvent);
	}

	public void Init(Action acceptEvent, Action rejectEvent)
	{
		_acceptEvent = acceptEvent;
		_rejectEvent = rejectEvent;
	}
	public void Bind()
	{
		if (_acceptButton != null)
		{
			_acceptButton.onClick.AddListener(OnAccept);
		}
		if (_cancelButton != null)
		{
			_cancelButton.onClick.AddListener(OnReject);
		}
		if (_background != null)
		{
			_background.onClick.AddListener(OnReject);
		}
	}

	public virtual void OnAccept()
	{
		this.gameObject.SetActive(false);
		_acceptEvent?.Invoke();
	}
	public virtual void OnReject()
	{
		this.gameObject.SetActive(false);
		_rejectEvent?.Invoke();
	}

}
