using Microsoft.Extensions.Logging;

namespace YCompany.Claims.Logging.PracticeLogger
{
    public class ColorConsoleLogger : ILogger
    {
        private readonly string _name;
        private readonly Func<ColorConsoleLoggerConfiguration> _getCurrentConfig;

        public ColorConsoleLogger(
           string name,
           Func<ColorConsoleLoggerConfiguration> getCurrentConfig) =>
           (_name, _getCurrentConfig) = (name, getCurrentConfig);

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return default;
        }

        // to enable or disable logging by this logger for certain log levels
        public bool IsEnabled(LogLevel logLevel)
        {
            return _getCurrentConfig().LogLevelToColorMap.ContainsKey(logLevel);
        }

        // actual log method
        public void Log<TState>(LogLevel logLevel,
                                EventId eventId,
                                TState state,
                                Exception? exception,
                                Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            ColorConsoleLoggerConfiguration config = _getCurrentConfig();

            if (config.EventId == 0 || config.EventId == eventId.Id)
            {
                ConsoleColor originalColor = Console.ForegroundColor;

                Console.ForegroundColor = config.LogLevelToColorMap[logLevel];
                Console.WriteLine($"[{eventId.Id,2}: {logLevel,-12}]");

                Console.ForegroundColor = originalColor;
                Console.Write($"     {_name} - ");

                Console.ForegroundColor = config.LogLevelToColorMap[logLevel];
                Console.Write($"{formatter(state, exception)}");

                Console.ForegroundColor = originalColor;
                Console.WriteLine();

            }
        }
    }
}
