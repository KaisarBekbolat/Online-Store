using System;
using System.Diagnostics.CodeAnalysis;

namespace SportsStore.Test;

public class Comparer 
{
    public static Comparer<T> Get<T>(Func<T, T, bool> func){
        return new Comparer<T>(func);
    }
}

public class Comparer<T> : IEqualityComparer<T>
{
    private Func<T, T, bool> _func;
    public Comparer(Func<T, T, bool> func){
        _func = func;
    }
    public bool Equals(T? x, T? y)
    {
        return _func(x, y);
    }

    public int GetHashCode([DisallowNull] T obj)
    {
        return obj?.GetHashCode() ?? 0;
    }
}
