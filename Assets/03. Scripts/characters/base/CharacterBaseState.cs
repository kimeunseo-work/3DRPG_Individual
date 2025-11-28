using UnityEngine;

public class CharacterBaseState : IState
{
    protected Character character;
    protected CharacterStateMachine stateMachine;
    protected CharacterType type;

    public CharacterBaseState(CharacterStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        character = stateMachine.Character;
        type = stateMachine.Character.Type;
    }

    public virtual void Enter()
    {
        Debug.Log($"[{ToString()}] {nameof(Enter)}");
        AddEvents();
    }

    public virtual void Exit()
    {
        Debug.Log($"[{ToString()}] {nameof(Exit)}");
        RemoveEvents();
    }

    public virtual void HandleInput()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }

    protected virtual void AddEvents()
    {
        EventBus_CharacterToBattle.AddOnDeadChanged(
            type,
            DeadChangedHandler
        );
    }
    protected virtual void RemoveEvents()
    {
        EventBus_CharacterToBattle.RemoveOnDeadChanged(
            type,
            DeadChangedHandler
        );
    }

    #region Animation Controllers
    /// <summary>
    /// 애니메이션 시작 함수. 대개 Enter()에서 호출.
    /// </summary>
    /// <param name="animatorHash"></param>
    protected void StartAnimation(int animatorHash)
    {
        stateMachine.Character.Animator.SetBool(animatorHash, true);
    }
    /// <summary>
    /// 애니메이션 종료 함수. 대개 Exit()에서 호출.
    /// </summary>
    /// <param name="animatorHash"></param>
    protected void StopAnimation(int animatorHash)
    {
        stateMachine.Character.Animator.SetBool(animatorHash, false);
    }
    #endregion

    #region Handlers
    /// <summary>
    /// 애니메이션 종료 이벤트 핸들러.
    /// 애니메이션 종료를 전달 받으면 상태 전환을 위해 사용.
    /// </summary>
    protected virtual void AnimationExitedHandler(bool isEnd)
    {
    }
    /// <summary>
    /// 캐릭터 생사 이벤트 핸들러.
    /// 생존 → 사망 | 사망 → 생존시 사용.
    /// </summary>
    protected virtual void DeadChangedHandler(bool? isDead)
    {
    }
    /// <summary>
    /// 캐릭터 스킬 사용 이벤트 핸들러.
    /// </summary>
    protected virtual void SpFulledHandler(bool? isSpFulled)
    {
    }
    #endregion
}