using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
	[SerializeField] private Vector2 _sideDirVec;
	[SerializeField] private float _sideSpeed;
	[SerializeField] private float _forwardSpeed;
	[SerializeField] private float _sideCycle;
	[SerializeField] private float _forwardCycle;

	private float _sideCycleTime;
	private float _forwardCycletime;

	private Rigidbody2D _rigidbody;

	private Vector2 _vibrationDir;

	private Vector2 _sideDir;
	private Vector2 _forwardDir;
	

	private void Awake()
	{
		_sideCycleTime = 0;
		_forwardCycletime = 0;

		_sideDirVec = _sideDirVec == Vector2.zero ? new Vector2(1,0) : _sideDirVec.normalized;
		_sideDir = _sideDirVec;
		_rigidbody = GetComponent<Rigidbody2D>();
		_sideSpeed = _sideSpeed == 0 ? 10 : _sideSpeed;
		_forwardSpeed = _forwardSpeed == 0 ? 10 : _forwardSpeed;
		_sideCycle = _sideCycle == 0 ? 1.0f : _sideCycle;
		_forwardCycle = _forwardCycle == 0 ? 1.0f : _forwardCycle;
		_vibrationDir = new Vector2(-_sideDirVec.y, _sideDirVec.x);
		_forwardDir = _vibrationDir;
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		_sideCycleTime = (_sideCycleTime + _sideCycle * Time.fixedDeltaTime) % 2.0f;
		_forwardCycletime = (_forwardCycletime + _forwardCycle * Time.fixedDeltaTime) % 2.0f;
		

		float sideRadian = _sideCycleTime * Mathf.PI;
		float forwardRadian = _forwardCycletime * Mathf.PI;
		_sideDir = _sideDirVec * Mathf.Sin(sideRadian);
		_forwardDir = _vibrationDir * Mathf.Sin(forwardRadian);
		_rigidbody.velocity = _sideDir * _sideSpeed + _forwardDir * _forwardSpeed;
	}
}
