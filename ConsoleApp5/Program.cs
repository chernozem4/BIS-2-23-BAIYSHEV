using System;


    public class Employee
    {
        
        public string Name { get; set; }
        public string Position { get; set; }
        public int Salary { get; private set; }

        
        public Employee(string name, string position, int salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        // здесь будем повышать зарплату, я заюзал иф, т.к. им проще
        public void Salary1(int povyshenie)
        {
            if (povyshenie < 0)
            {
                return;
            }
            //здесь по формуле повышения зарплаты вычисляется повышение зарплаты
            int ahah = Salary * (Salary * povyshenie / 100);
            Salary += ahah;
            Console.WriteLine($"{Name} получил повышение { povyshenie}%.");
        }

        // Метод для вывода информации о сотруднике
        public void DisplayInfo()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Должность: {Position}");
            Console.WriteLine($"Зарплата: {Salary:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Employee gay = new Employee("шейский шей", "главный помощник заместителя уборщика", 10);

        // Выводим сотрудника 
            Console.WriteLine();
            gay.DisplayInfo();

            Console.WriteLine();
        //шей проявил себя, повысим зарплату
            Console.WriteLine();
            gay.Salary1(1000000);

            Console.WriteLine();

            // Выводим новую информацию
            Console.WriteLine();
            gay.DisplayInfo();
        }
    }


