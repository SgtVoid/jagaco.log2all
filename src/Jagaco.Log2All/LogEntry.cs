using System;

namespace Jagaco.Log2All
{
    public class LogEntry
    {
        public LogLevel Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public String Message { get; set; }


        // Optional stuff
        public Exception Exception { get; set; }
    }
}
