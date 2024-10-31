using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private GameObject _menu;
	public event Action<Vector2> Moving;
	public event Action<Vector2> Looking;
	public event Action Running;
	public event Action Menu;

	private bool _isMouseLock = false;

	private void Start()
	{
		MouseCursorLock();
	}

	private void MouseCursorLock()
	{
		_isMouseLock = !_isMouseLock;
		Cursor.lockState = _isMouseLock ? CursorLockMode.Locked : CursorLockMode.None;
	}
	
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
		if (_isMouseLock)
			OnLooking(context.ReadValue<Vector2>());
	}

	public void OnRun(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Running?.Invoke();
		}
	}

	public void OnMenu(InputAction.CallbackContext context)
	{
		MouseCursorLock();
		_menu.SetActive(!_isMouseLock);
		Menu?.Invoke();
	}

}
