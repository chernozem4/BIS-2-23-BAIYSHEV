using System;

namespace Gladiator
{
    class Program
    {
        // Структура для хранения информации о снаряжении
        class Weapons
        {
            public int Weight { get; set; }
            public int Cost { get; set; }

            public Weapons(int weight, int cost)
            {
                Weight = weight;
                Cost = cost;
            }
        }

        static void Main(string[] args)
        {
            // Словари для хранения информации о доспехах и оружии
            var armor = new System.Collections.Generic.Dictionary<string, Weapons>
            {
                { "легкие", new Weapons(5, 100) },
                { "средние", new Weapons(10, 200) },
                { "тяжелые", new Weapons(15, 300) }
            };

            var weapons = new System.Collections.Generic.Dictionary<string, Weapons>
            {
                { "меч", new Weapons(3, 150) },
                { "трезубец", new Weapons(4, 180) },
                { "копье", new Weapons(2, 120) }
            };

            var additionalDefense = new System.Collections.Generic.Dictionary<string, Weapons>
            {
                { "шлем", new Weapons(1, 80) },
                { "щит", new Weapons(3, 120) }
            };

            // Получение выбора пользователя
            Console.WriteLine("легкисе средние или тяжелые доспехи?");
            string selectedArmor = Console.ReadLine().ToLower();

            Console.WriteLine("меч трезубец или копье?");
            string selectedWeapon = Console.ReadLine().ToLower();

            Console.WriteLine("шлем или щит?");
            string selectedDefense = Console.ReadLine().ToLower();

           
            int totalWeight = 0;
            int totalCost = 0;
            

            if (armor.ContainsKey(selectedArmor))
            {
                totalWeight += armor[selectedArmor].Weight;
                totalCost += armor[selectedArmor].Cost;
            }
            else
            {
                Console.WriteLine("вы выбрали не те доспехи");
            }

            if (weapons.ContainsKey(selectedWeapon))
            {
                totalWeight += weapons[selectedWeapon].Weight;
                totalCost += weapons[selectedWeapon].Cost;
            }
            else
            {
                Console.WriteLine("такого оружия нет в списке");
            }

            if (additionalDefense.ContainsKey(selectedDefense))
            {
                totalWeight += additionalDefense[selectedDefense].Weight;
                totalCost += additionalDefense[selectedDefense].Cost;
            }
            else
            {
                Console.WriteLine("такого дополнения нет у нас");
            }

            Console.WriteLine($"\nОбщий веc: {totalWeight}");
            Console.WriteLine($"\nОбщая стоимость: {totalCost}");
        }
    }
}
