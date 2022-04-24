using System;
using System.Collections.Generic;

public class ReactiveField<T>
{
    private T _value;
    public T Value
    {
        get => _value;
        set
        {
            if (EqualityComparer<T>.Default.Equals(value,_value))
            {
                return;
            }

            _value = value;
                
            OnChanged?.Invoke();
        }
    }

    public ReactiveField()
    {
        _value = default;
    }

    public ReactiveField(T value)
    {
        _value = value;
    }

    public Action OnChanged;
}