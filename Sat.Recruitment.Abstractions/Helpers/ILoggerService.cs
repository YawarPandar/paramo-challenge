namespace Sat.Recruitment.Abstractions.Helpers
{
    public interface ILoggerService
    {
        void Info(string message);
        void Error(string message);
        void Warning(string message);
    }
}
