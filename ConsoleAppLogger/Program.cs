using LoggerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string logFileName = "log.txt";
            Logger logger = Logger.GetInstance();
            logger.LogMessage("Значение a изменилось");
        }
    }
}
