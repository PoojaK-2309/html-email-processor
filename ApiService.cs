using System.Text;

namespace HtmlEmailProcessor.Services;

public class ApiService
{
    public async Task<Stream> GetEmailStreamAsync()
    {
        var largeHtml = "<html><body>" +
                        string.Join("", Enumerable.Repeat("<p>This is a large email content.</p>", 100000)) +
                        "</body></html>";

        var bytes = Encoding.UTF8.GetBytes(largeHtml);
        return new MemoryStream(bytes);
    }
}