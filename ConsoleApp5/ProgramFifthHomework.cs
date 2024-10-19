using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Report
    {
        private const string Parser = "my_report.txt"; //здесь мы используем сохранение файла в формате документа, тобиш ткт

        static async Task Main()
        {
            Console.WriteLine("Загрузка");
            await ASYNCReport();
            Console.WriteLine("Отчёт успешно загружен");
        }

       
        static async Task ASYNCReport()
        {
            //здесь прикол такой: мы используем оператор таск делай чтобы создать имитацию, в данном случае у нас имитация равна 3000 значит 30 секунды
            await Task.Delay(30000);
            string report = "саранча летела летела все поела и дальше полетела";
            //Это асинхронная версия метода File.WriteAllText, которая записывает строку в файл, но выполняется асинхронно.
            await File.WriteAllTextAsync(Parser, report);
        }
    }
}
