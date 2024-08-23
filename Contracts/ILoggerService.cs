namespace Contracts
{
    public interface ILoggerService
    {
        void LogInfo(string messsage, params object[] details);
        void LogError(string message);
    }
}
