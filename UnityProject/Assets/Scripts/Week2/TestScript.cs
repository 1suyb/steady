using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    private ObjectPool4 pool;

	private void Awake()
	{
		pool = GetComponent<ObjectPool4>();
	}
	void Start()
    {
        AudioManager.Instance.StartBGM();
        pool.Pool.Get();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            pool.Pool.Get();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            pool.Pool.Release(GameObject.Find("Aesteriod(Clone)"));
        }
    }
}
