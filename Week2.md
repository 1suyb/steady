## Input Rebinding
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