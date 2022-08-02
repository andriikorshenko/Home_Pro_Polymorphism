var service = new Service(new AgregateLoggers(
    new FileLogger(), 
    new ConsoleLogger()
    ));
service.BusinessLogic();

class Service
{
    ILogger _logger;

    public Service(ILogger logger)
    {
        _logger = logger;
    }

    public void BusinessLogic()
    {
        _logger.LogTo("some log");
    }
}

interface ILogger
{
    void LogTo(string log);
}

class ConsoleLogger : ILogger
{
    void ILogger.LogTo(string log)
    {
        Console.WriteLine(log);
    }
}

class FileLogger : ILogger
{
    string path = @"loggfile.txt";

    void ILogger.LogTo(string log)
    {
        File.AppendAllText(path, log + Environment.NewLine);
    }
}

class AgregateLoggers : ILogger
{
    private readonly ILogger[] _loggers;

    public AgregateLoggers(params ILogger[] loggers)
    {
        _loggers = loggers;
    }

    void ILogger.LogTo(string log)
    {
        foreach (var logger in _loggers)
        {
            logger.LogTo(log);
        }
    }
}