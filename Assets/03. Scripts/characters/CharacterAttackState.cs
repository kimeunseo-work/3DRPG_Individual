public class CharacterAttackState : CharacterBattleState
{
    public CharacterAttackState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine
            .Character
            .AnimationData
            .AttackParameterHash
        );
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine
            .Character
            .AnimationData
            .AttackParameterHash
        );
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void AddEvents()
    {
        base.AddEvents();
        EventBus_CharacterToBattle.AddOnSpFulled(
            type,
            SpFulledHandler
        );
    }

    protected override void RemoveEvents()
    {
        base.RemoveEvents();
        EventBus_CharacterToBattle.RemoveOnSpFulled(
            type,
            SpFulledHandler
        );
    }

    protected override void SpFulledHandler(bool? isSpFulled)
    {
        stateMachine.ChangeState(stateMachine.SkillState);
    }
}