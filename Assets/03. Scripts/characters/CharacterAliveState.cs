using UnityEngine;

public class CharacterAliveState : CharacterBaseState
{
    public CharacterAliveState(CharacterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine
            .Character
            .AnimationData
            .AliveParameterHash
        );
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine
            .Character
            .AnimationData
            .AliveParameterHash
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

        Move(stateMachine.MoveDirection);
        Rotate(stateMachine.MoveDirection);
    }

    protected override void AddEvents()
    {
        base.AddEvents();
    }

    protected override void RemoveEvents()
    {
        base.RemoveEvents();
    }

    protected override void DeadChangedHandler(bool? isDead)
    {
        stateMachine.ChangeState(stateMachine.DieState);
    }


    #region Movement
    /// <summary>
    /// 플레이어 전진 함수.
    /// </summary>
    private void Move(Vector3 direction)
    {
        character.Controller.Move(
            stateMachine.MoveSpeed
            * Time.deltaTime
            * direction
        );
    }

    /// <summary>
    /// 플레이어 회전 함수.
    /// </summary>
    private void Rotate(Vector3 direction)
    {
        Transform characterTransform = stateMachine.Character.transform;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        characterTransform.rotation = Quaternion.Slerp(
            characterTransform.rotation, 
            targetRotation, 
            stateMachine.RotationDamping * Time.deltaTime
        );
    }

    #endregion

    /// <summary>
    /// 사거리 안에 몬스터가 들어왔을 때
    /// </summary>
    protected bool CheckDistance(float distance)
    {
        float currentDistance = Vector3.Distance(
            stateMachine.Target.position,
            character.transform.position
        );

        if (currentDistance <= distance)
            return true;
        return false;
    }
}