using System;

abstract class Bank
{
    public int Balance { get; protected set; }

    // абстрактный метод виздрав для снятия денег
    public abstract void Withdraw(int amount);

    // пополнение счета
    public void Deposit(int amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Пополнено на: {amount} Текущий баланс: {Balance}");
        }
        
    }
}

// Сберегательный счёт
class SavingsAccount : Bank
{
    private readonly int _minimum;

    // Конструктор, принимающий начальный баланс и минимальный остаток
    public SavingsAccount(int initialBal1, int minimum)
    {
        Balance = initialBal1;
        _minimum = minimum;
    }

    
    public override void Withdraw(int amount)
    {
        if (Balance - amount >= _minimum)
        {
            Balance -= amount;
            Console.WriteLine($"Снято: {amount}  Текущий баланс: {Balance}");
        }
        
    }
}

// Расчётный счёт с платой за обслуживание
class CheckingAccount: Bank
{
    private readonly int _service;

    // Конструктор, принимающий начальный баланс 
    public CheckingAccount(int initialBal, int service)
    {
        Balance = initialBal;
        _service = service;
    }

    // плата за обслугу
    public override void Withdraw(int amount)
    {
        int total = amount + _service;
        if (Balance >= total)
        {
            Balance = Balance - total;
            Console.WriteLine($"Снято: {amount}Плата за обслуживание: {_service} Текущий баланс: {Balance}");
        }
        
    }
}

class Program
{
    static void Main()
    {
        //сберегательный счёт
        SavingsAccount savings = new SavingsAccount(100000, 2000);
        Console.WriteLine("Сберегательный счёт:");
        savings.Deposit(50000);   // Пополнение счёта
        savings.Withdraw(4000);  // снятие
        

        Console.WriteLine();

        //расчётный счёт
        CheckingAccount checking = new CheckingAccount(999999, 500);
        Console.WriteLine("Расчётный счёт:");
        checking.Deposit(50000);    // Пополнение счёта
        checking.Withdraw(2000);   // снятие и  плата за обслуживание
        
    }
}

//не я фигею с этого задания, 2 часа с утра потратил, даже чат гпт офигевает от задания, сидишь сам читаешь про постоянные ошибки, и думаешь че ты сделал не так, я в депрессии

