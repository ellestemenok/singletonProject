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