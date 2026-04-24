using HtmlEmailProcessor.Models;
using HtmlEmailProcessor.Utilities;

namespace HtmlEmailProcessor.Services;

public class EmailProcessor
{
    private static readonly object _fileLock = new object();

    private static readonly string _outputPath =
        Path.Combine(AppContext.BaseDirectory, "output.txt");

    public void Process(EmailModel email)
    {
        try
        {
            var cleanText = HtmlCleaner.ExtractText(email.Body);

            // ✅ Clean grouped logging
            Logger.Info($"""
Processed Email ID: {email.Id}
Subject: {email.Subject}
Content Preview: {cleanText.Substring(0, Math.Min(100, cleanText.Length))}
--------------------------------------------------
""");

            // ✅ Thread-safe file write
            lock (_fileLock)
            {
                File.AppendAllText(_outputPath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ID: {email.Id}, Subject: {email.Subject}{Environment.NewLine}");
            }
        }
        catch (Exception ex)
        {
            Logger.Error($"Error processing email {email.Id}: {ex.Message}");
        }
    }
}