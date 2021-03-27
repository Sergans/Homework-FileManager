using System;

namespace Homework_FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string com;
            Command command = new Command(@"C:\Users\GANS\Desktop\Catalog");
            while (command.exit)
            {

                Console.WriteLine($"Путь:{command.put}");
                Console.WriteLine("Введите команду");
                com = Console.ReadLine();
                Console.Clear();
                command.Comand(command.ParseComand(com));
            }
        }
    }
}
