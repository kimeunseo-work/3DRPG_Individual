using UnityEngine;
public class CharacterBattleState : CharacterAliveState
{
    public CharacterBattleState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        StartAnimation(stateMachine
            .Character
            .AnimationData
            .BattleParameterHash
        );

        stateMachine.ChangeMoveDirection(Vector3.zero);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine
            .Character
            .AnimationData
            .BattleParameterHash
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

        if (!CanAttackEnemy())
            stateMachine.ChangeState(stateMachine.RunState);
    }
}
