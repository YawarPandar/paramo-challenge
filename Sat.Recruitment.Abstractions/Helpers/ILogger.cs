namespace Sat.Recruitment.Abstractions.Helpers
{
    public interface ILogger
    {
        void Info(string message);
        void Error(string message);
        void Warning(string message);
    }
}
