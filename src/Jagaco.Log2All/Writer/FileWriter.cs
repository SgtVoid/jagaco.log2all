using System;
using System.IO;
using System.Text;

namespace Jagaco.Log2All.Writer
{
    public class FileWriter : ILogWriter
    {
        StreamWriter strwrite;
        public string Name
        {
            get
            {
                return "FileWriter";
            }
            
        }
        public String File { get; set; }
        public Encoding Encoding { get; set; }
        public LogLevel Threshold { get; set; }

        private void Open()
        {
            try
            {
                strwrite = new StreamWriter(File, true, Encoding);
                
            }
            catch
            {
                strwrite = null;
            }
        }

        public void Close()
        {
            strwrite.Close();
            strwrite = null;
        }

        public void Write(LogEntry entry)
        {
            if (entry.Level >= this.Threshold)
            {
                Open();
                if (strwrite == null)
                    return;


                strwrite.WriteLine(String.Format("{0}({1}): {2}", entry.TimeStamp.ToShortTimeString(), entry.Level, entry.Message));
                if (entry.Exception != null)
                {
                    strwrite.WriteLine(String.Format("{0}:{1}", entry.Exception.ToString(), entry.Exception.Message));
                    strwrite.WriteLine(String.Format("{0}", entry.Exception.StackTrace));
                }

                Close();
            }

        }

    }
}
