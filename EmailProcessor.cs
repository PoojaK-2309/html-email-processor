namespace HtmlEmailProcessor.Services;

public class EmailProcessor
{
    public async Task ProcessStreamAsync(Stream stream)
    {
        using var reader = new StreamReader(stream);

        char[] buffer = new char[4096];
        int bytesRead;

        while ((bytesRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            var chunk = new string(buffer, 0, bytesRead);

            ProcessChunk(chunk);
        }
    }

    private void ProcessChunk(string chunk)
    {
        int count = chunk.Split("<p>").Length - 1;
        Console.WriteLine($"Processed chunk: {count} <p> tags");
    }
}