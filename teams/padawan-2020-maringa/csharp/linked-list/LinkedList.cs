using System;

public class Item<T>
{
    public T Valor { get; set; }
    public Item<T> Proximo { get; set; }
    public Item<T> Anterior { get; set; }
}

public class Deque<T>
{

    private Item<T> Item;

    public void Push(T value)
    {
        if (Item is null)
        {
            Item = new Item<T> { Valor = value };
            return;
        }

        Item<T> anterior = Item;

        while (!(anterior.Proximo is null))
        {
            anterior = Item.Proximo;
        }

        anterior.Proximo = new Item<T> { Valor = value, Anterior = anterior };
    }

    public T Pop()
    {
        Item<T> item = Item;

        while (!(item.Proximo is null))
        {
            item = item.Proximo;
        }

        T pop = item.Valor;
        item.Valor = default(T);
        if (!(item.Anterior is null))
        {
            (item.Anterior).Proximo = null;
            return pop;
        }
        else
        {
            Item.Valor = default(T);
        }
        return pop;
    }

    public void Unshift(T value)
    {
        if (Item is null)
        {
            Item = new Item<T> { Valor = value };
            return;
        }

        Item<T> proximo = Item;
        Item = new Item<T> { Valor = value, Proximo = proximo };
        proximo.Anterior = Item;
    }

    public T Shift()
    {
        if (Item.Proximo is null)
        {
            T ultimo = Item.Valor;
            Item.Valor = default(T);
            return ultimo;
        }

        Item<T> proximo = Item.Proximo;
        T shift = Item.Valor;
        Item = proximo;
        Item.Anterior = null;
        return shift;
    }
}
