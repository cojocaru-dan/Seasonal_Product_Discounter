namespace CodeCool.SeasonalProductDiscounter.Service.Logger;

public interface ILogger
{
    public void LogInfo(string message);
    public void LogError(string message);
}

public class ConsoleLogger : ILogger
{
    public void LogInfo(string message)
    {
        LogMessage(message, "INFO");
    }

    public void LogError(string message)
    {
        LogMessage(message, "ERROR");
    }

    public void LogMessage(string message, string type)
    {
        var entry = $"[{DateTime.Now}] {type}: {message}";
        Console.WriteLine(entry);
    }
}
