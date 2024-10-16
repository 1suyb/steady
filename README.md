# steady
## Q1
1) RocketControllerC.cs
```
   public void OnBoost()
	{
		_rocketMovement.ApplyBoost();
		_energySystem.UseEnergy(ENERGY_BURST);
  }
```

---

2) EnergyDashboardC.cs
```
   private void Start()
	{
		fillBar = GetComponent<Image>();
		energySystem.OnEnergyChanged += UpdateDashBoard;

	}
	public void UpdateDashBoard(float energy)
	{
		fillBar.fillAmount = energy / energySystem.MaxFuel;
  }
```

---

3) AcheivementManager.cs
```
    private void Awake()
    {
        Instance = this;
		    achievements = achievements.OrderBy(x=>x.threshold).ToArray();
        RocketMovementC.OnHighScoreChanged += CheckAchievement;
        SetCurrentThresholdIndex();
	  }
    private void SetCurrentThresholdIndex()
    {
        for(int i = 0; i < achievements.Length; i++)
        {
            if (!achievements[i].isUnlocked) { currentThresholdIndex = i; return; }
		    }
        currentThresholdIndex = achievements.Length - 1;
	  }
    private void CheckAchievement(float height)
    {
        if(!(achievements[currentThresholdIndex].threshold > height))
        {
            achievements[currentThresholdIndex].isUnlocked = true;
            if (currentThresholdIndex < achievements.Length-1)
                currentThresholdIndex++ ;
		    }
    }
```

   
