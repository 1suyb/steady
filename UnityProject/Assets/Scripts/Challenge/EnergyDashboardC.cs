using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboardC : MonoBehaviour
{
    [SerializeField] private EnergySystemC energySystem;
    [SerializeField] private Image fillBar;
	private void Start()
	{
		fillBar = GetComponent<Image>();
		energySystem.OnEnergyChanged += UpdateDashBoard;

	}


	public void UpdateDashBoard(float energy)
	{
		fillBar.fillAmount = energy / energySystem.MaxFuel;
	}

}