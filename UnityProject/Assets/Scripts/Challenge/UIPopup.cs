using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopup : MonoBehaviour
{
	private Action _acceptEvent;
	private Action _rejectEvent;

	public void Init(Action acceptEvent, Action rejectEvent)
	{
		_acceptEvent = acceptEvent;
		_rejectEvent = rejectEvent;
	}
	
	public virtual void OnAccept()
	{
		_acceptEvent?.Invoke();
	}
	public virtual void OnReject()
	{
		_rejectEvent?.Invoke();
	}

}
