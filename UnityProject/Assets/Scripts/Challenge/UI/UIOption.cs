using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIOption : UIPopup
{
	[Header("Sound")]
	[SerializeField] private Slider _bgmSlider;
	[SerializeField] private Slider _sfxSlider;

	[Header("Resoultion")]
	[SerializeField] private TMP_Dropdown _resoultionDropDown;

	private Resolution[] resolutions;

	protected override void Start()
	{
		base.Start();
		resolutions = Screen.resolutions;
		_resoultionDropDown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}
		}

		_resoultionDropDown.AddOptions(options);
		_resoultionDropDown.value = currentResolutionIndex;
		_resoultionDropDown.RefreshShownValue();
	}

	public void SetResolution(int resolutionIndex)
	{
		Debug.Log(resolutionIndex);
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}
}


	/*
	
	using UnityEngine;
using UnityEngine.UI;

	public class ResolutionManager : MonoBehaviour
	{
	    public TMP_Dropdown resolutionDropdown;
	 
	    private Resolution[] resolutions;
	 
	   	private void Start()
	    {
	        resolutions = Screen.resolutions;
	 
	        resolutionDropdown.ClearOptions();
	 
	        HashSet<string> options = new HashSet<string>();
	 
	        int currentResolutionIndex = 0;
	        for (int i = 0; i < resolutions.Length; i++)
	        {
	            string option = resolutions[i].width + " x " + resolutions[i].height;
	            options.Add(option);
	 
	            if (resolutions[i].width == Screen.currentResolution.width &&
	                resolutions[i].height == Screen.currentResolution.height)
	            {
	                currentResolutionIndex = i;
	            }
	        }
	 
	        resolutionDropdown.AddOptions(new List<string>(options));
	        resolutionDropdown.value = currentResolutionIndex;
	        resolutionDropdown.RefreshShownValue();
	    }
	 
	    public void SetResolution(int resolutionIndex)
	    {
	        Resolution resolution = resolutions[resolutionIndex];
	        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	    }
	}
	 */
