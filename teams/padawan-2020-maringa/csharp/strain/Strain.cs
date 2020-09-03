using System;
using System.Collections.Generic;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        List<T> lista = new List<T>();

        foreach (T item in collection)
        {
            if (predicate(item))
            {
                lista.Add(item);
            }
        }
        return lista;
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        List<T> lista = new List<T>();

        foreach (T item in collection)
        {
            if (!predicate(item))
            {
                lista.Add(item);
            }
        }
        return lista;
    }
}