/// <summary>
/// 각 상태(IState)를 관리하며,
/// 상태 전환과 업데이트 호출을 중앙에서 처리.
/// </summary>
public abstract class StateMachine
{
    /// <summary>
    /// 현재 활성화된 상태
    /// </summary>
    protected IState currentState;

    /// <summary>
    /// 상태 전환 메서드.
    /// 기존 상태 Exit 호출 → currentState 갱신 → 새 상태 Enter 호출
    /// </summary>
    /// <param name="state">새 상태</param>
    public void ChangeState(IState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }

    /// <summary>
    /// 입력 처리 위임.
    /// 현재 상태의 HandleInput 호출
    /// </summary>
    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    /// <summary>
    /// 논리 업데이트 위임.
    /// 현재 상태의 Update 호출.
    /// </summary>
    public void Update()
    {
        currentState?.Update();
    }

    /// <summary>
    /// 물리 업데이트 위임.
    /// 현재 상태의 PhysicsUpdate 호출.
    /// </summary>
    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}