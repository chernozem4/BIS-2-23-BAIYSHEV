using System;

// Интерфейс для оплаты
interface Method
{
    void Pay(int amount);  
}

// Оплата с помощью кредитной карты
class CreditCard: Method
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Оплата {amount} с кредиткой");
    }
}


class PayPal: Method
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Оплата {amount} PayPal.");
    }
}

class BankTransfer: Method
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Оплата {amount} с банком");
    }
}

class Program
{
    static void Main()
    {
   //здесь с помощью интерфеса будем выбирать способ оплаты
        Method paymentMethod;

    
        paymentMethod = new CreditCard();
        paymentMethod.Pay(5000000);
        Console.WriteLine();
        paymentMethod = new PayPal();
        paymentMethod.Pay(5000000);
        Console.WriteLine();
        paymentMethod = new BankTransfer();
        paymentMethod.Pay(500000);  
        Console.WriteLine();
    }
}

