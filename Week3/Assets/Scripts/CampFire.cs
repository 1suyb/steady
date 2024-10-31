using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
	[SerializeField] private int damage;
	[SerializeField] private float damageRate;

	private Dictionary<IDamagable,Coroutine> coroutines = new Dictionary<IDamagable, Coroutine> ();
	private WaitForSeconds waitTime;

	private void Awake()
	{
		waitTime = new WaitForSeconds(damageRate);
	}

	private void Start()
	{
		//StartCoroutine(DealDamage());
	}

	private IEnumerator DealDamage(IDamagable damagable)
	{
		while (true)
		{
			damagable.TakePhysicalDamage(damage);
			yield return waitTime;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.TryGetComponent(out IDamagable damagable))
		{
			coroutines.Add(damagable,StartCoroutine(DealDamage(damagable)));
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.TryGetComponent(out IDamagable damagable))
		{
			StopCoroutine(coroutines[damagable]);
			coroutines.Remove(damagable);
		}
	}

}
