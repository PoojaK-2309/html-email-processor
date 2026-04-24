using HtmlAgilityPack;

namespace HtmlEmailProcessor.Utilities;

public static class HtmlCleaner
{
    public static string ExtractText(string html)
    {
        if (string.IsNullOrWhiteSpace(html))
            return string.Empty;

        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        return doc.DocumentNode.InnerText.Trim();
    }
}