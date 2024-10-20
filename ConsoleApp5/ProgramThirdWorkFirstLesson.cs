using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class CustomSystem
    {
       
        class Customer
        {
            public string Name { get; set; }
            public string Services { get; set; }
            public int Payment { get; set; }

            public Customer(string name, string services, int payment)
            {
                Name = name;
                Services = services;
                Payment = payment;
            }
        }

        static void Main()
        {
            // Список для хранения клиентов
            List<Customer> customers = new List<Customer>();

            while (true)
            {
                Console.WriteLine("имя клиента  ");
                string name = Console.ReadLine();
                
                Console.WriteLine("услуги");
                string services = Console.ReadLine();

                Console.WriteLine("сумма оплаты?");
                int payment;
                while (true)
                {
                    try
                    {
                        payment = int.Parse(Console.ReadLine());
                        break; 
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неправильно, необходимо ввести правильную сумму!");
                    }
                }

                // new customer
                customers.Add(new Customer(name, services, payment));

                Console.WriteLine("Ne customer");
                Console.WriteLine();
            }

            // print of the customers
            Console.WriteLine("\nСписок клиентов");
            decimal sum = 0;
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"Клиент: {customer.Name}, Услуги: {customer.Services}, Сумма {customer.Payment}");
                sum += customer.Payment;
            }

            Console.WriteLine(sum);
        }
    }
}
