using System;



class OrderProccessing
{
    static void Main(string[] args)
    {
        try
        {

            Console.Write("Количество товара: ");
            int quantity = int.Parse(Console.ReadLine());

            // Проверка, если количество меньше 0, то ошибка
            if (quantity < 0)
            {
                throw new ArgumentException("Ошибка: введено неверное количество товара.");
            }


            Console.Write("Цена товара: ");
            int price = int.Parse(Console.ReadLine());

            // Проверка, что цена нормальная
            if (price < 0)
            {
                throw new ArgumentException("неверная цена товара.");
            }

            //умножаем количсетво на цену

            int total = quantity * price;
            Console.WriteLine($"Итоговая сумма: {total}");
        }
        catch (FormatException)
        {

            Console.WriteLine("Ошибка");
        }

    }
}

