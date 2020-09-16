using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Markdown
{
    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static string Parse(string markdown, string delimiter, string tag) =>
     Regex.Replace(markdown, $"{delimiter}(.+){delimiter}", $"<{tag}>$1</{tag}>");

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = Parse(Parse(markdown, "__", "strong"), "_", "em");
        return list ? parsedText : Wrap(parsedText, "p");
    }

    private static string ParseHeader(string markdown, bool list, out bool inListAfter)
    {
        var count = 0;

        while (markdown[count] == '#')
            count++;

        if (count == 0)
        {
            inListAfter = list;
            return null;
        }

        var headerHtml = Wrap(markdown.Substring(count + 1), $"h{count}");        inListAfter = false;        return list ? $"</ul>{headerHtml}" : headerHtml;
    }

    private static string ParseLineItem(string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            var innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");
            inListAfter = true;            return list ? innerHtml : $"<ul>{innerHtml}";
        }

        inListAfter = list;
        return null;
    }

    private static string ParseParagraph(string markdown, bool list, out bool inListAfter)
    {
        inListAfter = false;
        return list ? $"</ul>{ParseText(markdown, false)}" : ParseText(markdown, list);
    }

    private static string ParseLine(string markdown, bool list, out bool inListAfter) =>
                ParseHeader(markdown, list, out inListAfter) ??
                ParseLineItem(markdown, list, out inListAfter) ??
                ParseParagraph(markdown, list, out inListAfter) ??
                throw new ArgumentException("Invalid markdown");

    public static string Parse(string markdown)
    {
        var lines = markdown.Split("\n");
        var result = new StringBuilder();
        var list = false;

        foreach (var t in lines)
        {
            var lineResult = ParseLine(t, list, out list);
            result.Append(lineResult);
        }
        return list ? $"{result}</ul>" : result.ToString();
    }
}