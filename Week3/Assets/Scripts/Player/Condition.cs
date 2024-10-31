using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
	[SerializeField] private float curValue;
	[SerializeField] private float maxValue;
	[SerializeField] private float startValue;
	[SerializeField] private float passiveValue;
	[SerializeField] private Image uiBar;

	public float PassiveValue => passiveValue;
	public bool isExhausted => curValue<=0.0f;

	private void Start()
	{
		curValue = startValue;
	}
	private void Update()
	{
		uiBar.fillAmount = GetPercentage();
	}
	public void Add(float amout)
	{
		curValue = Mathf.Min(curValue+amout, maxValue);
	}
	public void Subtract(float amout)
	{
		curValue = Mathf.Max(curValue - amout, 0);
	}
	public float GetPercentage()
	{
		return curValue/maxValue;
	}

}
