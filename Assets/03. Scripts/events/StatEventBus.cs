using System;

public static class StatEventBus
{
    public static void Add(Stat key, Action<int, int> listener)
        => EventBus<Stat, (int current, int max)>.Add(
            key, payload => listener(payload.current, payload.max)
        );

    public static void Remove(Stat key, Action<int, int> listener)
        => EventBus<Stat, (int current, int max)>.Remove(
            key, payload => listener(payload.current, payload.max)
        );

    public static void Invoke(Stat key, int current, int max)
        => EventBus<Stat, (int current, int max)>.Invoke(key, (current, max));
}