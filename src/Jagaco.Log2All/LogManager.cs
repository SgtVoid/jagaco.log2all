using Jagaco.Log2All.Writer;
using System.Collections.Generic;

namespace Jagaco.Log2All
{
    public class LogManager
    {
        private static readonly string DEFAULTLOG = "DEFAULTLOG";

        internal List<ILogWriter> Writers { get;  private set; }
        private Dictionary<string, ILog> Logs { get; set; }

        public LogLevel Threshold { get; set; }


        private static LogManager _instance = null;
        public static LogManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LogManager();

                return _instance;
            }
        }
        private LogManager()
        {
            Writers = new List<ILogWriter>();
            Logs = new Dictionary<string, ILog>();
            RegisterLog(DEFAULTLOG);
        }



        public void RegisterWriter(ILogWriter writer)
        {
            if(writer != null)
                Writers.Add(writer);
        }

        public void RegisterLog(string name)
        {
            if (!Logs.ContainsKey(name))
                Logs[name] = new Logger();
        }

        public ILog GetLogger()
        {
            return GetLogger(DEFAULTLOG);
        }

        public ILog GetLogger(string name)
        {
            if (Logs.ContainsKey(name))
                return Logs[name];

            return null;
        }

    }
}
