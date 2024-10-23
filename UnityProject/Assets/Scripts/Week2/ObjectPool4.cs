using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool4 : MonoBehaviour
{
	[SerializeField] private GameObject _prefab;
	private IObjectPool<GameObject> _pool;

	public IObjectPool<GameObject> Pool
	{
		get
		{
			if(_pool == null)
			{
				_pool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject, defaultCapacity: 50,maxSize:300);
			}
			return _pool;
		}
	}

	private const int minSize = 50;
	private const int maxSize = 300;

	private void Start()
	{
		for (int i = 0; i < minSize; i++)
		{
			GameObject go = this.Pool.Get();
		}
		for (int i = 0; i < minSize; i++)
		{
			_pool.Release(this.transform.GetChild(i).gameObject);
		}
	}


	private GameObject CreateObject()
	{
		// [¿ä±¸½ºÆå 1] Create Object
		return Instantiate(_prefab,this.transform);
	}

	public void GetObject(GameObject obj)
	{
		// [¿ä±¸½ºÆå 2] Get Object
		obj.SetActive(true);
	}

	public void ReleaseObject(GameObject obj)
	{
		// [¿ä±¸½ºÆå 3] Release Object
		obj.SetActive(false);
	}

	

}