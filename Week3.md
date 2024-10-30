# Week 3
## Q1
### 분석 문제
- 입문 주차와 비교해 입력 받는 방식의 차이와 공통점 비교
	- 입문 주차에서는 sendMessage
		- On+ActionName으로 구성된 함수를 찾아 바인딩 해주고, perform일 때 호출해줌
		- PlayerInput과 같은 곳에 붙어 있는 스크립트에 있어야 함.
	- 숙련 주차에서는 Unity Event로 입력 호출
		- 직접 함수를 유니티 이벤트에 할당해 줄 수 있음.
		- perform일 때만 불리는 것이 아니라 start perform cancle 일때 불려 각 상황에 맞게 제어 할 수 있음.
		- start perform cancle 각각의 상태는 InputAction.CallbackContext에서 각각의 bool 값을 가져다 쓸 수 있음.

- CharacterManager(CM)와 Player의 역할
	- CM은 singleton으로 생성된 player를 들고 있으면서, player를 전역 변수 처럼 여기저기 전해주기 쉽도록 함
	- Player는 플레이어가 들고 있는 스크립트들(컴포넌트들)을 관리해줌

- 핵심로직 분석 (Move, CameraLook, IsGrounded)
	- Move   
		OnMoveInput에서 눌린 버튼에 따라 방향을 저장함  
		OnMoveInput에서 받은 ws를 눌러 얻은 y축은 캐릭터의 전진/후진이므로 캐릭터 기준 z축의 이동방향  
		 ad를 눌러 얻은 얻은 x축은 캐릭터의 좌우 이므로 캐릭터 기준 x축의 이동으로 함  
		Move에서 OnMoveInput에서 지정한 방향대로 움직이도록 rigidbody에 velocity를 설정해줌.  
		이때, y축은 기존의 velocity를 사용하도록 하여 점프등이 움직임에 영향 받지 않도록 함
	- CameraLook  
		마우스의 y축 이동의 변화량에 따라 카메라가 위아래로(x축) 회전하도록 하였음.  
		마우스의 x축 이동의 변화량에 따라 캐릭터가 좌우로 회전(y축) 하도록 하였음.  
	- IsGrounded  
		바닥으로 짧은 ray를 쏘아 땅에 닿았는지를 검사.  
		이때 앞뒤 좌우로 조금의 간격을 두고 쏘아 캐릭터가 살짝 걸쳤을 때도 땅에 닿았음을 감지 할 수 있도록 함


- Move와 CameraLook함수를 각각 fixedUpdate, LateUpdate에서 호출하는 이유
	 - fixedUpdate는 고정된 시간간격으로 호출되는 함수로, 일정하게 처리되어야 하는 물리처리에 적합한 함수임. 이에 따라 캐릭터 이동의 물리 처리는 FixedUpdate에서 처리함.
	 - LateUpdate는 모든 물리등의 처리가 완료되고 마지막에 호출되는 함수로, 해당 프레임에 일어날 일들이 모두 일어난후 호출됨. 따라서 랜더링 관련된 함수는 lateupdate에서 처리함.
	 
### 확장
- Menu액션 생성 및 tab키 바인딩
- controller에 isMouseLock 플래그를 만들어 해당 플래그에 따라 마우스 커서 및 회전이 잠겼다 풀리도록 구현
### 개선
- Run 액션 생성 및 leftshift키 바인딩
- playermove에 코루틴을 사용하여 speed를 5배 늘렸다가 일정시간후 되돌림.
- isRunCooldown 플래그를 만들어 쿨다운 시간동안 달리기가 다시 실행되지 못하도록 함
- cooldown 또한 코루틴에서 관리

## Q2
### 분석 문제
- 별도의 UI 스크립트를 만드는 이유에 대해 객체지향적 관점에서 생각
	- 단일 책임 원칙
		- 게임 로직은 게임로직을 처리하는 부분에서, Ui는 UI를 처리하는 클래스에서 처리하도록 하여 단일 책임 원칙을 지킬 수 있음.
	- 개방/폐쇄 원칙
		- UI와 로직을 함께 만들게 되면 로직을 추가하는데 UI를 바꿔야하는 경우가 생길 수 있음.
- 인터페이스의 특징에 대해 정리하고 구현된 로직을 분석
	- 인터페이스의 특징
		- 어떤 행동, 기능을 한다는 것을 명시 해둠.
		- 이 인터ㅔ이
	- IDamagable 로직 분석