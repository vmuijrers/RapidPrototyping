using UnityEngine;
using UnityEngine.Events;

public abstract class BaseVariable<T> : ScriptableObject
{
    [HideInInspector] public UnityEvent<T> OnValueChanged;
    [SerializeField] private T value;
    public T Value
    {
        get => value;
        set
        {
            T oldValue = this.value;
            this.value = value;
            if (!value.Equals(oldValue))
            {
                OnValueChanged?.Invoke(value);
            }

        }
    }
}
