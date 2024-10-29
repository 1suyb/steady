using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public event Action<Vector2> Moving;
	public event Action<Vector2> Looking;
	public event Action Menu;

	private bool _isToggle;

	
	public void OnMoveing(Vector2 dir)
	{
		Moving?.Invoke(dir);
	}
	public void OnLooking(Vector2 dir)
	{
		Looking?.Invoke(dir);
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		OnMoveing(context.ReadValue<Vector2>());
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		OnLooking(context.ReadValue<Vector2>());
	}

	public void OnMenu(InputAction.CallbackContext context)
	{
		Menu?.Invoke();
	}

}
