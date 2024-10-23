using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool3 : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	private Queue<GameObject> pool;
	private int poolCount = 0;
	private const int minSize = 50;
	private const int maxSize = 100;


	void Awake()
	{ 
		pool = new Queue<GameObject>();
		poolCount = 0;
	}
	
	private GameObject CreateObject()
	{
		// [�䱸���� 1] Create Object
		return Instantiate(prefab);

	}

	public GameObject GetObject()
	{
		// [�䱸���� 2] Get Object
		if(pool.Count == 0)
		{
			poolCount++;
			return CreateObject();
		}
		return pool.Dequeue();
	}

	public void ReleaseObject(GameObject obj)
	{
		if (poolCount > maxSize)
		{
			poolCount--;
			Destroy(obj);
			return;
		}
		pool.Enqueue(obj);
	}
}