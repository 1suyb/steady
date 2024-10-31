using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	[SerializeField] private Transform _camContainer;
	[SerializeField] private float _lookXSensitivity;
	[SerializeField] private float _lookYSensitivity;
	[SerializeField] private float minXLook;
	[SerializeField] private float maxXLook;

	[SerializeField] private LayerMask layerMask;

	private PlayerController _controller;
	private Vector2 _mouseDelta;
	private float _cameraCurrentXRot = 0;

	private void Awake()
	{
		_controller = GetComponent<PlayerController>();
	}
	private void Start()
	{
		_controller.Looking += Look;
	}

	private void LateUpdate()
	{
		PlayerRotate();
		CameraRotate();
	}
	public void Look(Vector2 delta)
	{
		_mouseDelta = delta;
	}
	private void PlayerRotate()
	{
		transform.eulerAngles += new Vector3(0, _mouseDelta.x * _lookYSensitivity, 0);
	}
	private void CameraRotate()
	{
		_cameraCurrentXRot += _mouseDelta.y * _lookXSensitivity;
		_cameraCurrentXRot = Mathf.Clamp(_cameraCurrentXRot, minXLook, maxXLook);
		_camContainer.eulerAngles = new Vector3(-_cameraCurrentXRot, transform.eulerAngles.y, _camContainer.eulerAngles.z);
	}
}
