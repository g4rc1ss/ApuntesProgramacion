using System.Text.RegularExpressions;

namespace HtmlToMd;

public static class HtmlToMarkdown
{
    private static readonly Dictionary<string, string> replacements = new Dictionary<string, string>
    {
        { "<ul>", string.Empty },
        { "</ul>", string.Empty },
        { "<li>", "- " },
        { "</li>", "\n" },
        { "<p>", "\n" },
        { "</p>", "\n" },
        { "<br />", "\n" },
        { "<strong>", "**" },
        { "</strong>", "**" },
        { "</span>", string.Empty },
        { "<br>", "\n" },
        { "</br>", "\n" },
        { "¬", "\n" },
    };

    public static string ConvertHtmlToMD(this string source)
    {
        if (string.IsNullOrEmpty(source))
            return source;

        var result = Regex.Replace(
            source,
            string.Join("|", replacements.Keys.Select(k => k.ToString()).ToArray()),
            m => replacements[m.Value]);

        result = Regex.Replace(result, "<span[^>]*>", string.Empty);
        result = Regex.Replace(result, "\\[", "&#91;");
        result = Regex.Replace(result, "\\]", "&#93;");
        return result;
    }
}