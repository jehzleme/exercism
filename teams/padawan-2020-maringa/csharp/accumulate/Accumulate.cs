using System;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {

        foreach (T item in collection)
        {
            yield return (func(item));
        }
    }

    public static IEnumerable<U> AccumulateNonLazy<T, U>(this IEnumerable<T> collection, Func<T, U> func)

    {
        var result = new List<U>();

        foreach (T item in collection)
        {
            result.Add(func(item));
        }

        return result;
    }
}