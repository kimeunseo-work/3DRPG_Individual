public interface IState
{
    /// <summary>
    /// 플레이어 상태가 변경될 때 최초 1회 실행.
    /// 해당 상태에서 사용할 속성 초기화, 애니메이션 트리거 설정, 변수 리셋 등을 처리.
    /// </summary>
    public void Enter();
    /// <summary>
    /// 다른 상태로 넘어가기 직전에 1회 실행.
    /// 사용한 버퍼·플래그 초기화, 애니메이션 트리거 해제, 이벤트 구독 해제 등을 처리.
    /// </summary>
    public void Exit();
    /// <summary>
    /// 입력 기반 상태 전환 판단.
    /// Move 입력, Jump 입력, Attack 입력 등을 읽어서
    /// 이동 상태 → 점프 상태, 이동 상태 → 공격 상태 같은 전환 결정을 수행.
    /// </summary>
    public void HandleInput();
    /// <summary>
    /// 프레임 기반 논리 처리.
    /// 캐릭터 방향 전환, 애니메이션 파라미터 갱신, stamina 회복·감소처럼 물리 연산이 아닌 일반 로직 실행.
    /// </summary>
    public void Update();
    /// <summary>
    /// FixedUpdate 주기의 물리 처리.
    /// Rigidbody 힘 적용, 속도 조절, 지면 체크(레이캐스트)처럼 물리 기반 이동과 상호작용을 수행.
    /// </summary>
    public void PhysicsUpdate();
}
