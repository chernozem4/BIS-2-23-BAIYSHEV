using System;

class magazine
{
    private const string LogFile = "log.txt"; // используем файл лог ткт

    static void Main()
    {
       
        LogEvent("Пользователь внутри");
        Console.WriteLine("событие: ");
        // в будущем этот метод понадобится для вывода и чтения одновременно
        ReadAndDisplay();
    }

    // Метод для записи события в журнал
    static void LogEvent(string message)
    {
        // добавляем дату и мессеж
        string logMessage = $"{DateTime.Now}: {message}";
        using (StreamWriter writer = new StreamWriter(LogFile, true))
        {
            writer.WriteLine(logMessage);
        }
    }

    //метод ниже очень классныйЮ он как в пайтоне метод апдейт-дейстрой, имеет 2 функции- чтение и вывож
 
    static void ReadAndDisplay()
    {
        Console.WriteLine(File.ReadAllText(LogFile)); Console.WriteLine("Журнал событи пуст.");
        
    }
}

