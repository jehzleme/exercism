using System;
using System.Collections.Generic;


public class ItemLista<T>
{
    public T Value { get; set; }
    public ItemLista<T> Anterior { get; set; }
    public ItemLista<T> Proximo { get; set; }
}
public class QueueDeque<T>
{
    private ItemLista<T> Item;

    public void Enqueue(T value)
    {
        if (Item is null)
        {
            Item = new ItemLista<T> { Value = value };
            return;
        }

        ItemLista<T> anterior = Item;

        while (!(anterior.Proximo is null))
        {
            anterior = Item.Proximo;
        }

        anterior.Proximo = new ItemLista<T> { Value = value, Anterior = anterior };
    }


    public T Dequeue()
    {
        if (Item.Proximo is null)
        {
            T onlyItemRemoved = Item.Value;
            Item.Value = default(T);
            return onlyItemRemoved;
        }

        ItemLista<T> nextItem = Item.Proximo;
        T firstItemRemoved = Item.Value;
        Item.Value = default(T);
        Item = nextItem;
        return firstItemRemoved;

    }
}