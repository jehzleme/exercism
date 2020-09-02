using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        char[] stringToCharArray = input.ToCharArray();
        Array.Reverse(stringToCharArray);
        return new string(stringToCharArray);
    }
}
