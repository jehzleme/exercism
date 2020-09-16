using System;
using System.Text.RegularExpressions;

public static class ScrabbleScore
{
    public static int Score(string input)
    {
        int totalScore = 0;
        input = input.ToUpper();

        totalScore += (Regex.Matches(input, @"A|E|I|O|U|L|N|R|S|T").Count) * 1;
        totalScore += (Regex.Matches(input, @"D|G").Count) * 2;
        totalScore += (Regex.Matches(input, @"B|C|M|P").Count) * 3;
        totalScore += (Regex.Matches(input, @"F|H|V|W|Y").Count) * 4;
        totalScore += (Regex.Matches(input, @"K").Count) * 5;
        totalScore += (Regex.Matches(input, @"J|X").Count) * 8;
        totalScore += (Regex.Matches(input, @"Q|Z").Count) * 10;

        return totalScore;
    }
}

// .Count conta quantas vezes uma ou mais letras do conjunto (String) bate (Matches) com cada letra do input.
// Depois multiplica pela pontuação, e vai somando no totalScore.