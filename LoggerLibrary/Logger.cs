using System;

namespace LoggerLibrary
{
    public class Logger
    {
        private static Logger instance;

        // Приватный конструктор, чтобы предотвратить создание объектов извне класса.
        private Logger()
        {
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
        }
    }
}