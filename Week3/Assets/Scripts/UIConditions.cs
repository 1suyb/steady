using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditions : MonoBehaviour
{
	[SerializeField] private Condition health;
	[SerializeField] private Condition hunger;
	[SerializeField] private Condition stamina;
	[SerializeField] private Condition mana;

	public Condition Health => health;
	public Condition Hunger => hunger;
	public Condition Stamina => stamina;
	public Condition Mana => mana;

	private void Start()
	{
		CharacterManager.Instance.Player.Conditions.UIConditions = this;
	}
}
