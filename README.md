# SingletonProject
## Реализация паттерна Singleton
SingletonProject - это решение, состоящее из 3 проектов: ConsoleAppLogger, LoggerLibrary и LoggerLibraryTests, предназначенных для демонстрации и использования паттерна Singleton, логгирования в приложении на платформе .NET, а также проведении тестов библиотеки классов.
***
## Содержание

1. [Singleton](#Singleton)
2. [Установка](#Установка)
3. [Структура проекта](#Структура-проекта)
4. [Описание кода](#Описание-кода)


## Singleton
Singleton - это порождающий паттерн проектирования, который гарантирует, что у класса есть только один экземпляр, и предоставляет глобальную точку доступа к этому экземпляру. Это означает, что при попытке создать новый объект класса Singleton будет возвращен уже существующий экземпляр, если он уже был создан ранее.

### Основные принципы:
1. Одиночный экземпляр: Singleton обеспечивает, что в системе существует только один экземпляр данного класса.
2. Глобальный доступ: Singleton предоставляет глобальную точку доступа к своему единственному экземпляру, что позволяет клиентам получать доступ к нему из любой части приложения.
3. Ленивая инициализация: Создание экземпляра Singleton может быть отложено до момента, когда он действительно потребуется.

### Когда использовать Singleton:
1. Когда в приложении требуется иметь один и только один экземпляр определенного класса, обеспечивая глобальный доступ к нему.
2. Когда нужно контролировать доступ к ресурсам, таким как база данных или файловая система, чтобы избежать конфликтов и проблем с синхронизацией.
3. Когда класс должен обладать глобальной точкой для координации определенной функциональности, например, логгирования, кэширования или управления настройками приложения.

### Примеры использования Singleton:
Логгирование: Класс Logger может быть реализован как Singleton, чтобы гарантировать, что логгирование централизовано и все части приложения могут использовать один и тот же логгер.

Управление настройками приложения: Класс, отвечающий за хранение и предоставление настроек приложения, может быть реализован как Singleton, чтобы избежать несогласованных изменений настроек.

Пул соединений к базе данных: Если приложение работает с базой данных, Singleton может использоваться для управления пулом соединений и обеспечения эффективного использования ресурсов.


## Установка
Для использования проекта Singleton Project, выполните следующие шаги:

1. Склонируйте репозиторий с помощью Git:
```
git clone https://github.com/your-repo/singleton-project.git
```
2. Откройте решение SingletonProjectByElza.sln в Visual Studio или другой среде разработки .NET.
3. Соберите и запустите проект ConsoleAppLogger.

## Структура проекта
ConsoleAppLogger: Консольное приложение для демонстрации использования паттерна Singleton и логгирования.

Program.cs: Главный файл приложения, содержащий логику демонстрации.
VariableWatcher.cs: Класс для отслеживания изменений переменной.
LoggerLibrary: Библиотека классов для логгирования сообщений и реализации паттерна Singleton.

Logger.cs: Класс логгера с методами записи в консоль и файл.
FileLogger.cs: Вспомогательный класс для записи в текстовый файл.


## Описание кода
### ConsoleAppLogger
Проект `ConsoleAppLogger` представляет собой консольное приложение, которое использует класс `Logger` из проекта `LoggerLibrary` для логгирования изменений переменной `а` с использованием паттерна Singleton.

Пример кода Program.cs:

```csharp
using LoggerLibrary;
using System;

namespace ConsoleAppLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            VariableWatcher<int> a = new VariableWatcher<int>();
            a.ValueChanged += Variable_ValueChanged;
            bool i = true;

            while (i)
            {
                Console.WriteLine("Введите значение переменной (целое число):");
                if (int.TryParse(Console.ReadLine(), out int newValue))
                {
                    a.Value = newValue;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Ожидалось целое число.");
                }
            }
        }

        private static void Variable_ValueChanged(object sender, ValueChangedEventArgs<int> e)
        {
            Logger logger = Logger.GetInstance();
            string change = "Значение 'а' изменилось на " + Convert.ToString(e.NewValue);
            logger.LogMessage(change);
        }
    }
}
```
### LoggerLibrary
Проект LoggerLibrary представляет собой библиотеку классов, которая содержит реализацию паттерна Singleton для создания и управления единственным экземпляром логгера. Логгер записывает сообщения как в консоль, так и в текстовый файл.

```csharp
﻿using System;
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
```
Это простой пример Singleton, который гарантирует, что у класса Singleton есть только один экземпляр, и клиенты могут получать доступ к нему через метод GetInstance().


































## Структура проекта
