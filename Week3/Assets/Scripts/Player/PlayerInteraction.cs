using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	[SerializeField] private float checkRate = 0.5f;
	[SerializeField] private float maxCheckDistance;
	[SerializeField] private LayerMask layerMask;

	private bool _isLookInteractableObject = false;
	private IInteractable _tempInteractable = null;

	private float lastCheckTime;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

	public void DetectInteractObject()
	{
		Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
		Ray ray = Camera.main.ScreenPointToRay(screenCenter);
		Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward);
		if (Physics.Raycast(ray, out RaycastHit hit, 10f, layerMask))
		{
			if (!_isLookInteractableObject)
			{
				_isLookInteractableObject = true;
				_tempInteractable = hit.collider.gameObject.GetComponentInParent<IInteractable>();
				_tempInteractable.ShowInformation();
			}
		}
		else
		{
			if (_isLookInteractableObject)
			{
				_isLookInteractableObject = false;
				_tempInteractable.CloseInformation();
			}
		}
	}
}
