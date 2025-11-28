public class CharacterSkillState : CharacterBattleState
{
    public CharacterSkillState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine
            .Character
            .AnimationData
            .SkillParameterHash
        );
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine
            .Character
            .AnimationData
            .SkillParameterHash
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
        EventBus_CharacterToBattle.AddOnSkillAnimationExited(
            type, 
            AnimationExitedHandler
        );
    }

    protected override void RemoveEvents()
    {
        base.RemoveEvents();
        EventBus_CharacterToBattle.RemoveOnSkillAnimationExited(
            type, 
            AnimationExitedHandler
        );
    }

    protected override void AnimationExitedHandler(bool isEnd)
    {
        stateMachine.ChangeState(stateMachine.AttackState);
    }
}