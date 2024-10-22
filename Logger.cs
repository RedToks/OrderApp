using System;
using System.IO;

public static class Logger
{
    public static void LogError(string logFilePath, string message)
    {
        try
        {
            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR: {message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Не удалось записать в лог: {ex.Message}");
        }
    }
}
