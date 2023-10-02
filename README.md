# SingletonProject
Реализация паттерна Singleton
SingletonProject - это решение, состоящее из 3 проектов: ConsoleAppLogger, LoggerLibrary и LoggerLibraryTests, предназначенных для демонстрации и использования паттерна Singleton, логгирования в приложении на платформе .NET, а также проведении тестов библиотеки классов.
***
## Содержание


1. [Установка](#Установка)
2. [Структура проекта](#Структура-проекта)
3. [Использование](#Использование)
4. [Author](#author)
5. [License](#license)


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



## Использование
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



































## Структура проекта
