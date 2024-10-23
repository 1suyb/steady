# Week 2
## Input Rebinding Q1
### 구현사항 0
- 기존의 Input `InputAsset`에 Challenge Map을 추가하고 Space 액션을 추가  
### 구현사항 1
- `Scripts/Week2/InputRebinder.cs` 스크립트의 Start 메소드에 구현
```C#
	void Start()
	{
		// [구현사항 1] actionAsset에서 Space 액션을 찾고 활성화합니다.
		spaceAction = actionAsset.FindActionMap("Challenge").FindAction("Space");
		spaceAction.Enable();

	}
```

### 구현사항 2
```C#
[ContextMenu("RebindSapceToEscape")]
public void RebindSpaceToEscape()
{
    // 매소드
}
```

### 구현사항 3
```C#
public void RebindSpaceToEscape()
{
	spaceAction.ApplyBindingOverride("<keyboard>/Escape");
	Debug.Log("Done!");
}
```

## Generic Singleton Q2
### 구현사항 1
- Singleton.cs
```C#
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
```
- Singleton.cs
### 구현사항 2
```C#
	public virtual void Awake()
	{
		// make it as dontdestroyobject
		DontDestroyOnLoad(transform.root.gameObject);
	}
```

### 구현사항 3
```C#
public class AudioManager : Singleton<AudioManager>
{
	private AudioSource _audioSource;
	private string[] _tempAudioList;
	public override void Awake()
	{
		_audioSource = this.gameObject.GetComponentInChildren<AudioSource>();
		if(_audioSource == null)
		{
			_audioSource = this.gameObject.AddComponent<AudioSource>();
		}
	}
	public void StartBGM()
	{
		_audioSource.clip = Resources.Load<AudioClip>("Sound/BGM_01");
		_audioSource.Play();
	}
}
```

## Object Pool Q3

### 구현사항 1
- ObjectPool1.cs
- ObjectPool을 List로 관리.
- List는 뒤에서 뽑거나 지울때 O(1)이므로 Pool에서 꺼내거나 넣을때 List의 맨뒤에서 오브젝트를 추가하거나 삭제하도록 함
- objectCount로 Object의 개수를 관리하며, Maxcount(300) 초과 일 때 release시 오브젝트를 삭제하도록 함.

### 구현사항 2
- ObjectPool2.cs
- Pool은 queue로 관리하며, 이미 사용중인 object를 list로 관리함
- List는 맨앞에서 오브젝트를 뽑거나 지우면 O(N)이지만, Queue는 obj를 찾아서 삭제해주는 기능이 없어, 사용중인 오브젝트를 list로 관리.
- Pool에서 꺼낼때 queue에서 dequeue로 꺼내고 used에 add로 추가함.
- poolCount로 오브젝트의 개수를 관리하며, maxSize이상이면 used에서 맨 첫번째 오브젝트를 release한 후 재사용함
- Pool에 넣을 때 queue에 enqueu로 넣으며, used에서는 obj를 찾아 remove해줌.
### 구현사항 3
- ObjectPool3.cs
- 구현사항 1이랑 동일.
- 차이점은 list로 관리하던 pool을 queue로 관리하게 수정하였음.
### 구현사항 4
- ObjectPool4.cs
- 구현사항 1을 IObjectPool을 사용하여 구현하였음.