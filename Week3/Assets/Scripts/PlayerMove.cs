using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody _rigidbody;

	private PlayerController _controller;
	private Vector2 _dir;

	[SerializeField] private float speed;
	[SerializeField] private float runDuration;
	[SerializeField] private float runColldown;
	private float _currentSpeed;

	private bool _isRunCooldown;

	private void Awake()
	{
		_controller = GetComponent<PlayerController>();
		_rigidbody = GetComponent<Rigidbody>();
	}
	private void Start()
	{
		_controller.Moving += SetMoveDir;
		_controller.Running += Run;
		_currentSpeed = speed;
	}
	private void Update()
	{
		Move();
	}

	public void Run()
	{
		if(!_isRunCooldown)
		{
			StartCoroutine(SpeedUp());
		}
		
	}
	private IEnumerator SpeedUp()
	{
		_currentSpeed= speed*5;
		_isRunCooldown = true;
		StartCoroutine(RunCooldown());
		yield return new WaitForSeconds(runDuration);
		_currentSpeed = speed;
		

	}
	private IEnumerator RunCooldown()
	{
		yield return new WaitForSeconds(runColldown);
		_isRunCooldown = false;
	}

	public void SetMoveDir(Vector2 dir)
	{
		_dir = dir.normalized;
	}
	public void Move()
	{
		_rigidbody.velocity = transform.forward * _dir.y * _currentSpeed + transform.right * _dir.x * _currentSpeed + transform.up * _rigidbody.velocity.y;

	}
}
