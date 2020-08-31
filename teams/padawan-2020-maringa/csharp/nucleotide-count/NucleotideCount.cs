using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var contadorA = 0;
        var contadorC = 0;
        var contadorG = 0;
        var contadorT = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] == 'A')
                contadorA++;
            else if (sequence[i] == 'C')
                contadorC++;
            else if (sequence[i] == 'G')
                contadorG++;
            else if (sequence[i] == 'T')
                contadorT++;
            else throw new ArgumentException();
        }

        IDictionary<char, int> dictionary = new Dictionary<char, int>();
        dictionary.Add('A', contadorA);
        dictionary.Add('C', contadorC);
        dictionary.Add('G', contadorG);
        dictionary.Add('T', contadorT);

        return dictionary;
    }
}