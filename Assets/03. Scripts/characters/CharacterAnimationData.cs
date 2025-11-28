using System;
using UnityEngine;

[Serializable]
public class CharacterAnimationData
{
    [SerializeField] string aliveParameterName = "@Alive";
    [SerializeField] string runParameterName = "Run";

    [SerializeField] string battleParameterName = "@Battle";
    [SerializeField] string attackParameterName = "Attack";
    [SerializeField] string skillParameterName = "Skill";

    [SerializeField] string dieParameterName = "Die";

    [HideInInspector] public int AliveParameterHash { get; private set; }
    [HideInInspector] public int RunParameterHash { get; private set; }
    [HideInInspector] public int BattleParameterHash { get; private set; }
    [HideInInspector] public int AttackParameterHash { get; private set; }
    [HideInInspector] public int SkillParameterHash { get; private set; }
    [HideInInspector] public int DieParameterHash { get; private set; }

    public void Init()
    {
        AliveParameterHash = Animator.StringToHash(aliveParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);

        BattleParameterHash = Animator.StringToHash(battleParameterName);
        AttackParameterHash = Animator.StringToHash(attackParameterName);
        SkillParameterHash = Animator.StringToHash(skillParameterName);

        DieParameterHash = Animator.StringToHash(dieParameterName);
    }
}