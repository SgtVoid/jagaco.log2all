
namespace Jagaco.Log2All.Writer
{
    public interface ILogWriter
    {
        string Name { get; }
        LogLevel Threshold { get; set; }

        void Close();
        void Write(LogEntry entry);
    }
}
