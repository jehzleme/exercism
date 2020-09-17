﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string description, decimal change)
    {
        Date = date;
        Description = description;
        Change = change;
    }

    public DateTime Date { get; }
    public string Description { get; }
    public decimal Change { get; }
}

public static class Ledger
{
    public static LedgerEntry CreateEntry(string date, string desc, int change) =>
        new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, change / 100.0m);

    private static (CultureInfo, string) CreateCulture(string currency, string locale)
    {
        int curNeg = 0;
        string datPat = null;
        string format = string.Empty;

        if ((currency != "USD" && currency != "EUR") || (locale != "nl-NL" && locale != "en-US"))
            throw new ArgumentException("Invalid currency");

        string currencySymbol = currency switch
        {
            "USD" => "$",
            "EUR" => "€",
        };

        switch (locale)
        {
            case "en-US":
                datPat = "MM/dd/yyyy";
                format = $"{"Date"?.PadRight(11, ' ')}| {"Description"?.PadRight(26, ' ')}| {"Change"?.PadRight(13, ' ')}";
                break;
            case "nl-NL":
                curNeg = 12;
                datPat = "dd/MM/yyyy";
                format = $"{"Datum"?.PadRight(11, ' ')}| {"Omschrijving"?.PadRight(26, ' ')}| {"Verandering"?.PadRight(13, ' ')}"; ;
                break;
        }

        var culture = new CultureInfo(locale)
        {
            NumberFormat = { CurrencySymbol = currencySymbol, CurrencyNegativePattern = curNeg },
            DateTimeFormat = { ShortDatePattern = datPat }
        };
        return (culture, format);
    }

    private static string PrintEntry(IFormatProvider culture, LedgerEntry entry)
    {
        var date = entry.Date.ToString("d", culture);

        var description = entry.Description.Length > 25 ?
            $"{entry.Description.Substring(0, 22)}..." :
            entry.Description;

        var change = entry.Change < 0.0m ? entry.Change.ToString("C", culture) : $"{entry.Change.ToString("C", culture)} ";


        var format = new StringBuilder();
        format.Append(date).Append(" | ").Append($"{description,-25}").Append(" | ").Append($"{change,13}");
        return format.ToString();
    }

    private static IEnumerable<LedgerEntry> Sort(LedgerEntry[] entries)
    {
        var result = new List<LedgerEntry>();
        result.AddRange(entries.Where(e => e.Change < 0)
            .OrderBy(x => $"{x.Date}@{x.Description}@{x.Change}"));

        result.AddRange(entries.Where(e => e.Change >= 0)
            .OrderBy(x => $"{x.Date}@{x.Description}@{x.Change}"));

        return result;
    }

    public static string Format(string currency, string locale, LedgerEntry[] entries)
    {
        var (item1, item2) = CreateCulture(currency, locale);

        var stringBuilder = new StringBuilder();
        stringBuilder.Append(item2);

        if (entries.Length <= 0)
            return stringBuilder.ToString();

        var ledgerEntries = Sort(entries).ToList();

        for (var i = 0; i < ledgerEntries.Count(); i++)
            stringBuilder.Append("\n").Append(PrintEntry(item1, ledgerEntries.Skip(i).First()));

        return stringBuilder.ToString();
    }
}