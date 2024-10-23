## Q1
### [구현사항 1]
- RocketControllerC.cs에 OnBoost() 함수 구현
- rocketMovement의 ApplyBoost()를 사용해 boost를 적용하고
- energySystem의 UseEnergy()로 Energy를 사용하게 함
### [구현사항 2]
- EnergyDashBoardC.cs에 UpdateDashBoard구현
- FillBar의 fillAmout를 조절하도록 함
- energySystem의 OnenergyChanged이벤트를 구독함
### [구현사항 3]
- AcheivementManager.cs의 CheckAchievement를 구현
- - 100미터, 200미터, 300미터의 AcheivementSO를 생성하고 이를 AcheivementManager의 achievements에 넣어줌
- RocketMovementC의 OnHighScoreChanged 를 구독하도록 함
- 초기화시 achievements 스렛숄드로 정렬해서 갖고 있도록 함
  - 리스트에 정렬해서 넣어주지 않을 수 있으므로.
- 업적이 SO로 구현되어 있으므로 게임이 종료되도 기록이 남아있으므로 currentThresholdIndex를 초기화 해주는 SetCurrentThresholdIndex() 구현

## Q2
### [구현사항 1]
- UI 구성
### [구현사항 2]
- AchievementView.cs에  CreateAchievementSlots 함수 구현
  - achivements의 크기만큼 슬롯을 생성하도록 함
### [구현사항 3]
- AchievementView.cs UnlockAchievement함수 구현 achievementSlots의 threshold키값으로 찾아 MarkAsChecked를 호출해줌

## Q3
### [구현사항 1]
- RocketControllerC.cs의 OnMove() 구현
  - 좌우 누른 float값을 _moveDirection에 저장함
- RocketMovementC.cs의 Rotate 구현
  - Asine으로 방향을 정하고 그뱡향으로 quternion slerp을 활용해 천천히 돌아가도록 함
### [구현사항 2]
- AlertSystem.cs의 CheckAlert() 구현
  - Start 함수에서 cos(fov)를 구해 alertThreshold를 구해 저장해둠
  - 콜라이더도 없고, 레이도 어울리지 않으니 OverlapCircle로 소행성 레이어 콜라이더를 체크
  - 소행성 콜라이더가 탐지 되었을때 해당 위치와 로켓의 위치의 차이로 로켓->소행성 방향 노멀백터를 구하고, 로켓의 위 노멀 백터의 내적을 구함
  - 노멀백터로 내적을 구하였으므로 cos(x)값과 동일. 내적값이 alert쓰랫숄드보다 크면 시야각 내부에 있는것으로 판단
  ![image](https://github.com/user-attachments/assets/4f2285ee-f211-4cea-9a5c-35adfeb63ed3)
### [구현사항 3]
- 구현사항 2에서 시야각 내부에 있는 것으로 판단될때 animator.SetBool(blicking,true)를 호출
- 아닐땐 animator.SetBool(blicking,false) 호출

   
