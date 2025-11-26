using System;
using System.Collections.Generic;

/// <summary>
/// 제네릭 기반 정적 이벤트 버스
/// </summary>
/// <typeparam name="Tkey">이벤트를 식별하는 열거형(Enum)</typeparam>
/// <typeparam name="TPayload">이벤트가 전달할 데이터 타입</typeparam>
public static class EventBus<Tkey, TPayload> where Tkey : Enum
{
    /// <summary>
    ///이벤트 키별로 구독된 delegate(Action)를 저장하는 사전.
    /// Dictionary<TKey, Action<TPayload>> 구조로, 각 키마다 하나의 delegate 체인을 관리.
    /// </summary>
    static readonly Dictionary<Tkey, Action<TPayload>> events = new();

    /// <summary>
    /// 이벤트 구독 메서드.
    /// </summary>
    /// <param name="key">구독할 이벤트 식별자</param>
    /// <param name="handler">이벤트가 발생했을 때 호출될 Action<TPayload> delegate</param>
    public static void Add(Tkey key, Action<TPayload> handler)
    {
        // 해당 키가 사전에 없으면 초기화
        if (!events.ContainsKey(key))
            events[key] = null;

        // 기존 delegate 체인에 handler를 추가
        events[key] += handler;
    }

    /// <summary>
    /// 이벤트 구독 해지 메서드
    /// </summary>
    /// <param name="key">구독 해제할 이벤트 식별자</param>
    /// <param name="handler">제거할 Action<TPayload> delegate</param>
    public static void Remove(Tkey key, Action<TPayload> handler)
    {
        if (events.ContainsKey(key))
            events[key] -= handler;
    }

    /// <summary>
    /// 이벤트 발생 메서드
    /// </summary>
    /// <param name="key">발생시킬 이벤트 식별자</param>
    /// <param name="payload">이벤트와 함께 전달할 데이터</param>
    public static void Invoke(Tkey key, TPayload payload)
    {
        // 해당 키에 구독된 delegate가 있으면 호출
        if (events.TryGetValue(key, out var action))
            action?.Invoke(payload); // null-safe 호출
    }
}