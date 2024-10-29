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
	 
