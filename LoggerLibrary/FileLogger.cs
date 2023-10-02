using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
