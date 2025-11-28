using UnityEngine;
public class CharacterDieState : CharacterBaseState
{
    public CharacterDieState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine
            .Character
            .AnimationData
            .DieParameterHash
        );

        stateMachine.ChangeMoveDirection(Vector3.zero);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine
            .Character
            .AnimationData
            .DieParameterHash
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

    protected override void DeadChangedHandler(bool? isDead)
    {
        stateMachine.ChangeState(stateMachine.RunState);
    }
}
