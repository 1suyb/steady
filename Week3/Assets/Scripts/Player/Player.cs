using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public PlayerController Controller{ get; private set; }
	public PlayerConditions Conditions { get; private set; }

	private void Awake()
	{
		Controller = GetComponent<PlayerController>();
		Conditions = GetComponent<PlayerConditions>();
		CharacterManager.Instance.Player = this;
	}
}
