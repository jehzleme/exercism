using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var validPhoneNumber = new Regex(@"^(?:\+?1)?\D*\(?([2-9]{1}[0-9]{2})\)?\D*([2-9]{1}[0-9]{2})\D*([0-9]{4})\D*$");

        if (!validPhoneNumber.IsMatch(phoneNumber))
        throw new ArgumentException("Não é um telefone válido");

        var match = validPhoneNumber.Match(phoneNumber);
        var cleanPhoneNumber = match.Groups[1].Value + match.Groups[2].Value + match.Groups[3].Value;

        return cleanPhoneNumber;
    }
}