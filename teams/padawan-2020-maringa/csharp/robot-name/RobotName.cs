using System;
using System.Collections.Generic;

public class Robot
{
    private Random rnd = new Random();
    public string Name { get; private set; }
    private static HashSet<string> names = new HashSet<string>();

    public Robot()
    {
        Reset();
    }

    private char GetRandomLetter()
    {
        return (char)rnd.Next(65, 91);
    }

    private char GetRandomNumber()
    {
        return (char)rnd.Next(48, 58);
    }

    public void Reset()
    {
        var nome = "";
        do
        {
            rnd = new Random();
            nome = string.Empty
                        + GetRandomLetter()
                        + GetRandomLetter()
                        + GetRandomNumber()
                        + GetRandomNumber()
                        + GetRandomNumber();
        } while (!UniqueName(nome));

        Name = nome;
    }

    public bool UniqueName(string nome)
    {
        return names.Add(nome);
    }
}