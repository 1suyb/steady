using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				GameObject go;
				T t = GameObject.FindObjectOfType<T>();
				if (t == null)
				{
					go = new GameObject(typeof(T).Name);
					t = go.AddComponent<T>();

				}
				go = t.gameObject;
				instance = go.GetComponent<T>();
			}
			return instance;

		}
	}


	public virtual void Awake()
	{
		// make it as dontdestroyobject
		DontDestroyOnLoad(transform.root.gameObject);
	}
}

