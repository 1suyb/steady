using System.Buffers;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRebinder : MonoBehaviour
{
	public InputActionAsset actionAsset;
	private InputAction spaceAction;

	void Start()
	{
		// [�������� 1] actionAsset���� Space �׼��� ã�� Ȱ��ȭ�մϴ�.
		spaceAction = actionAsset.FindActionMap("Challenge").FindAction("Space");
		spaceAction.Enable();

	}

	// [�������� 2] ContextMenu ��Ʈ����Ʈ�� Ȱ���ؼ� �ν�����â���� ������ �� �ֵ��� ��
	[ContextMenu("RebindSapceToEscape")]
	public void RebindSpaceToEscape()
	{
		if (spaceAction == null)
			return;

		// [�������� 3] ���� ���ε��� ��Ȱ��ȭ�ϰ� �� Ű�� ����ε�
		spaceAction.ApplyBindingOverride("<keyboard>/Escape");

		Debug.Log("Done!");
	}

	void OnDestroy()
	{
		// �׼��� ��Ȱ��ȭ�մϴ�.
		spaceAction?.Disable();
	}
}