using System;

public static class EventBus_CharacterToBattle
{
    #region OnSkillAnimationExited/스킬 애니메이션 종료 이벤트

    public enum Key_SkillAnimationExited
    {
        None,
        Babarian
    }

    public static void AddOnSkillAnimationExited(CharacterType key, Action<bool> listener)
        => EventBus<Key_SkillAnimationExited, bool>.Add((Key_SkillAnimationExited)key, listener);

    public static void RemoveOnSkillAnimationExited(CharacterType key, Action<bool> listener)
        => EventBus<Key_SkillAnimationExited, bool>.Remove((Key_SkillAnimationExited)key, listener);
    public static void InvokeOnSkillAnimationExited(CharacterType key, bool isEnd)
        => EventBus<Key_SkillAnimationExited, bool>.Invoke((Key_SkillAnimationExited)key, isEnd);
    #endregion

    #region OnDeadChanged/캐릭터 생존 여부 이벤트

    public enum Key_DeadChanged
    {
        None,
        Babarian
    }

    public static void AddOnDeadChanged(CharacterType key, Action<bool?> listener)
        => EventBus<Key_DeadChanged, bool?>.Add((Key_DeadChanged)key, listener);

    public static void RemoveOnDeadChanged(CharacterType key, Action<bool?> listener)
        => EventBus<Key_DeadChanged, bool?>.Remove((Key_DeadChanged)key, listener);
    public static void InvokeOnDeadChanged(CharacterType key, bool? isDead = null)
        => EventBus<Key_DeadChanged, bool?>.Invoke((Key_DeadChanged)key, isDead);
    #endregion

    #region OnBattleChanged/캐릭터 공격 가능 여부 이벤트

    public enum Key_BattleChanged
    {
        None,
        Babarian
    }

    public static void AddOnBattleChanged(CharacterType key, Action<bool?> listener)
        => EventBus<Key_BattleChanged, bool?>.Add((Key_BattleChanged)key, listener);

    public static void RemoveOnBattleChanged(CharacterType key, Action<bool?> listener)
        => EventBus<Key_BattleChanged, bool?>.Remove((Key_BattleChanged)key, listener);
    public static void InvokeOnBattleChanged(CharacterType key, bool? isBattle = null)
        => EventBus<Key_BattleChanged, bool?>.Invoke((Key_BattleChanged)key, isBattle);
    #endregion

    #region OnSpFulled/캐릭터 스킬 가능 여부 이벤트

    public enum Key_SpFulled
    {
        None,
        Babarian
    }

    public static void AddOnSpFulled(CharacterType key, Action<bool?> listener)
        => EventBus<Key_SpFulled, bool?>.Add((Key_SpFulled)key, listener);

    public static void RemoveOnSpFulled(CharacterType key, Action<bool?> listener)
        => EventBus<Key_SpFulled, bool?>.Remove((Key_SpFulled)key, listener);
    public static void InvokeOnSpFulled(CharacterType key, bool? isSpFulled = null)
        => EventBus<Key_SpFulled, bool?>.Invoke((Key_SpFulled)key, isSpFulled);
    #endregion
}