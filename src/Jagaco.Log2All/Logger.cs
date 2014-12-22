
using System;

namespace Jagaco.Log2All
{
    public class Logger : ILog
    {

        private LogEntry CreateEntry(LogLevel level,string message,Exception exception)
        {
            LogEntry entry = new LogEntry();

            entry.Level = level;
            entry.TimeStamp = DateTime.Now;
            entry.Message = message;
            entry.Exception = exception;

            return entry;
        }


        public void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        public void Debug(string message, Exception exception)
        {
            Log(LogLevel.Debug, message, exception);
        }

        public void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        public void Info(string message, Exception exception)
        {
            Log(LogLevel.Info, message, exception);
        }

        public void Warning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        public void Warning(string message, Exception exception)
        {
            Log(LogLevel.Warning, message, exception);
        }

        public void Error(string message)
        {
            Log(LogLevel.Error, message);
        }

        public void Error(string message, Exception exception)
        {
            Log(LogLevel.Error, message, exception);
        }

        public void Fatal(string message)
        {
            Log(LogLevel.Fatal, message);
        }

        public void Fatal(string message, Exception exception)
        {
            Log(LogLevel.Fatal, message,exception);
        }


        public void Log(LogLevel level, string message)
        {
            Log(level, message, null);
        }

        public void Log(LogLevel level, string message, Exception exception)
        {
            if (level >= LogManager.Instance.Threshold)
            {
                LogEntry entry = new LogEntry();

                entry.Level = level;
                entry.TimeStamp = DateTime.Now;
                entry.Message = message;
                entry.Exception = exception;

                foreach (var writer in LogManager.Instance.Writers)
                {
                    writer.Write(entry);
                }
            }
        }
    }
}
