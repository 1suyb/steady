using System;
using UnityEngine;

public interface IDamagable
{
    public void TakePhysicalDamage(int damageAmount);
}

public interface IRecoverable
{
	public void Heal(int amount);
}


public class PlayerConditions : MonoBehaviour, IDamagable, IRecoverable
{
	private UIConditions uiCondition;
	public UIConditions UIConditions
	{
		get => uiCondition;
		set => uiCondition = value;
	}

	private Condition health => uiCondition.Health;
	private Condition hunger => uiCondition.Hunger;
	private Condition stamina => uiCondition.Stamina;
	private Condition mana => uiCondition.Mana;

	[SerializeField] private float noHunerHealthDecay;
	public event Action onTakeDamage;

	private void Update()
	{
		hunger.Subtract(hunger.PassiveValue * Time.deltaTime);
		stamina.Add(stamina.PassiveValue * Time.deltaTime);
		mana.Add(mana.PassiveValue * Time.deltaTime);
		if (hunger.isExhausted)
		{
			health.Subtract(noHunerHealthDecay*Time.deltaTime);
		}
		if(health.isExhausted)
		{
			Die();
		}
	}

	private void Die()
	{
		Debug.Log("¡Í±›");
	}

	public void Eat(float amount)
	{
		hunger.Add(amount);
	}

	public void TakePhysicalDamage(int damageAmount)
	{
		health.Subtract(damageAmount);
		onTakeDamage?.Invoke();
	}

	public void Heal(int amount)
	{
		health.Add(amount);
	}

	public void UseSkill(int amount)
	{
		mana.Subtract(amount);
	}
	public void RecoveryMana(int amount)
	{
		mana.Add(amount);
	}

}
