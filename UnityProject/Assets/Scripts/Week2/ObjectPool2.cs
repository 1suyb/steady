using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool2 : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	private Queue<GameObject> pool;
	private List<GameObject> used;
	private int poolCount = 0;
	private const int minSize = 50;
	private const int maxSize = 300;


	void Awake()
	{

		pool = new Queue<GameObject>();
		used = new List<GameObject>();
		for (int i = 0; i < minSize; i++)
		{
			GameObject go = CreateObject();
			pool.Enqueue(go);
		}
		poolCount = minSize;
	}
	
	private GameObject CreateObject()
	{
		// [¿ä±¸½ºÆå 1] Create Object
		return Instantiate(prefab);

	}

	public GameObject GetObject()
	{
		// [¿ä±¸½ºÆå 2] Get Object
		if(pool.Count == 0)
		{
			if(poolCount <= maxSize)
			{
				pool.Enqueue(CreateObject());
				poolCount++;
				
			}
			else
			{
				ReleaseObject(used[0]);
			}
		}
		GameObject go = pool.Dequeue();
		used.Add(go);
		return go;


	}

	public void ReleaseObject(GameObject obj)
	{
		used.Remove(obj);
		pool.Enqueue(obj);
	}
}