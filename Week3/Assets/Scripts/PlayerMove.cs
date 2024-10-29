using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody _rigidbody;

	private PlayerController _controller;
	private Vector2 _dir;

	[SerializeField] private float speed;

	private void Awake()
	{
		_controller = GetComponent<PlayerController>();
		_rigidbody = GetComponent<Rigidbody>();
	}
	private void Start()
	{
		_controller.Moving += SetMoveDir;
	}
	private void Update()
	{
		Move();
	}

	public void SetMoveDir(Vector2 dir)
	{
		_dir = dir.normalized;
	}
	public void Move()
	{
		_rigidbody.velocity = transform.forward * _dir.y * speed + transform.right * _dir.x * speed + transform.up*_rigidbody.velocity.y;
	}
}
