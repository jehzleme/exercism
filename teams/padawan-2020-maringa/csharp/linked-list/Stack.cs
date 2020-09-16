using System;
using System.Collections.Generic;

public class Biruleibe<T>
{
    public T Value { get; set; }
    public Biruleibe<T> Previous { get; set; }
    public Biruleibe<T> Next { get; set; }
}

public class StackDeque<T>
{
    Biruleibe<T> Biru;

    public void Push(T value)
    {
        if (Biru is null)
        {
            Biru = new Biruleibe<T> { Value = value };
            return;
        }

        Biruleibe<T> next = Biru;
        Biru = new Biruleibe<T> { Value = value, Next = next };
        next.Previous = Biru;
    }


    public T Pop()
    {
        Biruleibe<T> biru = Biru;

        while (!(biru.Next is null))
        {
            biru = biru.Next;
        }

        T biruRemoved = biru.Value;
        biru.Value = default(T);
        if (!(biru.Previous is null))
        {
            (biru.Previous).Next = null;
            return biruRemoved;
        }
        else
        {
            Biru.Value = default(T);
        }
        return biruRemoved;
    }
}