using System.Collections.Generic;
using UnityEngine;

public class ObjectPool1 : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	private List<GameObject> pool;
	private int objectCount = 0;
	private const int minSize = 50;
	private const int maxSize = 300;


	void Awake()
	{
		pool = new List<GameObject>();
		for (int i = 0; i < minSize; i++)
		{
			pool.Add(CreateObject());
		}
		objectCount = minSize;
	}
	
	private GameObject CreateObject()
	{
		// [¿ä±¸½ºÆå 1] Create Object
		return Instantiate(prefab);

	}

	public GameObject GetObject()
	{
		// [¿ä±¸½ºÆå 2] Get Object
		if (pool.Count == 0)
		{
			objectCount++;
			return CreateObject();
		}
		GameObject go = pool[pool.Count - 1];
		pool.RemoveAt(pool.Count - 1);
		return go;
	}

	public void ReleaseObject(GameObject obj)
	{
		// [¿ä±¸½ºÆå 3] Release Object
		if (objectCount > maxSize)
		{
			Destroy(obj);
			objectCount--;
			return;
		}
		pool.Add(obj);
	}
}