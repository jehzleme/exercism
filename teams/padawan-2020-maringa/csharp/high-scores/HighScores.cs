using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    public List<int> List { get; set; }

    public HighScores(List<int> list)
    {
        List = list;
    }

    public List<int> Scores()
    {
        return List;
    }

    public int Latest()
    {
        return List.Last();
    }

    public int PersonalBest()
    {
        return List.Max();

    }

    public List<int> PersonalTopThree()
    {
        return List.OrderByDescending(q => q).Take(3).ToList();
    }
}