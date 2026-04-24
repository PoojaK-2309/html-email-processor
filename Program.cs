using HtmlEmailProcessor.Services;

class Program
{
    static async Task Main(string[] args)
    {
        string filePath = "sample-emails.json";

        var apiService = new ApiService();
        var processor = new EmailProcessor();

        int batchSize = 2;
        var batch = new List<HtmlEmailProcessor.Models.EmailModel>();

        await foreach (var email in apiService.StreamEmailsAsync(filePath))
        {
            batch.Add(email);

            if (batch.Count >= batchSize)
            {
                ProcessBatch(batch, processor);
                batch.Clear();
            }
        }

        // process remaining
        if (batch.Count > 0)
        {
            ProcessBatch(batch, processor);
        }

        Console.WriteLine("Processing completed.");
    }

    static void ProcessBatch(List<HtmlEmailProcessor.Models.EmailModel> batch, EmailProcessor processor)
    {
        Parallel.ForEach(batch, email =>
        {
            processor.Process(email);
        });
    }
}