using System;
using System.IO;
using System.Text;

namespace YarcheTextEditor.Classes
{
    public sealed class Log
    {
        private static volatile Log _instance;
        private static readonly object SyncRoot = new object();
        private readonly object _logLocker = new object();

        private Log()
        {
            CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            LogDirectory = Path.Combine(CurrentDirectory, "log");
        }

        public string CurrentDirectory { get; set; }
        public string LogDirectory { get; set; }

        public static Log Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null) _instance = new Log();
                    }
                }
                return _instance;
            }
        }

        public void Error(int errorNumber, string errorText, string owner)
        {
            // Ошибки пишем в лог всегда
            Add($"Ошибка {(errorNumber.ToString()).PadLeft(4, '0')}: {errorText}", "[ERROR]", owner);
        }

        public void Info(string log, string owner)
        {
            Add(log, "[INFO]", owner);
        } 

        private void Add(string log, string logLevel, string owner)
        {
            lock (_logLocker)
            {
                try
                {
                    if (!Directory.Exists(LogDirectory))
                    {
                        // creating log directory
                        Directory.CreateDirectory(LogDirectory);
                    }
                    // write to log
                    string newFileName = Path.Combine(LogDirectory, String.Format("{0}.txt", DateTime.Now.ToString("yyyyMMdd")));
                    File.AppendAllText(newFileName, $"{DateTime.Now} {owner} {logLevel} {log} \r\n", Encoding.UTF8);
                }
                catch { }
            }
        }
    }
}
