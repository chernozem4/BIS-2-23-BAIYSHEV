using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Alkash
    {
        
        const int SafeLimit = 500; // здесь будет указана безопасная норма для распития алкоголя

        // Алкогольное содержание на порцию для каждого напитка
          
        const double Wine = 0.12;  
        const double Vodka = 0.45; 

        // Размер порций в миллилитрах
        
        const double WineSize = 450;
        const double VodkaSize = 500;  

        static void Main(string[] args)
        {
            double totalAlcohol = 0; // total alkohol

            while (true)
            {
                Console.WriteLine("что вы хотите пить? водку или вино?");
                string drink = Console.ReadLine().ToLower();

   
                Console.WriteLine("количество рюмок");
                int ryumka;
                try
                {
                    ryumka = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Нужно ввести число.");
                    continue;
                }

                int alkashkanarymku = 0;
                switch (drink)
                {
                    case "вино":
                        alkashkanarymku = (int)(WineSize * Wine);
                        break;
                    case "водка":
                        alkashkanarymku = (int)(VodkaSize * Vodka);
                        break;
                    
                }

                totalAlcohol += alkashkanarymku * ryumka;
                Console.WriteLine($"Вы выпили {totalAlcohol} мл");



                // если вы превысили 500 мл то вам выдаст это сообщение
                if (totalAlcohol > SafeLimit)
                {
                    Console.WriteLine("Да ты угораешь, куда столько рюмок?");
                }
            }

            
        }
    }
}
