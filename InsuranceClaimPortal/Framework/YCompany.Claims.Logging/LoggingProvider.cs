using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace YCompany.Claims.Logging
{
    public class LoggingProvider : ILoggerProvider
    {
        private LogingProviderConfiguration _currentConfig;
        private readonly IDisposable? _onChangeToken;
        public LoggingProvider(IOptionsMonitor<LogingProviderConfiguration> config)
        {
            _currentConfig = config.CurrentValue;
            _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(categoryName, GetCurrentConfig);
        }
        private LogingProviderConfiguration GetCurrentConfig() => _currentConfig;

        public void Dispose()
        {
            _onChangeToken?.Dispose();
        }
    }
}
