using System;
namespace LoggerLibrary
{
    public class Logger
    {
        private static Logger instance;
        private FileLogger fileLogger;

        // Инициализируем FileLogger с именем файла по умолчанию.
        private Logger()
        {
            fileLogger = new FileLogger("log.txt");
        }

        // Метод для получения единственного экземпляра Logger.
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        // Метод для записи сообщения в консоль.
        public void LogMessage(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {message}");
            fileLogger.LogMessage(message);
        }
    }
}