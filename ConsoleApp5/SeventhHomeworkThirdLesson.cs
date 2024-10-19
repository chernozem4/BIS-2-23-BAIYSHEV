using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class asyncupdate
    {
        static async Task Main()
        {
            Console.WriteLine("Обновление...");

            // этот метод являются асинхронным и возвращает задачу Task string
            Task<string> weatherTask = GetWeatherAsync();
            
            //end
            await Task.WhenAll(weatherTask);
            Console.WriteLine("успешное обновление");
            Console.WriteLine(await weatherTask);
           
        }
        //Метод возвращает задачу (Task), которая завершится с результатом типа string
        static async Task<string> GetWeatherAsync()
        {
            await Task.Delay(2000); 
            return "саранча летела летела все съела и улетела";
        }

        

        
    }
}
