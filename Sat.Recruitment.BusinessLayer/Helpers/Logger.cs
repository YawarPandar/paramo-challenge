using Microsoft.Extensions.Options;
using Sat.Recruitment.Abstractions.Helpers;
using Sat.Recruitment.Models.Configuration;
using System;
using System.Diagnostics;
using System.IO;

namespace Sat.Recruitment.BusinessLayer.Helpers
{
    public class Logger : ILogger
    {
        private readonly IOptions<AppSettings> _settings;
        public Logger(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }
        public void Info(string message)
        {
            WriteLog(message, LogType.INFO);
        }
        public void Error(string message)
        {
            WriteLog(message, LogType.ERROR);
        }
        public void Warning(string message)
        {
            WriteLog(message, LogType.INFO);
        }
        private void WriteLog(string message, LogType type)
        {
            message = $"[{type}] - {message}";
            Debug.WriteLine(message);
            if (_settings.Value.SaveLog)
            {
                var path = string.IsNullOrEmpty(_settings.Value.LogFilePath) ? AppDomain.CurrentDomain.BaseDirectory + "/app.log" : _settings.Value.LogFilePath;
                var directory = Path.GetDirectoryName(path);
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
                File.WriteAllText(path, message);
            }
        }
        private enum LogType
        {
            INFO,
            ERROR,
            WARN
        }
    }
}
