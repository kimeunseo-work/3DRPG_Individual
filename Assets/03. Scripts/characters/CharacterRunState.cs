using UnityEngine;

public class CharacterRunState : CharacterAliveState
{
    public CharacterRunState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine
            .Character
            .AnimationData
            .RunParameterHash
        );

        stateMachine.ChangeMoveDirection(Vector3.forward);
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine
            .Character
            .AnimationData
            .RunParameterHash
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
        // 발견 사거리 안에 몬스터가 들어왔을 때
        if (CheckDistance(stateMachine.FindDistance))
        {
        }
        // 공격 사거리 안에 몬스터가 들어왔을 때
        else if (CheckDistance(stateMachine.AttackDistance))
        {
            // 공격 상태로 전환
            stateMachine.ChangeState(stateMachine.AttackState);
        }

        base.Update();
    }
}