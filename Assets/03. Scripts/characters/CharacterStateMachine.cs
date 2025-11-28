using UnityEngine;

/// <summary>
/// 플레이어블 캐릭터 상태 머신 클래스.
/// </summary>
public class CharacterStateMachine : StateMachine
{
    /// <summary>
    /// 상태 머신이 제어하는 캐릭터
    /// </summary>
    public Character Character { get; private set; }

    #region States
    public CharacterRunState RunState { get; private set; }
    public CharacterAttackState AttackState { get; private set; }
    public CharacterSkillState SkillState { get; private set; }
    public CharacterDieState DieState { get; private set; }
    #endregion

    #region State가 필요로 하는 데이터
    // 이동 방향
    public Vector3 MoveDirection { get; private set; }
    // 이동 속도
    public float MoveSpeed { get; private set; }
    // 회전 속도
    public float RotationDamping { get; private set; } = 1f;
    // 목표물 위치
    public Transform Target { get; private set; }
    // 발견 사거리
    public float FindDistance { get; private set; }
    // 공격 사거리
    public float AttackDistance { get; private set; }
    // 공격 속도
    public float AttackSpeed { get; private set; }
    // 스킬 사용 가능 여부
    public bool IsSkillAvailable { get; private set; } = false;

    #endregion

    /// <summary>
    /// 캐릭터 객체를 전달받아 초기화
    /// </summary>
    /// <param name="character">제어하는 캐릭터</param>
    public CharacterStateMachine(Character character)
    {
        Character = character;

        RunState = new(this);
        AttackState = new(this);
        SkillState = new(this);
        DieState = new(this);

        var data = character.Data;
        Target = character.Target;
        MoveSpeed = data.AliveData.MovementSpeed;
        AttackDistance = data.AliveData.AttackDistance;
        AttackSpeed = data.BattleData.AttackSpeed;
    }

    public void ChangeMoveDirection(Vector3 vector)
    {
        MoveDirection = vector;
    }
}