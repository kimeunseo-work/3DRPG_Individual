using UnityEngine;

public abstract class ValueUIController<T> : MonoBehaviour
{
    protected abstract void ValueChangedHandler(T value);
}

public abstract class ValueUIController<T1, T2> : MonoBehaviour
{
    protected abstract void ValueChangedHandler(T1 value1, T2 value2);
}