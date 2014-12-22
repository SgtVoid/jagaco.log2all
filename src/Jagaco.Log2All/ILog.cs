using System;

namespace Jagaco.Log2All
{
    public interface ILog
    {
        void Debug(string message);
        void Debug(string message, Exception exception);

        void Info(string message);
        void Info(string message, Exception exception);

        void Warning(string message);
        void Warning(string message, Exception exception);

        void Error(string message);
        void Error(string message, Exception exception);

        void Fatal(string message);
        void Fatal(string message, Exception exception);


        void Log(LogLevel level, string message);
        void Log(LogLevel level, string message, Exception exception);
    }
}
