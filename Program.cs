using HtmlEmailProcessor.Services;

var apiService = new ApiService();
var processor = new EmailProcessor();

Console.WriteLine("Fetching email stream...");

using var stream = await apiService.GetEmailStreamAsync();

Console.WriteLine("Processing emails...");

await processor.ProcessStreamAsync(stream);

Console.WriteLine("Done.");