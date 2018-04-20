using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjFile
{
    class Program
    {
        const string path = @"C:\my_file";

        static bool IsFileExist(string fullPath)
        {
            if (File.Exists(fullPath))
                return true;
            else
                Console.WriteLine($"Brak pliku {fullPath}.");
            return false;
        }

        static void Main(string[] args)
        {
            string command = string.Empty;
            while (command.ToLower() != "end")
            {
                command = Console.ReadLine();
                string[] commandArr = command.Split(' ');
                if (commandArr.Length > 1)
                {
                    string commandPart1 = commandArr[0].ToLower();
                    string commandPart2 = commandArr[1];
                    string fullPath = $"{path}\\{commandPart2}";
                    if (commandPart1 == "add")
                    {
                        using (File.Create(fullPath))
                            Console.WriteLine($"Utworzono plik: {fullPath}");
                    }
                    else if (commandPart1 == "remove")
                    {
                        if (IsFileExist(fullPath))
                        {
                            File.Delete(fullPath);
                            Console.WriteLine($"Usunięto plik: {fullPath}");
                        }
                    }
                    else if (commandPart1 == "write")
                    {
                        if (IsFileExist(fullPath))
                        {
                            var sb = new StringBuilder();
                            if (commandArr.Length > 2)
                            {
                                for (int i = 2; i < commandArr.Length; i++)
                                    sb.Append($" {commandArr[i]}");
                            }
                            File.WriteAllText(fullPath, sb.ToString());
                            Console.WriteLine($"Zapisano zmiany w pliku: {fullPath}");
                        }
                    }
                    else if (commandPart1 == "read")
                    {
                        if (IsFileExist(fullPath))
                        {
                            string txt = File.ReadAllText(fullPath);
                            Console.WriteLine($"Tekst z pliku: {txt}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Użyłeś {commandPart1}. " +
                            $"Dozwolone są tylko: add, remove, write, read");
                    }
                }
            }
        }
    }
}
