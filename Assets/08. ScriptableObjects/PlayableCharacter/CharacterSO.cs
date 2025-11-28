using System;
using UnityEngine;

[Serializable]
public class CharacterData
{
    [field: SerializeField] public string Name { get; private set; }
}

[Serializable]
public class CharacterBattleData
{
    [field: SerializeField] public int MaxHp { get; private set; }
    [field: SerializeField] public int MaxSp { get; private set; }
    /// <summary>
    /// 공격 당 채워지는 Sp
    /// </summary>
    [field: SerializeField] public int SpPerAttack { get; private set; }
    [field: SerializeField] public int Atk { get; private set; }
    [field: SerializeField] public int AttackSpeed { get; private set; }
}

[Serializable]
public class CharacterAliveData
{
    [field: SerializeField] public float MovementSpeed { get; private set; } = 5f;
    [field: SerializeField] public float AttackDistance { get; private set; }
}

[CreateAssetMenu(fileName = "PlayableCharacter", menuName = "SO/PlayableCharacter", order = 0)]
public class CharacterSO : ScriptableObject
{
    [field: SerializeField] public CharacterData Data { get; private set; }
    [field: SerializeField] public CharacterBattleData BattleData { get; private set; }
    [field: SerializeField] public CharacterAliveData AliveData { get; private set; }
}