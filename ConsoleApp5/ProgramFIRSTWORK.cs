using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    

    class SkiRental
    {
        static void Main()
        {
            // Цены за день аренды
            const int skiPrice = 15000;  // цена аренды лыж
            const int snowboardPrice = 200; // цена сноуборда
            const int insurancecount = 150; // стоимость страховки 

            Console.Write("На сколько вы хотите взять аренду?(дни)");
            int rentalDays = int.Parse(Console.ReadLine());

            Console.Write("лыжи или сноуборд? 1 или 2?");
            int TypeSkin = int.Parse(Console.ReadLine());

            Console.Write("если сдохните страховка требутеся? да нет?");
            //благодваря булеву значению можно не писать иф елс и увеличивать код, а туловер позволят сделать код удобннее, допустим, ДА Да дА и да будут всегда равны да
            bool insurance = Console.ReadLine().ToLower() == "да";

            int total = 0;

           
            if (TypeSkin == 1) // это лыжи
            {
                total = rentalDays * skiPrice;
            }
            else if (TypeSkin == 2) // а это сноуборд
            {
                total = rentalDays * snowboardPrice;
            }
           

            // здесь проводим стоимость страховки если выбрана она
            if (insurance)
            {
                total += rentalDays * insurancecount;
            }

            // Выводим итоговую сумму
            Console.WriteLine($" {total}");
        }
    }







}
