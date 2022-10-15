using System.Text;
using System.Text.RegularExpressions;

namespace StringHandler;

class RegexHandler
{
    public static string? GetMatches(string? data, string pattern)
    {
        if (data is null)
            return null;

        var rgx = new Regex(pattern);
        var sb  = new StringBuilder("");

        foreach (Match match in rgx.Matches(data).Cast<Match>())
        {
            sb.Append(match.Value);
            sb.Append(' ');
        }

        return sb.ToString();
    }
}

class SpecificTaskHandler
{
    public static string? ReverseEverySecondMatch(string? data, string pattern)
    {
        if (data is null)
            return null;
      
        var rgx = new Regex(pattern);
        var sb  = new StringBuilder("");

        int matchCounter = 1,
            currentIndex = 0;
        foreach (Match match in rgx.Matches(data).Cast<Match>())
        {
            for (int i = currentIndex; i < match.Index; ++i)
                sb.Append(data[i]);

            if (matchCounter % 2 == 0)
                for (int i = match.Value.Length - 1; i >= 0; --i)
                    sb.Append(match.Value[i]);
            else
                sb.Append(match.Value);

            ++matchCounter;
            currentIndex = match.Index + match.Length;
        }

        return sb.ToString();
    }
}