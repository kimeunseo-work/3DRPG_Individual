using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    Hp,
    MaxHp,
    Mp,
    MaxMp,
    Exp,
    MaxExp
}

/// <summary>
/// 캐릭터 정보 관리.
/// 플레이어 스탯 관리, 레벨업, 스킬 관리.
/// </summary>
public class CharacterManager : Manager
{
    #region Fields
    int hp;
    int maxHp;
    int mp;
    int maxMp;
    int exp;
    int maxExp;
    #endregion

    #region Properties
    public int Hp
    {
        get => hp;
        private set => hp = Mathf.Clamp(value, 0, maxHp);
    }
    public int Mp
    {
        get => mp;
        private set => mp = Mathf.Clamp(value, 0, maxMp);
    }
    public int Exp
    {
        get => exp;
        private set => exp = Mathf.Clamp(value, 0, maxExp);
    }
    public int MaxHp
    {
        get => maxHp;
        private set => maxHp = value;
    }
    public int MaxMp
    {
        get => maxMp;
        private set => maxMp = value;
    }
    public int MaxExp
    {
        get => maxExp;
        private set => maxExp = value;
    }
    #endregion

    public Dictionary<Stat, int> Stats;

    public override void Init()
    {
        MaxHp = 100;
        MaxMp = 200;
        MaxExp = 800;

        Hp = 90;
        Mp = 180;
        Exp = 100;

        Stats = new()
        {
            {Stat.Hp, Hp},
            {Stat.MaxHp, MaxHp},
            {Stat.Mp, Mp},
            {Stat.MaxMp, MaxMp},
            {Stat.Exp, Exp},
            {Stat.MaxExp, MaxExp},
        };
    }

    #region In/Decrease Stats

    #region Hp/MaxHp
    public void IncreaseHp(int amount)
    {
        Hp += amount;
        StatEventBus.Invoke(Stat.Hp, Hp, MaxHp);
    }

    public void DecreaseHp(int amount)
    {
        Hp -= amount;
        StatEventBus.Invoke(Stat.Hp, Hp, MaxHp);
    }

    public void IncreaseMaxHp(int amount)
    {
        MaxHp += amount;
        StatEventBus.Invoke(Stat.Hp, Hp, MaxHp);
    }

    public void DecreaseMaxHp(int amount)
    {
        MaxHp -= amount;
        StatEventBus.Invoke(Stat.Hp, Hp, MaxHp);
    }
    #endregion

    #region Mp/MaxMp
    public void IncreaseMp(int amount)
    {
        Mp += amount;
        StatEventBus.Invoke(Stat.Mp, Mp, MaxMp);
    }

    public void DecreaseMp(int amount)
    {
        Mp -= amount;
        StatEventBus.Invoke(Stat.Mp, Mp, MaxMp);
    }
    public void IncreaseMaxMp(int amount)
    {
        MaxMp += amount;
        StatEventBus.Invoke(Stat.Mp, Mp, MaxMp);
    }

    public void DecreaseMaxMp(int amount)
    {
        MaxMp -= amount;
        StatEventBus.Invoke(Stat.Mp, Mp, MaxMp);
    }
    #endregion

    #region Exp/MaxExp
    public void IncreaseExp(int amount)
    {
        Exp += amount;
        StatEventBus.Invoke(Stat.Exp, Exp, MaxExp);
    }

    public void DecreaseExp(int amount)
    {
        Exp -= amount;
        StatEventBus.Invoke(Stat.Exp, Exp, MaxExp);
    }
    public void IncreaseMaxExp(int amount)
    {
        MaxExp += amount;
        StatEventBus.Invoke(Stat.Exp, Exp, MaxExp);
    }

    public void DecreaseMaxExp(int amount)
    {
        MaxExp -= amount;
        StatEventBus.Invoke(Stat.Exp, Exp, MaxExp);
    }
    #endregion

    #endregion
}