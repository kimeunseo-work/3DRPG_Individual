using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    private ManagerRoot root;
    private Character character;
    private void Awake()
    {
        root = ManagerRoot.Instance;
        character = GameObject.Find("Babarian").GetComponent<Character>();
    }

    public void OnHpIncreased(int amount)
    {
        root.CharacterManager.IncreaseHp(amount);
    }
    public void OnHpDecreased(int amount)
    {
        root.CharacterManager.DecreaseHp(amount);
    }
    public void OnMaxHpIncreased(int amount)
    {
        root.CharacterManager.IncreaseMaxHp(amount);
    }
    public void OnMaxHpDecreased(int amount)
    {
        root.CharacterManager.DecreaseMaxHp(amount);
    }
    public void OnMpIncreased(int amount)
    {
        root.CharacterManager.IncreaseMp(amount);
    }
    public void OnMpDecreased(int amount)
    {
        root.CharacterManager.DecreaseMp(amount);
    }
    public void OnMaxMpIncreased(int amount)
    {
        root.CharacterManager.IncreaseMaxMp(amount);
    }
    public void OnMaxMpDecreased(int amount)
    {
        root.CharacterManager.DecreaseMaxMp(amount);
    }
    public void OnExpIncreased(int amount)
    {
        root.CharacterManager.IncreaseExp(amount);
    }
    public void OnExpDecreased(int amount)
    {
        root.CharacterManager.DecreaseExp(amount);
    }
    public void OnMaxExpIncreased(int amount)
    {
        root.CharacterManager.IncreaseMaxExp(amount);
    }
    public void OnMaxExpDecreased(int amount)
    {
        root.CharacterManager.DecreaseMaxExp(amount);
    }

    public void OnRunStateChanged()
    {
        EventBus_CharacterToBattle.InvokeOnBattleChanged(CharacterType.Babarian);
    }
    public void OnAttackStateChanged()
    {
        EventBus_CharacterToBattle.InvokeOnSpFulled(CharacterType.Babarian);
    }
    public void OnDieStateChanged()
    {
        EventBus_CharacterToBattle.InvokeOnDeadChanged(CharacterType.Babarian);
    }
}
