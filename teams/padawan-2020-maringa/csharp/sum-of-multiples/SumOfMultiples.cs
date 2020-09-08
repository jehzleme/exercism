using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        List<int> lista = new List<int>();
        var collectionOfMultiples = multiples.Where(q => q != 0);

        foreach (var item in collectionOfMultiples)
        {
            var i = 1;
            while ((item * i) < max)
            {
                var calculo = item * i;
                if (calculo >= max)
                {
                    break;
                }
                else
                {
                    lista.Where(x => x == calculo).Any();
                    if (!lista.Where(x => x == calculo).Any())
                    {
                        lista.Add(calculo);
                    }
                }
                i++;
            }
        }
        return lista.Sum();
    }
}