using System;
using System.IO;

namespace LoggerLibrary
{
    internal class FileLogger
    {
        private string logFileName;

        public FileLogger(string fileName)
        {
            logFileName = fileName;
        }

        public void LogMessage(string message)
        {
            string logEntry = $"[{DateTime.Now}] {message}";

            // Записываем сообщение в файл.
            File.AppendAllText(logFileName, logEntry + Environment.NewLine);
        }
    }
}
