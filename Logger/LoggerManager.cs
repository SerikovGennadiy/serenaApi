using NLog;
using Contracts;
using System.Security.AccessControl;

namespace LoggerService
{
    public class LoggerManager : ILoggerService
    {
        private static ILogger logger => LogManager.GetCurrentClassLogger();

        public void LogInfo(string messsage, params object[] details) => logger.Info(messsage, details);
        public void LogError(string message) => logger.Error(message);
    }
}
