using System;
using System.Linq;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    private int currentThresholdIndex;

    [SerializeField] private AchievementSO[] achievements;
    [SerializeField] private AchievementView achievementView;

    public int NextThreshold { get; private set; }

    private void Awake()
    {
        Instance = this;
		achievements = achievements.OrderBy(x=>x.threshold).ToArray();
        RocketMovementC.OnHighScoreChanged += CheckAchievement;
        SetCurrentThresholdIndex();
	}
    // 업적시스템을 so로 관리하므로 게임을 종료해도 클리어 여부가 남아 있음.
    // 아직 클리어하지 않은 index를 찾아주는 함수
    private void SetCurrentThresholdIndex()
    {
        for(int i = 0; i < achievements.Length; i++)
        {
            if (!achievements[i].isUnlocked) { currentThresholdIndex = i; return; }
		}
        currentThresholdIndex = achievements.Length - 1;

	}

    private void Start()
    {
        achievementView.CreateAchievementSlots(achievements);  // UI 생성
    }

    // 최고 높이를 달성했을 때 업적 달성 판단, 이벤트 기반으로 설계할 것
    // 
    private void CheckAchievement(float height)
    {
        if(!(achievements[currentThresholdIndex].threshold > height))
        {
            achievements[currentThresholdIndex].isUnlocked = true;
            if (currentThresholdIndex < achievements.Length-1)
                currentThresholdIndex++ ;
		}
    }
}