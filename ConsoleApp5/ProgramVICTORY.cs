using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int wins = 0;
            int losses = 0;

            while (true)
            {
                Console.WriteLine("результат боя- 1-победа, 0-поражение");
                string input = Console.ReadLine();

                // Проверка на выход из программы


                // Обработка ввода
                if (input == "1")
                {
                    wins++;
                }
                else if (input == "0")
                {
                    losses++;
                }
                else
                {
                    Console.WriteLine("надо ввести либо 1 либо 2!");
                    continue;
                }


                int total = wins + losses;
                //double лучше подходит для выяснения стастики чем инт, поэтому использовал его здесь
                double winPercentage = total > 0 ? (double)wins / total * 100 : 0;

                // Вывод статистики
                Console.WriteLine($"Победы: {wins}, Поражения: {losses}, Процент побед: {winPercentage:F2}%");

                // Мотивационное сообщение
                if (winPercentage >= 65)
                {
                    Console.WriteLine("ХОРОООООООШ");
                }
                else if (winPercentage >= 50)
                {
                    Console.WriteLine("ХОРОШ");
                }
                else
                {
                    Console.WriteLine("А надо было учить с#");
                }
            }

            
        }
    }
}
