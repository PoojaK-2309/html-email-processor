using System.Text.Json;
using HtmlEmailProcessor.Models;

namespace HtmlEmailProcessor.Services;

public class ApiService
{
    public async IAsyncEnumerable<EmailModel> StreamEmailsAsync(string filePath)
    {
        using FileStream stream = File.OpenRead(filePath);

        await foreach (var email in JsonSerializer.DeserializeAsyncEnumerable<EmailModel>(stream))
        {
            if (email != null)
            {
                await Task.Delay(50);
                yield return email;
            }
        }
    }
}